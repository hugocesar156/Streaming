using Streaming.Shared;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Streaming.Application.Validations
{
    public class TimeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Regex regex = new Regex("^\\d{1,2}:[0-5]\\d:[0-5]\\d$");

            var valueField = value?.ToString();

            if (!string.IsNullOrEmpty(valueField) && !regex.IsMatch(valueField))
                return new ValidationResult(string.Format(ErrorMessages.InvalidTimeFormat, validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}
