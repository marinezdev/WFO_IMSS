using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DevExpress.Export;
using DevExpress.XtraPrinting;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ListarEfectividadV : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref DDLQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }

        protected void lnkExportar_Click(object sender, EventArgs e)
        {
            if (DDLTipoNomina.SelectedValue.ToString() != "" && DDLQuincena.SelectedValue.ToString() != "00")
            {
                Funciones.ManejoExcel.ExportarDataSetAExcel(this, i.imssportal.tramites.ObtenerEfectividadOperatividad_DataSet(DDLTipoNomina.SelectedValue, DDLQuincena.SelectedValue));
            }
        }

        protected void lnkExportarConcentrado_Click(object sender, EventArgs e)
        {
            gridConcentrado.ExportXlsxToResponse("ASAEConsultores.xlsx", new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //tramites.ObtenerEfectividad_GridView(ref GVEfectividad);
            //tramites.ObtenerConcentrado_GridView(ref GVConcentrado);
            //gridEfectividad.DataSource = GVEfectividad.DataSource;
            //gridEfectividad.DataBind();
            //gridConcentrado.DataSource = GVConcentrado.DataSource;
            //gridConcentrado.DataBind();

            if (DDLTipoNomina.SelectedValue.ToString() != "" && DDLQuincena.SelectedValue.ToString() != "00")
            {
                lnkExportarResumen.Visible = true;
                gridConcentrado.Visible = true;
                gridEfectividad.Visible = true;

                i.imssportal.tramites.ObtenerEfectividadOperacion_AspxGridView(ref gridConcentrado, ref gridEfectividad, DDLTipoNomina.SelectedValue, DDLQuincena.SelectedValue);
            }
        }
    }
}