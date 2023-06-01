using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class ContactUsController : BaseController
    {
        private readonly IContactUsService _service;

        public ContactUsController(IContactUsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var values = _service.TGetListByFalse();
            return View(values);
        }

        public IActionResult ChangeStatus(int id)
        {
            _service.TChangeStatus(id);
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var data = _service.TGetById(id);
            return View(data);
        }
    }
}
