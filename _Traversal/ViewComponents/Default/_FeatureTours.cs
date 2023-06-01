using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _FeatureTours : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var manager = new FeatureManager(new EfFeatureDal());
            var list = manager.TGetList();
           

            return View(list);
        }
    }
}
