using _Traversal.Models.Login;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Traversal.Models.Login;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly SignInManager<AppUser> _signinmanager;

        public LoginController(UserManager<AppUser> usermanager,SignInManager<AppUser> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel SignUser)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = SignUser.Name,
                    Surname = SignUser.Surname,
                    Email = SignUser.Email,
                    UserName = SignUser.Username
                };

                if(SignUser.Password.Equals(SignUser.ConfrimPassword))
                {
                    var result = await _usermanager.CreateAsync(user, SignUser.Password);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("",error.Description);
                        }
                    }
                }
                
            }
            
            return View(SignUser);
        }

        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var result = await _signinmanager.PasswordSignInAsync(vm.Username, vm.Password, false, true);

                if(result.Succeeded)
                {
                    return RedirectToAction("Update", "Profile", new { area = "member" });
                }
            }
            return View(vm);
        }


        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }




    }
}
