using CongesSociaux_Web.Models;
using CongesSociaux_Web.ViewModels;

namespace CongesSociaux_Web.Services.IServices
{
    public interface IServiceEmploye
    {
        public void CreaBanqueMala(Employe employe);
        public void MisAJourBanqueMala();
        public void AddEmploye(CreaEmployeVM employe);
    }
}
