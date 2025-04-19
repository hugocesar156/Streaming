using Streaming.Shared;
using System.ComponentModel.DataAnnotations;

namespace Streaming.Application.Validations
{
    public class StringLengthAttribute : ValidationAttribute
    {
        private readonly short _stringLength;
        
        public StringLengthAttribute(short stringLength)
        {
            _stringLength = stringLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if ((value?.ToString()?.Length ?? 0) > _stringLength)
                return new ValidationResult(string.Format(ErrorMessages.StringLength, validationContext.DisplayName, _stringLength));

            return ValidationResult.Success;
        }
    }
}
