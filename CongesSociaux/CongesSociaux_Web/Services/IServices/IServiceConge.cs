using CongesSociaux_Web.Models;

namespace CongesSociaux_Web.Services.IServices
{
    public interface IServiceConge
    {
        public bool VerifCongeDispo(int employeId, TypeConge type) { return false; }
    }
}
