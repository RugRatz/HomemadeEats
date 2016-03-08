using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HE.MVC.UserInterface.Models;
using HE.API;
using HE.MVC.UserInterface.Filters;
using System.Diagnostics;
using Microsoft.Owin.Security.DataHandler.Serializer;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using HE.API.Models;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace HE.MVC.UserInterface.Controllers
{
    [Authorize]
    //[HandleApiError]
    public class AccountController : Controller //HE_UI_ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        

        //
        // POST: to api/Account/Register
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost] //this is MANDATORY because on the API side, there is also another controller method named exactly like this
        public async Task<ActionResult> Register(Models.RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //var customer = new CustomerProfile { UserName = model.Email, Email = model.Email };

                await WebApiService.Instance.PostAsync("api/Account/Register", model);

                //this part is probably handled differently
                //await SignInManager.SignInAsync(, isPersistent: false, rememberBrowser: false);
                //await SignInHelper
                var result = SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                
                return RedirectToAction("Index", "Home");
            }
            catch (ApiException ex)
            {
                //No 200 OK result, what went wrong?
                //HandleBadRequest(ex);
                Debug.WriteLine(ex.Message);

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                throw;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #region MVC original code
            //// This doesn't count login failures towards account lockout
            //// To enable password failures to trigger account lockout, change to shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //}
            #endregion
            try
            {
                var result = await AuthenticateAsync<SignInResult>(model.Email, model.Password);

                if (result.UserName == null)
                    return View(model);
                
                //Let's keep the user authenticated in the MVC webapp.
                //By using the AccessToken, we can use User.Identity.Name in the MVC controllers to make API calls.
                FormsAuthentication.SetAuthCookie(result.AccessToken, model.RememberMe);

                //Create an AuthenticationTicket to generate a cookie used to authenticate against Web API.
                //But before we can do that, we need a ClaimsIdentity that can be authenticated in Web API.
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, result.UserName), //Name is the default name claim type, and UserName is the one known also in Web API.
                    new Claim(ClaimTypes.NameIdentifier, result.UserName) //If you want to use User.Identity.GetUserId in Web API, you need a NameIdentifier claim.
                };

                //Generate a new ClaimsIdentity, using the DefaultAuthenticationTypes.ApplicationCookie authenticationType.
                //This also matches what we've set up in Web API.
                var authTicket = new AuthenticationTicket(new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie), new AuthenticationProperties
                {
                    ExpiresUtc = result.Expires,
                    IsPersistent = model.RememberMe,
                    IssuedUtc = result.Issued,
                    RedirectUri = returnUrl
                });

                //And now it's time to generate the cookie data. This is using the same code that is being used by the CookieAuthenticationMiddleware class in OWIN.
                byte[] userData = DataSerializers.Ticket.Serialize(authTicket);

                //Protect this user data and add the extra properties. These need to be the same as in Web API!
                byte[] protectedData = MachineKey.Protect(userData, new[] { "Microsoft.Owin.Security.Cookies.CookieAuthenticationMiddleware", DefaultAuthenticationTypes.ApplicationCookie, "v1" });

                //base64-encode this data.
                string protectedText = TextEncodings.Base64Url.Encode(protectedData);

                //And now, we have the cookie.
                Response.SetCookie(new HttpCookie("HE.API.Auth")
                {
                    HttpOnly = true,
                    Expires = result.Expires.UtcDateTime,
                    Value = protectedText
                });

                return Redirect(returnUrl ?? "/");
            }
            catch (ApiException ex)
            {
                //No 200 OK result, what went wrong?
                //HandleBadRequest(ex);
                Debug.WriteLine(ex.Message);

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        #region internal class ChallengeResult : HttpUnauthorizedResult
        //internal class ChallengeResult : HttpUnauthorizedResult
        //{
        //    public ChallengeResult(string provider, string redirectUri)
        //        : this(provider, redirectUri, null)
        //    {
        //    }

        //    public ChallengeResult(string provider, string redirectUri, string userId)
        //    {
        //        LoginProvider = provider;
        //        RedirectUri = redirectUri;
        //        UserId = userId;
        //    }

        //    public string LoginProvider { get; set; }
        //    public string RedirectUri { get; set; }
        //    public string UserId { get; set; }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //        if (UserId != null)
        //        {
        //            properties.Dictionary[XsrfKey] = UserId;
        //        }
        //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //    }
        //}
        #endregion
        #endregion


        private string BuildActionUri(string action)
        {
            return "https://localhost:44301/" + action;
        }

        public async Task<SignInResult> AuthenticateAsync<SignInResult>(string userName, string password)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(BuildActionUri("/Token"), new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("userName", userName),
                    new KeyValuePair<string, string>("password", password)
                }));

                string json = await result.Content.ReadAsStringAsync();

                //result.EnsureSuccessStatusCode();

                if (!result.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }

                return JsonConvert.DeserializeObject<SignInResult>(json);

                //throw new ApiException(result.StatusCode, json);
                //throw new Exception(json);
            }
        }
    }
}