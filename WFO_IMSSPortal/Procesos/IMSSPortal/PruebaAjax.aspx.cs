using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class PruebaAjax : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
        }

        protected void BtnProcesar_Click(object sender, EventArgs e)
        {
            LblMensajes.Text = "";
            System.Threading.Thread.Sleep(1000);
            LblMensajes.Text = "Terminado.";
        }
    }
}