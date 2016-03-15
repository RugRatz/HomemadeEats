using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using HE.API.Providers;
using HE.API.DbContexts;

namespace HE.API
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(HE_IdentityDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            # region Enable the application to use a cookie to store information for the signed in user and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // adds supports for CLASSIC COOKIE BASED AUTHENTICATION
            // The authentication type is simply called Cookies or in code the middleware is referenced using CookieAuthenticationDefaults.AuthenticationType
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            // This cookie is used to temporarily store information about a user logging in with a THIRD PARTY LOGIN PROVIDER
            // and registers itself as ExternalCookie or  DefaultAuthenticationTypes.ExternalCookie
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            #endregion

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            // *registers three middlewares behind the scenes:
            // 1) OAuth2 authorization server
            // 2) Token-based authentication (local accounts using an authentication type of "Bearer" or OAuthDefault.AuthenticationType)
            // and only accepts claims where the issuer has been set to LOCAL AUTHORITY
            // 3) Token-based authentication (external accounts resulting from authentication handshake with external login provider)
            // and uses authentication type of "ExternalBearer" or DefaultAuthenticationTypes.ExternalBearer and only accepts claims where the issuer is NOT LOCAL AUTHORITY
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
