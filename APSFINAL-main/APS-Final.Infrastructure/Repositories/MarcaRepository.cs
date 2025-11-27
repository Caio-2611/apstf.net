using APS_Final.Domain.Entities;
using APS_Final.Domain.Repositories;
using APS_Final.Infrastructure.Data;

namespace APS_Final.Infrastructure.Repositories
{
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(AppDbContext context) : base(context)
        {
        }
        
        // Se a IMarcaRepository tivesse métodos extras, eles seriam implementados aqui.
    }
}