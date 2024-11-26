using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class Operacion
    {
        /// <summary>
        /// Acceso a metodos de bitacora
        /// </summary>
        public Bitacora bitacora;
        /// <summary>
        /// Acceso a metodos de catalogo de pendientes
        /// </summary>
        public Cat_Pendientes catpendientes;
        /// <summary>
        /// Acceso a metodos de indicador status mesa
        /// </summary>
        public Indicador_StatusMesas indicadorstatusmesas;
        /// <summary>
        /// Acceso a metodos de Mapa General
        /// </summary>
        public MapaGeneral mapageneral;
        /// <summary>
        /// Acceso a metodos de mesas
        /// </summary>
        public Mesas mesas;
        /// <summary>
        /// Acceso a metodos de negocio de motivos suspension
        /// </summary>
        public MotivosSuspension motivossuspension;
        /// <summary>
        /// Acceso a metodos de negocio de pendientes
        /// </summary>
        public Pendientes pendientes;
        /// <summary>
        /// Acceso a metodos de negocio de tramites a procesar
        /// </summary>
        public TramiteProcesar tramiteprocesar;
        /// <summary>
        /// Acceso a metodos de negocio de tramites
        /// </summary>
        public Tramites tramites;
        /// <summary>
        /// Acceso a metodos de negocio de flujo de usuarios
        /// </summary>
        public UsuariosFlujo usuariosflujo;

        public Operacion()
        {
            bitacora = new Bitacora();
            catpendientes = new Cat_Pendientes();
            indicadorstatusmesas = new Indicador_StatusMesas();
            mapageneral = new MapaGeneral();
            mesas = new Mesas();
            motivossuspension = new MotivosSuspension();
            pendientes = new Pendientes();
            tramiteprocesar = new TramiteProcesar();
            tramites = new Tramites();
            usuariosflujo = new UsuariosFlujo();
        }
    }
}
