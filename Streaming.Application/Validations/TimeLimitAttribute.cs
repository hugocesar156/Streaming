using Streaming.Shared;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
            Regex regex = new Regex("^\\d{1,2}:[0-5]\\d:[0-5]\\d$");

            var propertyLimit = validationContext.ObjectInstance.GetType().GetProperty(_timeLimitField)?.GetValue(validationContext.ObjectInstance)?.ToString();
            var propertyField = value?.ToString();

            if (propertyLimit is not null && regex.IsMatch(propertyLimit) && propertyField is not null && regex.IsMatch(propertyField))
            {
                int[] t1 = propertyLimit.Split(":").Select(int.Parse).ToArray();
                TimeSpan limitValue = new TimeSpan(t1[0], t1[1], t1[2]);

                int[] t2 = propertyField.Split(":").Select(int.Parse).ToArray();
                TimeSpan fieldValue = new TimeSpan(t2[0], t2[1], t2[2]);

                if (fieldValue >= limitValue)
                    return new ValidationResult(string.Format(ErrorMessages.InvalidTime, validationContext.DisplayName, _timeLimitField));
            }
 
            return ValidationResult.Success;
        }
    }
}
