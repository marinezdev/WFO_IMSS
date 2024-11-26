using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Sistema
{
    public class cat_producto
    {
        AccesoDatos.Sistema.cat_producto catproducto = new AccesoDatos.Sistema.cat_producto();

        public void Seleccionar(ref GridView gridview)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, catproducto.Seleccionar());
        }

        public int Agregar(string idtipotramite, string nombre, string descripcion, string activo)
        {
            return catproducto.Agregar(idtipotramite, nombre, descripcion, activo);
        }

        public int Modificar(string id, string idtipotramite, string nombre, string descripcion, string activo, string fecharegistro)
        {
            return catproducto.Modificar(id, idtipotramite, nombre, descripcion, activo, fecharegistro);
        }
    }
}
