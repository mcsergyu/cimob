using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models;

namespace Cimob.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class InterviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cimob.Controllers.InterviewsController" /> class. 
        /// </summary>
        /// <param name="context"></param>
        /// <remarks></remarks>
        public InterviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interviews
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Interview;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interviews/Details/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interview = await _context.Interview
                .SingleOrDefaultAsync(m => m.InterviewId == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }
        /*
        // GET: Interviews/Create
        public IActionResult Create()
        {
            ViewData["CandidaturaId"] = new SelectList(_context.Candidatura, "CandidaturaId", "CandidaturaId");
            return View();
        }
        

        // POST: Interviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterviewId,CandidaturaId,Description,StartDate,Confirmed")] Interview interview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidaturaId"] = new SelectList(_context.Candidatura, "CandidaturaId", "CandidaturaId", interview.CandidaturaId);
            return View(interview);
        }
        */

        // GET: Interviews/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interview = await _context.Interview.SingleOrDefaultAsync(m => m.InterviewId == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // POST: Interviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="interview"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterviewId,StartDate")] Interview interview)
        {
            var i = _context.Interview.SingleOrDefault(m => m.InterviewId == id);
            i.StartDate = interview.StartDate;
            _context.Update(i);
            await _context.SaveChangesAsync();
            var candidatura = await _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == i.CandidaturaId);
            candidatura.State = CandidaturaState.interview;
            _context.Update(candidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Candidaturas", new { id = candidatura.CandidaturaId });
        }
        /*
        // GET: Interviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interview = await _context.Interview
                .Include(i => i.Candidatura)
                .SingleOrDefaultAsync(m => m.InterviewId == id);
            if (interview == null)
            {
                return NotFound();
            }

            return View(interview);
        }

        // POST: Interviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interview = await _context.Interview.SingleOrDefaultAsync(m => m.InterviewId == id);
            _context.Interview.Remove(interview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool InterviewExists(int id)
        {
            return _context.Interview.Any(e => e.InterviewId == id);
        }
    }
}
