using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class ResumenValidar
    {
        AccesoDatos.Tablas.ResumenValidar rva = new AccesoDatos.Tablas.ResumenValidar();
        AccesoDatos.Tablas.ArchivoExcel aex = new AccesoDatos.Tablas.ArchivoExcel();

        public void SeleccionarDetalleExcel_GridView(ref DetailsView detailsview, ref string archivo)
        {
            var resumen = rva.SeleccionarAsignarPrimerRegistrodisponible();
            archivo = "..\\..\\Archivos\\" + resumen[2].ToString();
            Funciones.LlenarControles.LlenarDetailsView(ref detailsview, SeleccionarDetalleExcel(resumen[0].ToString(), resumen[1].ToString(), resumen[3].ToString(), resumen[5].ToString()));
        }

        /// <summary>
        /// Obtiene el detalle del registro
        /// </summary>
        /// <param name="poliza">Poliza</param>
        /// <param name="unidadpago">Unidad de Pago</param>
        /// <param name="tiponomina">Tipo de Nómina</param>
        /// <param name="annquincena">Año/Quincena</param>
        /// <returns>Tabla con los datos obtenidos</returns>
        private DataTable SeleccionarDetalleExcel(string poliza, string unidadpago, string tiponomina, string annquincena)
        {
            return aex.SeleccionarDatosRevision(poliza, unidadpago, tiponomina, annquincena);
        }
    }
}
