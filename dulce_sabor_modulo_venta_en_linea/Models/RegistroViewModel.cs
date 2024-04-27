using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace dulce_sabor_modulo_venta_en_linea.Models
{
    public class RegistroViewModel
    {
        [Required (ErrorMessage ="El campo {0} es necesario")]
        public string nombre { get; set; }

        [Required(ErrorMessage ="El campo {0} es necesario")]
        public string apellido { get; set; }

        [Required(ErrorMessage ="Es necesario que ingrese su {0}")]
        public string direccion { get; set; }

        [Required(ErrorMessage ="Es necesario ingresar un número de {0}")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }

        [Required(ErrorMessage ="Tiene que crear una {0}")]
        [DataType(DataType.Password)]
        public string  contraseña { get; set; }
    }
}
