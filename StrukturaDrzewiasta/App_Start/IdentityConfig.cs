using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using StrukturaDrzewiasta.Persistance;

namespace StrukturaDrzewiasta.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {

            app.CreatePerOwinContext<IdentityDatabaseContext>(IdentityDatabaseContext.Create);
            app.CreatePerOwinContext<AccountManager>(AccountManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}