
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Dashboard
{
    public class _ProfileInfo : ViewComponent
    {
        private  UserManager<AppUser> userManager;

        public _ProfileInfo(UserManager<AppUser> _userManager)
        {
            userManager = _userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var manager = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.MemberName = manager.Name + " " + manager.Surname;
            ViewBag.MemberMail = manager.Email; 
            ViewBag.MemberPhone = manager.PhoneNumber;
            ViewBag.MemberCountry = "Türkiye";

            return View();
        }
    }
}
