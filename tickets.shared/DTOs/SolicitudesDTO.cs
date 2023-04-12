using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tickets.shared.DTOs
{
    public class SolicitudesDTO
    {
        public int ID_SOLICITUD { get; set; }
        public string IDENSOLI { get; set; }
        public string ESTADO { get; set; }
        public string SUCURSAL { get; set; }
        public string OFICIAL { get; set; }
        public int ID_OFICIAL { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string GENERO { get; set; }
        public string TIPO_EMPLEO { get; set; }
        public string PUBLICIDAD { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public DateTime FECHA_SOLICITUD { get; set; }
        public DateTime FECHA_MODIFICACION_SOLICITUD { get; set; }
        public DateTime FECHA_CORTA { get; set; }
        public TimeSpan HORA { get; set; }
        public string NOMBRE_SOCIO { get; set; }
        public string APELLIDOO_SOCIO { get; set; }
        public string SOCIO_NOMBRE_COMPLETO { get; set; }
        public string DOCUMENTO_SOCIO { get; set; }
        public DateTime FECHA_NAC_SOCIO { get; set; }
        public string TELEFONO_SOCIO { get; set; }
        public string CELULAR_SOCIO { get; set; }
        public string EMAIL_SOCIO { get; set; }
        public string NACIONALIDAD { get; set; }
        public string DIRECCION_SOCIO { get; set; }
        public string REFERENCIA_DIRE_SOCIO { get; set; }
        public string REF_FAM_NOMBRE { get; set; }
        public string REF_FAM_TELEFONO { get; set; }
        public string REF_FAM_DIRECCION { get; set; }
        public string REF_PER_NOMBRE { get; set; }
        public string REF_PER_TELEFONO { get; set; }
        public string REF_PER_DIRECCION { get; set; }
        public string TRABAJO_SOCIO { get; set; }
        public int? ANO_TRABAJO_SOCIO { get; set; }
        public int? MESES_TRABAJO_SOCIO { get; set; }
        public string TEL_TRABAJO_SOCIO { get; set; }
        public decimal? INGRESOSMENSUALES { get; set; }
        public decimal? HONORARIOS { get; set; }
        public decimal? COMISIONES { get; set; }
        public decimal? OTROSINGRESOS { get; set; }
        public decimal? RENTA { get; set; }
        public decimal? OTROSGASTOS { get; set; }
        public decimal? MONTOPRESTAMO { get; set; }
        public int? TERMINOPRESTAMO { get; set; }
        public string PROPOSITOPRESTAMO { get; set; }
        public string NOTAS { get; set; }
        public bool SOCIO { get; set; }
        public bool PRODUCTOS { get; set; }
        public string USUARIOMODIFICACION { get; set; }
        public string USUARIORECHAZA { get; set; }
        public string USUARIOACEPTA { get; set; }
        public string USUARIOPROCESA { get; set; }
        public bool TERMINOSCOND { get; set; }
        public string IDEN_EMPRESA { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public string NOMBRECOM_EMPRESA { get; set; }
        public string RNC { get; set; }
        public string TELEFONO_EMP { get; set; }
        public string DIRECCION_EMP { get; set; }
        public string CORREO_EMP { get; set; }
        public string WEB_EMPRESA { get; set; }
        public string URL_IMG_EMP { get; set; }
        public byte[] IMAGEN_EMP { get; set; }
        public decimal? GASTOS_ALIMENTACION { get; set; }
        public decimal? GASTOS_SERVICIOS { get; set; }
        public decimal? GASTOS_PRESTAMOS { get; set; }
        public decimal? GASTOS_COMBUSTIBLE { get; set; }
        public string IP_CLIENTE { get; set; }
        public string RAZON_RECHAZO { get; set; }
    }
}
