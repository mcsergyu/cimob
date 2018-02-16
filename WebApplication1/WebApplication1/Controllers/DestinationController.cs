﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cimob.Data;
using Cimob.Models;
using Newtonsoft.Json;

namespace Cimob.Controllers
{
    [JsonObject(IsReference = true)]
    public class DestinationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Destination
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destinations.ToListAsync());
        }

        // GET: Destination/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
  
            var destination = await _context.Destinations
     
                .SingleOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destination/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Destination/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("DestinationId,Cidade,Pais")] Destination destination)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(destination);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(destination);
        //}

        //// GET: Destination/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var destination = await _context.Destinations.SingleOrDefaultAsync(m => m.DestinationId == id);
        //    if (destination == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(destination);
        //}

        //// POST: Destination/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("DestinationId,Cidade,Pais")] Destination destination)
        //{
        //    if (id != destination.DestinationId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(destination);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DestinationExists(destination.DestinationId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(destination);
        //}

        //// GET: Destination/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var destination = await _context.Destinations
        //        .SingleOrDefaultAsync(m => m.DestinationId == id);
        //    if (destination == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(destination);
        //}

        // GET: Destination/Delete/5
        public async Task<IActionResult> DestinationProgram(int? id)
        {
            var programas = await _context.Programs.Where(p => p.DestinationId == id).ToListAsync();
            

            return View(programas);
        }


        // POST: Destination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destinations.SingleOrDefaultAsync(m => m.DestinationId == id);
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
            return _context.Destinations.Any(e => e.DestinationId == id);
        }



        }
}
