using System;
using FWS.Log;
using FWS.MVC.Areas.Users.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

namespace FWS.MVC
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            //var cripto = Helper.Cryptography.Criptografia.Criptografar(((int)Helper.Enumerators.BancoDados.TipoBanco.SqlLocalDb).ToString());
            //cripto = Helper.Cryptography.Criptografia.Criptografar("(LocalDb)\\v11.0");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fws_desenv.mdf");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fws_desenv");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fwscrew");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fwscrew");

            //cripto = Helper.Cryptography.Criptografia.Criptografar(((int)Helper.Enumerators.BancoDados.TipoBanco.Sql).ToString());
            //cripto = Helper.Cryptography.Criptografia.Criptografar(@"HOMEWF\PERSONA");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fws_desenv");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fwscrew");
            //cripto = Helper.Cryptography.Criptografia.Criptografar("fwscrew");

            Log.appLog.LogMe(erro.Info, null, this.GetType(), "Start Project");


            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Users/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "dsasd asdasdasd asd asdasd",
            //    clientSecret: "asd asdasd asdasdasda");

            //app.UseTwitterAuthentication(
            //   consumerKey: "asd asd asd a",
            //   consumerSecret: "a sdasd as dasd asd asd");

            //app.UseFacebookAuthentication(
            //   appId: "asd asd asd asd a",
            //   appSecret: "as dasdasd ");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "as dasd asd a",
            //    ClientSecret = "as das dasd asd asd as"
            //});
        }
    }
}