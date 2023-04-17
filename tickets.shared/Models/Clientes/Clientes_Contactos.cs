using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tickets.shared.Enums;

namespace tickets.shared.Models
{
    public class Clientes_Contactos
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Estado")]
        public EstadosGenerales Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = null!;

        [Display(Name = "Departamento")]
        public string? Departamento { get; set; }

        [Display(Name = "Cargo")]
        public string? Cargo { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} must be maximun {1} characters length")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }

        [MaxLength(20, ErrorMessage = "The field {0} must be maximun {1} characters length")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Flota")]
        public string? Flota { get; set; }

        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Notas { get; set; }

        public string FullName => $"{Nombre} {Apellido}";
        public string FullNameWithPhone => $"{Nombre} {Apellido} - Teléfono: {Telefono}";


        public Clientes? Cliente { get; set; }
        public ICollection<Tickets>? Tickets { get; set; }
        public int CantidadTickets => Tickets == null ? 0 : Tickets.Count;


    }
}
