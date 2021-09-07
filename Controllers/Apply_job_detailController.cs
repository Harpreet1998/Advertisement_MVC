using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Advertisement_MVC_.Data;
using Advertisement_MVC_.Models;
using Microsoft.AspNetCore.Authorization;

namespace Advertisement_MVC_.Controllers
{
    [Authorize]
    public class Apply_job_detailController : Controller
    {
        private readonly AdvertisementDbContext _context;

        public Apply_job_detailController(AdvertisementDbContext context)
        {
            _context = context;
        }

        // GET: Apply_job_detail
        public async Task<IActionResult> Index()
        {
            var advertisementDbContext = _context.Apply_job_detail.Include(a => a.Candidate).Include(a => a.Job_Detail);
            return View(await advertisementDbContext.ToListAsync());
        }

        // GET: Apply_job_detail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_job_detail = await _context.Apply_job_detail
                .Include(a => a.Candidate)
                .Include(a => a.Job_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apply_job_detail == null)
            {
                return NotFound();
            }

            return View(apply_job_detail);
        }

        // GET: Apply_job_detail/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Mobile_no_of_candidate");
            ViewData["Job_DetailId"] = new SelectList(_context.Jobs, "Id", "Id");
            return View();
        }

        // POST: Apply_job_detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CandidateId,Job_DetailId,Candidate_availabilities,Candidate_notice_period")] Apply_job_detail apply_job_detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apply_job_detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Mobile_no_of_candidate", apply_job_detail.CandidateId);
            ViewData["Job_DetailId"] = new SelectList(_context.Jobs, "Id", "Id", apply_job_detail.Job_DetailId);
            return View(apply_job_detail);
        }

        // GET: Apply_job_detail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_job_detail = await _context.Apply_job_detail.FindAsync(id);
            if (apply_job_detail == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Mobile_no_of_candidate", apply_job_detail.CandidateId);
            ViewData["Job_DetailId"] = new SelectList(_context.Jobs, "Id", "Id", apply_job_detail.Job_DetailId);
            return View(apply_job_detail);
        }

        // POST: Apply_job_detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CandidateId,Job_DetailId,Candidate_availabilities,Candidate_notice_period")] Apply_job_detail apply_job_detail)
        {
            if (id != apply_job_detail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apply_job_detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Apply_job_detailExists(apply_job_detail.Id))
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
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Mobile_no_of_candidate", apply_job_detail.CandidateId);
            ViewData["Job_DetailId"] = new SelectList(_context.Jobs, "Id", "Id", apply_job_detail.Job_DetailId);
            return View(apply_job_detail);
        }

        // GET: Apply_job_detail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apply_job_detail = await _context.Apply_job_detail
                .Include(a => a.Candidate)
                .Include(a => a.Job_Detail)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apply_job_detail == null)
            {
                return NotFound();
            }

            return View(apply_job_detail);
        }

        // POST: Apply_job_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apply_job_detail = await _context.Apply_job_detail.FindAsync(id);
            _context.Apply_job_detail.Remove(apply_job_detail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Apply_job_detailExists(int id)
        {
            return _context.Apply_job_detail.Any(e => e.Id == id);
        }
    }
}
