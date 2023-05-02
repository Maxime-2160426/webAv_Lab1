namespace CongesSociaux_Web.Models
{
    public class Periode
    {
        public int Id { get; set; }
        public string? PeriodeName { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; }
       
        public bool PeriodeActive { get; set; }
        
        public TypeEmploye TypeEmploye { get; set; }
        public List<TypeConge> TypeConges { get; set; }
        public List<BanqueMaladie> BanqueMaladies { get; set; }

    }
}
