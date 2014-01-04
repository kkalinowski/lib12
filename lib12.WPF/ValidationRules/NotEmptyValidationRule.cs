using System.Windows.Controls;
using System.Globalization;

namespace lib12.WPF.ValidationRules
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(false, "Field cannot be empty");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
