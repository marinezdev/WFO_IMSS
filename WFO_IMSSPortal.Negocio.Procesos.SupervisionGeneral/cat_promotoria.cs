using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class cat_promotoria
    {
        AccesoDatos.Procesos.Promotoria.cat_promotoria catpromotoria = new AccesoDatos.Procesos.Promotoria.cat_promotoria();
        public void Seleccionar_DropdownList(ref DropDownList dropdownlist)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catpromotoria.Seleccionar(), "Nombre", "Id");
        }

        public void Seeccionar_DropDownListPorNombre(ref DropDownList dropdownlist)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catpromotoria.SeleccionarPorNombre(), "Nombre", "Clave");
        }
    }
}
