using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class DesbloqueoUsuarios : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            //buscar detalle del usuario
            i.administracion.usuarios.Buscar(ref GVUsuarios, ref lblMensajesUsuarios, txtUsuario.Text);
        }

        protected void GVUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string idusuario = e.CommandArgument.ToString();
            if (e.CommandName == "Desconectar")
            {
                if (i.administracion.usuarios.ActualizarDesconectarSesion(Funciones.Nums.TextoAEntero(idusuario), 0, 0) == 1)
                {
                    i.administracion.usuarios.Buscar(ref GVUsuarios, ref lblMensajesUsuarios, txtUsuario.Text);
                    lblMensajesUsuarios.Text = "Se desconectó el usuario del sistema.";
                }
            }
            if (e.CommandName == "Desactivar")
            {
                if (i.administracion.usuarios.ActivaDesactiva(idusuario) == 1)
                {
                    i.administracion.usuarios.Buscar(ref GVUsuarios, ref lblMensajesUsuarios, txtUsuario.Text);
                    lblMensajesUsuarios.Text = "Se activo de nuevo el usuario en el sistema.";
                }
            }
            if (e.CommandName == "ReiniciarContra")
            {
                i.administracion.usuarios.ReiniciarContraseña(idusuario);
                lblMensajesUsuarios.Text = "Se reinició la contraseña del usuario a ASAE2019, debe cambiarla cuando entre de nuevo.";
            }
            
        }
    }
}