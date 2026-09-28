using _12prak.Data;
using _12prak.Service;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace _12prak.ValidationRules
{
    public class emailValidationRule : ValidationRule
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

      
        public int ExcludedId { get; set; } = 0;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //адрес электронной почты должен проверяться на наличие знака @ и быть
            //уникальным

            bool simvol = false;

            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод в поле обязателен");
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '@')
                { simvol = true; }
            }
            if (simvol != true)
            {
                return new ValidationResult(false, "нет @");
            }

            bool isUnique = _db.Students.Any(x => x.Email == input && x.Id != ExcludedId);
            if (isUnique == true)
            {
                return new ValidationResult(false, "не уникально"); ;
            }

            return ValidationResult.ValidResult;
        }
    }
}