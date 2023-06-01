using _Traversal.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace _Traversal.Areas.Admin.Controllers
{
    public class ApiExchangeController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
                {
                    { "X-RapidAPI-Key", "4350e0aadbmsha730cbbb8f7beedp159113jsn588f407901f9" },
                    { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

              
                var SendData = JsonConvert.DeserializeObject<ApiExchangeViewModel>(body);

                return View(SendData.exchange_rates.ToList());
            }
           
              
        }
    }
}
