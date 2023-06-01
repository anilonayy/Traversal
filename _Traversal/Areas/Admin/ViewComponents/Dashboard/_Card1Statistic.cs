using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _Card1Statistic : ViewComponent
    {
        Context context = new Context();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.v1 = context.Destinatons.Count();
            ViewBag.v2 = context.Users.Count();
            return View();
        }
    }
}
