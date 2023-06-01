using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Dashboard
{
    public class _ProfilePlatformSettings : ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
