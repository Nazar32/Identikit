using System;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Identikit.App_Start.Startup))]
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Identikit.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Identikit.App_Start.NinjectWebCommon), "Stop")]

namespace Identikit.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SetAuth(app);
        }

        private void SetAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                CookieName = "LOGIN",
                LoginPath = new PathString("/Account/Login"),
                ExpireTimeSpan = TimeSpan.FromHours(1)
            });
        }
    }
}
