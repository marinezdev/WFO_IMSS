using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class sprMapaSupervisor : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            try
            {
                if (!IsPostBack)
                {
                    string modo = GridViewDetailExportMode.All.ToString();
                    string Mesa = Request.Params["Id"];
                    string IdFlujo = Request.Params["idFlujo"];
                    lblMesa.Text = "MESA: " + Mesa;
                    i.supervision.mapasupervisor.MapaSupervisorMesa(ref dvgdTramites, Mesa, IdFlujo);
                    dvgdTramites.SettingsDetail.ExportMode = (GridViewDetailExportMode)Enum.Parse(typeof(GridViewDetailExportMode), modo);
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }
        protected void dvgdDetalleTramite_Init(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView gridDetalle = (ASPxGridView)sender;
                string idMesa = gridDetalle.GetMasterRowFieldValues("idMesa").ToString();
                DataTable dtD = i.supervision.mapasupervisor.MapaSupervisorDetalleMesa(idMesa);
                gridDetalle.DataSource = dtD;
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }
        protected void lnkExportar_Click(object sender, EventArgs e)
        {
            try
            {
                dvgdTramites.ExportXlsxToResponse("MapaSupervisor.xlsx", new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }
    }
}