using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Areas.Employes
{
    public class CreateModel : PageModel
    {
        private readonly CongesSociaux_Web.Data.CongeSociauxDbContext _context;

        public CreateModel(CongesSociaux_Web.Data.CongeSociauxDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Conge Conge { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Conges == null || Conge == null)
            {
                return Page();
            }

            _context.Conges.Add(Conge);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
