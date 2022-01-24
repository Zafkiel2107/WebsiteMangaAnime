using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WebsiteMangaAnime.Models.Context;
using WebsiteMangaAnime.Models.Services;

namespace WebsiteMangaAnime.Models.IdentityControl
{
    public class IdentityUserContext : UserManager<User>
    {
        public IdentityUserContext(IUserStore<User> store) : base(store)
        {
            this.EmailService = new EmailService();
            this.SmsService = new SmsService();
        }
        public static IdentityUserContext CreateContext(IdentityFactoryOptions<IdentityUserContext> options,
            IOwinContext context)
        {
            return new IdentityUserContext(new UserStore<User>(context.Get<AppDbContext>()));
        }
    }
    public class IdentityRoleContext : RoleManager<Role>
    {
        public IdentityRoleContext(RoleStore<Role> store) : base(store)
        {

        }
        public static IdentityRoleContext CreateContext(IdentityFactoryOptions<IdentityRoleContext> options,
            IOwinContext context)
        {
            return new IdentityRoleContext(new RoleStore<Role>(context.Get<AppDbContext>()));
        }
    }
}