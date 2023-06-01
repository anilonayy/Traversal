using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.ViewComponents.Dashboard
{
    public class _ProfileGuides : ViewComponent
    {
        private readonly GuideManager manager = new GuideManager(new EfGuideDal());
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = manager.TGetList();
            return View(data);
        }
    }
}
