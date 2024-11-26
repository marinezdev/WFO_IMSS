using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using promotoria = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class TramiteProcesar
    {
        AccesoDatos.Procesos.Operacion.TramiteProcesar Tramites = new AccesoDatos.Procesos.Operacion.TramiteProcesar();
        AccesoDatos.Procesos.Operacion.PolizaSistemasLegados sistemasLegados = new AccesoDatos.Procesos.Operacion.PolizaSistemasLegados();
        AccesoDatos.Procesos.Operacion.kwik kwik = new AccesoDatos.Procesos.Operacion.kwik();

        public List<prop.TramiteProcesar> ObtenerTramite(int pIdUsuario, int pIdMesa, int pIdTramite)
        {
            return Tramites.ObtenerTramite(pIdUsuario, pIdMesa, pIdTramite);
        }

        public List<prop.TramiteProcesar> ObtenerTramite(int pIdTramite)
        {
            return Tramites.ObtenerTramite(pIdTramite);
        }

        public List<prop.TramiteProcesado> PromotoriaAcepta(int IdTramite, bool StatusPoliza, int IdUsuario, string ObservacionPublica, string ObservacionPrivada)
        {
            return Tramites.PromotoriaAcepta(IdTramite, StatusPoliza, IdUsuario, ObservacionPublica, ObservacionPrivada);
        }

        public List<prop.TramiteProcesado> ReingresarTramite(int IdTramite, int IdUsuario, string ObservacionPublica, string ObservacionPrivada)
        {
            return Tramites.ReingresarTramite(IdTramite, IdUsuario, ObservacionPublica, ObservacionPrivada);
        }

        public List<prop.TramiteProcesado> ProcesarTramite(int IdTramite, int IdMesa, int IdUsuario, Funciones.VariablesGlobales.StatusMesa IdStatusMesa, string ObsPublica, string ObsPrivada, string MotivosRechazo, string Importe, string PolizaPortal)
        {
            return Tramites.ProcesarTramite(IdTramite, IdMesa, IdUsuario, IdStatusMesa, ObsPublica, ObsPrivada, MotivosRechazo, Importe, PolizaPortal);
        }

        public List<prop.TramiteProcesado> EnviarTramite(int IdTramite, int IdMesa, int IdMesaToSend, int IdUsuario, string observacionesPublicas, string observacionesPrivadas)
        {
            return Tramites.EnviarTramite(IdTramite, IdMesa, IdMesaToSend, IdUsuario, observacionesPublicas, observacionesPrivadas);
        }

        public List<prop.RespuestaTramite> ActualizarTramite(int IdUsuario, int IdTramite, promotoria.TramiteN1 tramite)
        {
            return Tramites.ActualizarTramite(IdUsuario,IdTramite,tramite);
        }

        public int ActualizaPolizaSistemasLegados(int IdTramite, int IdUsuario, string IdSisLegados)
        {
            return sistemasLegados.ActualizaPolizaSistemasLegados(IdTramite, IdUsuario, IdSisLegados);
        }

        public int AgregarInteractivo(int IdTramite)
        {
            return sistemasLegados.AgregarInteractivo(IdTramite);
        }

        public int ActualizaKwik(int IdTramite, int IdUsuario, string IdSisLegados)
        {
            return kwik.ActualizaKwik(IdTramite, IdUsuario, IdSisLegados);
        }

        public prop.TipoTramite ObtenerTipoTramite(int IdTramite)
        {
            return Tramites.ObtenerTipoTramite(IdTramite);
        }

        public promotoria.cat_riesgos ObtenerRiesgoTramite(int IdTramite)
        {
            return Tramites.ObtenerRiesgoTramite(IdTramite);
        }
    }
}