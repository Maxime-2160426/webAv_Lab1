using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Services.IServices
{
    public interface IServiceEmploye
    {
        public void CreaBanqueMala(Employe employe);
        public void MisAJourBanqueMala();
        public void AddEmploye();
    }
}
