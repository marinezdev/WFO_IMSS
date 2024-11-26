using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades;

namespace WFO_IMSSPortal.Negocio.Catalogos
{
    public class Catalogo
    {
        ProcesosInternos pi = new ProcesosInternos();

        public void TramiteTipo_DropDownList(ref DropDownList dropdownlist, string tabla)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, pi.Seleccionar(tabla), "Nombre", "Id");
        }

        class ProcesosInternos
        {
            AccesoDatos.Catalogos catalogos = new AccesoDatos.Catalogos();

            /// <summary>
            /// Método genérico para obtener los registros de una tabla y llenar un control
            /// </summary>
            /// <param name="tabla"></param>
            /// <returns></returns>
            public List<prop.Catalogos> Seleccionar(string tabla)
            {
                return catalogos.Seleccionar(tabla);
            }


        }
    }
}
