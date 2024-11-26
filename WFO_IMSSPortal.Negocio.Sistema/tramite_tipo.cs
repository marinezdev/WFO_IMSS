using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Sistema
{
    public class tramite_tipo
    {
        AccesoDatos.Sistema.tramite_tipo tramitetipo = new AccesoDatos.Sistema.tramite_tipo();

        public void Seleccionar(ref GridView gridview)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, tramitetipo.Seleccionar());
        }

        public int Agregar(string idflujo, string nombre, string abrevfolio, string nivel, string alcance, string tabla, string tablabitacora, string activo)
        {
            return tramitetipo.Agregar(idflujo, nombre, abrevfolio, nivel, alcance, tabla, tablabitacora, activo);
        }

        public int Modificar(string id, string idflujo, string nombre, string abrevfolio, string nivel, string alcance, string tabla, string tablabitacora, string activo)
        {
            return tramitetipo.Modificar(id, idflujo, nombre, abrevfolio, nivel, alcance, tabla, tablabitacora, activo);
        }
    }
}
