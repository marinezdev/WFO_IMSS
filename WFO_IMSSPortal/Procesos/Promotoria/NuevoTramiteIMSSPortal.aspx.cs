using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

namespace WFO_IMSSPortal.Procesos.Promotoria
{
    public partial class NuevoTramiteIMSSPortal : Utilerias.Comun
    {
        public DataTable dt;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RegistrosTemporales"] = null;
                GVRegistros.DataSource = null;
                GVRegistros.DataBind();

                Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    if (Session["RegistrosTemporales"] == null)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("TipoNomina", typeof(string)).MaxLength = 2;         // [0] Tipo de Nomina
                        dt.Columns.Add("TipoMovimiento", typeof(string)).MaxLength = 1;     // [1] Tipo de Movimiento
                        dt.Columns.Add("AñoQuincena", typeof(string)).MaxLength = 6;        // [2] Año Quincena
                        dt.Columns.Add("Poliza", typeof(string)).MaxLength = 10;            // [3] Numero de Poliza
                        dt.Columns.Add("Unidad", typeof(string)).MaxLength = 10;            // [4] Unidad de Pago
                        dt.Columns.Add("Archivo", typeof(string)).MaxLength = 255;          // [5] Archivo => Carta de Instrucción
                        GVRegistros.DataSource = dt;
                        GVRegistros.DataBind();
                        Session["RegistrosTemporales"] = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Agregar("Problemas en la carga inicial en Procesos/frmFormatoEnvios: " + ex.Message);
                mensajes.MostrarMensaje(this, "Ha habido un error al iniciar la página, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            bool blnFaltaRequeridos = false;

            try
            {
                blnFaltaRequeridos = false;

                if (ddlTipoNomina.SelectedValue.ToString() == "")
                {
                    blnFaltaRequeridos = true;
                    lblTipoNomina.Visible = true;
                }
                else
                {
                    lblTipoNomina.Visible = false;
                }

                if (ddlTipoMovimiento.SelectedValue.ToString() == "")
                {
                    blnFaltaRequeridos = true;
                    lblTipoMovimiento.Visible = true;
                }
                else
                {
                    lblTipoMovimiento.Visible = false;
                }

                if (ddlAnnQuincena.SelectedValue.ToString() == "0")
                {
                    blnFaltaRequeridos = true;
                    lblAnnQuincena.Visible = true;
                }
                else
                {
                    lblAnnQuincena.Visible = false;
                }

                if (txtNoPoliza.Text.Trim() == "")
                {
                    blnFaltaRequeridos = true;
                    lblNoPoliza.Visible = true;
                }
                else
                {
                    lblNoPoliza.Visible = false;
                }

                if (txtUnidadPago.Text.Trim() == "")
                {
                    blnFaltaRequeridos = true;
                    lblUnidadPago.Visible = true;
                }
                else
                {
                    lblUnidadPago.Visible = false;
                }

                if (!blnFaltaRequeridos)
                {
                    GVComparador.DataSource = null;
                    GVComparador.DataBind();
                    BtnAceptar.Visible = true;
                    BtnGuardar.Visible = false;
                    lblResumeRegistros.Visible = false;
                    lblResumeRegistros.Text = "";

                    dt = (DataTable)Session["RegistrosTemporales"];
                    dt.Rows.Add(ddlTipoNomina.SelectedValue.ToString(), ddlTipoMovimiento.SelectedValue.ToString(), ddlAnnQuincena.SelectedValue.ToString(), txtNoPoliza.Text.Trim().PadLeft(10, '0'), txtUnidadPago.Text.Trim(), "[ Sin Archivo ]");

                    GVRegistros.DataSource = dt;
                    GVRegistros.DataBind();

                    Session["RegistrosTemporales"] = dt;

                    txtNoPoliza.Text = "";
                    txtUnidadPago.Text = "";
                    txtNoPoliza.Focus();
                }
            }
            catch (Exception ex)
            {
                log.Agregar("Problemas al tratar de agregar registro Procesos/frmFormatoEnvios: " + ex.Message);
                mensajes.MostrarMensaje(this, "Ha habido un error al tratar de agregar un registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //guardar los datos obtenidos
                //DataTable dtt = new DataTable();
                //dtt = (DataTable)Session["RegistrosTemporales"];
                //fen.GuardarDatos(ddlAnnQuincena.SelectedValue, ref dtt);

                Recargar();
            }
            catch (Exception ex)
            {
                log.Agregar("Problemas al tratar de guardar registro Procesos/frmFormatoEnvios: " + ex.Message);
                mensajes.MostrarMensaje(this, "Ha habido un error al tratar de guardar registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            DataTable ddtt = new DataTable();
            ddtt = (DataTable)Session["RegistrosTemporales"];
            string nombreArchivo = Path.GetFileName(e.FileName);
            string rutaArchivo = Server.MapPath("~/Archivos/" + nombreArchivo);
            bool blnExisteMovimiento = false;
            string archivoPoliza = "";

            try
            {
                lblUpload.Visible = false;

                if (ddtt is null)
                {
                    // No hay movimientos registrados...
                    //mensajes.MostrarMensaje(this, "No hay movimientos registrados...", "Default.aspx");
                    lblUpload.Text = "No hay movimientos registrados...";
                    lblUpload.Visible = true;
                    return;
                }

                if (ddtt.Rows.Count > 0)
                {
                    blnExisteMovimiento = false;
                    foreach (DataRow dr in ddtt.Rows)
                    {
                     
                        archivoPoliza = manejo_sesion.Usuarios.ClavePromotoria + "_" + dr[3].ToString().TrimStart(new Char[] { '0' }) + "_" + dr[4].ToString() + "_" + dr[2].ToString() + ".pdf";
                        if (archivoPoliza.ToUpper() == nombreArchivo.ToUpper())
                        {
                            blnExisteMovimiento = true;
                            dr[5] = nombreArchivo;
                        }
                    }

                    if (blnExisteMovimiento)
                    {
                        AjaxFileUpload1.SaveAs(Server.MapPath("~/Archivos/" + nombreArchivo));
                        Session["RegistrosTemporales"] = ddtt;

                        GVRegistros.DataSource = ddtt;
                        GVRegistros.DataBind();
                    }
                    else
                    {
                        // No se encontró el movimiento de la póliza asociada a la carta de instrucción.
                        mensajes.MostrarMensaje(this, "No se encontró el movimiento de la póliza asociada a la carta de instrucción.*/", "Default.aspx");
                        lblUpload.Text = "No se encontró el movimiento de la póliza asociada a la carta de instrucción.";
                        lblUpload.Visible = true;
                    }
                }
                else
                {
                    // No hay movimientos registrados...
                    //mensajes.MostrarMensaje(this, "No hay movimientos registrados...", "Default.aspx");
                    lblUpload.Text = "No hay movimientos registrados...";
                    lblUpload.Visible = true;
                }
            }
            catch (Exception ex)
            {
                log.AgregarError(ex.InnerException.ToString());
            }
        }

        protected void GVRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Literal ltrlNomina = (Literal)GVRegistros.Rows[index].FindControl("ltrlNomina");
                Literal ltrlTipoMovimiento = (Literal)GVRegistros.Rows[index].FindControl("ltrlTipoMovimiento");
                Literal ltrlAnoQuincena = (Literal)GVRegistros.Rows[index].FindControl("ltrlAnoQuincena");
                Literal ltrlPoliza = (Literal)GVRegistros.Rows[index].FindControl("ltrlPoliza");
                Literal ltrlUnidadPago = (Literal)GVRegistros.Rows[index].FindControl("ltrlUnidadPago");
                Literal ltrlArchivo = (Literal)GVRegistros.Rows[index].FindControl("ltrlArchivo");

                dt = (DataTable)Session["RegistrosTemporales"];
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if (
                        dr["TipoNomina"].ToString() == ltrlNomina.Text
                        && dr["TipoMovimiento"].ToString() == ltrlTipoMovimiento.Text
                        && dr["AñoQuincena"].ToString() == ltrlAnoQuincena.Text
                        && dr["Poliza"].ToString() == ltrlPoliza.Text
                        && dr["Unidad"].ToString() == ltrlUnidadPago.Text
                        && dr["Archivo"].ToString() == ltrlArchivo.Text
                    )
                    {
                        dr.Delete();
                    }

                }
                dt.AcceptChanges();
                Session["RegistrosTemporales"] = dt;
                GVRegistros.DataSource = dt;
                GVRegistros.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + ltrlTipoMovimiento.Text + "');", true);
            }
        }

        protected void Recargar()
        {
            DataTable dtMovimientos = new DataTable();
            string archivoPoliza = "";
            bool blnError = false;
            dtMovimientos = (DataTable)Session["RegistrosTemporales"];

            // Recorremos todos los movimientos para verificar que existen cartas de Instrucción.
            blnError = false;
            foreach (DataRow dr in dtMovimientos.Rows)
            {
                archivoPoliza = manejo_sesion.Usuarios.ClavePromotoria + "_" + dr[3].ToString().TrimStart(new Char[] { '0' }) + "_" + dr[4].ToString() + "_" + dr[2].ToString() + ".pdf";
                if (archivoPoliza.ToUpper() != dr[5].ToString().ToUpper())
                {
                    blnError = true;
                }
            }

            if (!blnError)
            {
                lblAceptar.Visible = false;
                BtnAceptar.Visible = false;

                lblResumeRegistros.Text = "Total de Cartas: " + dtMovimientos.Rows.Count.ToString();
                lblResumeRegistros.Visible = true;

                BtnGuardar.Visible = true;
                GVComparador.DataSource = dtMovimientos;
                GVComparador.DataBind();
                GVRegistros.DataSource = null;
                GVRegistros.DataBind();
            }
            else
            {
                lblAceptar.Visible = true;
                GVRegistros.DataSource = dtMovimientos;
                GVRegistros.DataBind();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Guarda la tabla
            int IdTipoTramite = 1;  // TODO: ### Pendiente: El parámttro deberá ser automátizado.
            int IdTramite = 0;
            string Folio = "";

            //IdTramite = fen.TramiteNuevo(ref Folio, IdTipoTramite, manejo_sesion.Usuarios.IdUsuario, manejo_sesion.Usuarios.IdPromotoria);
            //if (IdTramite != -1)
            //{
            //    DataTable dt = new DataTable();
            //    dt = (DataTable)Session["RegistrosTemporales"];
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        fen.AgregarCartas(IdTramite, dr[5].ToString(), "Archivo", dr[3].ToString(), dr[0].ToString(), dr[1].ToString(), dr[4].ToString(), dr[2].ToString());
            //        // fen.GuardarRegistrosFinalesValidados(ref IdTramite, manejo_sesion.Usuarios.IdUsuario, manejo_sesion.Usuarios.IdPromotoria, dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), ref strFolio);
            //    }
            //    mensajes.MostrarMensaje(this, "Se guardaron los datos exitosamente. Folio: " + Folio, "ListarTramites.aspx");
            //}
            //else
            //{
            //    mensajes.MostrarMensaje(this, "NO SE PUDÓ GUARDAR LA SOLICITUD DEL TRÁMITE. !!!");
            //}
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            bool blnFaltaRequeridos = false;

            if (ddlTipoNomina.SelectedValue.ToString() == "")
            {
                blnFaltaRequeridos = true;
                lblTipoNomina.Visible = true;
            }
            else
            {
                lblTipoNomina.Visible = false;
            }

            if (ddlTipoMovimiento.SelectedValue.ToString() == "")
            {
                blnFaltaRequeridos = true;
                lblTipoMovimiento.Visible = true;
            }
            else
            {
                lblTipoMovimiento.Visible = false;
            }

            if (ddlAnnQuincena.SelectedValue.ToString() == "0")
            {
                blnFaltaRequeridos = true;
                lblAnnQuincena.Visible = true;
            }
            else
            {
                lblAnnQuincena.Visible = false;
            }

            if (!blnFaltaRequeridos)
            {
                DataTable dtImport = null;
                string Poliza = "";
                string UnidadPago = "";

                btnImportar.Enabled = false;
                BtnAgregar.Enabled = false;

                GVComparador.DataSource = null;
                GVComparador.DataBind();
                dt = (DataTable)Session["RegistrosTemporales"];

                ExcelPackage pagina = new ExcelPackage(AsyncFileUpload1.FileContent);
                dtImport = i.imssportal.extraccion.ProcesarExcelPromotoria(pagina);

                foreach (DataRow row in dtImport.Rows)
                {
                    Poliza = row[2].ToString();
                    UnidadPago = row[3].ToString();
                    dt.Rows.Add(ddlTipoNomina.SelectedValue.ToString(), ddlTipoMovimiento.SelectedValue.ToString(), ddlAnnQuincena.SelectedValue.ToString(), Poliza.Trim().PadLeft(10, '0'), UnidadPago, "[ Sin Archivo ]");
                }

                btnImportar.Enabled = false;
                BtnAgregar.Enabled = false;

                BtnAceptar.Visible = true;
                BtnGuardar.Visible = false;
                lblResumeRegistros.Visible = false;
                lblResumeRegistros.Text = "";


                GVRegistros.DataSource = dt;
                GVRegistros.DataBind();

                Session["RegistrosTemporales"] = dt;
            }

            lblProcesadoExcel.Text = "Se procesó el archivo exitosamente.";
            lblProcesadoExcel.ForeColor = System.Drawing.Color.Blue;
        }

        protected void ddlAnnQuincena_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //// string message = ddlAnnQuincena.SelectedItem.Text + " - " + ddlAnnQuincena.SelectedItem.Value;
            //lblAnnQuincena.Text = "";
            //lblAnnQuincena.Visible = false;
            //bool blnJubilados = false;

            //btnImportar.Enabled = true;
            //BtnAgregar.Enabled = true;
            //BtnAceptar.Enabled = true;
            //BtnGuardar.Enabled = true;

            ////if (ddlAnnQuincena.SelectedItem.Value.ToString() == "201904")
            ////    return;

            //if (ddlTipoNomina.SelectedValue.ToString().ToUpper() == "J")
            //    blnJubilados = true;

            //if (!fen.ValidarQuincena(ddlAnnQuincena.SelectedItem.Value.ToString(), blnJubilados))
            //{
                lblAnnQuincena.Text = "Quincena no habilitada.";
                lblAnnQuincena.Visible = true;
                btnImportar.Enabled = false;
                BtnAgregar.Enabled = false;
                BtnAceptar.Enabled = false;
                BtnGuardar.Enabled = false;
            //}
        }
    }
}