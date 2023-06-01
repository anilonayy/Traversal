using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.ViewComponents.Dashboard
{
    public class _DestinationStatistics :ViewComponent  
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
