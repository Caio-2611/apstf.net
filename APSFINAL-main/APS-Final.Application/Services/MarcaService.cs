using Mapster;
using APS_Final.Domain.Entities;
using APS_Final.Domain.Repositories;
using APS_Final.Application.Interfaces;
using APS_Final.Application.ViewModels;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore; // Para usar .Include

namespace APS_Final.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository) // DI do Repositório
        {
            _marcaRepository = marcaRepository;
        }

        // READ - Listagem
        public async Task<IEnumerable<MarcaViewModel>> GetAllAsync()
        {
            // O Include é importante para carregar a coleção de Modelos (Lazy Loading)
            var marcas = await _marcaRepository.FindAsync(m => true, m => m.Modelos); 
            // Usa Mapster para mapear Entidade -> ViewModel
            return marcas.Adapt<IEnumerable<MarcaViewModel>>();
        }
        
        // READ - Detalhe
        public async Task<MarcaViewModel> GetByIdAsync(int id)
        {
            var marca = await _marcaRepository.FindAsync(m => m.Id == id, m => m.Modelos);
            return marca.FirstOrDefault().Adapt<MarcaViewModel>();
        }

        // CREATE
        public async Task CreateAsync(MarcaCreateViewModel viewModel)
        {
            // Usa Mapster para mapear ViewModel -> Entidade
            var marcaEntity = viewModel.Adapt<Marca>();
            await _marcaRepository.AddAsync(marcaEntity);
            await _marcaRepository.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateAsync(int id, MarcaCreateViewModel viewModel)
        {
            var marcaEntity = await _marcaRepository.GetByIdAsync(id);
            if (marcaEntity == null) return; // Ou lançar exceção

            // Atualiza apenas as propriedades do ViewModel na Entidade
            viewModel.Adapt(marcaEntity); 
            
            _marcaRepository.Update(marcaEntity);
            await _marcaRepository.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var marcaEntity = await _marcaRepository.GetByIdAsync(id);
            if (marcaEntity == null) return; 

            _marcaRepository.Remove(marcaEntity);
            await _marcaRepository.SaveChangesAsync();
        }

        // BUSCA DINÂMICA (Requisito 7)
        public async Task<IEnumerable<MarcaViewModel>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllAsync();
            }

            string q = query.ToLower();
            
            // Busca no repositório por parte do nome
            var marcas = await _marcaRepository.FindAsync(
                m => m.Nome.ToLower().Contains(q), 
                m => m.Modelos // Inclui Modelos para calcular o total
            );
            
            return marcas.Adapt<IEnumerable<MarcaViewModel>>();
        }
    }
}