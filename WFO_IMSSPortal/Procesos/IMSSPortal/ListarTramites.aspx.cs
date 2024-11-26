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
    public partial class ListarTramites : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
        }

        protected string GetFormatString(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();

            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref DDLQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string strFolio = txtFolio.Text.Trim();
            string strFechaI = dtFechaInicio.Text.Trim();
            string strFechaF = dtFechaFin.Text.Trim();

            lblMensaje.Visible = false;
            lblMensaje.Text = "";

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
            //            strFechaI = dt1.ToString("yyyyMMdd HH:mm:ss");
            //            strFechaF = dt2.ToString("yyyyMMdd HH:mm:ss");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        lblMensaje.Visible = true;
            //        lblMensaje.Text = "Formato de fechas inválido [ dd-MM-yyyy ].";
            //    }

            //    //tramites.ObtenerConcentrado_GridView(ref GVConcentrado, ref lblCartasEsperadas, ref lblCartasRecibidas, ref lblCartasFaltantes,
            //    //    manejo_sesion.Usuarios.IdPromotoria, strFechaI, strFechaF, RBLNomina.SelectedValue, DDLQuincena.SelectedValue);
            //    //grid.DataSource = GVConcentrado.DataSource;
            //    //grid.DataBind();


            //}
            //else
            //{
            //    //lblMensaje.Visible = true;
            //    //lblMensaje.Text = "Debe seleccionar un rango de Fechas.";
            //    //tramites.ObtenerConcentrado_GridView(ref GVConcentrado, ref lblCartasEsperadas, ref lblCartasRecibidas, ref lblCartasFaltantes,
            //    //    manejo_sesion.Usuarios.IdPromotoria);
            //    //grid.DataSource = GVConcentrado.DataSource;
            //    //grid.DataBind();
            //}

            i.imssportal.tramites.ObtenerConcentrado_GridView(ref GVConcentrado, ref lblCartasEsperadas, ref lblCartasRecibidas, ref lblCartasFaltantes,manejo_sesion.Usuarios.IdPromotoria, "", "", RBLNomina.SelectedValue, DDLQuincena.SelectedValue);
            grid.DataSource = GVConcentrado.DataSource;
            grid.DataBind();
        }

        protected void lnkExportar_Click(object sender, EventArgs e)
        {
            // grid.ExportXlsxToResponse("ASAEConsultores.xlsx", new XlsxExportOptionsEx() { ExportType = ExportType.Default });

            grid.ExportXlsxToResponse("Promotoria.xlsx", new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });


            //using (MemoryStream ms = new MemoryStream())
            //{
            //    ASPxGridViewExporter1.WriteXlsx(ms, new XlsxExportOptionsEx() { ExportType = ExportType.DataAware });
            //    ASPxSpreadsheet mySpreadsheet = new ASPxSpreadsheet() { ID = "sheet" };
            //    form1.Controls.Add(mySpreadsheet);
            //    ms.Position = 0;
            //    mySpreadsheet.Open("myDocument", DocumentFormat.Xlsx, () =>
            //    {
            //        return ms;
            //    });
            //    mySpreadsheet.Document.Worksheets[0].Columns[1].AutoFit();
            //    byte[] result = mySpreadsheet.SaveCopy(DocumentFormat.Xlsx);
            //    DocumentManager.CloseDocument("myDocument");
            //    Response.Clear();
            //    Response.ContentType = "application/force-download";
            //    Response.AddHeader("content-disposition", "attachment; filename=test.xlsx");
            //    Response.BinaryWrite(result);
            //    Response.End();
            //}
        }

        protected void grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
        }
    }
}