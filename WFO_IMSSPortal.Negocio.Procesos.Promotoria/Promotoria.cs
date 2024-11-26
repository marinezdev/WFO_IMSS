using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class Promotoria
    {
        /// <summary>
        /// Acceso a métodos de negocio de archivos
        /// </summary>
        public Archivos archivos;
        /// <summary>
        /// Acceso a métodos de negocio de bitacora
        /// </summary>
        public Bitacora bitacora;
        /// <summary>
        /// Acceso a métodos de negocio de cartas
        /// </summary>
        public Cartas cartas;
        /// <summary>
        /// Acceso a métodos de negocio de catalogos
        /// </summary>
        public Catalogos catalogos;
        /// <summary>
        /// Acceso a métodos de negocio de indicador general
        /// </summary>
        public IndicadorGeneral indicadorgeneral;
        /// <summary>
        /// Acceso a métodos de negocio de tramiteN1
        /// </summary>
        public TramiteN1 tramiten1;
        /// <summary>
        /// Acceso a métodos de negocio de tramites promotoria
        /// </summary>
        public TramitesPromotoria tramitespromotoria;

        public Promotoria()
        {
            archivos = new Archivos();
            bitacora = new Bitacora();
            cartas = new Cartas();
            catalogos = new Catalogos();
            indicadorgeneral = new IndicadorGeneral();
            tramiten1 = new TramiteN1();
            tramitespromotoria = new TramitesPromotoria();
        }
    }
}
