using Microsoft.AspNetCore.Mvc;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Model;

namespace SignalRApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult CreateVisitor()
        {
            try
            {
                Random random = new Random();

                Enumerable.Range(1, 10).ToList().ForEach(x =>
                {
                    foreach (ECity item in Enum.GetValues(typeof(ECity)))
                    {
                        var newVisitor = new Visitor
                        {
                            City = item,
                            CityVisitCount = random.Next(100, 2000),
                            VisitDate = DateTime.UtcNow.AddDays(x)
                        };
                        _visitorService.SaveVisitor(newVisitor).Wait();
                        Thread.Sleep(1000);
                    }
                });

                return Ok("Ziyaretçiler Başarılı Bir Şekilde Eklendi");

            } 
            catch (Exception e)
            {

                return Problem($"Hata Verdi! {e.ToString()}");
            }

        }

    }
}
