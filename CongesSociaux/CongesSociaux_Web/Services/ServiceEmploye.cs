using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;
using CongesSociaux_Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Services
{
    public class ServiceEmploye : IServiceEmploye
    {
        private CongeSociauxDbContext _context;

        public ServiceEmploye(CongeSociauxDbContext context)
        {
            _context = context;
        }

        public void AddEmploye(CreaEmployeVM employe)
        {
            throw new NotImplementedException();
        }

        public void CreaBanqueMala(Employe employe)
        {
            Periode periodeCourante = new Periode();
            if (employe.Type == TypeEmploye.Soutien)
            {
                periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true && x.TypeEmploye == TypeEmploye.Soutien).Include(x => x.TypeConges).First();
            }
            else
            {
                periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true && x.TypeEmploye == TypeEmploye.Enseignant).Include(x => x.TypeConges).First();
            }

            periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true).Include(x => x.TypeConges).First();

            BanqueMaladie banqueMaladie = new BanqueMaladie()
            {
                Periode = periodeCourante,
                Employe = employe,
                Solde = periodeCourante.TypeConges.Where(x => x.Description == "Maladie").First().NombreJours
            };

            _context.BanquesMaladie.Add(banqueMaladie);
            _context.SaveChanges();
        }

        public void MisAJourBanqueMala()
        {
            throw new NotImplementedException();
        }
    }
}
