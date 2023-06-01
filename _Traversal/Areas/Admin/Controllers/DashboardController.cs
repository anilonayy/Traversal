using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace _Traversal.Areas.Admin.Controllers
{

    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
