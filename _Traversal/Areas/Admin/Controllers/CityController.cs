using _Traversal.Areas.Admin.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _Traversal.Areas.Admin.Controllers
{
    public class CityController : BaseController
    {
        private readonly IDestinationService _service;
        public CityController(IDestinationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_service.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCity(Destination d)
        {
            d.Status = true;
            d.Image1 = "Empty";
            d.Image2 = "Empty";
            d.CoverImage = "Empty";
            d.Description= "Empty";
            d.Description2 = "Empty";

            _service.TAdd(d);

            var value = JsonConvert.SerializeObject(d);
            return Json(value);
        }

        public IActionResult GetById(int id)
        {
            var values = _service.TGetById(id);
            var jsonValues = JsonConvert.SerializeObject(values);
            

            return Json(jsonValues);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _service.TGetById(id);
            _service.TDelete(data);

            return data != null ? Ok() : NotFound();
        }

        [HttpPut]
        public IActionResult Update(Destination d)
        {
            try
            {
                _service.TUpdate(d);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
            
        }

      
    }
}
