using CongesSociaux_Web.Data;
using CongesSociaux_Web.Models;
using CongesSociaux_Web.Services.IServices;

namespace CongesSociaux_Web.Services
{
    public class ServiceConge : IServiceConge
    {
        private readonly CongeSociauxDbContext _context;

        public ServiceConge(CongeSociauxDbContext db)
        {
            _context = db;
        }

        public bool verifCongeDispo(int employeId, TypeConge type)
        {
            IEnumerable<Conge> congeList = _context.Conges.Where(c => c.Employe.Id == employeId).Where(c => c.TypeConge == type);

            return congeList.Count() < type.NombreJours;
        }
    }
}
