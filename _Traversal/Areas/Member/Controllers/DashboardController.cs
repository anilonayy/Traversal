using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller=Dashboard}/{action=Index}")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.userName = $"{user.Name} {user.Surname}";
            ViewBag.pp = user.ImageUrl;

            return View();
        }
    }
}
