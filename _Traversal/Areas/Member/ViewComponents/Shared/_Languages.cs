using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Shared
{
    public class _Languages : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }

    }
}
