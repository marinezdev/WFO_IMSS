using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Operacion
{

	public class TramitesDetalle
	{
		public int IdTramte { get; set; }
		public DateTime FechaRegitro { get; set; }
		public string Poliza { get; set; }
		public string Quincena { get; set; }
		public string TipoNomina { get; set; }
		public string TipoMovimimento { get; set; }
		public string statusMesa { get; set; }
	}

	public class ListaDeTramites
	{
		public List<TramitesDetalle> Tramites { get; set; }
	}

	public class Tramites_SLA
	{
		public int SLA
		{
			get;
			set;
		}

		public int Tramites_Total
		{
			get;
			set;
		}

		public int Tramites_xDia
		{
			get;
			set;
		}

		public int Tramites_Procesados
		{
			get;
			set;
		}

		public int Tramites_Pedientes
		{
			get;
			set;
		}

		public string Periodo
		{
			get;
			set;
		}
	}

	public class CalendarioOperacion
	{
		public int Id { get; set; }

		public string Quincena
		{
			get;
			set;
		}

		public string TipoNomina
		{
			get;
			set;
		}

		public DateTime Fecha_Concentrado
		{
			get;
			set;
		}

		public DateTime Fecha_LimiteCartas
		{
			get;
			set;
		}

		public DateTime Fecha_InciaCaptura
		{
			get;
			set;
		}

		public DateTime Fecha_TerminaCaptura
		{
			get;
			set;
		}

		public DateTime Fecha_InciaInteractivo
		{
			get;
			set;
		}

		public DateTime Fecha_TerminaInteractivo
		{
			get;
			set;
		}

		public DateTime Fecha_RptEfectividad
		{
			get;
			set;
		}
	}

	public class TramitesProcesados
    {
        public DateTime Fecha { get; set; }
        public int TramitesIngresados { get; set; }
        public int TramitesRevision { get; set; }
        public int TramitesControl { get; set; }
        public int TramitesPortal { get; set; }
        public int TramitesInteractivo { get; set; }
    }

    public class Pendientes
    {
        public int IdTramite { get; set; }
        public int IdMesa { get; set; }
        public int IdStatusMesa { get; set; }
        public int IdStatusTramite { get; set; }
        public string FolioCompuesto { get; set; }
        public string Operacion { get; set; }

        //Nuevo
        public string Poliza { get; set; }
        public string TipoNomina { get; set; }
        public string TipoMovimiento { get; set; }
        public string UnidadPago { get; set; }
        public string Quincena { get; set; }
        public string Importe { get; set; }
        //*******

        public string Contratante { get; set; }
        public string RFC { get; set; }
        public string Titular { get; set; }

        public string NombreMesa { get; set; }
        public string EstatusMesa { get; set; }
        public string EstatusTramite { get; set; }
        public string FechaRegistro { get; set; }
    }
}
