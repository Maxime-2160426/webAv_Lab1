using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;
using CongesSociaux_Web.Services;

namespace CongesSociaux_Web.Controllers
{
    public class CongesController : Controller
    {
        private readonly CongeSociauxDbContext _context;
        private IServiceConge serviceConge;

        public CongesController(CongeSociauxDbContext context, ServiceConge service)
        {
            _context = context;
            serviceConge = service;
        }

        // GET: Conges
        public async Task<IActionResult> Index()
        {
              return _context.Conges != null ? 
                          View(await _context.Conges.ToListAsync()) :
                          Problem("Entity set 'CongeSociauxDbContext.Conges'  is null.");
        }

        // GET: Conges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conges == null)
            {
                return NotFound();
            }

            var conge = await _context.Conges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // GET: Conges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateDebut,Duree,Description")] Conge conge)
        {
            if (ModelState.IsValid)
            {
                if (serviceConge.VerifCongeDispo(conge))
                {
                    _context.Add(conge);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(nameof(Conge.TypeCongeId), "Vous n'avez plus de congé en banque pour ce type");
                }
            }
            return View(conge);
        }

        // GET: Conges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conges == null)
            {
                return NotFound();
            }

            var conge = await _context.Conges.FindAsync(id);
            if (conge == null)
            {
                return NotFound();
            }
            return View(conge);
        }

        // POST: Conges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateDebut,Duree,Description")] Conge conge)
        {
            if (id != conge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongeExists(conge.Id))
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
            return View(conge);
        }

        // GET: Conges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conges == null)
            {
                return NotFound();
            }

            var conge = await _context.Conges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // POST: Conges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conges == null)
            {
                return Problem("Entity set 'CongeSociauxDbContext.Conges'  is null.");
            }
            var conge = await _context.Conges.FindAsync(id);
            if (conge != null)
            {
                _context.Conges.Remove(conge);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongeExists(int id)
        {
          return (_context.Conges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
