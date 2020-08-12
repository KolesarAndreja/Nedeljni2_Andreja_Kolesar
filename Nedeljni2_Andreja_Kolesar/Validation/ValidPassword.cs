using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Nedeljni2_Andreja_Kolesar.Validation
{
    class ValidPassword : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string psw = value as string;

            if (psw.Length < 8)
            {
                return new ValidationResult(false, "must be at least 8 characters");
            }
            else
            {
                int upper = 0;
                int lower = 0;
                int number = 0;
                int special = 0;
                for(int i=0; i<psw.Length; i++)
                {
                    if(psw[i] >=48 && psw[i] <= 57)
                    {
                        number++;
                    }
                    else if(psw[i]>=65 && psw[i] < 90)
                    {
                        upper++;
                    }
                    else if(psw[i]>=97 && psw[i] < 122)
                    {
                        lower++;
                    }
                    else
                    {
                        special++;
                    }
                }
                if(upper>0 && lower>0 && special>0 && number > 0)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "must contain at least one upper, one lower, one numeric and one special char");
                }
               
            }
        }
    }
}
