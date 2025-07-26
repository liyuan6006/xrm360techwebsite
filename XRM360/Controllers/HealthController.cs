using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class HealthController : Controller
    {
        [Route("Health/{lang=en}")]
        public IActionResult Index(string lang)
        {
            return lang?.ToLower() == "zh" ? View("Index.zh") : View("Index");
        }
    }
}
