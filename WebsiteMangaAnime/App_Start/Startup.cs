using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using WebsiteMangaAnime.Models.Context;
using WebsiteMangaAnime.Models.IdentityControl;

namespace WebsiteMangaAnime.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppDbContext>(new Func<AppDbContext>(() =>
            {
                return new AppDbContext();
            }));
            app.CreatePerOwinContext<IdentityUserContext>(IdentityUserContext.CreateContext);
            app.CreatePerOwinContext<IdentityRoleContext>(IdentityRoleContext.CreateContext);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Identity/Register"),
            });
        }
    }
}