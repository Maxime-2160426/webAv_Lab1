namespace CongesSociaux_Web.Models
{
    public class BanqueMaladie
    {
        public int Id { get; set; }
        public int Solde { get; set; }

        public Periode Periode { get; set; }
        public Employe Employe { get; set; }
    }
}
