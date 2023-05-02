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

        public DbSet<Soutien> Soutiens { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<BanqueMaladie> BanquesMaladie { get; set; }

        
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<TypeConge> TypeConges { get; set; }
    }
}