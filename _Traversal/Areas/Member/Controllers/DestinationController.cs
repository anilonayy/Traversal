using _Traversal.Areas.Member.Models;
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
            ViewBag.Breadcrumb = new Breadcrumb
            {
                HasSubTitle = true,
                Title = "Rotalar",
                SubTitle = "Rotalar"


            };
            var destinations = destinationService.TGetList();
            return View(destinations);
        }
    }
}
