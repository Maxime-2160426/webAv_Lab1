using CongesSociaux_Web.Models;
using CongesSociaux_Web.ViewModels;
using CongesSociaux_Web.Data;

namespace CongesSociaux_Web.Services.IServices
{
    public interface IServiceEmploye
    {
        public void CreaBanqueMala(Employe employe);
        public void MisAJourBanqueMala();
        public void AddEmploye(CreaEmployeVM vm);
    }
}
