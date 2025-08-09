using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Areas.Education.Controllers
{
    [Area("Education")]
    [Route("Education")] // clean /Education URLs
    public class HomeController : Controller
    {
        [HttpGet("")] public IActionResult Index() => View();
        [HttpGet("Services")] public IActionResult Services() => View();
        [HttpGet("Cases")] public IActionResult Cases() => View();
        [HttpGet("Pricing")] public IActionResult Pricing() => View();
        [HttpGet("About")] public IActionResult About() => View();
        [HttpGet("Contact")] public IActionResult Contact() => View();

        [HttpPost("Contact")]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string Name, string Email, string Subject, string Message)
        {
            // TODO: send email
            TempData["ContactSuccess"] = true;
            return RedirectToAction(nameof(Contact));
        }
    }
}
