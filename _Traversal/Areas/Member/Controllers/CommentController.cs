using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
    public class CommentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
