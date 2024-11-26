using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ProcesarTramite : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            //Cargar datos del excel correspondiente
            string archivo = string.Empty;
            int IdTramite = 0;
            int IdMovimiento = 0;
            i.imssportal.tramites.ObtenerTramites_Porcesar(ref IdTramite, ref IdMovimiento, ref DetailsView1, ref archivo, manejo_sesion.Usuarios.IdUsuario);

            if (DetailsView1.Rows.Count > 0)
            {
                DetailsView1.Rows[0].Visible = false;
                DetailsView1.Rows[1].Visible = false;
                DetailsView1.Rows[8].Visible = false;
                DetailsView1.Rows[9].Visible = false;

                Literal lit = new Literal();
                lit.Text = "<embed src='" + archivo + "' style='width:100%; height:100%' type='application/pdf'>";
                PnlImagenes.Controls.Add(lit);
            }
            else
            {
                mensajes.MostrarMensaje(this, "No hay movimientos para procesar.");
                DetailsView1.Visible = false;
                BtnAceptar.Visible = false;
                BtnRechazar.Visible = false;
                Literal lit = new Literal();
                lit.Text = "<p>No hay movimientos para procesar.</p>";
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
                )
            {
                mensajes.MostrarMensaje(this, "No se han validado todos los datos...");
            }
            else
            {
                int IdMovimiento = 0;
                string strIdMovimiento = DetailsView1.Rows[0].Cells[1].Text.Trim();
                string IdTramite = DetailsView1.Rows[1].Cells[1].Text.Trim();
                string Poliza = DetailsView1.Rows[2].Cells[1].Text.Trim();
                string UnidadPago = DetailsView1.Rows[3].Cells[1].Text.Trim();
                string Archivo = DetailsView1.Rows[4].Cells[1].Text.Trim();
                string TipoNomina = DetailsView1.Rows[5].Cells[1].Text.Trim();
                string TipoMovimiento = DetailsView1.Rows[6].Cells[1].Text.Trim();
                string AnoQuincena = DetailsView1.Rows[7].Cells[1].Text.Trim();
                string Estado = DetailsView1.Rows[8].Cells[1].Text.Trim();
                string IdUsuario = DetailsView1.Rows[9].Cells[1].Text.Trim();
                string Matricula = DetailsView1.Rows[10].Cells[1].Text.Trim();
                string Importe = DetailsView1.Rows[11].Cells[1].Text.Trim();
                string UsuarioServicio = DetailsView1.Rows[12].Cells[1].Text.Trim();
                string Nombre = DetailsView1.Rows[13].Cells[1].Text.Trim();
                string PromOrigen = DetailsView1.Rows[14].Cells[1].Text.Trim();
                string PromUltimoSer = DetailsView1.Rows[15].Cells[1].Text.Trim();
                string PromResponsable = DetailsView1.Rows[16].Cells[1].Text.Trim();
                string EstadoCarta = "Carta Aceptada";
                string EstadoCartaInstruccionNoAplica = "";
                string EstadoCartaInstruccionRechazo = "";
                string MotivoRechazo = "";
                string strEstado = "";
                IdMovimiento = int.Parse(strIdMovimiento);

                switch (TipoMovimiento.Trim())
                {
                    case "A":
                        EstadoCartaInstruccionNoAplica = "";
                        EstadoCartaInstruccionRechazo = "Procedió en Portal Alta/Modificación";
                        MotivoRechazo = "Procedió alta/modificación";
                        break;

                    case "M":
                        EstadoCartaInstruccionNoAplica = "";
                        EstadoCartaInstruccionRechazo = "Procedió en Portal Alta/Modificación";
                        MotivoRechazo = "Procedió alta/modificación";
                        break;

                    case "B":
                        EstadoCartaInstruccionNoAplica = "No Aplica";
                        EstadoCartaInstruccionRechazo = "Procedió en Portal Baja";
                        MotivoRechazo = "Procedió Baja";
                        break;
                }

                if (i.imssportal.tramites.ValidarMovimiento(IdMovimiento, 6, EstadoCartaInstruccionRechazo, MotivoRechazo) == 2)
                {
                    //tramites.AgregarConcentrado(strIdMovimiento, IdTramite, IdUsuario, Matricula, Importe, Poliza, PromOrigen, UsuarioServicio, PromUltimoSer, PromResponsable, TipoMovimiento, UnidadPago, TipoNomina, AnoQuincena, EstadoCarta, EstadoCartaInstruccionNoAplica, EstadoCartaInstruccionRechazo, MotivoRechazo, strEstado, Nombre);
                    mensajes.MostrarMensaje(this, "Trámite Procesado.", "ProcesarTramite.aspx");
                }
                else
                {
                    mensajes.MostrarMensaje(this, "No se pudo procesar el Trámite ");
                }
            }

        }

        protected void BtnRechazar_Click(object sender, EventArgs e)
        {
            BtnAceptar.Visible = false;
            BtnRechazar.Visible = false;
            BtnGuardarRechazo.Visible = true;
            comun.CargaRechazosValidacionImss(ref ddlRechazosValidacionesImss);
            ddlRechazosValidacionesImss.Visible = true;
        }

        protected void BtnGuardarRechazo_Click(object sender, EventArgs e)
        {
            int IdMovimiento = 0;
            string strRechazo1 = "";
            string strRechazo2 = "";

            lblMensaje.Visible = false;
            lblMensaje.Text = "";

            IdMovimiento = int.Parse(DetailsView1.Rows[0].Cells[1].Text.ToString());

            if (ddlRechazosValidacionesImss.SelectedIndex > 0)
                strRechazo2 = ddlRechazosValidacionesImss.Items[ddlRechazosValidacionesImss.SelectedIndex].Text.Trim();

            if (i.imssportal.tramites.ValidarMovimiento(IdMovimiento, 7, strRechazo1, strRechazo2) == 2)
            {
                mensajes.MostrarMensaje(this, "Trámite Rechazado.", "ProcesarTramite.aspx");
            }
            else
            {
                mensajes.MostrarMensaje(this, "No se pudo rechazar el Trámite.");
            }

        }











    }
}