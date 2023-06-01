using _Traversal.Areas.Admin.Models.ViewModels;
using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class AnnouncementController : BaseController
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService,IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());

            return View(values);
        }


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AnnouncementAddDTO dto)
        {
            Announcement data = _mapper.Map<Announcement>(dto);
            data.AnnouncmentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if(! ModelState.IsValid)
                return View(dto);
            

            _announcementService.TAdd(data);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _announcementService.TDelete(_announcementService.TGetById(id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetById(id));

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AnnouncementUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
              


            var data = _mapper.Map<Announcement>(dto);
            data.AnnouncmentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _announcementService.TUpdate(data);

            return RedirectToAction("Index");
        }
    }
}
