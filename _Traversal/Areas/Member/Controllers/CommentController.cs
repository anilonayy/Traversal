using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/Comment")]
    public class CommentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
