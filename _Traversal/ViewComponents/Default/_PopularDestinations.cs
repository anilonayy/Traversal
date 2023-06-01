using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        IDestinationService  _service;

        public _PopularDestinations(IDestinationService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
        
            var list =  _service.TGetList();

            return View(list);
        }
    }
}
