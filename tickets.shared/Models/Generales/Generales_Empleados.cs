using System.ComponentModel.DataAnnotations;
using tickets.shared.Enums;

namespace tickets.shared.Models
{
    public class Generales_Empleados
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string UserId { get; set; } = null!;

        [Display(Name = "Sucursal")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int SucursalId { get; set; }

        [Display(Name = "Departamento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int DepartamentoId { get; set; }

        public EstadosGenerales Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Empleado")]
        public string Nombre { get; set; } = null!;

        public Generales_Departamentos? Departamento { get; set; }
        public Generales_Sucursales? Sucursal { get; set; }
        public User? Usuario { get; set; }

        public ICollection<Tickets>? Tickets { get; set; }
        public int CantidadTickets => Tickets == null ? 0 : Tickets.Count;


    }
}
