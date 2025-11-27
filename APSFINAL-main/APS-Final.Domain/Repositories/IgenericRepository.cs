using System.Linq.Expressions;

namespace APS_Final.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // CRUD Básico
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);

        // Funcionalidade de Busca/Filtro (para o AJAX)
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        
        // Salvar mudanças na unidade de trabalho (o DbContext)
        Task<int> SaveChangesAsync();
    }
}