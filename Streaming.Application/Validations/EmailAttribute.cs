using Streaming.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Streaming.Application.Validations
{
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(value?.ToString()))
            {
                try
                {
                    new MailAddress(value.ToString() ?? string.Empty);   
                }
                catch
                {
                    return new ValidationResult(ErrorMessages.InvalidEmailAddres);
                }
            }

            return ValidationResult.Success;
        }
    }
}
