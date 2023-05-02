namespace CongesSociaux_Web.Models
{
    public class Conge
    {
        public int CongeId { get; set; }
        public DateTime DateDebut { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }

        public int TypeCongeId { get; set; }
        public TypeConge TypeConge { get; set; }
        public Employe Employe { get; set; }
    }
}
