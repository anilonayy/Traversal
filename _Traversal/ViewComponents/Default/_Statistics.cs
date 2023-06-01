using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _StatisticsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var context = new Context();
            ViewBag.v1 = context.Destinatons.Count();
            ViewBag.v2 = context.Guides.Count();
            ViewBag.v3 = 256;
            ViewBag.v4 = 23;
            return View();
        }
    }
    
}
