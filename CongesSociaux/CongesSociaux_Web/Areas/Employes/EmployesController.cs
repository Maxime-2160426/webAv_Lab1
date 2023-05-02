using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Areas.Employes
{
    [Area("Employes")]
    public class EmployesController : Controller
    {
        private readonly CongeSociauxDbContext _context;

        public EmployesController(CongeSociauxDbContext context)
        {
            _context = context;
        }

        // GET: Employes/Employes
        public async Task<IActionResult> Index()
        {
              return _context.Employes != null ? 
                          View(await _context.Employes.ToListAsync()) :
                          Problem("Entity set 'CongeSociauxDbContext.Employes'  is null.");
        }

        // GET: Employes/Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employes == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // GET: Employes/Employes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employes/Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Prenom,Nom,DateEmbauche")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employe);
        }

        // GET: Employes/Employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employes == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return View(employe);
        }

        // POST: Employes/Employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Prenom,Nom,DateEmbauche")] Employe employe)
        {
            if (id != employe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.Id))
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
            return View(employe);
        }

        // GET: Employes/Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employes == null)
            {
                return NotFound();
            }

            var employe = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employes/Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employes == null)
            {
                return Problem("Entity set 'CongeSociauxDbContext.Employes'  is null.");
            }
            var employe = await _context.Employes.FindAsync(id);
            if (employe != null)
            {
                _context.Employes.Remove(employe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
          return (_context.Employes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
