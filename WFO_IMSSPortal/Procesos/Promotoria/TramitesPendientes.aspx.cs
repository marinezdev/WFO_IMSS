using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.Procesos.Promotoria
{
    public partial class TramitesPendientes : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                i.promotoria.tramitespromotoria.ListaTramitesPromotoriaPendientes(ref rptTramite, manejo_sesion.Usuarios.IdUsuario);

                //List<prop.TramitesPromotoria> Tramites = i.promotoria.tramitespromotoria.ListaTramitesPromotoriaPendientes(manejo_sesion.Usuarios.IdUsuario);
                //rptTramite.DataSource = Tramites;
                //rptTramite.DataBind();
            }
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                string IdTramite = e.CommandArgument.ToString();
                Response.Redirect("ConsultaTramite.aspx?Id=" + IdTramite);
            }
        }
    }
}