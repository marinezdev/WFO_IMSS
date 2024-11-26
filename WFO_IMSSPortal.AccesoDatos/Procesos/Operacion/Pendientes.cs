using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Operacion
{
    public class Pendientes
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.TramitesProcesados> TramitesProcesados(DateTime FechaI, DateTime FechaF)
        {
            b.ExecuteCommandSP("Tramites_Procesados");
            b.AddParameter("@FECHAINICIO", FechaI, SqlDbType.DateTime);
            b.AddParameter("@FECHATERMINO", FechaF, SqlDbType.DateTime);
            List<prop.TramitesProcesados> resultado = new List<prop.TramitesProcesados>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesProcesados item = new prop.TramitesProcesados()
                {
                    Fecha = Funciones.Fechas.TextoAFecha(reader["FECHA"].ToString()),
                    TramitesIngresados = Funciones.Nums.TextoAEntero(reader["INGRESOS"].ToString()),
                    TramitesRevision = Funciones.Nums.TextoAEntero(reader["MESA_REVISION"].ToString()),
                    TramitesControl = Funciones.Nums.TextoAEntero(reader["MESA_CONTROL"].ToString()),
                    TramitesPortal = Funciones.Nums.TextoAEntero(reader["MESA_PORTAL"].ToString()),
                    TramitesInteractivo = Funciones.Nums.TextoAEntero(reader["MESA_INTERACTIVO"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<TramitesDetalle> TramitesSLADetalle(int Dia, string rangoFecha, string Quincena, string TipoNomina)
        {
            this.b.ExecuteCommandSP("Tramites_SLADetalle");
            this.b.AddParameter("@QUINCENA", Quincena, SqlDbType.NChar);
            this.b.AddParameter("@TIPONOMINA", TipoNomina, SqlDbType.NChar);
            this.b.AddParameter("@DIA", Dia, SqlDbType.Int);
            this.b.AddParameter("@RANGOFECHA", rangoFecha, SqlDbType.NVarChar);
            List<TramitesDetalle> resultado = new List<TramitesDetalle>();
            var reader = this.b.ExecuteReader();
            while (reader.Read())
            {
                TramitesDetalle item = new TramitesDetalle
                {
                    IdTramte = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString()),
                    FechaRegitro = Funciones.Fechas.TextoAFecha(reader["FechaRegistro"].ToString()),
                    Poliza = reader["Poliza"].ToString(),
                    Quincena = reader["Quincena"].ToString(),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimimento = reader["TipoMovimiento"].ToString(),
                    statusMesa = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            this.b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Tramites_SLA> TramitesSLA(string Quincena, string TipoNomina)
        {
            this.b.ExecuteCommandSP("Tramites_SLA");
            this.b.AddParameter("@QUINCENA", Quincena, SqlDbType.NChar);
            this.b.AddParameter("@TIPONOMINA", TipoNomina, SqlDbType.NChar);
            List<Tramites_SLA> resultado = new List<Tramites_SLA>();
            var reader = this.b.ExecuteReader();
            while (reader.Read())
            {
                Tramites_SLA item = new Tramites_SLA
                {
                    SLA = Funciones.Nums.TextoAEntero(reader["SLA"].ToString()),
                    Tramites_Total = Funciones.Nums.TextoAEntero(reader["TOTAL_TRAMITESQUINCENA"].ToString()),
                    Tramites_xDia = Funciones.Nums.TextoAEntero(reader["TRAMITES_xDIA"].ToString()),
                    Tramites_Procesados = Funciones.Nums.TextoAEntero(reader["TRAMITES_PROCESADOS"].ToString()),
                    Tramites_Pedientes = Funciones.Nums.TextoAEntero(reader["TRAMITES_PENDIENTES"].ToString()),
                    Periodo = reader["PERIODO"].ToString()
                };
                resultado.Add(item);
            }
            this.b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<CalendarioOperacion>  QuincenanGet(int IdCalendario)
        {
            this.b.ExecuteCommandSP("QuincenaOperacion");
            this.b.AddParameter("@IdCalendario", IdCalendario, SqlDbType.Int);
            List<CalendarioOperacion> resultado = new List<CalendarioOperacion>();
            var reader = this.b.ExecuteReader();
            while (reader.Read())
            {
                CalendarioOperacion item = new CalendarioOperacion
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Quincena = reader["Quincena"].ToString(),
                    TipoNomina = reader["NominaTipo"].ToString(),
                    Fecha_Concentrado = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_Concentrado"].ToString()),
                    Fecha_LimiteCartas = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_LimiteCartas"].ToString()),
                    Fecha_InciaCaptura = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_InciaCaptura"].ToString()),
                    Fecha_TerminaCaptura = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_TerminaCaptura"].ToString()),
                    Fecha_InciaInteractivo = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_InciaInteractivo"].ToString()),
                    Fecha_TerminaInteractivo = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_TerminaInteractivo"].ToString()),
                    Fecha_RptEfectividad = Funciones.Fechas.ConvertirTextoAFecha(reader["Fecha_RptEfectividad"].ToString())
                };
                resultado.Add(item);
            }
            this.b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Pendientes> Selecionar_Pendientes_PorId(int IdPendiente, int IdUsuario)
        {
            b.ExecuteCommandSP("Pendientes_Selecionar_PorIdpendiente");
            b.AddParameter("@IdPendiente", IdPendiente, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            List<prop.Pendientes> resultado = new List<prop.Pendientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Pendientes item = new prop.Pendientes()
                {
                    IdTramite           = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString()),
                    IdMesa              = Funciones.Nums.TextoAEntero(reader["IdMesa"].ToString()),
                    IdStatusMesa        = Funciones.Nums.TextoAEntero(reader["IdStatusMesa"].ToString()),
                    IdStatusTramite     = Funciones.Nums.TextoAEntero(reader["IdStatusTramite"].ToString()),
                    FolioCompuesto      = reader["FolioCompuesto"].ToString(),
                    Operacion           = reader["Operacion"].ToString(),
                    
                    //Contratante = reader["Contratante"].ToString(),
                    //RFC = reader["RFC"].ToString(),
                    //Titular = reader["Titular"].ToString(),

                    Poliza              = reader["Poliza"].ToString(),
                    TipoNomina          = reader["TipoNomina"].ToString(),
                    TipoMovimiento      = reader["TipoMovimiento"].ToString(),
                    UnidadPago          = reader["UnidadPago"].ToString(),
                    Quincena            = reader["Quincena"].ToString(),
                    Importe             = reader["Importe"].ToString(),

                    NombreMesa          = reader["NombreMesa"].ToString(),
                    EstatusMesa         = reader["EstatusMesa"].ToString(),
                    EstatusTramite      = reader["EstatusTramite"].ToString(),
                    FechaRegistro       = reader["FechaRegistro"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
