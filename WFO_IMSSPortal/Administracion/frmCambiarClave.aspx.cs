using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmCambiarClave : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                i.administracion.usuarios.ActualizarContraseña(manejo_sesion.Usuarios.IdUsuario, txtNueva.Text);
                i.administracion.usuarios.ActualizarDesconectarSesion(manejo_sesion.Usuarios.IdUsuario, 0, manejo_sesion.IdParaCierreSesion);
                mensajes.MostrarMensaje(this, "Se ha cambiado la contraseña exitosamente, debe volver a entrar para que tome efecto.", "../.");
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                //LblMensajes.Text = "Ha habido un error al intentar cambiar la clave, fin de la operación.";
            }
        }
    }
}