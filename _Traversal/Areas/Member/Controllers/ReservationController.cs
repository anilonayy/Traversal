using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace _Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationManager ;
        private readonly IReservationService _reservationManager ;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IDestinationService destinationManager, IReservationService reservationManager, UserManager<AppUser> userManager)
        {
            _destinationManager = destinationManager;
            _reservationManager = reservationManager;
            _userManager = userManager;
        }

        public IActionResult MyCurrentReservations()
        {
            return View();
        }
        public async Task<IActionResult> MyOldReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var data = _reservationManager.TGetListByPreviousReservations(user.Id);
            return View(data);
        }

        public async Task<IActionResult> MyApprovalReservations()
        {
            var user =await  _userManager.FindByNameAsync(User.Identity.Name);
            var data = _reservationManager.TGetListByApprovalReservations(user.Id);

            return View(data);
        }

        public async Task<IActionResult> MyAcceptedReservations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var data = _reservationManager.TGetListByAcceptedReservations(user.Id);

            return View(data);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationId.ToString()
                                           }).ToList();
            ViewBag.ListValues = values;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            //p.Status = "Onay Bekliyor";
            //p.AppUserId = user.Id;
            //p.AppUser = user;

            p.AppUserId = user.Id;
            p.Status = "Onay Bekliyor";
            _reservationManager.TAdd(p);

            return RedirectToAction("MyApprovalReservations");
        }
    }
}
