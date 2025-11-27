using Mapster;
using APS_Final.Domain.Entities;
using APS_Final.Domain.Repositories;
using APS_Final.Application.Interfaces;
using APS_Final.Application.ViewModels;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace APS_Final.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMarcaRepository _marcaRepository; // Necessário para carregar a lista de marcas (dropdown)

        // DI do Repositório de Modelo e Marca
        public ModeloService(IModeloRepository modeloRepository, IMarcaRepository marcaRepository) 
        {
            _modeloRepository = modeloRepository;
            _marcaRepository = marcaRepository;
        }

        // READ - Listagem Geral
        public async Task<IEnumerable<ModeloViewModel>> GetAllAsync()
        {
            // Inclui a propriedade de navegação 'Marca' para que o Mapster possa obter o 'MarcaNome'
            var modelos = await _modeloRepository.FindAsync(m => true, m => m.Marca); 
            return modelos.Adapt<IEnumerable<ModeloViewModel>>();
        }
        
        // READ - Listagem por Marca (relacionamento 1:N)
        public async Task<IEnumerable<ModeloViewModel>> GetByMarcaIdAsync(int marcaId)
        {
            var modelos = await _modeloRepository.FindAsync(m => m.MarcaId == marcaId, m => m.Marca);
            return modelos.Adapt<IEnumerable<ModeloViewModel>>();
        }

        // READ - Detalhe
        public async Task<ModeloViewModel> GetByIdAsync(int id)
        {
            var modelo = await _modeloRepository.FindAsync(m => m.Id == id, m => m.Marca);
            return modelo.FirstOrDefault().Adapt<ModeloViewModel>();
        }

        // CREATE
        public async Task CreateAsync(ModeloCreateViewModel viewModel)
        {
            var modeloEntity = viewModel.Adapt<Modelo>();
            await _modeloRepository.AddAsync(modeloEntity);
            await _modeloRepository.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateAsync(int id, ModeloCreateViewModel viewModel)
        {
            var modeloEntity = await _modeloRepository.GetByIdAsync(id);
            if (modeloEntity == null) return;

            // Mapeia as propriedades do ViewModel (Nome, Ano, MarcaId) para a Entidade
            viewModel.Adapt(modeloEntity); 
            
            _modeloRepository.Update(modeloEntity);
            await _modeloRepository.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var modeloEntity = await _modeloRepository.GetByIdAsync(id);
            if (modeloEntity == null) return;

            _modeloRepository.Remove(modeloEntity);
            await _modeloRepository.SaveChangesAsync();
        }

        // BUSCA DINÂMICA (Requisito 7)
        public async Task<IEnumerable<ModeloViewModel>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllAsync();
            }

            string q = query.ToLower();
            
            // Busca por nome do modelo OU por nome da marca (graças ao .Include)
            Expression<Func<Modelo, bool>> predicate = 
                m => m.Nome.ToLower().Contains(q) || m.Marca.Nome.ToLower().Contains(q);
            
            var modelos = await _modeloRepository.FindAsync(predicate, m => m.Marca);
            
            return modelos.Adapt<IEnumerable<ModeloViewModel>>();
        }
    }
}