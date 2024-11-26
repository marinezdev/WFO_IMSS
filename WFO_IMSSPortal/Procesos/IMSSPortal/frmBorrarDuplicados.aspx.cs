using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class frmBorrarDuplicados : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // NO FUNCIONA!!!
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            // NO FUNCIONA!!!
            //busca las polizas indicadas
            GVDuplicados.DataSource = i.imssportal.eliminarduplicados.EliminarRegistrosDuplicados(txtPolizas.Text);
            GVDuplicados.DataBind();
        }

        protected void GVDuplicados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // NO FUNCIONA!!!
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "EliminarRegistro")
            {
                i.imssportal.eliminarduplicados.EliminarRegistro(id);
                GVDuplicados.DataSource = i.imssportal.eliminarduplicados.EliminarRegistrosDuplicados(txtPolizas.Text);
                GVDuplicados.DataBind();
                txtPolizas.Text = "";
                mensajes.MostrarMensaje(this, "Se eliminó el registro " + id);
            }
        }






    }
}