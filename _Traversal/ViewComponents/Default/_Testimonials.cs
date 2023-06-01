using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _Testimonials :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var manager = new TestimonialManager(new EfTestimonialDal());
            
            return View(manager.TGetList());
        }
    }
}
