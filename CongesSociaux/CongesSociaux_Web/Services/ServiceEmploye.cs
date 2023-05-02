using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;
using CongesSociaux_Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CongesSociaux_Web.Services
{
    public class ServiceEmploye : IServiceEmploye
    {
        private readonly CongeSociauxDbContext _context;

        public ServiceEmploye(CongeSociauxDbContext context)
        {
            _context = context;
        }

        public async void AddEmploye(CreaEmployeVM vm)
        {
            
            if (vm.Type == TypeEmploye.Soutien)
            {
                Soutien employe = new Soutien()
                {
                    Prenom = vm.Prenom,
                    Nom = vm.Nom,
                    DateEmbauche = vm.DateEmbauche,
                    Poste = vm.Poste,
                    Type = vm.Type
                };
                _context.Soutiens.Add(employe);
            }
            if (vm.Type == TypeEmploye.Enseignant)
            {
                Enseignant employe = new Enseignant()
                {
                    Prenom = vm.Prenom,
                    Nom = vm.Nom,
                    DateEmbauche = vm.DateEmbauche,
                    Specialite = vm.Specialite,
                    Type = vm.Type,
                    Departement = vm.Departement
                };

                _context.Enseignants.Add(employe);
            }
            await _context.SaveChangesAsync();
        }


        public void CreaBanqueMala(Employe employe)
        {
            Periode periodeCourante = new Periode();
            if (employe.Type == TypeEmploye.Soutien)
            {
                periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true && x.TypeEmploye == TypeEmploye.Soutien)
                                          .Include(x => x.TypeConges).First();
            }
            else
            {
                periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true && x.TypeEmploye == TypeEmploye.Enseignant)
                                          .Include(x => x.TypeConges).First();
            }

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
            List<Enseignant> enseignants = _context.Enseignants.ToList();
            List<Soutien> soutiens = _context.Soutiens.ToList();

            foreach (var item in enseignants)
            {
                Periode periodeCourante = new Periode();
                periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true && x.TypeEmploye == TypeEmploye.Enseignant)
                                          .Include(x => x.TypeConges).Include(x => x.BanqueMaladies).ThenInclude(x => x.Employe).First();
                TypeConge congeMaladie = periodeCourante.TypeConges.Where(x => x.Description == "Maladie").First();

                BanqueMaladie bbq = periodeCourante.BanqueMaladies.Where(x => x.Employe.Id == item.Id).First();
                if (!congeMaladie.Cumulable)
                    bbq.Solde = congeMaladie.NombreJours;
                else
                    bbq.Solde += congeMaladie.NombreJours;

                _context.Update(bbq);
            }

            foreach (var item in soutiens)
            {
                Periode periodeCourante = new Periode();
                periodeCourante = _context.Periodes.Where(x => x.PeriodeActive == true && x.TypeEmploye == TypeEmploye.Soutien)
                                          .Include(x => x.TypeConges).Include(x => x.BanqueMaladies).ThenInclude(x => x.Employe).First();
                TypeConge congeMaladie = periodeCourante.TypeConges.Where(x => x.Description == "Maladie").First();

                BanqueMaladie bbq = periodeCourante.BanqueMaladies.Where(x => x.Employe.Id == item.Id).First();
                if (!congeMaladie.Cumulable)
                    bbq.Solde = congeMaladie.NombreJours;
                else
                    bbq.Solde += congeMaladie.NombreJours;

                _context.Update(bbq);
            }
            
            _context.SaveChanges();
        }

    }
}
