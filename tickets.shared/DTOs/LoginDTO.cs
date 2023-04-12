using System.ComponentModel.DataAnnotations;

namespace tickets.shared.DTOs
{
    public class LoginDTO
	{
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Username { get; set; } = null!;

        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        //public string Email { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener al menos {1} carácteres.")]
        public string Password { get; set; } = null!;

    }
}

