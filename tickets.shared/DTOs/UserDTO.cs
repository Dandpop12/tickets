using System.ComponentModel.DataAnnotations;
using tickets.shared.Models;

namespace tickets.shared.DTOs
{
    public class UserDTO : User
	{
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación no son iguales.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener entre {2} y {1} carácteres.")]
        [Display(Name = "Confirmación de contraseña")]
        public string PasswordConfirm { get; set; } = null!;

    }
}