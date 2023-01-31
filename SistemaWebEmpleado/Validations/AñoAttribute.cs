using System.ComponentModel.DataAnnotations;
using System;

namespace SistemaWebEmpleado.Validations
{
    public class AñoAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            if (Convert.ToDateTime(value) < new DateTime(2000, 01, 01))
            {
                return new ValidationResult("Solo se aceptan años del 2000 en adelante!");
            }

            return ValidationResult.Success;
        }
    }
}


