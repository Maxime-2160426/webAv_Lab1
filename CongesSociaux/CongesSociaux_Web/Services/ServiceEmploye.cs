using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Services
{
    public class ServiceEmploye : IServiceEmploye
    {
        private CongeSociauxDbContext _context;

        public ServiceEmploye(CongeSociauxDbContext db)
        {
            _context = db;
        }
        public void AddEmploye()
        {
            throw new NotImplementedException();
        }

        public void CreaBanqueMala(Employe employe)
        {
            throw new NotImplementedException();
        }

        public void MisAJourBanqueMala()
        {
            throw new NotImplementedException();
        }

        public async void MisAJourPeriode() 
        {
            Periode periode = await _context.Periodes.Where(a => a.PeriodeActive == true).FirstAsync();
            periode.PeriodeActive = false;

            _context.SaveChangesAsync();
        }
        public async void CreationPeriode(string nomPeriode)
        {
            Periode periode = new Periode();
            periode.DateDebut = DateTime.Now;
            periode.PeriodeActive = true;
            periode.PeriodeName = nomPeriode;

            _context.Periodes.Add(periode);
        }
    }
}
