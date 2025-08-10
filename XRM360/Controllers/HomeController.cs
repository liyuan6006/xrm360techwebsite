using Microsoft.AspNetCore.Mvc;

using XRM360website.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using MailKit.Security;
using System.Net;
namespace XRM360website.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmtpOptions _smtp;
        public HomeController(IOptions<SmtpOptions> smtp) => _smtp = smtp.Value;

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

            try
            {
                // Build the email
                var msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("XRM360 Website", _smtp.From));
                msg.To.Add(MailboxAddress.Parse(_smtp.To));
                msg.Subject = string.IsNullOrWhiteSpace(form.Subject)
                    ? "New Contact Form Submission"
                    : form.Subject.Trim();

                // Make replies go to the visitor
                if (!string.IsNullOrWhiteSpace(form.Email))
                    msg.ReplyTo.Add(MailboxAddress.Parse(form.Email));

                // Simple HTML body
                var bodyHtml = $@"
                    <h3>New message from XRM360.com</h3>
                    <p><strong>Name:</strong> {WebUtility.HtmlEncode(form.Name)}</p>
                    <p><strong>Email:</strong> {WebUtility.HtmlEncode(form.Email)}</p>
                    <p><strong>Phone:</strong> {WebUtility.HtmlEncode(form.Phone ?? "")}</p>
                    <p><strong>Message:</strong><br/>{WebUtility.HtmlEncode(form.Message).Replace("\n", "<br/>")}</p>";

                msg.Body = new TextPart("html") { Text = bodyHtml };

                // Send via Gmail SMTP
                using var client = new SmtpClient();
                var secure = _smtp.UseStartTls ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                client.Connect(_smtp.Host, _smtp.Port, secure);
                client.Authenticate(_smtp.User, _smtp.Pass);
                client.Send(msg);
                client.Disconnect(true);

                TempData["ContactSuccess"] = true;
                return RedirectToAction(nameof(Contact));
            }
            catch (Exception)
            {
                TempData["ContactError"] = "Sorry, we couldn’t send your message. Please try again shortly.";
                return View(form);
            }
        }
    }
}
