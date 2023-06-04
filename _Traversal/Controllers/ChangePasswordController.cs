using _Traversal.Models.Login;
using BusinessLayer.Helpers.Abstracts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using NuGet.DependencyResolver;

namespace _Traversal.Controllers
{
    [AllowAnonymous]
    [Route("ChangePassword/{action=ForgetPassword}")]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailer _mailer;

        public ChangePasswordController(UserManager<AppUser> userManager, IMailer mailer)
        {
            _userManager = userManager;
            _mailer = mailer;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword( ForgetPasswordViewModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);

            if(user==null)
            {
                TempData["kullaniciBulunamadi"] = "Bu E-Maile ait kullanıcı bulunamadı.";
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var passwordResetTokenLink = Url.Action("ResetPassword", "ChangePassword", new
            {
                userId = user.Id,
                token = token
            }, HttpContext.Request.Scheme);


            _mailer.SendMail(user.Email, "Mail Yenileme İşlemi",$"<a href='{passwordResetTokenLink}'>Şifrenizi yenilemek için buraya tıklayın.</a>");
            TempData["mailBasarili"] = "Mail yenileme linki başarıyla gönderildi.";


            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }


            string userId = TempData["userId"].ToString();
            string token = TempData["token"].ToString();

            if(userId.ToString().IsNullOrEmpty() || token.ToString().IsNullOrEmpty())
            {
                return View("Errorlu");
            }

            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

            if(result.Succeeded)
            {
                TempData["basariliMesaj"] = "Şifreniz başarıyla güncellendi. Lütfen yeniden giriş yapın.";
            }
            return RedirectToAction("SignIn","Login");
        }
    }
}
