using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller=Dashboard}/{action=Index}/{id?}")]
    public class BaseController : Controller
    {
     
    }
}
