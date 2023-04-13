using System.ComponentModel.DataAnnotations;

namespace tickets.shared.Models
{
    public class Generales_Departamentos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Departamento")]
        public string Descripcion { get; set; } = null!;

        public ICollection<Generales_Empleados>? Empleados { get; set; }
        public int CantidadEmpleados => Empleados == null ? 0 : Empleados.Count;

    }
}
