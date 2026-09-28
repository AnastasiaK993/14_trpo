using _12prak.Data;
using _12prak.Service;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _12prak.ValidationRules
{
    public class loginValidationRule : ValidationRule
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public int ExcludedId { get; set; } = 0;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //логин пользователя должен состоять минимум из 5 символов, быть уникальным и
            //независимым от регистра

            var input = (value ?? "").ToString().Trim();
            if (input == string.Empty)
            {
                return new ValidationResult(false, "Ввод в поле обязателен");
            }

            if (input.Length < 5)
            {
                return new ValidationResult(false, "напишите больше");
            }
            if (input.Length == 5)
            {
                string lol = input.ToLower();

                return new ValidationResult(false, "вообще классно");
            }
            
            bool isUnique = _db.Students.Any(x => x.Login == input && x.Id != ExcludedId);
            if (isUnique == true)
            {
                return new ValidationResult(false, "не уникально"); ;
            }

            return ValidationResult.ValidResult;
        }
    }
}