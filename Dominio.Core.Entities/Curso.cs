using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Curso
    {
        [DisplayName("Código del Curso")]
        public int codigo { get; set; }
        [DisplayName("Nombre del Curso")]
        [Required(ErrorMessage = "Nombre del curso es requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "No más de 30 caracteres")]
        public string nombre { get; set; }
        [DisplayName("Correo del Curso")]
        [Required(ErrorMessage = "Correo del curso es requerido")]
        [StringLength(50, ErrorMessage = "No más de 50 caracteres")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string correo { get; set; }
        [DisplayName("Créditos del Curso")]
        [Required(ErrorMessage = "Número de créditos del curso es requerido")]
        [Range(1, 6)]
        public int credito { get; set; }
    }
}
