using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _12prak.ValidationRules
{
    public class passwordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //пароль, не менее 8 символов, обязательно должен включать: символы, цифры, буквы
            // в верхнем и нижнем регистре.

           
            bool simvol=false;
            bool qifr = false;
            bool bukv = false;
            bool vver = false;
            bool niz = false;

                        var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод в поле обязателен");
            }

            if (input.Length < 8)
            {
                return new ValidationResult(false, "напишите больше");
            }
            
                for (int i=0;i< input.Length;i++)
                {
                    if (char.IsDigit( input[i]))
                    { qifr = true; }
                    if (char.IsLetter(input[i]))
                        { bukv = true; }
                    if (!char.IsLetterOrDigit(input[i]))
                    { simvol = true; }
                    if (char.IsUpper(input[i]))
                    { vver = true; }
                    if (char.IsLower(input[i]))
                    { niz = true; }
                }
                if (qifr!=true|| bukv != true || simvol != true || vver != true || niz != true )
                {
                    return new ValidationResult(false, "пароль обязательно должен включать: символы, цифры, буквы в верхнем и нижнем регистре.");
                }
               
           
            






            return ValidationResult.ValidResult;
        }
    }
}
