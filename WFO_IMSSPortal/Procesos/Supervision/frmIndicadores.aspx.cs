using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class frmIndicadores : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //cmbFlujoM.DataSource = i.supervision.default_.DatosComboFlujo();
            //cmbFlujoM.DataTextField = "Nombre";
            //cmbFlujoM.DataValueField = "Id";
            //cmbFlujoM.DataBind();
            Funciones.LlenarControles.LlenarDropDownList(ref cmbFlujoM, i.supervision.default_.DatosComboFlujo(), "Nombre", "Id");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            i.supervision.default_.MostrarMapa(ref IndicadoresMapa, cmbFlujoM.SelectedValue.ToString());
            i.supervision.default_.MapaDetalle(ref dvgdEstatusTramite, ref dxChtTotales, cmbFlujoM.SelectedValue.ToString());
            var valor = Ancho.Value;
            dxChtTotales.Width = new Unit(Convert.ToInt32(Ancho.Value));
        }

        protected void dxChtTotales_CustomCallback(object sender, DevExpress.XtraCharts.Web.CustomCallbackEventArgs e)
        {
            dxChtTotales.Width = new Unit(Convert.ToInt32(Ancho.Value));
        }

        protected void dvgdDetallePromotoria_Init(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView gridDetalle = (ASPxGridView)sender;
                string estado = gridDetalle.GetMasterRowFieldValues("ESTADO").ToString();
                //DataTable dtD = i.supervision.default_.DatosResumenPromotoria(estado, cmbFlujoM.SelectedValue.ToString());
                //gridDetalle.DataSource = dtD;
                Funciones.LlenarControles.LlenarGridViewASPx(ref gridDetalle, i.supervision.default_.DatosResumenPromotoria(estado, cmbFlujoM.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.ToString();
            }
        }

    }
}