using BusinessLayer.Abstract;
using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace _Traversal.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {
            var list = _roleService.TGetList();
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RoleAddDTO dto)
        {
            _roleService.TAdd(new AppRole
            {
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var transferData = _roleService.TGetById(id);
            var data = new RoleUpdateDTO
            {
                Id = transferData.Id,
                Name = transferData.Name
            };

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(RoleUpdateDTO dto)
        {
            _roleService.TUpdate(new AppRole
            {
                Id = dto.Id,
                Name = dto.Name
            });

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _roleService.TDelete(_roleService.TGetById(id));

            return RedirectToAction("Index");
        }
    }
}
