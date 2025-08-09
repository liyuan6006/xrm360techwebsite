using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Areas.Health.Controllers
{
    [Area("Health")]
    [Route("Health")] // gives /Health, /Health/Products, etc.
    public class HomeController : Controller
    {
        [HttpGet("")] public IActionResult Index() => View();
        [HttpGet("Products")] public IActionResult Products() => View();
        [HttpGet("Specs")] public IActionResult Specs() => View();
        [HttpGet("Pricing")] public IActionResult Pricing() => View();
        [HttpGet("About")] public IActionResult About() => View();
        [HttpGet("Contact")] public IActionResult Contact() => View();

        [HttpPost("Contact")]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string Name, string Email, string Subject, string Message)
        {
            // TODO: send email via SMTP
            TempData["ContactSuccess"] = true;
            return RedirectToAction(nameof(Contact));
        }
    }
}
