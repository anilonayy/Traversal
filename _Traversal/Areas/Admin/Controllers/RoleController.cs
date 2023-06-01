using _Traversal.Areas.Admin.Models.ViewModels;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace _Traversal.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var list = _roleManager.Roles.ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(RoleAddDTO dto)
        {
            AppRole role = new AppRole
            {
                Name = dto.Name
            };

            await _roleManager.CreateAsync(role);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAsync(int id)
        {
            var transferData = await _roleManager.FindByIdAsync(id.ToString());

            var data = new RoleUpdateDTO
            {
                Id = transferData.Id,
                Name = transferData.Name
            };

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(RoleUpdateDTO dto)
        {
            await _roleManager.UpdateAsync(new AppRole
            {
                Id = dto.Id,
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id.ToString()));

            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        public async Task<IActionResult> RoleAssign(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            TempData["UserId"] = user.Id;

            List<RoleAssignViewModel> roleAssignViewModels = new();

            foreach (var role in roles)
            {

                RoleAssignViewModel tempModel = new RoleAssignViewModel();

                tempModel.RoleId = role.Id;
                tempModel.RoleName = role.Name;
                tempModel.RoleExist = userRoles.Contains(role.Name);

                roleAssignViewModels.Add(tempModel);

            }

            var data = roleAssignViewModels;

            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> models)
        {
            var userId = TempData["UserId"];
            var user = await _userManager.FindByIdAsync(userId.ToString());

            foreach (var item in models)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);

                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }

    }
}
