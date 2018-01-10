using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafetyManagementSystem.Models;

namespace SafetyManagementSystem.Controllers
{
    public class SMS : Controller
    {
        private readonly SafetyManagementSystemContext _context;

        public SMS(SafetyManagementSystemContext context)
        {
            _context = context;
        }

        // GET: SMS
        public async Task<IActionResult> Index()
        {
            var safetyManagementSystemContext = _context.HazardReports.Include(h => h.HazardCategory).Include(h => h.Site);
            return View(await safetyManagementSystemContext.ToListAsync());
        }

        // GET: SMS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hazardReports = await _context.HazardReports
                .Include(h => h.HazardCategory)
                .Include(h => h.Site)
                .SingleOrDefaultAsync(m => m.HazardReportId == id);
            if (hazardReports == null)
            {
                return NotFound();
            }

            return View(hazardReports);
        }

        // GET: SMS/Create
        public IActionResult Create()
        {
            ViewData["HazardCategoryId"] = new SelectList(_context.HazardCategories, "HazardCategoryId", "HazardCategory");
            ViewData["SiteId"] = new SelectList(_context.Sites, "SiteId", "SiteName");
            return View();
        }

        // POST: SMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HazardReportId,SiteId,ReportedByEmployee,ReportedByEmpDept,HazardCategoryId,Witnesses,AffectedPersonnel,HazardLocation,InvolvedMaterial,Issue,HazardPotential,HazardReportDate,RegulatoryViolation,Supervisor,Manager,SuggestedCorrections,CorrectiveAction,RequiredPurchases,CostOfPurchases,DateImplemented,AdminEmployee,AdminDate")] HazardReports hazardReports)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hazardReports);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HazardCategoryId"] = new SelectList(_context.HazardCategories, "HazardCategoryId", "HazardCategory", hazardReports.HazardCategoryId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "SiteId", "SiteName", hazardReports.SiteId);
            return View(hazardReports);
        }

        // GET: SMS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hazardReports = await _context.HazardReports.SingleOrDefaultAsync(m => m.HazardReportId == id);
            if (hazardReports == null)
            {
                return NotFound();
            }
            ViewData["HazardCategoryId"] = new SelectList(_context.HazardCategories, "HazardCategoryId", "HazardCategory", hazardReports.HazardCategoryId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "SiteId", "SiteName", hazardReports.SiteId);
            return View(hazardReports);
        }

        // POST: SMS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HazardReportId,SiteId,ReportedByEmployee,ReportedByEmpDept,HazardCategoryId,Witnesses,AffectedPersonnel,HazardLocation,InvolvedMaterial,Issue,HazardPotential,HazardReportDate,RegulatoryViolation,Supervisor,Manager,SuggestedCorrections,CorrectiveAction,RequiredPurchases,CostOfPurchases,DateImplemented,AdminEmployee,AdminDate")] HazardReports hazardReports)
        {
            if (id != hazardReports.HazardReportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hazardReports);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HazardReportsExists(hazardReports.HazardReportId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HazardCategoryId"] = new SelectList(_context.HazardCategories, "HazardCategoryId", "HazardCategory", hazardReports.HazardCategoryId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "SiteId", "SiteName", hazardReports.SiteId);
            return View(hazardReports);
        }

        // GET: SMS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hazardReports = await _context.HazardReports
                .Include(h => h.HazardCategory)
                .Include(h => h.Site)
                .SingleOrDefaultAsync(m => m.HazardReportId == id);
            if (hazardReports == null)
            {
                return NotFound();
            }

            return View(hazardReports);
        }

        // POST: SMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hazardReports = await _context.HazardReports.SingleOrDefaultAsync(m => m.HazardReportId == id);
            _context.HazardReports.Remove(hazardReports);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HazardReportsExists(int id)
        {
            return _context.HazardReports.Any(e => e.HazardReportId == id);
        }
    }
}
