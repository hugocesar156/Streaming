using Streaming.Shared;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Application.Validations
{
    public class RequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
                return new ValidationResult(string.Format(ErrorMessages.FieldRequired, validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}
