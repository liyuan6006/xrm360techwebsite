using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Areas.SoftwareSolutions.Controllers
{
    [Area("SoftwareSolutions")]// Tells MVC what area the controller belongs to.
    [Route("Software")]//To make the URL different from the Area name
    public class HomeController : Controller
    {
        [HttpGet("")] public IActionResult Index() => View(); // /Software
        [HttpGet("Services")] public IActionResult Services() => View(); // /Software/Services
        [HttpGet("Cases")] public IActionResult Cases() => View();
        [HttpGet("Pricing")] public IActionResult Pricing() => View();
        [HttpGet("About")] public IActionResult About() => View();
        [HttpGet("Contact")] public IActionResult Contact() => View();

        [HttpPost("Contact")]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string Name, string Email, string Subject, string Message)
        {
            // TODO: send SMTP email
            TempData["ContactSuccess"] = true;
            return RedirectToAction(nameof(Contact));
        }
    }
}
