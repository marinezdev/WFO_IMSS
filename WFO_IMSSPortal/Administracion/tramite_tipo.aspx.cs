using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Administracion
{
    public partial class tramite_tipo : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            if (!IsPostBack)
            {
                i.administracion.tramitetipo.Seleccionar(ref GVRegistros);
            }
        }
    }
}