﻿using System.Globalization;
using System.Windows.Controls;

namespace Nedeljni2_Andreja_Kolesar.Validation
{
    class ValidAccount : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string number = value as string;

            if (Service.Service.UsedAccount(number))
            {
                return new ValidationResult(false, "This account is already taken");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
