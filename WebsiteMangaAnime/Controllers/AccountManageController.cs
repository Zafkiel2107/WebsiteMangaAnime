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
        [HttpGet, Authorize]
        public ActionResult Settings()
        {
            User user = userContext.FindById(HttpContext.User.Identity.GetUserId());
            return View(user);
        }
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<ActionResult> ChangeSettings(string phoneNumber, string imageLink, string userName)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
            User user = userContext.FindById(HttpContext.User.Identity.GetUserId());
            user.PhoneNumber = phoneNumber;
            user.ImageLink = imageLink;
            user.UserName = userName;
            IdentityResult identityResult = await userContext.UpdateAsync(user);
            if (identityResult.Succeeded)
                return RedirectToAction("Settings");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
        }
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public void ChangeEmail(string email)
        {
            if (ModelState.IsValid)
            {
                User user = userContext.FindById(User.Identity.GetUserId());
                user.Email = email;
                userContext.UserTokenProvider = GetProvider();
                string token = userContext.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = Url.Action("ConfirmEmail", "Identity", new { id = user.Id, token }, protocol: Request.Url.Scheme);
                userContext.SendEmail(user.Id, "Подтверждение почты", "Для подтверждения почты, перейдите по ссылке <a href=\"" + callbackUrl + "\">подтвердить</a>");
            }
        }
        private DataProtectorTokenProvider<User> GetProvider()
        {
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            var provider = new DpapiDataProtectionProvider(appName);
            return new DataProtectorTokenProvider<User>(provider.Create(appName));
        }
    }
}