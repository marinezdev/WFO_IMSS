using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class IMSSPortal
    {
        /// <summary>
        /// Acceso a metodos de negocio de archivos
        /// </summary>
        public Archivos archivos;
        /// <summary>
        /// Acceso a métodos de negocio de elimnar duplicados
        /// </summary>
        public EliminarDuplicados eliminarduplicados;
        /// <summary>
        /// Acceso a métodos de negocio de EnlaceImportarTxt
        /// </summary>
        public EnlaceImportarTxt enlaceimportartxt;
        /// <summary>
        /// Acceso a métodos de negocio de extracción
        /// </summary>
        public Extraccion extraccion;
        /// <summary>
        /// Acceso a métodos de negocio de  extracción movimientos
        /// </summary>
        public ExtraccionMovimientos extraccionmovimientos;
        /// <summary>
        /// Acceso a métodos de negocio de formato envíos
        /// </summary>
        public FormatoEnvios formatoenvios;
        /// <summary>
        /// Acceso a métodos de negocio de resumen validar
        /// </summary>
        public ResumenValidar resumenvalidar;
        /// <summary>
        /// Acceso a métodos de negocio de tramites
        /// </summary>
        public Tramites tramites;
        /// <summary>
        /// Acceso a métodos de negocio de validar concentrado
        /// </summary>
        public Validar validar;

        public IMSSPortal()
        {
            archivos = new Archivos();
            eliminarduplicados = new EliminarDuplicados();
            enlaceimportartxt = new EnlaceImportarTxt();
            extraccion = new Extraccion();
            extraccionmovimientos = new ExtraccionMovimientos();
            formatoenvios = new FormatoEnvios();
            resumenvalidar = new ResumenValidar();
            tramites = new Tramites();
            validar = new Validar();
        }

    }
}