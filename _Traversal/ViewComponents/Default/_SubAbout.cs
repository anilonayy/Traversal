using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var manager = new SubAboutManager(new EfSubAboutDal());
            var list = manager.TGetById(1);
            return View(list);
        }
    }
}
