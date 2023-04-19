using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using tickets.shared.Enums;

namespace tickets.shared.Models
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Estado")]
        public EstadosTickets Estado { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Prioridad")]
        public Prioridades Prioridad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Clasificación")]
        public int ClasificacionId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Contacto")]
        public int ContactoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Empleado Asignado")]
        public int EmpleadoId { get; set; }

        [Display(Name = "Usuario Registro")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.MultilineText)]
        public string Notas { get; set; } = null!;

        public DateTime FechaRegistro { get; set; }
        public TimeSpan Hora { get; set; }

        public DateTime? FechaAsignada { get; set; } = null;

        public DateTime? FechaEntrega { get; set; } = null;
        public TimeSpan? HoraEntrega { get; set; } = null;


        public string? NotasArchivado { get; set; }
        public DateTime? FechaArchivado { get; set; } = null;

        public string DiasEspera
        {
            get
            {
                if (Estado.ToString() != "Entregado")
                {
                    var resultado = DateTime.Now - FechaRegistro;

                    if (resultado.Days > 0)
                    {
                        return $"{resultado.Days}d";
                    }

                    return "";
                }

                var result = Convert.ToDateTime(FechaEntrega) - FechaRegistro;

                if (result.Days > 0)
                {
                    return $"{result.Days}d";
                }

                return "";
            }
        }

        public string HorasEspera
        {
            get
            {
                if (Estado.ToString() != "Entregado")
                {
                    var resultado = DateTime.Now - FechaRegistro;

                    if (resultado.Hours > 0)
                    {
                        return $"{resultado.Hours}h";
                    }

                    return "";
                }

                var result = Convert.ToDateTime(FechaEntrega) - FechaRegistro;
                if (result.Hours > 0)
                {
                    return $"{result.Hours}h";
                }

                return "";

            }
        }

        public string MinutosEspera
        {
            get
            {
                if (Estado.ToString() != "Entregado")
                {
                    var resultado = DateTime.Now - FechaRegistro;
                    if (resultado.Minutes > 0)
                    {
                        return $"{resultado.Minutes}m";
                    }

                    return "";
                }

                var result = Convert.ToDateTime(FechaEntrega) - FechaRegistro;
                if (result.Minutes > 0)
                {
                    return $"{result.Minutes}m";
                }

                return "";
            }
        }

        public string SegundosEspera
        {
            get
            {
                if (Estado.ToString() != "Entregado")
                {
                    var resultado = DateTime.Now - FechaRegistro;
                    if (resultado.Seconds > 0)
                    {
                        return $"{resultado.Seconds} - Segundos";
                    }

                    return "";
                }

                var result = Convert.ToDateTime(FechaEntrega) - FechaRegistro;
                if (result.Seconds > 0)
                {
                    return $"{result.Seconds} - Segundos";
                }

                return "";
            }
        }

        public string TiempoEspera
        {
            get
            {
                var res = $"{DiasEspera} {HorasEspera} {MinutosEspera}";

                if (String.IsNullOrEmpty(DiasEspera)
                    && String.IsNullOrEmpty(HorasEspera)
                    && String.IsNullOrEmpty(MinutosEspera))
                {
                    return SegundosEspera;
                }

                return res;
            }
        }



        public Tickets_Clasificacion? Clasificacion { get; set; }

        public Clientes? Cliente { get; set; }

        public Clientes_Contactos? Contacto { get; set; }

        public Generales_Empleados? Empleado { get; set; }

        public User? User { get; set; }


    }
}
