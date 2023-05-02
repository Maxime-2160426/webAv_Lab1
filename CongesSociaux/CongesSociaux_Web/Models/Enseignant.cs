namespace CongesSociaux_Web.Models
{
    public class Enseignant : Employe
    {
        public string Specialite { get; set; }

        public Departement Departement { get; set; }
    }
}
