using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AccessSystem.Validators
{
    public class ValidateCode : ValidationRule
    {
        private readonly int _min = 0;
        private readonly int _max = 99999;
        public int newValue;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                newValue = int.Parse((string)value);
            }
            catch (Exception)
            {
                newValue = 0;
                return GetErrorValidation("Ошибка. Код должен быть числом.");
            }

            if (newValue < _min)
            {
                newValue = 0;
                return GetErrorValidation("Ошибка. Код должен быть больше 0.");
            }
            else if (newValue > _max)
            {
                newValue = _max;
                return GetErrorValidation("Ошибка. Код должен быть меньше 99999.");
            }

            return new ValidationResult(true, null);
        }

        private ValidationResult GetErrorValidation(string message)
        {
            return new ValidationResult(false, message);
        }

    }
}
