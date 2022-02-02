using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.IdentityControl;

namespace WebsiteMangaAnime.Controllers
{
    public class AccountManageController : Controller
    {
        private IdentityUserContext userContext => HttpContext.GetOwinContext().GetUserManager<IdentityUserContext>();
        [Authorize]
        public ActionResult Settings()
        {
            User user = userContext.FindById(HttpContext.User.Identity.GetUserId());
            return View(user);
        }
        [HttpPost, Authorize]
        public async Task<ActionResult> ChangeSettings(User user)
        {
            IdentityResult identityResult = await userContext.UpdateAsync(user);
            if (identityResult.Succeeded)
            {
                return RedirectToAction("Settings");
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
        }
        public void ChangeEmail(string email)
        {
            User user = userContext.FindById(User.Identity.GetUserId());
            userContext.UserTokenProvider = GetProvider();
            string token = userContext.GenerateEmailConfirmationToken(user.Id);
            string callbackUrl = Url.Action("ConfirmEmail", "Identity", new { id = user.Id, token }, protocol: Request.Url.Scheme);
            userContext.SendEmail(user.Id, "Подтверждение почты", "Для подтверждения почты, перейдите по ссылке <a href=\"" + callbackUrl + "\">подтвердить</a>");
        }
        public void ChangePhone(string phone)
        {
            var code = userContext.GenerateChangePhoneNumberToken(User.Identity.GetUserId(), phone);
            var message = new IdentityMessage
            {
                Destination = phone,
                Body = "Ваш код безопасности: " + code
            };
            userContext.SmsService.Send(message);
        }
        private DataProtectorTokenProvider<User> GetProvider()
        {
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            var provider = new DpapiDataProtectionProvider(appName);
            return new DataProtectorTokenProvider<User>(provider.Create(appName));
        }
    }
}