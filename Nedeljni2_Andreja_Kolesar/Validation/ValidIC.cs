using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nedeljni2_Andreja_Kolesar.Validation
{
    class ValidIC : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;

            if (Service.Service.UsedNumber(number))
            {
                return new ValidationResult(false, "This ICnumber is already taken");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
