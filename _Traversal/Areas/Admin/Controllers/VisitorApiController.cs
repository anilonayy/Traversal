using _Traversal.Areas.Admin.Mapping;
using _Traversal.Areas.Admin.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace _Traversal.Areas.Admin.Controllers
{
    public class VisitorApiController : BaseController
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5299/api/Visitor"); 

            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(data);
            }

            return View();

            
            
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Add(VisitorViewModel v)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(v);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5299/api/Visitor", content);


            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(v);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5299/api/Visitor/{id}");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync($"http://localhost:5299/api/Visitor/{id}");

            if(result.IsSuccessStatusCode)
            {
                var stringResult = await result.Content.ReadAsStringAsync();

                object sendData = JsonConvert.DeserializeObject<VisitorViewModel>(stringResult);
                
                return View(sendData);
            }
            else
            {
                return RedirectToAction("Index");
            }
            

            
        }

        [HttpPost]
        public async  Task<IActionResult> Update(VisitorViewModel v)
        {
            var client = _httpClientFactory.CreateClient();

            var JsonData = JsonConvert.SerializeObject(v);

            StringContent PutContent = new StringContent(JsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync($"http://localhost:5299/api/visitor", PutContent);


            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else
                return View(v);

            
        }

    }
}
