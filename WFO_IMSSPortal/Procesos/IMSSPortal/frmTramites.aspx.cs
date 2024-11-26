using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class frmTramites : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Sesion"] == null)
            //    Response.Redirect("../Default.aspx");
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
        }

        protected void BtnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmFormatoEnvios.aspx?t=" + rblTipoMovimiento.SelectedValue);
        }
    }
}