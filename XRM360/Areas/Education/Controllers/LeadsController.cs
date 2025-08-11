using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XRM360website.Data;
using XRM360website.Models;

namespace XRM360website.Areas.Education.Controllers
{
    [Area("Education")]
    // Default to Index instead of Create
    [Route("Education/Leads/{action=Index}/{id?}")]
    public class LeadsController : Controller
    {
        private readonly AppDbContext _db;
        public LeadsController(AppDbContext db) => _db = db;

        // helper to populate dropdowns (reuse in Create/Edit)
        private void LoadDropdowns()
        {
            ViewBag.ContactMethods = Enum.GetValues(typeof(ContactMethod))
                .Cast<ContactMethod>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
            ViewBag.StudyLevels = Enum.GetValues(typeof(StudyLevel))
                .Cast<StudyLevel>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
            ViewBag.EnglishStatuses = Enum.GetValues(typeof(EnglishTestStatus))
                .Cast<EnglishTestStatus>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
            ViewBag.LeadSources = Enum.GetValues(typeof(LeadSource))
                .Cast<LeadSource>().Select(x => new SelectListItem(x.ToString(), x.ToString()));
        }

        // GET: /Education/Leads
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

        // GET: /Education/Leads/Create
        [HttpGet]
        public IActionResult Create(string? utm)
        {
            LoadDropdowns();
            var model = new StudentLead { UtmSource = utm };
            return View(model);
        }

        // POST: /Education/Leads/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentLead model)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(model);
            }

            model.CreatedUtc = DateTime.UtcNow;
            _db.StudentLeads.Add(model);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        // GET: /Education/Leads/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var lead = await _db.StudentLeads.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (lead == null) return NotFound();
            return View(lead);
        }

        // GET: /Education/Leads/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var lead = await _db.StudentLeads.FindAsync(id);
            if (lead == null) return NotFound();
            LoadDropdowns();
            return View(lead);
        }

        // POST: /Education/Leads/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentLead model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(model);
            }

            _db.Entry(model).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        // GET: /Education/Leads/Delete/5  (confirm page)
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var lead = await _db.StudentLeads.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (lead == null) return NotFound();
            return View(lead);
        }

        // POST: /Education/Leads/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lead = await _db.StudentLeads.FindAsync(id);
            if (lead != null)
            {
                _db.StudentLeads.Remove(lead);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
