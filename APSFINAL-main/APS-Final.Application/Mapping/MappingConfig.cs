using Mapster;
using APS_Final.Domain.Entities;
using APS_Final.Application.ViewModels;

namespace APS_Final.Application.Mapping
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            // Mapeamento Padrão (Entidade -> ViewModel)
            TypeAdapterConfig<Marca, MarcaViewModel>.NewConfig()
                // Mapeamento customizado para o campo "TotalModelos"
                .Map(dest => dest.TotalModelos, src => src.Modelos.Count);

            // Mapeamento customizado para a ViewModel de Modelo
            TypeAdapterConfig<Modelo, ModeloViewModel>.NewConfig()
                .Map(dest => dest.MarcaNome, src => src.Marca.Nome);
            
            // Mapeamento de Criação/Edição (ViewModel -> Entidade)
            TypeAdapterConfig<MarcaCreateViewModel, Marca>.NewConfig();
            TypeAdapterConfig<ModeloCreateViewModel, Modelo>.NewConfig();
        }
    }
}