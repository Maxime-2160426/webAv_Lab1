namespace CongesSociaux_Web.Models
{
    public class TypeConge
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool Cumulable { get; set; }
        public int NombreJours  { get; set; }

        public Periode Periode { get; set; }

    }
}
