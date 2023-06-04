using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _Traversal.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly RequestLocalizationOptions _localizationOptions;

        public LanguageController(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions.Value;
        }

        public IActionResult ChangeCulture(string culture)
        {
            var supportedCultures = _localizationOptions.SupportedUICultures
                .Select(c => c.Name)
                .ToList();

            if (supportedCultures.Contains(culture))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true, // Cookie required for localization to work
                    SameSite = SameSiteMode.Strict
                };

           
                Response.Cookies.Append("SelectedLanguage", culture, cookieOptions);

            }

            // Redirect to the same page
            return Redirect(Url.Content(Request.Headers["Referer"].ToString()));
        }
    }
}
