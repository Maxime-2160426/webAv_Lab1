using CongesSociaux_Web.Areas.Employes;
using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;
using CongesSociaux_Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            throw new NotImplementedException();
        }

        public void MisAJourBanqueMala()
        {
            throw new NotImplementedException();
        }

    }
}
