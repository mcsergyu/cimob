﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models;
using Microsoft.AspNetCore.Identity;

namespace Cimob.Controllers
{
    public class CandidaturasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CandidaturasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Candidaturas
        public async Task<IActionResult> Index()
        {
            var user = _userManager.GetUserId(HttpContext.User);
            var applicationDbContext = _context.Candidatura.Where(m => m.UserId == user).Include(c => c.AppliedProgram);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura
                .Include(c => c.AppliedProgram)
                .SingleOrDefaultAsync(m => m.CandidaturaId == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // GET: Candidaturas/Create
        public IActionResult Create(int? id)
        {
            ViewData["ProgramId"] = new SelectList(_context.Programs, "ProgramId", "Description", id);
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidaturaId,ProgramId,UserId,StartDate,LastStateDate")] Candidatura candidatura)
        {
            if (ModelState.IsValid)
            {
                var programName = _context.Programs.SingleOrDefault(p => p.ProgramId == candidatura.ProgramId).Name;
                var interview = new Interview() { Description = "Descrição do contexto da entrevista relativa ao programa " + programName };
                interview.StartDate = DateTime.Now.AddDays(-1);
                _context.Add(interview);
                await _context.SaveChangesAsync();
                var user = _userManager.GetUserId(HttpContext.User);
                candidatura.UserId = user;
                candidatura.StartDate = DateTime.Now;
                candidatura.LastStateDate = DateTime.Now;
                candidatura.State = CandidaturaState.scheduling;
                candidatura.InterviewId = interview.InterviewId;
                _context.Add(candidatura);
                await _context.SaveChangesAsync();
                interview.CandidaturaId = candidatura.CandidaturaId;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramId"] = new SelectList(_context.Programs, "ProgramId", "Description", candidatura.ProgramId);
            return View(candidatura);
        }

        
        public async Task<IActionResult> Cancel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura
                .Include(c => c.AppliedProgram)
                .SingleOrDefaultAsync(m => m.CandidaturaId == id && (m.State == CandidaturaState.interview || m.State == CandidaturaState.scheduling));
            if (candidatura == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(candidatura);
        }

        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            var candidatura = await _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == id);
            candidatura.State = CandidaturaState.canceled;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /*
        // GET: Candidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == id);
            if (candidatura == null)
            {
                return NotFound();
            }
            ViewData["ProgramId"] = new SelectList(_context.Programs, "ProgramId", "Description", candidatura.ProgramId);
            return View(candidatura);
        }

        
        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaId,ProgramId,UserId,StartDate,LastStateDate")] Candidatura candidatura)
        {
            if (id != candidatura.CandidaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturaExists(candidatura.CandidaturaId))
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
            ViewData["ProgramId"] = new SelectList(_context.Programs, "ProgramId", "Description", candidatura.ProgramId);
            return View(candidatura);
        }

        // GET: Candidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatura = await _context.Candidatura
                .Include(c => c.AppliedProgram)
                .SingleOrDefaultAsync(m => m.CandidaturaId == id);
            if (candidatura == null)
            {
                return NotFound();
            }

            return View(candidatura);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatura = await _context.Candidatura.SingleOrDefaultAsync(m => m.CandidaturaId == id);
            _context.Candidatura.Remove(candidatura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturaExists(int id)
        {
            return _context.Candidatura.Any(e => e.CandidaturaId == id);
        }
        */
    }
}
