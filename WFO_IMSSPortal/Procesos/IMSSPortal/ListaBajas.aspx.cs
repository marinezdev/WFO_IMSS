using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ListaBajas : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                i.imssportal.tramites.ObtenerConcentradoBajas_AspxGridView(ref grid);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void lnkExportar_Click(object sender, EventArgs e)
        {
            grid.ExportXlsxToResponse("ASAEConsultores.xlsx", new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }

        protected void grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
        }

        protected string GetFormatString(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        private void CargarDatos()
        {
            //tramites.ObtenerConcentrado_Bajas_GridView(ref GVConcentrado);
            //grid.DataSource = GVConcentrado.DataSource;
            //grid.DataBind();
            //if (GVConcentrado.Rows.Count == 0)
            //    mensajes.MostrarMensaje(this, "No existen bajas a procesar...");
        }





    }
}