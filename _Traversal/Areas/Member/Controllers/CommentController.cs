using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
<<<<<<< HEAD
=======
    [Area("Member")]
    [Route("Member/Comment")]
>>>>>>> member-page
    public class CommentController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
