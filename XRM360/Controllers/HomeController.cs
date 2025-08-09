using Microsoft.AspNetCore.Mvc;
using XRM360website.Models;

namespace XRM360website.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        // GET /Home/Contact  and pretty alias /Contact
        [HttpGet]
        [Route("Home/Contact")]
        [Route("Contact")]
        public IActionResult Contact() => View(new ContactForm());

        // POST /Home/Contact and /Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Home/Contact")]
        [Route("Contact")]
        public IActionResult Contact(ContactForm form)
        {
            if (!ModelState.IsValid) return View(form);

            // TODO: send email (SMTP/MailKit) or store to DB
            TempData["ContactSuccess"] = true;
            return RedirectToAction(nameof(Contact));
        }
    }
}
