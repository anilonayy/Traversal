using _Traversal.Areas.Member.Models;
using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.DestinationDTOs;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Member.Controllers
{

    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            this.destinationService = destinationService;
            _mapper = mapper;
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

        [HttpGet]
        public async Task<IActionResult> GetCityByName(string city="")
        {
            var values = from x in destinationService.TGetList() select x;
            var searchResults = values.Where(y => y.City.ToLower().Contains(city.ToLower()));

            var dtoResult = _mapper.Map<List<GetCityByNameResultDTO>>(searchResults);
          
            return Json(dtoResult);
        }
    }
}
