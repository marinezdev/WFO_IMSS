using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Utilerias
{
    public partial class Menu : System.Web.UI.UserControl
    {
        IU.ManejadorSesion manejo_sesion = new IU.ManejadorSesion();

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            LblMenu.Text = manejo_sesion.Menu;
        }
    }
}