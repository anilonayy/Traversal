using _Traversal.Areas.Member.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Shared
{
    public class Navbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Navbar(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            return View(new NavbarInfoViewModel
            {
                ImageUrl = user.ImageUrl,
                Name = user.Name
            });
        }
    }
}
