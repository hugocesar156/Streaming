using Streaming.Shared;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Application.Validations
{
    public class TimeLimitAttribute : ValidationAttribute
    {
        private readonly string _timeLimitField;

        public TimeLimitAttribute(string timeLimitField)
        {
            _timeLimitField = timeLimitField;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var timeLimit = short.Parse(validationContext.ObjectInstance.GetType().GetProperty(_timeLimitField)?.GetValue(validationContext.ObjectInstance)?.ToString() ?? "0");
            var timeField = short.Parse(value?.ToString() ?? "0");

            if (timeLimit > 0 && timeField > 0 && timeLimit <= timeField)
            {
                return new ValidationResult(string.Format(ErrorMessages.InvalidTime, validationContext.DisplayName, _timeLimitField));
            }
                
            return ValidationResult.Success;
        }
    }
}
