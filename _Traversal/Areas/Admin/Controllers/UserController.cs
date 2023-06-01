using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        IAppUserService service;
        IReservationService _reservationService;

        public UserController(IAppUserService _service,IReservationService reservationService)
        {
            service = _service;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var data = service.TGetList();
            return View(data);
        }

        
        public IActionResult Delete(int id)
        {
            service.TDelete(service.TGetById(id));
            return Ok(true);
        }

        public IActionResult Reservations(int id)
        {
            var data = _reservationService.TGetListByAcceptedReservations(id);
            return View(data);
        }
    }
}
