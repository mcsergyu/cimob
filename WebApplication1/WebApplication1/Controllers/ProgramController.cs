using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Models;
using Cimob.Models.ProgramViewModels;

namespace Cimob.Controllers
{
    public class ProgramController : Controller
    {
        private readonly ProgramDbContext _context;

        public ProgramController(ProgramDbContext context)
        {
            _context = context;
        }

        // GET: Program
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProgramViewModel.ToListAsync());
        }

        // GET: Program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programViewModel = await _context.ProgramViewModel
                .SingleOrDefaultAsync(m => m.ProgramId == id);
            if (programViewModel == null)
            {
                return NotFound();
            }

            return View(programViewModel);
        }

        // GET: Program/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramId,Name,Entity,Description,Vacancies,StartDate,EndDate")] ProgramViewModel programViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programViewModel);
        }

        // GET: Program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programViewModel = await _context.ProgramViewModel.SingleOrDefaultAsync(m => m.ProgramId == id);
            if (programViewModel == null)
            {
                return NotFound();
            }
            return View(programViewModel);
        }

        // POST: Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,Name,Entity,Description,Vacancies,StartDate,EndDate")] ProgramViewModel programViewModel)
        {
            if (id != programViewModel.ProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramViewModelExists(programViewModel.ProgramId))
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
            return View(programViewModel);
        }

        // GET: Program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programViewModel = await _context.ProgramViewModel
                .SingleOrDefaultAsync(m => m.ProgramId == id);
            if (programViewModel == null)
            {
                return NotFound();
            }

            return View(programViewModel);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programViewModel = await _context.ProgramViewModel.SingleOrDefaultAsync(m => m.ProgramId == id);
            _context.ProgramViewModel.Remove(programViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramViewModelExists(int id)
        {
            return _context.ProgramViewModel.Any(e => e.ProgramId == id);
        }
    }
}
