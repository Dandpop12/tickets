using System.ComponentModel.DataAnnotations;

namespace tickets.shared.Models
{
    public class Generales_Empresas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreComercial { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "RNC")]
        public string RNC { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Telefono { get; set; } = null!;

        public string? Telefono2 { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.MultilineText)]
        public string Direccion { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }

        public string? Website { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? URL_Imagen { get; set; }

        public ICollection<Generales_Sucursales>? Sucursales { get; set; }
        public int CantidadSucursales => Sucursales == null ? 0 : Sucursales.Count;

    }
}
