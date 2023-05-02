using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Areas.Employes
{
    public class DeleteModel : PageModel
    {
        private readonly CongesSociaux_Web.Data.CongeSociauxDbContext _context;

        public DeleteModel(CongesSociaux_Web.Data.CongeSociauxDbContext context)
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

            var conge = await _context.Conges.FirstOrDefaultAsync(m => m.Id == id);

            if (conge == null)
            {
                return NotFound();
            }
            else 
            {
                Conge = conge;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Conges == null)
            {
                return NotFound();
            }
            var conge = await _context.Conges.FindAsync(id);

            if (conge != null)
            {
                Conge = conge;
                _context.Conges.Remove(Conge);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
