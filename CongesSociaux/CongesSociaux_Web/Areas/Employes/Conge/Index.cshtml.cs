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
    public class IndexModel : PageModel
    {
        private readonly CongesSociaux_Web.Data.CongeSociauxDbContext _context;

        public IndexModel(CongesSociaux_Web.Data.CongeSociauxDbContext context)
        {
            _context = context;
        }

        public IList<Conge> Conge { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Conges != null)
            {
                Conge = await _context.Conges.ToListAsync();
            }
        }
    }
}
