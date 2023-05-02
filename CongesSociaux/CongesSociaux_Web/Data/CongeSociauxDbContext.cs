using CongesSociaux_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Data
{
    public class CongeSociauxDbContext : IdentityDbContext
    {
       


        public CongeSociauxDbContext(DbContextOptions<CongeSociauxDbContext> options)
            : base(options)
        {
        }


        public DbSet<Conge> Conges { get; set; }

        DbSet<Soutien> Soutiens { get; set; }
        DbSet<Enseignant> Enseignants { get; set; }
        DbSet<Departement> Departements { get; set; }

    }
}