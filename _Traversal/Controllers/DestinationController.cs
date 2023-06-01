using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        IDestinationService destinationService;
        SignInManager<AppUser> signInManager;

        public DestinationController(IDestinationService _destinationService,SignInManager<AppUser> _signInManager)
        {
            destinationService = _destinationService;
            signInManager = _signInManager;

        }
        public IActionResult Index()
        {
            return View(destinationService.TGetList()); 
        }

        [HttpGet]
        [Route("destination/{id}",Name ="DestinationDetail")]
        public IActionResult Detail(int id)
        {
            ViewBag.IsLogin = signInManager.IsSignedIn(User);
            ViewBag.DestId = id;
            var values = destinationService.TGetDestinaitonWithGuide(id);
            return View(values);
        }

        
    }
}
