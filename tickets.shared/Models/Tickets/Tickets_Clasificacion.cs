using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tickets.shared.Enums;

namespace tickets.shared.Models
{
    public class Tickets_Clasificacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Estado")]
        public EstadosGenerales Estado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Clasificación")]
        public string Descripcion { get; set; } = null!;

        public ICollection<Tickets>? Tickets { get; set; }
        public int CantidadTickets => Tickets == null ? 0 : Tickets.Count;

    }
}
