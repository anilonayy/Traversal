using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class DestinationController : Controller
    {
        IDestinationService destinationService;

        public DestinationController(IDestinationService _destinationService)
        {
            destinationService = _destinationService;
        }

        public IActionResult Index()
        {
            var destinations = destinationService.TGetList();
            return View(destinations);
        }
    }
}
