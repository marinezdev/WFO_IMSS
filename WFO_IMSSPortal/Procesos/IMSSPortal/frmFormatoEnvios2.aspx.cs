using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class frmFormatoEnvios2 : Utilerias.Comun
    {
        public DataTable dtMovPromotoria;
        public DataTable dtMovExtraccion;

        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                Session["RegistrosTemporales"] = null;
                Session["RegistrosTemporalesExtraccion"] = null;
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
                        dtMovPromotoria = new DataTable();
                        dtMovPromotoria.Columns.Add("TipoNomina", typeof(string)).MaxLength = 2;         // [0] Tipo de Nomina
                        dtMovPromotoria.Columns.Add("TipoMovimiento", typeof(string)).MaxLength = 1;     // [1] Tipo de Movimiento
                        dtMovPromotoria.Columns.Add("AñoQuincena", typeof(string)).MaxLength = 6;        // [2] Año Quincena
                        dtMovPromotoria.Columns.Add("Poliza", typeof(string)).MaxLength = 10;            // [3] Numero de Poliza
                        dtMovPromotoria.Columns.Add("Unidad", typeof(string)).MaxLength = 10;            // [4] Unidad de Pago
                        dtMovPromotoria.Columns.Add("Archivo", typeof(string)).MaxLength = 255;          // [5] Archivo => Carta de Instrucción
                        //dtMovPromotoria.Columns.Add("Importe", typeof(string)).MaxLength = 10;         // [6] Importe
                        dtMovPromotoria.Columns.Add("Observacion", typeof(string)).MaxLength = 1000;     // [7] Observación

                        //dtMovPromotoria.Columns.Add("IdTramite", typeof(int));                           // [8] Observación
                        //dtMovPromotoria.Columns.Add("IdStatusMesa_Revision", typeof(int));               // [9] Observación
                        //dtMovPromotoria.Columns.Add("IdStatusMesa_Control", typeof(int));               // [10] Observación
                        GVRegistros.DataSource = dtMovPromotoria;
                        GVRegistros.DataBind();
                        Session["RegistrosTemporales"] = dtMovPromotoria;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
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

                if (txtUnidadPago.Text.Trim() == "")
                {
                    blnFaltaRequeridos = true;
                    lblImporte.Visible = true;
                }
                else
                {
                    lblImporte.Visible = false;
                }

                if (!blnFaltaRequeridos)
                {
                    GVComparador.DataSource = null;
                    GVComparador.DataBind();
                    BtnAceptar.Visible = true;
                    BtnGuardar.Visible = false;
                    lblResumeRegistros.Visible = false;
                    lblResumeRegistros.Text = "";

                    dtMovPromotoria = (DataTable)Session["RegistrosTemporales"];
                    dtMovPromotoria.Rows.Add(ddlTipoNomina.SelectedValue.ToString(), ddlTipoMovimiento.SelectedValue.ToString(), ddlAnnQuincena.SelectedValue.ToString(), txtNoPoliza.Text.Trim().PadLeft(10, '0'), txtUnidadPago.Text.Trim(), "[ Sin Archivo ]", txtImporte.Text.Trim());

                    GVRegistros.DataSource = dtMovPromotoria;
                    GVRegistros.DataBind();

                    Session["RegistrosTemporales"] = dtMovPromotoria;

                    txtNoPoliza.Text = "";
                    txtUnidadPago.Text = "";
                    txtImporte.Text = "";
                    txtNoPoliza.Focus();
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al tratar de agregar un registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //guardar los datos obtenidos en la tabla correspondiente.
                //DataTable dtt = new DataTable();
                //dtt = (DataTable)Session["RegistrosTemporales"];
                //fen.GuardarDatos(ddlAnnQuincena.SelectedValue, ref dtt);

                Recargar();
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al tratar de guardar registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            DataTable dtMovimientosAdd = new DataTable();
            DataTable dtExtraccion = new DataTable();
            dtExtraccion = (DataTable)Session["RegistrosTemporalesExtraccion"];
            dtMovimientosAdd = (DataTable)Session["RegistrosTemporales"];
            string nombreArchivo = Path.GetFileName(e.FileName);
            bool blnExisteMovimiento = false;
            string strArchivoPoliza = "";
            string strPoliza = "";
            //string rutaArchivosTemporaly = Server.MapPath("~/ArchivosTemporales/") + DateTime.Now.ToString("yyMMdd") + manejo_sesion.Usuarios.ClavePromotoria;
            int IdTramite = 0;
            int IdStatusMesa_Revision = 0;
            int IdStatusMesa_Control = 0;
            int IdStatusMesa_Portal = 0;
            string strPolizaAgrgada = "";
            //string rutaArchivo = Server.MapPath("~/ArchivosTemporales/" + nombreArchivo);

            try
            {
                lblUpload.Visible = false;

                if (dtMovimientosAdd is null)
                {
                    // No hay movimientos registrados...
                    //mensajes.MostrarMensaje(this, "No hay movimientos registrados...", "Default.aspx");
                    lblUpload.Text = "No hay movimientos registrados...";
                    lblUpload.Visible = true;
                    return;
                }

                if (dtMovimientosAdd.Rows.Count > 0)
                {
                    blnExisteMovimiento = false;
                    foreach (DataRow dr in dtMovimientosAdd.Rows)
                    {
                        strArchivoPoliza = manejo_sesion.Usuarios.ClavePromotoria + "_" + dr[3].ToString().TrimStart(new Char[] { '0' }) + "_" + dr[4].ToString() + "_" + dr[2].ToString() + ".pdf";
                        if (strArchivoPoliza.ToUpper() == nombreArchivo.ToUpper())
                        {
                            blnExisteMovimiento = true;
                            dr[5] = nombreArchivo;
                            strPoliza = dr[3].ToString();
                            Session["RegistrosTemporales"] = dtMovimientosAdd;
                            break;
                        }
                    }

                    if (blnExisteMovimiento)
                    {
                        //if (!Directory.Exists(rutaArchivosTemporaly))
                        //{
                        //    Directory.CreateDirectory(rutaArchivosTemporaly);
                        //}

                        //// ### Pendiente: Verificar como evitar que se suban cartas duplicadas (disminuir el trafico de red)
                        //AjaxFileUpload1.SaveAs(rutaArchivosTemporaly + nombreArchivo);
                        //AjaxFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));

                        //Verificamos si la carta no existe dentro del sistema o si cuenta con rechazo para agregarla nuevamente...
                        DataView dvMovimiento = new DataView(dtExtraccion, "POLIZA LIKE '%" + strPoliza + "%'", "POLIZA", DataViewRowState.CurrentRows);
                        if (dvMovimiento.Count > 0)
                        {
                            foreach (DataRowView row in dvMovimiento)
                            {
                                IdTramite = int.Parse(row["IDTRAMITE"].ToString());
                                IdStatusMesa_Revision = int.Parse(row["IDSTATUSREVISION"].ToString());
                                IdStatusMesa_Control = int.Parse(row["IDSTATUSCONTROL"].ToString());
                                IdStatusMesa_Portal = int.Parse(row["IDSTATUSPORTAL"].ToString());

                                if (IdTramite == 0)
                                {
                                    // ### Pendiente: Verificar como evitar que se suban cartas duplicadas (disminuir el trafico de red)
                                    //AjaxFileUpload1.SaveAs(rutaArchivosTemporaly + nombreArchivo);

                                    if (strPolizaAgrgada != strPoliza)
                                    {
                                        AjaxFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));
                                        log.AgregarError("Archivo ingresado: " + Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));

                                        //File.Copy(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo), rutaArchivosTemporaly + @"\" + nombreArchivo, true);
                                    }
                                    strPolizaAgrgada = strPoliza;

                                    Session["RegistrosTemporales"] = dtMovimientosAdd;
                                    GVRegistros.DataSource = dtMovimientosAdd;
                                    GVRegistros.DataBind();
                                }
                                else
                                {
                                    if (
                                        (IdStatusMesa_Revision == 18 && IdStatusMesa_Control == 18)
                                        ||
                                        (IdStatusMesa_Portal == 18)
                                        ||
                                        (IdStatusMesa_Portal == 17)
                                    )
                                    {
                                        // ### Pendiente: Verificar como evitar que se suban cartas duplicadas (disminuir el trafico de red)
                                        //AjaxFileUpload1.SaveAs(rutaArchivosTemporaly + nombreArchivo);

                                        if (strPolizaAgrgada != strPoliza)
                                        {
                                            AjaxFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));
                                            log.AgregarError("Archivo reingresado: " + Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));
                                            //File.Copy(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo), rutaArchivosTemporaly + @"\" + nombreArchivo, true);
                                        }
                                        strPolizaAgrgada = strPoliza;

                                        Session["RegistrosTemporales"] = dtMovimientosAdd;
                                        GVRegistros.DataSource = dtMovimientosAdd;
                                        GVRegistros.DataBind();
                                    }
                                }

                            }
                        }
                        else
                        {
                            // El movimiento no se encontró en la extracción. por lo que no se realizará la carga del Archivo
                            //////// ### Pendiente: Verificar como evitar que se suban cartas duplicadas (disminuir el trafico de red)
                            ////////AjaxFileUpload1.SaveAs(rutaArchivosTemporaly + nombreArchivo);
                            //////AjaxFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));
                            //////File.Copy(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo), rutaArchivosTemporaly + @"\" + nombreArchivo);
                            //////Session["RegistrosTemporales"] = dtMovimientosAdd;
                            //////GVRegistros.DataSource = dtMovimientosAdd;
                            //////GVRegistros.DataBind();

                            //////mensajes.MostrarMensaje(this, "No se encontró el movimiento de la póliza asociada a la carta de instrucción.*/", "Default.aspx");
                            //////lblUpload.Text = "No se encontró el movimiento de la póliza asociada a la carta de instrucción.";
                            //////lblUpload.Visible = true;
                        }
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
                log.Agregar(ex);
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
                //Literal ltrlImporte = (Literal)GVRegistros.Rows[index].FindControl("ltrlImporte");

                dtMovPromotoria = (DataTable)Session["RegistrosTemporales"];
                for (int i = dtMovPromotoria.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtMovPromotoria.Rows[i];
                    if (
                        dr["TipoNomina"].ToString() == ltrlNomina.Text
                        && dr["TipoMovimiento"].ToString() == ltrlTipoMovimiento.Text
                        && dr["AñoQuincena"].ToString() == ltrlAnoQuincena.Text
                        && dr["Poliza"].ToString() == ltrlPoliza.Text
                        && dr["Unidad"].ToString() == ltrlUnidadPago.Text
                        && dr["Archivo"].ToString() == ltrlArchivo.Text
                    //&& dr["Importe"].ToString() == ltrlImporte.Text
                    )
                    {
                        dr.Delete();
                    }

                }
                dtMovPromotoria.AcceptChanges();
                Session["RegistrosTemporales"] = dtMovPromotoria;
                GVRegistros.DataSource = dtMovPromotoria;
                GVRegistros.DataBind();
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('" + ltrlTipoMovimiento.Text + "');", true);
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<Propiedades.Procesos.Promotoria.RespuestaNuevoTramiteN1> respuesta = new List<Propiedades.Procesos.Promotoria.RespuestaNuevoTramiteN1>();

            try
            {
                // Guarda la tabla
                int IdTramite = 0;
                string strFolio = "NA";
                string ruta = Server.MapPath("~/ArchivosTemporales/");
                string rutaPDF = Server.MapPath("~/PDF/");
                string rutaPDFBackUp = Server.MapPath("~/PDF/BCK/");
                string archivo = "";
                string archivonombre = "";
                DataTable dt = new DataTable();
                dt = (DataTable)Session["RegistrosTemporales"];

                foreach (DataRow dr in dt.Rows)
                {
                    // mensajes.MostrarMensaje(this, dr["Archivo"].ToString(), "frmFormatoEnvios.aspx");
                    archivonombre = dr["Archivo"].ToString();
                    archivo = ruta + dr["Archivo"].ToString();
                    if (File.Exists(archivo))
                    {
                        //guardar
                        FileStream fStream = File.OpenRead(archivo);
                        byte[] contenido = new byte[fStream.Length];
                        fStream.Read(contenido, 0, (int)fStream.Length);
                        fStream.Close();

                        Propiedades.Procesos.Promotoria.TramiteN1 tramiten1 = new Propiedades.Procesos.Promotoria.TramiteN1();

                        //Archivo
                        tramiten1.IdTipoArchivo = 1;
                        tramiten1.Archivo = contenido;
                        tramiten1.NombreArchivo = archivonombre;

                        //Tramite
                        tramiten1.IdTipoTramite = 3; //anterior 1
                        tramiten1.IdStatus = 1;
                        tramiten1.IdPromotoria = manejo_sesion.Usuarios.IdPromotoria;
                        tramiten1.IdUsuario = manejo_sesion.Usuarios.IdUsuario;
                        tramiten1.idPrioridad = 5;          // ###Pendiente: Obtener información del enumerado para poder visualizar mejor el código.

                        //Nuevo
                        tramiten1.Poliza = dr[3].ToString().PadLeft(10, '0');
                        tramiten1.TipoNomina = dr[0].ToString();
                        tramiten1.TipoMovimiento = dr[1].ToString();
                        tramiten1.UnidadPago = dr[4].ToString();
                        tramiten1.Quincena = ddlAnnQuincena.SelectedValue;
                        //tramiten1.Importe = "0"; // dr[6].ToString();

                        //Todo el proceso en un stored procedure
                        respuesta.AddRange(i.promotoria.tramiten1.NuevoTramiteN1(tramiten1, contenido));

                        // Movemos el Archivo a la carpeta PDF
                        try
                        {
                            File.Copy(archivo, rutaPDFBackUp + DateTime.Now.ToString("yyMMddHHmmss") + "_" + manejo_sesion.Usuarios.IdUsuario.ToString() + archivonombre, true);
                            if (File.Exists(rutaPDF + archivonombre))
                            {
                                File.Delete(rutaPDF + archivonombre);
                            }

                            File.Move(archivo, rutaPDF + archivonombre);

                            //borrar el archivo fisicamente
                            File.Delete(archivo);
                        }
                        catch (Exception ex)
                        {
                            i.promotoria.tramiten1.LogError("ERROR", "99999", "CRÍTICO", "SIN RESOLVER", "PROMOTORÍA. TRÁMITE NUEVO V2", "POR DEFINIR", "Ocurrio un error con el archivo: " + rutaPDF + archivonombre);
                            log.Agregar("Ocurrio un error con el archivo: " + rutaPDF + archivonombre);
                            log.Agregar(ex);
                            string strError = ex.Message.ToString();
                        }
                    }
                    else
                    {
                        mensajes.MostrarMensaje(this, "No se pudo encontrar la carta asociada.", "Default.aspx");
                        lblUpload.Text = "No se pudo encontrar la carta asociada.";
                        lblUpload.Visible = true;

                        i.promotoria.tramiten1.LogError("ERROR", "99999", "CRÍTICO", "SIN RESOLVER", "PROMOTORÍA. TRÁMITE NUEVO V2", "POR DEFINIR", "ADVERTENCIA: No se encontró el archivo " + archivo);
                        log.Agregar("ADVERTENCIA: No se encontró el archivo " + archivo);
                        return;
                    }
                }

                //mensajes.MostrarMensaje(this, "Se guardaron los datos exitosamente. Folio: " + string.Format("{0:0000000000}", IdTramite), "ListarTramites.aspx");
                var x = respuesta;
                for (int ii = 0; ii < respuesta.Count; ii++)
                {
                    seguimiento.Seguimiento("Se agregaron los siguientes registros: \r" + respuesta[ii].Id + "|" + respuesta[ii].Folio + "|" + respuesta[ii].DescError + "\r");
                }
                mensajes.MostrarMensaje(this, "Se guardaron los datos exitosamente.", "Default.aspx");
            }
            catch (Exception ex)
            {
                string _errormessage = "";

                for (int ii = 0; ii < respuesta.Count; ii++)
                {
                    _errormessage = "Hubo un error pero se agregaron los siguientes registros: \r" + respuesta[ii].ToString() + "|" + respuesta[ii].ToString() + "|" + respuesta[ii].ToString() + "\r";

                    i.promotoria.tramiten1.LogError("WARNING", "99999", "CRÍTICO", "SIN RESOLVER", "PROMOTORÍA. TRÁMITE NUEVO V2", "POR DEFINIR. ERROR GENERAL", _errormessage);
                    seguimiento.Seguimiento(_errormessage);
                }

                i.promotoria.tramiten1.LogError("ERROR", "99999", "CRÍTICO", "SIN RESOLVER", "PROMOTORÍA. TRÁMITE NUEVO V2", "POR DEFINIR. ERROR GENERAL", ex.Message);
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, ex.Message.ToString(), "Default.aspx");
            }
            }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            bool blnFaltaRequeridos = false;
            string strTipoNomina = "";
            string strTipoMovimiento = "";
            string strQuincenaSeleccionada = "";
            string strPromotoria = "";
            string strPoliza = "";
            string strUnidadPago = "";
            string strQuincena = "";
            //string strImporte = "";


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

            try
            {
                if (!blnFaltaRequeridos)
                {
                    DataTable dtImport = null;

                    btnImportar.Enabled = false;
                    BtnAgregar.Enabled = false;

                    GVComparador.DataSource = null;
                    GVComparador.DataBind();
                    dtMovPromotoria = (DataTable)Session["RegistrosTemporales"];

                    ExcelPackage pagina = new ExcelPackage(AsyncFileUpload1.FileContent);
                    dtImport = i.imssportal.extraccion.ProcesarExcelPromotoria(pagina);

                    //AjaxFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/"));
                    AsyncFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/" + AsyncFileUpload1.FileName));

                    // Obtenemos configuración de viables...
                    strTipoNomina = ddlTipoNomina.SelectedValue.ToString();
                    strTipoMovimiento = ddlTipoMovimiento.SelectedValue.ToString();
                    strQuincenaSeleccionada = ddlAnnQuincena.SelectedValue.ToString();

                    foreach (DataRow row in dtImport.Rows)
                    {
                        strPromotoria = row[1].ToString();
                        strPoliza = row[2].ToString();
                        strUnidadPago = row[3].ToString();
                        strQuincena = row[4].ToString();
                        //strImporte = row[5].ToString();

                        //dtMovPromotoria.Rows.Add(strTipoNomina, strTipoMovimiento, strQuincenaSeleccionada, strPoliza, strUnidadPago, "", strImporte.Replace(",", ""), "");
                        dtMovPromotoria.Rows.Add(strTipoNomina, strTipoMovimiento, strQuincenaSeleccionada, strPoliza, strUnidadPago, "", "");
                    }

                    //btnImportar.Enabled = false;
                    BtnAgregar.Enabled = true;

                    BtnAceptar.Visible = true;
                    BtnGuardar.Visible = false;
                    lblResumeRegistros.Visible = false;
                    lblResumeRegistros.Text = "";

                    GVRegistros.DataSource = dtMovPromotoria;
                    GVRegistros.DataBind();
                    Session["RegistrosTemporales"] = dtMovPromotoria;
                }

                lblProcesadoExcel.Text = "Se procesó el archivo exitosamente.";
                lblProcesadoExcel.ForeColor = System.Drawing.Color.Blue;
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                lblProcesadoExcel.ForeColor = System.Drawing.Color.Red;
                lblProcesadoExcel.Text = "Error en el archivo que se intenta procesar o no es el indicado.";
            }
        }

        protected void ddlAnnQuincena_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string strTipoNomina = ddlTipoNomina.SelectedValue.ToString().ToUpper();
            string strTipoMovimiento = ddlTipoMovimiento.SelectedValue.ToString().ToUpper();
            string strQuincena = ddlAnnQuincena.SelectedItem.Value.ToString();

            // Inicializamos controles.
            btnImportar.Enabled = false;
            BtnAgregar.Enabled = false;
            BtnAceptar.Enabled = false;
            BtnGuardar.Enabled = false;

            lblAnnQuincena.Text = "";
            lblAnnQuincena.Visible = false;

            // Validamos datos requeridos.
            if (strTipoNomina == "" || strTipoMovimiento == "" || strQuincena == "")
            {
                lblAnnQuincena.Text = "No seleccionó la información requerida.";
                lblAnnQuincena.Visible = true;
                ddlAnnQuincena.SelectedIndex = -1;
            }
            else
            {
                if (!i.imssportal.formatoenvios.ValidarQuincena(strQuincena, strTipoNomina))
                {
                    lblAnnQuincena.Text = "Quincena no habilitada.";
                    lblAnnQuincena.Visible = true;
                    btnImportar.Enabled = false;
                    BtnAgregar.Enabled = false;
                    BtnAceptar.Enabled = false;
                    BtnGuardar.Enabled = false;
                }
                else
                {
                    // Cargamos los movimientos de Extracción disponibles al momento.
                    dtMovExtraccion = i.imssportal.tramites.ObtenerExtraccion_dt(manejo_sesion.Usuarios.ClavePromotoria, strQuincena, strTipoNomina, strTipoMovimiento);
                    if (dtMovExtraccion.Rows.Count == 0)
                    {
                        lblAnnQuincena.Text = "No existen movimientos para la quincena seleccionada.";
                        lblAnnQuincena.Visible = true;
                        btnImportar.Enabled = false;
                        BtnAgregar.Enabled = false;
                        BtnAceptar.Enabled = false;
                        BtnGuardar.Enabled = false;
                    }

                    // Habilitamos controles.
                    Session["RegistrosTemporalesExtraccion"] = dtMovExtraccion;
                    btnImportar.Enabled = true;
                    BtnAgregar.Enabled = true;
                    BtnAceptar.Enabled = true;
                    BtnGuardar.Enabled = true;
                }
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
                string strFiltro = "";
                dtMovExtraccion = (DataTable)Session["RegistrosTemporalesExtraccion"];

                archivoPoliza = manejo_sesion.Usuarios.ClavePromotoria + "_" + dr[3].ToString().TrimStart(new Char[] { '0' }) + "_" + dr[4].ToString() + "_" + dr[2].ToString() + ".pdf";
                if (archivoPoliza.ToUpper() != dr[5].ToString().ToUpper())
                {
                    blnError = true;
                    lblAceptar.Text += "     Archivos no coinciden";
                }

                // [0] Tipo de Nomina
                // [1] Tipo de Movimiento
                // [2] Año Quincena
                // [3] Numero de Poliza
                // [4] Unidad de Pago
                // [5] Archivo => Carta de Instrucción
                // [6] Importe
                // [7] Observaciones

                // Generamos el filtro
                strFiltro += " POLIZA = '" + dr[3].ToString().PadLeft(10, '0') + "' ";
                strFiltro += " AND TIPO_MOVIMIENTO = '" + dr[1].ToString() + "' ";
                strFiltro += " AND TIPO_NOMINA = '" + dr[0].ToString() + "' ";
                strFiltro += " AND (UNIDAD_PAGO = '" + dr[4].ToString() + "' OR UNIDAD_PAGO = '" + dr[4].ToString().Substring(1,2) + "') ";
                //strFiltro += " AND IMPORTE = '" + dr[6].ToString() + "' "; 

                // Verificamos si existe el movimiento en MetLife Extracción
                DataView dv1 = dtMovExtraccion.DefaultView;
                //dv1.RowFilter = " ProductId = 1 or ProductId = 2 or ProductID = 3";
                dv1.RowFilter = strFiltro;
                DataTable dtMovimiento = dv1.ToTable();

                if (dtMovimiento.Rows.Count <= 0)
                {
                    blnError = true;
                    lblAceptar.Text += "     Movimientos no encontrados en Extracción / Concentrado.";
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
    }
}