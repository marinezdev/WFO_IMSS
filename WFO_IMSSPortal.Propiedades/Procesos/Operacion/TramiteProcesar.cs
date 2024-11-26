using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Operacion
{
    public class TramiteProcesado
    {
        public int IdTramite { get; set; }
        public string Accion { get; set; }
    }

    public class TramiteProcesar
    {
        public int IdTramite { get; set; }
        public string Folio { get; set; }
        public int IdTipoTramite { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaTermino { get; set; }
        public int IdStatus { get; set; }
        public string StatusTramite { get; set; }
        public int IdPromotoria { get; set; }
        public string Promotoria { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int idPrioridad { get; set; }
        public string Prioridad { get; set; }

        public string ArchivoNombre { get; set; }
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
        public string StatusConcentrado { get; set; }
    }
}