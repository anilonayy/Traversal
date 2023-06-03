using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Shared
{
    public class _Notifications : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
