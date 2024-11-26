using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmUsuarioSupervisorReportes : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {

            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                i.administracion.usuarios.AgregarUsuarioSuper(txtNombre.Text, txtCorreo.Text, txtClave.Text);
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtClave.Text = "";
                lblMensajes.Text = "Se agregó el usuario.";
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }
    }
}