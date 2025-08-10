using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XRM360website.Data;
using XRM360website.Models;

namespace XRM360website.Areas.Education.Controllers
{
    [Area("Education")]
    [Route("Education/Leads/{action=Create}/{id?}")]
    public class LeadsController : Controller
    {
        private readonly AppDbContext _db;
        public LeadsController(AppDbContext db) => _db = db;

        [HttpGet]
        public IActionResult Create(string? utm)
        {
            ViewBag.ContactMethods = Enum.GetValues(typeof(ContactMethod))
                .Cast<ContactMethod>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
            ViewBag.StudyLevels = Enum.GetValues(typeof(StudyLevel))
                .Cast<StudyLevel>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
            ViewBag.EnglishStatuses = Enum.GetValues(typeof(EnglishTestStatus))
                .Cast<EnglishTestStatus>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
            ViewBag.LeadSources = Enum.GetValues(typeof(LeadSource))
                .Cast<LeadSource>().Select(x => new SelectListItem(x.ToString(), x.ToString()));

            var model = new StudentLead { UtmSource = utm };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentLead model)
        {
            if (!ModelState.IsValid)
            {
                // re-bind dropdowns
                ViewBag.ContactMethods = Enum.GetValues(typeof(ContactMethod))
                    .Cast<ContactMethod>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
                ViewBag.StudyLevels = Enum.GetValues(typeof(StudyLevel))
                    .Cast<StudyLevel>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
                ViewBag.EnglishStatuses = Enum.GetValues(typeof(EnglishTestStatus))
                    .Cast<EnglishTestStatus>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
                ViewBag.LeadSources = Enum.GetValues(typeof(LeadSource))
                    .Cast<LeadSource>().Select(x => new SelectListItem(x.ToString(), x.ToString()));

                return View(model);
            }

            model.CreatedUtc = DateTime.UtcNow;
            _db.StudentLeads.Add(model);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Thanks), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Thanks(int id)
        {
            var lead = await _db.StudentLeads.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (lead == null) return RedirectToAction(nameof(Create));
            return View(lead);
        }

        // Basic listing (protect later with [Authorize] or roles)
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var leads = await _db.StudentLeads
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedUtc)
                .Take(200)
                .ToListAsync();
            return View(leads);
        }
    }
}
