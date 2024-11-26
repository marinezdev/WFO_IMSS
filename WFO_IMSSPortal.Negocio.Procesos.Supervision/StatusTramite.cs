using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.Supervision
{
    public class StatusTramite
    {
        AccesoDatos.Tablas.StatusTramite statustramite = new AccesoDatos.Tablas.StatusTramite();

        public void StatusTramite_DropDownList(ref DropDownList dropdownlist)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, statustramite.Seleccionar(), "Nombre", "Nombre");
        }

        public void StatusTramite_GridView(ref GridView gridview)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, statustramite.SeleccionarTodo());
        }

        public Propiedades.StatusTramite SeleccionarPorId(string id)
        {
            return statustramite.SeleccionarPorId(id);
        }

        public int Modificar(Propiedades.StatusTramite items)
        {
            return statustramite.Modificar(items);
        }
    }
}
