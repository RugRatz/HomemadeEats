using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using HE.API.Models;

namespace HE.API.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }


        /// <summary>
        /// Called when a request to the Token endpoint arrives with a "grant_type" of "password". 
        /// This occurs when the user has provided name and password credentials directly into the client application's user interface, and the client application is using those to acquire an "access_token" and optional "refresh_token". 
        /// If the web application supports the resource owner credentials grant type it must validate the context.Username and context.Password as appropriate. 
        /// To issue an access token the context.Validated must be called with a new ticket containing the claims about the resource owner which should be associated with the access token. 
        /// The application should take appropriate measures to ensure that the endpoint isn’t abused by malicious callers. The default behavior is to reject this grant type. See also http://tools.ietf.org/html/rfc6749#section-4.3.2
        /// https://msdn.microsoft.com/en-us/library/microsoft.owin.security.oauth.oauthauthorizationserverprovider.grantresourceownercredentials(v=vs.113).aspx
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            
            //goes to the database and attempts to find a user with the given username and password
            CustomerProfile user = await userManager.FindAsync(context.UserName, context.Password);

            //if no user record was found from above line, then user is NULL
            if (user == null)
            {
                //at this point, the application is unable to authenticate the user because either the username or the password is incorrect
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            #region 
            // http://leastprivilege.com/2013/11/26/dissecting-the-web-api-individual-accounts-templatepart-2-local-accounts/
            // This method does a little more than just validating credentials and creating a token. 
            // It also sends the username back as part of the OAuth2 response (as an extra parameter). 
            // Maybe this is just a sample how to directly return personalization related information back to the client without forcing an extra round trip to the API. 
            // Since those values are not signed, you shouldn’t base any security related decisions on them
            // The method also sets an application cookie.

            //if there is a username and password record found for this user, proceed to create a claim identity and 
            //sign in the user
            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            //this is used for refreshing the token?
            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
            #endregion
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}