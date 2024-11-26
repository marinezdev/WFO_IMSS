using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmUsuarioPromotoria : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                i.supervisiongeneral.catpromotoria.Seeccionar_DropDownListPorNombre(ref DDLPromotorias);
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                i.administracion.usuarios.AgregarUsuarioPromotoria(DDLPromotorias.SelectedValue, txtNombre.Text, txtCorreo.Text, txtClave.Text);
                DDLPromotorias.SelectedIndex = 0;
                txtNombre.Text = "";
                txtCorreo.Text = "";
                txtClave.Text = "";
                LblMensajes.Text = "Se agregó el usuario.";
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }
    }
}