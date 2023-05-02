using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.ViewModels
{
    public class CreaEmployeVM
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateEmbauche { get; set; }

        public TypeEmploye Type { get; set; }

        public string? Specialite { get; set; }
        public Departement? Departement { get; set; }

        public string? Poste { get; set; }
    }
}
