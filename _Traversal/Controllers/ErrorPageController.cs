using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {

            return View();
        }
    }
}
