using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class EducationController : Controller
    {
        [Route("Education/{lang=en}")]
        public IActionResult Index(string lang)
        {
            return lang?.ToLower() == "zh" ? View("Index.zh") : View("Index");
        }
    }
}
