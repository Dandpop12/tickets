using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tickets.shared.Enums;

namespace tickets.shared.Models
{
    public class Clientes_Clasificacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        [Display(Name = "Clasificación")]
        public string Descripcion { get; set; } = null!;

        public string? Color { get; set; }

        public ICollection<Clientes>? Clientes { get; set; }
        public int CantidadClientes => Clientes == null ? 0 : Clientes.Count;

    }
}
