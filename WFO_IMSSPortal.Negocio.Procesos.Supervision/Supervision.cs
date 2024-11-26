using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Procesos.Supervision
{
    /// <summary>
    /// Procesos de Negocio de Supervisión
    /// </summary>
    public class Supervision
    {
        /// <summary>
        /// Acceso a métodos de negocio de buscar tramites
        /// </summary>
        public BuscarTramites buscartramites;
        /// <summary>
        /// Acceso a métodos de negocio de default
        /// </summary>
        public Default default_;
        /// <summary>
        /// Acceso a métodos de negocio de detalle horas
        /// </summary>
        public DetalleHoras detallehoras;
        /// <summary>
        /// Acceso a métodos de negocio de detalle promotoria
        /// </summary>
        public DetallePromotoria detallepromotoria;
        /// <summary>
        /// Acceso a métodos de negocio de mapa supervisor
        /// </summary>
        public MapaSupervisor mapasupervisor;
        /// <summary>
        /// Acceso a métodos de negocio de reloj checador
        /// </summary>
        public RelojChecador relojchecador;
        /// <summary>
        /// Acceso a métodos de negocio de reportes caducados
        /// </summary>
        public ReporteCaducados reportecaducados;
        /// <summary>
        /// Acceso a métodos de negocio de reporte estatus tramite
        /// </summary>
        public ReporteEstatusTramite reporteestatustramite;
        /// <summary>
        /// Acceso a métodos de negocio de reporte general franja
        /// </summary>
        public ReporteGeneralFranja reportegeneralfranja;
        /// <summary>
        /// Acceso a métodos de negocio de reporte general mesa
        /// </summary>
        public ReporteGeneralMesa reportegeneralmesa;
        /// <summary>
        /// Acceso a métodos de negocio de reporte general top 10
        /// </summary>
        public ReporteGeneralTop10 reportegeneraltop10;
        /// <summary>
        /// Acceso a métodos de negocio de reporte general totales
        /// </summary>
        public ReporteGeneralTotales reportegeneraltotales;
        /// <summary>
        /// Acceso a métodos de negocio de reporte por ciento suspension
        /// </summary>
        public ReportePorcientoSuspension reporteporcientosuspension;
        /// <summary>
        /// Acceso a métodos de negocio de reporte productividad
        /// </summary>
        public ReporteProductividad reporteproductividad;
        /// <summary>
        /// Acceso a métodos de negocio de reporte sel procesado
        /// </summary>
        public ReporteSelProcesado reporteselprocesado;
        /// <summary>
        /// Acceso a métodos de negocio de sabana
        /// </summary>
        public Sabana sabana;
        /// <summary>
        /// Acceso a métodos de negocio de status tramite
        /// </summary>
        public StatusTramite statustramite;
        /// <summary>
        /// Acceso a métodos de negocio de TAT
        /// </summary>
        public TAT tat;
        /// <summary>
        /// Acceso a métodos de negocio de tiempos atencion
        /// </summary>
        public TiemposAtencion tiemposatencion;
        /// <summary>
        /// Acceso a métodos de negocio de total tramite estatus
        /// </summary>
        public TotalTramiteEstatus totaltramiteestatus;
        /// <summary>
        /// Acceso a métodos de negocio de tramites fecha movimiento
        /// </summary>
        public TramitesFechaMov tramitesfechamov;
        /// <summary>
        /// Acceso a métodos de negocio de tramites por mesa
        /// </summary>
        public TramitesPorMesa tramitespormesa;

        public Supervision()
        {
            buscartramites = new BuscarTramites();
            default_ = new Default();
            detallehoras = new DetalleHoras();
            detallepromotoria = new DetallePromotoria();
            mapasupervisor = new MapaSupervisor();
            relojchecador = new RelojChecador();
            reportecaducados = new ReporteCaducados();
            reporteestatustramite = new ReporteEstatusTramite();
            reportegeneralfranja = new ReporteGeneralFranja();
            reportegeneralmesa = new ReporteGeneralMesa();
            reportegeneraltop10 = new ReporteGeneralTop10();
            reportegeneraltotales = new ReporteGeneralTotales();
            reporteporcientosuspension = new ReportePorcientoSuspension();
            reporteproductividad = new ReporteProductividad();
            reporteselprocesado = new ReporteSelProcesado();
            sabana = new Sabana();
            statustramite = new StatusTramite();
            tat = new TAT();
            tiemposatencion = new TiemposAtencion();
            totaltramiteestatus = new TotalTramiteEstatus();
            tramitesfechamov = new TramitesFechaMov();
            tramitespormesa = new TramitesPorMesa();
        }
    }
}
