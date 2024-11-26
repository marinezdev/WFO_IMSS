using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class frmValidar : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

                //Cargar datos del excel correspondiente
                string archivo = string.Empty;
                i.imssportal.resumenvalidar.SeleccionarDetalleExcel_GridView(ref DetailsView1, ref archivo);

                Literal lit = new Literal();
                lit.Text = "<embed src='" + archivo + "' style='width:100%; height:100%' type='application/pdf'>";
                PnlImagenes.Controls.Add(lit);
            }

        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            var a = DetailsView1.Rows[0].Cells[1].Text;
            var b = DetailsView1.Rows[1].Cells[1].Text;
            var c = DetailsView1.Rows[2].Cells[1].Text;
            var d = DetailsView1.Rows[3].Cells[1].Text;
            var f = DetailsView1.Rows[4].Cells[1].Text;
            var g = DetailsView1.Rows[5].Cells[1].Text;
            var h = DetailsView1.Rows[6].Cells[1].Text;
            var ii = DetailsView1.Rows[7].Cells[1].Text;
            var j = DetailsView1.Rows[8].Cells[1].Text;
            var k = DetailsView1.Rows[9].Cells[1].Text;
            var l = DetailsView1.Rows[10].Cells[1].Text;
            var m = DetailsView1.Rows[11].Cells[1].Text;
            //Guardar los valores aceptados
             i.imssportal.validar.AgregarConcentrado(""); //Estado 1
        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            BtnAceptar.Visible = false;
            BtnRechazar.Visible = false;
            BtnGuardarRechazo.Visible = true;
            ddlRechazosInmediatos.Visible = true;
            ddlRechazosPromotorias.Visible = true;
            ddlRechazosSinCarta.Visible = true;
            ddlRechazosValidacionesImss.Visible = true;
            //comun.CargaRechazosInmediatos(ref ddlRechazosInmediatos);
            comun.CargaRechazosPromotorias(ref ddlRechazosPromotorias);
            //comun.CargaRechazosSinCarta(ref ddlRechazosSinCarta);
            comun.CargaRechazosValidacionImss(ref ddlRechazosValidacionesImss);
        }

        protected void BtnGuardarRechazo_Click(object sender, EventArgs e)
        {
            var a = DetailsView1.Rows[0].Cells[1].Text;
            var b = DetailsView1.Rows[1].Cells[1].Text;
            var c = DetailsView1.Rows[2].Cells[1].Text;
            var d = DetailsView1.Rows[3].Cells[1].Text;
            var f = DetailsView1.Rows[4].Cells[1].Text;
            var g = DetailsView1.Rows[5].Cells[1].Text;
            var h = DetailsView1.Rows[6].Cells[1].Text;
            var ii = DetailsView1.Rows[7].Cells[1].Text;
            var j = DetailsView1.Rows[8].Cells[1].Text;
            var k = DetailsView1.Rows[9].Cells[1].Text;
            var l = DetailsView1.Rows[10].Cells[1].Text;
            var m = DetailsView1.Rows[11].Cells[1].Text;
            i.imssportal.validar.AgregarConcentrado(a, b, c, d, f, g, h, ii, j, l, m,
            ddlRechazosInmediatos.SelectedValue,
            ddlRechazosPromotorias.SelectedValue,
            ddlRechazosSinCarta.SelectedValue,
            ddlRechazosValidacionesImss.SelectedValue); //Estado 0
        }













    }
}