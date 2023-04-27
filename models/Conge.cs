namespace CongesSociaux_Web.Models
{
    public class Conge
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public int Duree { get; set; }
        public string Description { get; set; }


        public Employe Employe { get; set; }
    }
}
