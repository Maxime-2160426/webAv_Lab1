using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;

namespace CongesSociaux_Web.Services
{
    public class ServiceConge : IServiceConge
    {
        private CongeSociauxDbContext _context;

        public ServiceConge(CongeSociauxDbContext db)
        {
            _context = db;
        }

        public bool verifCongeDispo(Conge conge)
        {
            IEnumerable<Conge> congeList = _context.Conges.Where(c => c.Employe.Id == conge.Employe.Id);

            TypeConge? type = _context.TypeConges.SingleOrDefault(t => t.Id == conge.TypeCongeId);

            return type != null && congeList.Count() < type.NombreJours;
        }
    }
}
