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
    public class ProgramController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Program
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Programs.Include(p => p.ProgramDestination).Include(p => p.ProgramEntity);  
            return View(await _context.Programs.ToListAsync());
        }

        // GET: Program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Programs
                .Include(p=>p.ProgramDestination)
                .Include(p => p.ProgramEntity)
                .SingleOrDefaultAsync(m => m.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // GET: Program/Create
        public IActionResult Create()
        {
            ViewData["DestinationId"] = new SelectList(_context.Set<Destination>(), "DestinationId", "DestinationId");
            ViewData["EntityId"] = new SelectList(_context.Set<Entity>(), "EntityId", "EntityId");
            return View();
        }

        // POST: Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramId,Name,DestinationId,EntityId,Description,Vacancies,StartDate,EndDate")] Program program)
        {
            if (ModelState.IsValid)
            {
                _context.Add(program);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationId"] = new SelectList(_context.Set<Destination>(), "DestinationId", "DestinationId", program.EntityId);
            ViewData["EntityId"] = new SelectList(_context.Set<Entity>(), "EntityId", "EntityId", program.EntityId);
            return View(program);
        }

        // GET: Program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Programs.SingleOrDefaultAsync(m => m.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }
            ViewData["DestinationId"] = new SelectList(_context.Set<Destination>(), "DestinationId", "DestinationId", program.DestinationId);
            ViewData["EntityId"] = new SelectList(_context.Set<Entity>(), "EntityId", "EntityId", program.EntityId);
            return View(program);
        }

        // POST: Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,Name,DestinationId,EntityId,Description,Vacancies,StartDate,EndDate")] Cimob.Models.Program program)
        {
            if (id != program.ProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(program);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramExists(program.ProgramId))
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
            ViewData["DestinationId"] = new SelectList(_context.Set<Destination>(), "DestinationId", "DestinationId", program.DestinationId);
            ViewData["EntityId"] = new SelectList(_context.Set<Entity>(), "EntityId", "EntityId", program.EntityId);
            return View(program);
        }

        // GET: Program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var program = await _context.Programs
                .SingleOrDefaultAsync(m => m.ProgramId == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var program = await _context.Programs.SingleOrDefaultAsync(m => m.ProgramId == id);
            _context.Programs.Remove(program);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramExists(int id)
        {
            return _context.Programs.Any(e => e.ProgramId == id);
        }
    }
}
