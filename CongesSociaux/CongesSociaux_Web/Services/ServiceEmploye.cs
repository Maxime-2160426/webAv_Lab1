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
                    Poste = vm.Poste
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
                    Specialite = vm.Specialite
                };

                _context.Enseignants.Add(employe);
            }
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
