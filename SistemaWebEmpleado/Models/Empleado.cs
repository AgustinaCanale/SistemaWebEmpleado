using System.ComponentModel.DataAnnotations;
using System;
using SistemaWebEmpleado.Validations;

namespace SistemaWebEmpleado.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string DNI { get; set; }
        [Required]
        [RegularExpression(@"^[A]{2}[0-9]{5}")]
        public string Legajo { get; set; }
        [AñoAttribute]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Titulo { get; set; }
    }
}
