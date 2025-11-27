using System.ComponentModel.DataAnnotations;

namespace APS_Final.Application.Attributes
{
    // Validação Personalizada 1: Garante que o nome comece com letra maiúscula.
    public class NomeProprioAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string nome && !string.IsNullOrEmpty(nome))
            {
                if (char.IsUpper(nome[0]))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage ?? "O campo deve começar com uma letra maiúscula.");
            }
            return ValidationResult.Success; // Não valida se o campo for nulo/vazio (o [Required] cuida disso)
        }
    }
}