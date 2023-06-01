using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller=Dashboard}/{action=Index}/{id?}")]
    public class BaseController : Controller
    {
       
    }
}
