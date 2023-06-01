using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Controllers
{
    [AllowAnonymous]
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;
        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AddContactUsDTO vm)
        {
            if(! ModelState.IsValid)
                return View(vm);
            

            var ConvertModel = _mapper.Map<ContactUs>(vm);
            _contactUsService.TAdd(ConvertModel);

            TempData["ContactUsSuccess"] = "İletişim Formu Başarıyla Gönderildi!";

            return RedirectToAction("Index");
        }
    }
}
