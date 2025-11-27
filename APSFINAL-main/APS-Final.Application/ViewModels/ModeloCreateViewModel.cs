using System.ComponentModel.DataAnnotations;
using APS_Final.Application.Attributes;

namespace APS_Final.Application.ViewModels
{
    public class ModeloCreateViewModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "O nome do modelo é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 50 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O ano é obrigatório.")]
        [Range(1900, 2099, ErrorMessage = "O ano deve ser válido.")]
        // Exemplo de uso da outra validação personalizada (A ser criada no passo 5.4)
        [AnoNaoFuturo(ErrorMessage = "O ano não pode ser no futuro.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Selecione uma marca.")]
        public int MarcaId { get; set; }
    }
}