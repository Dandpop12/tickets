using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tickets.shared.Enums;

namespace tickets.shared.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Clasificación")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una {0}.")]
        public int ClasificacionId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Estado")]
        public EstadosGenerales Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Cliente")]
        public string Nombre { get; set; } = null!;

        [MaxLength(20, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "RNC")]
        public string? RNC { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "The field {0} must be maximun {1} characters length")]
        [DataType(DataType.PhoneNumber)]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Notas { get; set; }

        public DateTime FechaRegistro { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? URL_Imagen { get; set; }


        public Clientes_Clasificacion? Clasificacion { get; set; }

        public ICollection<Clientes_Contactos>? Contactos { get; set; }
        public int CantidadContactos => Contactos == null ? 0 : Contactos.Count;

        public ICollection<Tickets>? Tickets { get; set; }
        public int CantidadTickets => Tickets == null ? 0 : Tickets.Count;

    }
}
