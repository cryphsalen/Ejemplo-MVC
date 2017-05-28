using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Usuario
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Usuario Requerido")]
        public string nombre { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string clave { get; set; }

        [DisplayName("Nombre")]
        public string nombre_Usuario { get; set; }
    }
}
