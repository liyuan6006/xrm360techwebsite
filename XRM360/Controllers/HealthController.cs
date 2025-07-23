using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
