using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ActualizarCarta : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                comun.CargaInicialdllTipoNomina(ref ddlTipoNomina);
                Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlMesa, i.operacion.mesas.MesasPorUsuario(manejo_sesion.Usuarios.IdUsuario, 3), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlStatusMesa, i.operacion.mesas.MesasStatus(3), "Nombre", "Id");
            }
        }

        protected void ddlMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMotivoRechazo.DataSource = null;
            ddlMotivoRechazo.DataBind();
            ddlStatusMesa.SelectedIndex = -1;

            grid.DataSource = null;
            grid.DataBind();

            grdResultados.DataSource = null;
            grdResultados.DataBind();
        }


        protected void ddlStatusMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string TipoNomina = "";
                string Quincena = "";
                string Poliza = "";
                string Mesa = "";
                string StatusMesa = "";

                lblBuscar.Text = "";
                lblBuscar.Visible = false;
                lblProcesarTramite.Text = "";
                lblProcesarTramite.Visible = false;


                TipoNomina = ddlTipoNomina.SelectedValue.ToString();
                Quincena = ddlAnnQuincena.SelectedValue.ToString();
                Poliza = txtPoliza.Text.Trim();


                if (Poliza.Length <= 4 || TipoNomina == "00" || Quincena == "00")
                {
                    lblBuscar.Text = "Debe indicar el tipo de nomina, quincena y poliza";
                    lblBuscar.Visible = true;
                }
                else
                {
                    Mesa = ddlMesa.SelectedValue.ToString();
                    StatusMesa = ddlStatusMesa.SelectedValue.ToString();

                    if (Mesa == "0")
                    {
                        lblProcesarTramite.Text = "Debe seleccionar una mesa.";
                        lblProcesarTramite.Visible = true;
                    }
                    else
                    {
                        if (StatusMesa == "18")
                            Funciones.LlenarControles.LlenarDropDownList(ref ddlMotivoRechazo, i.operacion.mesas.MesasMotivosRechazo(3, int.Parse(Mesa)), "Nombre", "Id");
                        else
                        {
                            ddlMotivoRechazo.DataSource = null;
                            ddlMotivoRechazo.DataBind();
                        }
                    }
                }

            }
            catch (Exception)
            {
                //log.Agregar(ex);
                //mensajes.MostrarMensaje(this, "Ha habido un error al tratar de mostrar los registros, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }

        }

        protected void btnProcesaMesa_Click(object sender, EventArgs e)
        {
            try
            {
                string Mensaje = "";
                string TipoNomina = "";
                string Quincena = "";
                string Poliza = "";
                string Mesa = "";
                string StatusMesa = "";
                string MotivoRechazo = "0";

                lblBuscar.Text = "";
                lblBuscar.Visible = false;
                lblProcesarTramite.Text = "";
                lblProcesarTramite.Visible = false;

                grid.DataSource = null;
                grid.DataBind();
                grdResultados.DataSource = null;
                grdResultados.DataBind();

                TipoNomina = ddlTipoNomina.SelectedValue.ToString();
                Quincena = ddlAnnQuincena.SelectedValue.ToString();
                Poliza = txtPoliza.Text.Trim();
                Mesa = ddlMesa.SelectedValue.ToString();
                StatusMesa = ddlStatusMesa.SelectedValue.ToString();

                if (StatusMesa == "18")
                {
                    MotivoRechazo = ddlMotivoRechazo.SelectedValue.ToString();
                    if (MotivoRechazo == "0")
                    {
                        Mensaje += "Debe indicar el Motivo de Rechazo que será asignado.";
                    }
                }

                if (Mensaje.Length > 0)
                {
                    lblProcesarTramite.Text = Mensaje;
                    lblProcesarTramite.Visible = true;
                }
                else
                {
                    DataTable dtResultado = i.operacion.mesas.ProcesoManualTramite(TipoNomina, Quincena, Poliza, int.Parse(Mesa), int.Parse(StatusMesa), int.Parse(MotivoRechazo), manejo_sesion.Usuarios.IdUsuario);
                    grdResultados.DataSource = dtResultado;
                    grdResultados.DataBind();
                    grdResultados.Visible = true;

                    BtnExcelAceptar_Click(sender, e);
                }

                //if (Poliza.Length <= 4 || TipoNomina == "00" || Quincena == "00")
                //{
                //    lblBuscar.Text = "Debe indicar el tipo de nomina, quincena y poliza";
                //    lblBuscar.Visible = true;
                //}
                //else
                //{


                //    if (Mesa == "0")
                //    {
                //        lblProcesarTramite.Text = "Debe seleccionar una mesa.";
                //        lblProcesarTramite.Visible = true;
                //    }
                //    else
                //    {
                //        if (StatusMesa == "18")
                //            Funciones.LlenarControles.LlenarDropDownList(ref ddlMotivoRechazo, i.operacion.mesas.MesasMotivosRechazo(3, int.Parse(Mesa)), "Nombre", "Id");
                //        else
                //        {
                //            ddlMotivoRechazo.DataSource = null;
                //            ddlMotivoRechazo.DataBind();
                //        }
                //    }
                //}

            }
            catch (Exception ex)
            {
                //log.Agregar(ex);
                //mensajes.MostrarMensaje(this, "Ha habido un error al tratar de mostrar los registros, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void BtnExcelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string TipoNomina = "";
                string Quincena = "";
                string Poliza = "";

                lblBuscar.Text = "";
                lblBuscar.Visible = false;
                grid.DataSource = null;
                grid.DataBind();
                grdResultados.DataSource = null;
                grdResultados.DataBind();

                TipoNomina = ddlTipoNomina.SelectedValue.ToString();
                Quincena = ddlAnnQuincena.SelectedValue.ToString();
                Poliza = txtPoliza.Text.Trim();

                if (Poliza.Length <= 4 || TipoNomina == "00" || Quincena == "00")
                {
                    lblBuscar.Text = "Debe indicar el tipo de nomina, quincena y poliza";
                    lblBuscar.Visible = true;
                }
                else
                {
                    DataTable dtTramiteProcesado = i.imssportal.extraccion.ObtenerTramiteProcesado(TipoNomina, Quincena, Poliza);

                    if (dtTramiteProcesado.Rows.Count > 0)
                    {
                        grid.DataSource = dtTramiteProcesado;
                        grid.DataBind();
                        grid.Visible = true;
                    }
                    else
                    {
                        lblBuscar.Text = "Póliza no encontrada.";
                        lblBuscar.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                //GVExtraccion.DataSource = null;
                //GVExtraccion.DataBind();
                //grid.DataSource = null;
                //grid.DataBind();
                //lblProcesadoExcel.Text = "No se pudo guardar el archivo. " + ex.Message;
                //lblProcesadoExcel.ForeColor = System.Drawing.Color.Red;
                //log.AgregarError(ex.Message.ToString());
            }
        }

        protected void grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
        }
    }
}