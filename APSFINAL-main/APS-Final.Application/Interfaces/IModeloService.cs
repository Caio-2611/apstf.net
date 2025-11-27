using APS_Final.Application.ViewModels;

namespace APS_Final.Application.Interfaces
{
    public interface IModeloService
    {
        Task<IEnumerable<ModeloViewModel>> GetAllAsync();
        Task<ModeloViewModel> GetByIdAsync(int id);
        Task CreateAsync(ModeloCreateViewModel viewModel);
        Task UpdateAsync(int id, ModeloCreateViewModel viewModel);
        Task DeleteAsync(int id);
        
        // Método para obter modelos de uma marca específica
        Task<IEnumerable<ModeloViewModel>> GetByMarcaIdAsync(int marcaId);
        
        // Para a busca com AJAX (futuro)
        Task<IEnumerable<ModeloViewModel>> SearchAsync(string query);
    }
}