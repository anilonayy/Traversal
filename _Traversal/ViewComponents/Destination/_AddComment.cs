using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Destination
{
    public class _AddComment :ViewComponent
    {
        public IViewComponentResult Invoke(int DestinationId)
        {

            return View(new Comment {DestinationId = DestinationId });
        }
    }
}
