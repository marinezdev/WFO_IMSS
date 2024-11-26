using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using DevExpress.Web;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ListarConcentradoPromo : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref DDLQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
            Buscar();

        }

        protected void grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            //if (e.DataColumn.Caption == "STATUS")
            //{
            //    ASPxImage img = null;
            //    switch (Convert.ToInt32(e.GetValue("STATUS_FOLIO").ToString()))
            //    {
            //        case 0:
            //            img = new ASPxImage() { ImageUrl = "~/imagenes/bolaNaranja.png" };
            //            break;

            //        case 1:
            //            img = new ASPxImage() { ImageUrl = "~/imagenes/bolaAmarilla.png" };
            //            break;

            //        case 3:
            //            img = new ASPxImage() { ImageUrl = "~/imagenes/bolaAzul.png" };
            //            break;

            //        case 6:
            //            img = new ASPxImage() { ImageUrl = "~/imagenes/bolaVerde.png" };
            //            break;

            //        case 4:
            //        case 7:
            //            img = new ASPxImage() { ImageUrl = "~/imagenes/bolaRoja.png" };
            //            break;

            //        default:
            //            img = new ASPxImage() { ImageUrl = "~/imagenes/bolaMorada.png" };
            //            break;
            //    }

            //    //e.Cell.Attributes.Add("onmouseover", String.Format("OnImageMouseOver(this,'{0}', '{1}');", e.DataColumn.FieldName, e.VisibleIndex));
            //    //    img.ClientSideEvents.Init = string.Format("function(s, e) {{ OpenPopupWithArguments(s, '{0}', {1}) }}", e.DataColumn.FieldName, e.VisibleIndex);
            //    e.Cell.Controls.AddAt(0, img);

            //}
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            //string strFolio = txtFolio.Text.Trim();
            //string strFechaI = dtFechaInicio.Text.Trim();
            //string strFechaF = dtFechaFin.Text.Trim();

            //lblMensaje.Visible = false;
            //lblMensaje.Text = "";

            //if (strFechaI.Length > 0 && strFechaF.Length > 0)
            //{
            //    strFechaI = dtFechaInicio.Text + " 00:00:00";
            //    strFechaF = dtFechaFin.Text + " 23:59:59";

            //    try
            //    {
            //        DateTime dt1 = DateTime.ParseExact(strFechaI, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //        DateTime dt2 = DateTime.ParseExact(strFechaF, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            //        if (dt1 >= dt2)
            //        {
            //            lblMensaje.Visible = true;
            //            lblMensaje.Text = "La Fecha Inicial no debe ser mayor que la final.";
            //        }
            //        else
            //        {
            //            strFechaI = dt1.ToString("yyyy-MM-dd HH:mm:ss");
            //            strFechaF = dt2.ToString("yyyy-MM-dd HH:mm:ss");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        lblMensaje.Visible = true;
            //        lblMensaje.Text = "Formato de fechas inválido [ dd-MM-yyyy ].";
            //    }

            //    //tramites.ObtenerConcentrado_GridView(ref GVConcentrado, manejo_sesion.Usuarios.IdPromotoria, strFechaI, strFechaF, RBLNomina.SelectedValue, DDLQuincena.SelectedValue);
            //    //grid.DataSource = GVConcentrado.DataSource;
            //    //grid.DataBind();
            //}

            if (RBLNomina.SelectedValue.ToString() != "" && DDLQuincena.SelectedValue.ToString() != "")
            {
                i.imssportal.tramites.ObtenerConcentrado_GridView(ref GVConcentrado, manejo_sesion.Usuarios.IdPromotoria, "", "", RBLNomina.SelectedValue.ToString(), DDLQuincena.SelectedValue.ToString());
                grid.DataSource = GVConcentrado.DataSource;
                grid.DataBind();
            }
        }
    }
}