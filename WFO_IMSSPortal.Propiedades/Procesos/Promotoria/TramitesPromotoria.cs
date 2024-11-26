using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Promotoria
{
    public class TramitesPromotoria
    {
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FolioCompuesto { get; set; }
        public string Operacion { get; set; }
        public string Estatus { get; set; }
        public string Poliza { get; set; }
        public string TipoNomina { get; set; }
        public string TipoMovimiento { get; set; }
        public string UnidadPago { get; set; }
        public string Quincena { get; set; }
        public string Importe { get; set; }
        public string Matricula { get; set; }
        public string Usr_Servicio { get; set; }
        public string Nombre_Trabajador { get; set; }
        public string Prom_Origen { get; set; }
        public string Prom_Respon { get; set; }
        public string Prom_U_Serv { get; set; }
        public byte[] Archivo { get; set; }
        public string ArchivoNombre { get; set; }
    }
}
