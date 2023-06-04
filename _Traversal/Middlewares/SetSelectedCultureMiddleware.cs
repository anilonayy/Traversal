using _Traversal.Middlewares;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace _Traversal.Middlewares
{
    public class SetSelectedCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public SetSelectedCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cookieProvider = new CookieRequestCultureProvider();
            var requestCultureResult = await cookieProvider.DetermineProviderCultureResult(context);
            if (requestCultureResult != null)
            {
                // Cookiede saklanan dil tercihini kullanarak kültürü ayarla
                var culture = requestCultureResult.Cultures.FirstOrDefault().ToString();
                if (!string.IsNullOrEmpty(culture))
                {
                    var selectedLanguage = context.Request.Cookies["SelectedLanguage"];
                    if (!string.IsNullOrEmpty(selectedLanguage))
                    {
                        // Cookiedeki dil tercihini güncelle
                        culture = selectedLanguage;
                    }

                    // Yeni kültürü ayarla
                    var cultureInfo = new CultureInfo(culture);
                    CultureInfo.CurrentCulture = cultureInfo;
                    CultureInfo.CurrentUICulture = cultureInfo;
                }
            }

            await _next(context);
        }
       
    }
  
}

public static class SetSelectedCultureMiddlewareExtensions
{
    public static IApplicationBuilder UseSetSelectedCulture(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SetSelectedCultureMiddleware>();
    }
}