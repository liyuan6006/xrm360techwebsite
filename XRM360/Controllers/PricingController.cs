using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class PricingController : BaseController
    {
        public IActionResult SoftwareSolutions()
        {
            ViewData["Title"] = "Pricing - Software Solutions";
            return LangView("SoftwareSolutions");
        }
        public IActionResult Health()
        {
            ViewData["Title"] = "Pricing - Health";
            return LangView("Health");
        }
        public IActionResult Education()
        {
            ViewData["Title"] = "Pricing - Education";
            return LangView("Education");
        }
    }
}

