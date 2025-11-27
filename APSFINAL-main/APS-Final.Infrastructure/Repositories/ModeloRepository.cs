using APS_Final.Domain.Entities;
using APS_Final.Domain.Repositories;
using APS_Final.Infrastructure.Data;

namespace APS_Final.Infrastructure.Repositories
{
    public class ModeloRepository : GenericRepository<Modelo>, IModeloRepository
    {
        public ModeloRepository(AppDbContext context) : base(context)
        {
        }
    }
}