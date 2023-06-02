using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{

    public class DestinationController : BaseController
    {
        IDestinationService destinationService;

        public DestinationController(IDestinationService _destinationService)
        {
            destinationService = _destinationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var destinations = destinationService.TGetList();
            return View(destinations);
        }
    }
}
