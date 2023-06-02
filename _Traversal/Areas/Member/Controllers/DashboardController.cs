using _Traversal.Areas.Member.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{

    public class DashboardController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb
            {
                HasSubTitle = false,
                Title = "Dashboard",
                SubTitle = ""

            };
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userName = $"{user.Name} {user.Surname}";
            ViewBag.pp = user.ImageUrl;

            return View();
        }
    }
}
