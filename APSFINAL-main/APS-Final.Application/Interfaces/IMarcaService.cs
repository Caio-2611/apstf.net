using APS_Final.Application.ViewModels;

namespace APS_Final.Application.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaViewModel>> GetAllAsync();
        Task<MarcaViewModel> GetByIdAsync(int id);
        Task CreateAsync(MarcaCreateViewModel viewModel);
        Task UpdateAsync(int id, MarcaCreateViewModel viewModel);
        Task DeleteAsync(int id);
        
        // Para a busca com AJAX (futuro)
        Task<IEnumerable<MarcaViewModel>> SearchAsync(string query); 
    }
}