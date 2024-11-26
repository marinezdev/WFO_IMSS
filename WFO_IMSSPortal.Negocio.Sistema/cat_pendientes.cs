using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Sistema
{
    public class cat_pendientes
    {
        AccesoDatos.Sistema.cat_pendientes catpendientes = new AccesoDatos.Sistema.cat_pendientes();

        public void Seleccionar(ref GridView gridview)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, catpendientes.Seleccionar());
        }

        public int Modificar(string id, string nombre, string tipo, string icono, string activo, string fecharegistro)
        {
            return catpendientes.Modificar(id, nombre, tipo, icono, activo, fecharegistro);
        }

    }
}
