using APS_Final.Domain.Entities;

namespace APS_Final.Domain.Repositories
{
    public interface IMarcaRepository : IGenericRepository<Marca>
    {
        // Por enquanto, não adicionamos métodos específicos,
        // mas eles seriam adicionados aqui se a Marca precisasse de lógica de acesso a dados única.
    }
}