// APS-Final.Application/ViewModels/MarcaCreateViewModel.cs
using System.ComponentModel.DataAnnotations;
using APS_Final.Application.Attributes;

namespace APS_Final.Application.ViewModels
{
    public class MarcaCreateViewModel
    {
        // ⭐️ Adicione esta propriedade:
        public int Id { get; set; } 

        [Required(ErrorMessage = "O nome da marca é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 50 caracteres.")]
        [NomeProprio(ErrorMessage = "O nome deve começar com letra maiúscula.")]
        public string Nome { get; set; }
    }
}