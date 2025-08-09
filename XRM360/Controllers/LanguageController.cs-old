using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class LanguageController : Controller
    {
        [Route("Language/Switch/{lang}")]
        public IActionResult Switch(string lang, string? returnUrl = "/")
        {
            if (lang != "zh" && lang != "en") lang = "en";

            // ✅ Store language preference in cookie (1 year)
            Response.Cookies.Append("XRM360_Lang", lang, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true
            });

            // ✅ Redirect back to previous page
            return Redirect(returnUrl ?? "/");
        }
    }
}
