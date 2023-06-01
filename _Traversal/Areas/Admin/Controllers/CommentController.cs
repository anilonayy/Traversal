using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            List<Comment> data = _service.GetCommentsWithUserAndDestination();
            return View(data);
        }


        public IActionResult Delete(int id)
        {
            _service.TDelete(_service.TGetById(id));
            return RedirectToAction("Index");
        }
    }
}
