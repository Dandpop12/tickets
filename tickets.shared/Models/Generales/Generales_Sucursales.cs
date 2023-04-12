using System.ComponentModel.DataAnnotations;

namespace tickets.shared.Models
{
    public class Generales_Sucursales
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Empresa")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int EmpresaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Sucursal")]
        public string Nombre { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "The field {0} must be maximun {1} characters length")]
        [DataType(DataType.PhoneNumber)]
        public string? Telefono { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        public Generales_Empresas? Empresa { get; set; }

    }
}
