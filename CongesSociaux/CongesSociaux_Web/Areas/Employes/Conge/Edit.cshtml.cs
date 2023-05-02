using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Areas.Employes
{
    public class EditModel : PageModel
    {
        private readonly CongesSociaux_Web.Data.CongeSociauxDbContext _context;

        public EditModel(CongesSociaux_Web.Data.CongeSociauxDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conge Conge { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Conges == null)
            {
                return NotFound();
            }

            var conge =  await _context.Conges.FirstOrDefaultAsync(m => m.Id == id);
            if (conge == null)
            {
                return NotFound();
            }
            Conge = conge;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Conge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongeExists(Conge.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CongeExists(int id)
        {
          return (_context.Conges?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
