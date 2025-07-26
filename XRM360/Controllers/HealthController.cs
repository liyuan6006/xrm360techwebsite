using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class HealthController : BaseController
    {
        public IActionResult Index()
        {
            return LangView("Index");
        }
    }
}
