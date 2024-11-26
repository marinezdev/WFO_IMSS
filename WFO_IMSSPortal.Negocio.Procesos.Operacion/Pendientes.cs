using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class Pendientes
    {
        AccesoDatos.Procesos.Operacion.Pendientes pendientes = new AccesoDatos.Procesos.Operacion.Pendientes();

        public List<prop.TramitesProcesados> TramitesProcesados(DateTime FechaI, DateTime FechaF)
        {
            return pendientes.TramitesProcesados(FechaI, FechaF);
        }

        public List<prop.Pendientes> SelecionarPendientes(int IdPendiente, int IdUsuario)
        {
            return pendientes.Selecionar_Pendientes_PorId(IdPendiente, IdUsuario);
        }

        public List<CalendarioOperacion>  QuincenanGet(int IdCalendario)
        {
            return this.pendientes.QuincenanGet(IdCalendario);
        }

        public List<Tramites_SLA> TramitesSLA(string Quincena, string TipoNomina)
        {
            return this.pendientes.TramitesSLA(Quincena, TipoNomina);
        }

        public List<TramitesDetalle> TramitesSLADetalle(int Dia, string rangoFecha, string Quincena, string TipoNomina)
        {
            return this.pendientes.TramitesSLADetalle(Dia, rangoFecha, Quincena, TipoNomina);
        }

    }
}
