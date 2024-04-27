using System.ComponentModel.DataAnnotations;

namespace dulce_sabor_modulo_venta_en_linea.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Es necesario ingresar un número de {0}")]
        [DataType(DataType.PhoneNumber)]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Tiene que crear una {0}")]
        [DataType(DataType.Password)]
        public string contraseña { get; set; }

        [Display(Name = "Recuérdame")]
        public bool Recuerdame { get; set; }
    }
}
