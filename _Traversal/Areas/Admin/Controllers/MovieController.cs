using _Traversal.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace _Traversal.Areas.Admin.Controllers
{
    public class MovieController : BaseController
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                    {
                        { "X-RapidAPI-Key", "4350e0aadbmsha730cbbb8f7beedp159113jsn588f407901f9" },
                        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
                    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<List<MovieViewModel>>(body);

                return View(json);
            }    

        
        }
    }
}
