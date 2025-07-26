using Microsoft.AspNetCore.Mvc;

namespace XRM360website.Controllers
{
    public class PrivacyController : BaseController
    {
        public IActionResult Index()
        {
            return LangView("Index");
        }
    }
}
