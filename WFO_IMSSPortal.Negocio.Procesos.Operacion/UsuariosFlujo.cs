using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class UsuariosFlujo
    {
        AccesoDatos.Procesos.Operacion.UsuariosFlujo usuariosFlujo = new AccesoDatos.Procesos.Operacion.UsuariosFlujo();

        public List<prop.UsuariosFlujo> SelecionarFlujo(int Id_Usuario)
        {
            return usuariosFlujo.SelecionarFlujo(Id_Usuario);
        }

        public void SeleccionarQuincenasPendientes_DropDownList(ref DropDownList dropdownlist, int idusuario)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, usuariosFlujo.SeleccionarQuincenasPendientes(), "Nombre", "Id");
        }

        public void SeleccionarFlujo_DropDownList(ref DropDownList dropdownlist, int idusuario)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, usuariosFlujo.SelecionarFlujo(idusuario), "Nombre", "Id");
        }
    }
}
