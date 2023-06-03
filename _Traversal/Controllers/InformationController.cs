using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
