using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ValidarCartaInstruccion : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

                //Cargar datos del excel correspondiente
                string archivo = string.Empty;
                int IdTramite = 0;
                int IdMovimiento = 0;
                i.imssportal.tramites.ObtenerTramites_Detalle(ref IdTramite, ref IdMovimiento, ref DetailsView1, ref archivo, manejo_sesion.Usuarios.IdUsuario);

                if (DetailsView1.Rows.Count > 0)
                {
                    DetailsView1.Rows[0].Visible = false;
                    DetailsView1.Rows[1].Visible = false;
                    Literal lit = new Literal();
                    lit.Text = "<embed src='" + archivo + "' style='width:100%; height:100%' type='application/pdf'>";
                    PnlImagenes.Controls.Add(lit);
                }
                else
                {
                    mensajes.MostrarMensaje(this, "No hay Movimientos para procesar.");
                    DetailsView1.Visible = false;
                    BtnAceptar.Visible = false;
                    BtnRechazar.Visible = false;
                    Literal lit = new Literal();
                    lit.Text = "<p>No hay Movimientos para procesar.</p>";
                }
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (
                    CheckBox1.Checked == false
                    || CheckBox2.Checked == false
                    || CheckBox3.Checked == false
                    || CheckBox4.Checked == false
                    || CheckBox5.Checked == false
                    || CheckBox6.Checked == false
                    || CheckBox7.Checked == false
                    || CheckBox8.Checked == false
                    || CheckBox9.Checked == false
                    || CheckBox10.Checked == false
                    || CheckBox11.Checked == false
                    || CheckBox12.Checked == false
                    || CheckBox13.Checked == false
                )
            {
                mensajes.MostrarMensaje(this, "No se han validado todos los datos...");
            }
            else
            {
                int IdMovimiento = 0;
                IdMovimiento = int.Parse(DetailsView1.Rows[0].Cells[1].Text.ToString());
                if (i.imssportal.tramites.ValidarMovimiento(IdMovimiento, 3, "", "") == 2)
                {
                    mensajes.MostrarMensaje(this, "Trámite Validado.", "ValidarCartaInstruccion.aspx");
                }
                else
                {
                    mensajes.MostrarMensaje(this, "No se pudo validar el Trámite ");
                }
            }
        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            BtnAceptar.Visible = false;
            BtnRechazar.Visible = false;
            BtnGuardarRechazo.Visible = true;
            comun.CargaRechazosPromotorias(ref ddlRechazosPromotorias);
            ddlRechazosPromotorias.Visible = true;
        }

        protected void BtnGuardarRechazo_Click(object sender, EventArgs e)
        {
            int IdMovimiento = 0;
            string strRechazo1 = "";
            string strRechazo2 = "";

            lblMensaje.Visible = false;
            lblMensaje.Text = "";

            IdMovimiento = int.Parse(DetailsView1.Rows[0].Cells[1].Text.ToString());

            if (ddlRechazosPromotorias.SelectedIndex > 0)
                strRechazo2 = ddlRechazosPromotorias.Items[ddlRechazosPromotorias.SelectedIndex].Text.Trim();

            if (i.imssportal.tramites.ValidarMovimiento(IdMovimiento, 4, strRechazo1, strRechazo2) == 2)
            {
                mensajes.MostrarMensaje(this, "Trámite Rechazado.", "ValidarCartaInstruccion.aspx");
            }
            else
            {
                mensajes.MostrarMensaje(this, "No se pudo rechazar el Trámite.");
            }
        }
    }
}