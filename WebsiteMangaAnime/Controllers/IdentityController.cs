using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteMangaAnime.Models;
using WebsiteMangaAnime.Models.IdentityControl;
using WebsiteMangaAnime.Models.LogControl;

namespace WebsiteMangaAnime.Controllers
{
    public class IdentityController : Controller
    {
        //Microsoft.Owin.Host.SystemWeb
        private IdentityUserContext userContext => HttpContext.GetOwinContext().GetUserManager<IdentityUserContext>();
        private IdentityRoleContext roleContext => HttpContext.GetOwinContext().GetUserManager<IdentityRoleContext>();
        private IAuthenticationManager authenticationManager => HttpContext.GetOwinContext().Authentication;

        [HttpGet]
        public ActionResult Login() => View();
        [HttpGet]
        public ActionResult Register() => View();
        [HttpGet]
        public ActionResult DisplayConfirmEmailInfo() => View();
        [HttpGet]
        public ActionResult SuccessedConfirmEmail() => View();
        [HttpGet]
        public ActionResult ForgotPassword() => View();
        [HttpGet]
        public ActionResult DisplayResetPasswordInfo() => View();
        [HttpGet]
        public ActionResult SuccessedResetPassword() => View();

        [HttpPost, ValidateAntiForgeryToken, ExceptionLogger]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = new User
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                Birthday = registerModel.Birthday,
                PasswordHash = GetPasswordHash(registerModel.Password),
                ImageLink = "Default/default-avatar.jpg"
            };

            IdentityResult identityUserResult = await userContext.CreateAsync(user, registerModel.Password);
            if(identityUserResult.Succeeded)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
            IdentityResult identityRoleResult = await userContext.AddToRoleAsync(user.Id, "User");
            if (!identityRoleResult.Succeeded)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            userContext.UserTokenProvider = GetProvider();
            string token = await userContext.GenerateEmailConfirmationTokenAsync(user.Id);
            string callbackUrl = Url.Action("ConfirmEmail", "Identity", new { id = user.Id, token }, protocol: Request.Url.Scheme);
            await userContext.SendEmailAsync(user.Id, "Подтверждение почты", "Для подтверждения почты, перейдите по ссылке <a href=\"" + callbackUrl + "\">подтвердить</a>");
            return RedirectToAction("DisplayConfirmEmailInfo", "Identity");
        }
        [HttpPost, ExceptionLogger]
        public async Task<ActionResult> ConfirmEmail(string id, string token)
        {
            if(string.IsNullOrEmpty(id) && string.IsNullOrEmpty(token))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            User user = await userContext.FindByIdAsync(id);
            if(user == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            userContext.UserTokenProvider = GetProvider();
            IdentityResult confirmEmailResult = await userContext.ConfirmEmailAsync(id, token);

            if(!confirmEmailResult.Succeeded)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            return RedirectToAction("SuccessedConfirmEmail");
        }
        [HttpPost, ExceptionLogger, ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            User user = await userContext.FindByEmailAsync(loginModel.Email);
            if (user == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
            if (!user.EmailConfirmed)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ClaimsIdentity claimsIdentity = await userContext.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignOut();
            authenticationManager.SignIn(new AuthenticationProperties()
            {
                IsPersistent = true
            }, claimsIdentity);
            return RedirectToAction("Main", "Home");
        }
        [HttpPost, ExceptionLogger, ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            User user = await userContext.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            userContext.UserTokenProvider = GetProvider();
            string token = await userContext.GeneratePasswordResetTokenAsync(user.Id);
            string callbackUrl = Url.Action("ResetPassword", "Identity", new { id = user.Id, token }, protocol: Request.Url.Scheme);
            await userContext.SendEmailAsync(user.Id, "Сброс пароля", "Для сброса пароля, перейдите по ссылке <a href=\"" + callbackUrl + "\">сбросить</a>");
            return RedirectToAction("DisplayResetPasswordInfo", "Identity");
        }
        [HttpPost, ExceptionLogger]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            User user = await userContext.FindByIdAsync(resetPasswordModel.Id);

            if (user == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");

            userContext.UserTokenProvider = GetProvider();
            IdentityResult resetPasswordResult = await userContext.ResetPasswordAsync(resetPasswordModel.Id, resetPasswordModel.Token, resetPasswordModel.Password);
            if (resetPasswordResult.Succeeded)
                return RedirectToAction("SuccessedResetPassword");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Некорректный запрос");
        }
        [Authorize]
        public ActionResult Logout()
        {
            authenticationManager.SignOut();
            return RedirectToAction("Main", "Home");
        }

        private string GetPasswordHash(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        private DataProtectorTokenProvider<User> GetProvider()
        {
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            var provider = new DpapiDataProtectionProvider(appName);
            return new DataProtectorTokenProvider<User>(provider.Create(appName));
        }
    }
}