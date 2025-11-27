using System.ComponentModel.DataAnnotations;
using System;

namespace APS_Final.Application.Attributes
{
    public class AnoNaoFuturoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int ano)
            {
                // ⭐️ MUDANÇA AQUI: Remove o +1 para que o máximo seja estritamente o ano atual (2025)
                int maxAno = DateTime.Now.Year; 

                if (ano <= maxAno)
                {
                    return ValidationResult.Success;
                }
                
                // Atualiza a mensagem de erro para refletir o ano atual
                return new ValidationResult(ErrorMessage ?? $"O ano não pode ser maior que o ano atual ({maxAno}).");
            }
            return ValidationResult.Success;
        }
    }
}