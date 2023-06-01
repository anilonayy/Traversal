using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace _Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _TotalRevenue :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
