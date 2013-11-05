using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;

using Owin;

namespace UserGroup
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "317684662672",
                AppSecret = "f2ced1b48242f10915def2e4d02753af",
                Provider = new FacebookAuthenticationProvider()
                {
                    OnAuthenticated = OnAuthenticated 
                }
            };
            app.UseFacebookAuthentication(facebookOptions);

            var googleAuthenticationOptions = new GoogleAuthenticationOptions()
            {
                Provider = new GoogleAuthenticationProvider()
                {
                    OnAuthenticated = OnAuthenticated
                }
            };
            app.UseGoogleAuthentication(googleAuthenticationOptions);
        }

        private Task OnAuthenticated(FacebookAuthenticatedContext facebookAuthenticatedContext)
        {
            var gender = facebookAuthenticatedContext.User.GetValue("gender");
            var genderClaim = new Claim(ClaimTypes.Gender, gender.ToString(),"","Facebook");
            facebookAuthenticatedContext.Identity.AddClaim(new Claim("urn:facebook:access_token", facebookAuthenticatedContext.AccessToken));
            facebookAuthenticatedContext.Identity.AddClaim(genderClaim);
            return Task.FromResult(0);
        }

        private Task OnAuthenticated(GoogleAuthenticatedContext googleAuthenticatedContext)
        {
            var identity = googleAuthenticatedContext.Identity;
            return Task.FromResult<object>(null);
        }
    }
}