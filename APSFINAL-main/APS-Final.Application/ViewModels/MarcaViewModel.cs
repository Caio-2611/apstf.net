using System.ComponentModel.DataAnnotations;

namespace APS_Final.Application.ViewModels
{
    // ViewModel para exibir a lista de marcas
    public class MarcaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TotalModelos { get; set; } // Campo extra para exibição do 1:N
    }
}