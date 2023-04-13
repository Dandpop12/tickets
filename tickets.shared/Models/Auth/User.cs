using tickets.shared.DTOs;
using tickets.shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace tickets.shared.Models
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Estado")]
        public EstadosGenerales Estado { get; set; }

        [Display(Name = "Imagen")]
        public string? URL_Imagen { get; set; }

        public UserType UserType { get; set; }

        public List<RolesDTO>? Roles { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Tickets>? Tickets { get; set; }
        public int CantidadTickets => Tickets == null ? 0 : Tickets.Count;

        public ICollection<Generales_Empleados>? Empleados { get; set; }
        public int CantidadEmpleados => Empleados == null ? 0 : Empleados.Count;

    }

}
