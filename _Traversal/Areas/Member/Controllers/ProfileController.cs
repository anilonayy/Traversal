using _Traversal.Areas.Member.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel userEditViewModel = new UserEditViewModel
            {
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                PhoneNumber = values.PhoneNumber
            };

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserEditViewModel vm)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (vm.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(vm.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = $"{resource}/wwwroot/user-images/{imageName}";
                var stream = new FileStream(saveLocation, FileMode.Create);
                await vm.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }


            user.Name = vm.Name;
            user.Surname = vm.Surname;
            user.Email = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;

            if (vm.Password != null && vm.Password.Equals(vm.ConfrimPassword))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, vm.Password);
            }
            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction("SignIn","Login", new {area = ""});
            }

            return View(vm);
        }
    }
}
