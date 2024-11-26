using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class EnlaceAgregarCasosEspeciales : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
            hfIdUsuario.Value = manejo_sesion.Usuarios.IdUsuario.ToString();

            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                BtnExcelAceptar.Enabled = true;
            }
        }

        protected void BtnExcelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                BtnExcelAceptar.Enabled = false;
                int TotalCasos = 0;
                string strFolio = DateTime.Now.ToString("yyMMddHHmm") + string.Format("{0:0000}", manejo_sesion.Usuarios.IdUsuario);
                string nombrearchivo = Server.MapPath("~/ArchivosTemporales/" + AsyncFileUpload1.FileName);
                AsyncFileUpload1.SaveAs(nombrearchivo);

                ExcelPackage pagina = new ExcelPackage(AsyncFileUpload1.FileContent);
                i.imssportal.extraccion.ProcesarExcel_EnlaseCasosEspeciales(pagina, manejo_sesion.Usuarios.IdUsuario, strFolio, txtObservaciones.Text.Trim(), Server.MapPath("~/EnlaceCasosEspeciales/"), txtQuincenaEnlace.Text.Trim(), ref TotalCasos);
                
                lblProcesadoExcel.ForeColor = System.Drawing.Color.Blue;
                lblProcesadoExcel.Text = "Total de Casos Especiales: " + TotalCasos.ToString();
                //i.imssportal.tramites.ObtenerExtaccion_GridView(ref GVExtraccion, manejo_sesion.Usuarios.IdUsuario, strFolio);
                //if (GVExtraccion.Rows.Count > 0)
                //{
                //    lblProcesadoExcel.Text = "Se guardó el archivo exitosamente.";
                //    lblProcesadoExcel.Text += "     Total de Registros: " + GVExtraccion.Rows.Count.ToString();
                //    grid.Visible = true;
                //    grid.DataSource = GVExtraccion.DataSource;
                //    grid.DataBind();
                //    GuardarBorrar(nombrearchivo, manejo_sesion.Usuarios.IdUsuario.ToString());
                //}
                //else
                //    lblProcesadoExcel.Text = "No se encontraron registros nuevos para agregar.";
            }
            catch (Exception ex)
            {
                GVExtraccion.DataSource = null;
                GVExtraccion.DataBind();
                grid.DataSource = null;
                grid.DataBind();
                lblProcesadoExcel.Text = "No se pudo guardar el archivo. " + ex.Message;
                lblProcesadoExcel.ForeColor = System.Drawing.Color.Red;
                log.AgregarError(ex.Message.ToString());
            }
        }

        protected void grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
        }

        protected void GuardarBorrar(string nombrearchivo, string idusuario)
        {
            // TODO: ### Pendiente: Realizar el guardado de archivos en diferentes ubicaciones de base de datos y servidores...

            //FileStream fStream = File.OpenRead(nombrearchivo);
            //byte[] contenido = new byte[fStream.Length];
            //fStream.Read(contenido, 0, (int)fStream.Length);
            //fStream.Close();
            //i.imssportal.archivos.Agregar("2", contenido, AsyncFileUpload1.FileName, idusuario);
            //File.Delete(nombrearchivo);
        }

        protected void AjaxFileUploadCartas_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            //manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            IU.ManejadorSesion manejo_sesionFiles = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            //DataTable ddtt = new DataTable();
            //ddtt = (DataTable)Session["RegistrosTemporales"];

            string nombreArchivo = Path.GetFileName(e.FileName);
            string rutaArchivo = Server.MapPath("~/EnlaceCasosEspeciales/" + manejo_sesionFiles.Usuarios.IdUsuario.ToString() + "_" +  nombreArchivo);
            bool blnExisteMovimiento = false;
            string archivoPoliza = "";

            try
            {
                AjaxFileUploadCartas.SaveAs(rutaArchivo);

                if (!File.Exists(rutaArchivo))
                {
                    log.AgregarError("No se pudó subir la carta de enlace : " + rutaArchivo);
                }

                //lblUpload.Visible = false;

                //if (ddtt is null)
                //{
                //    // No hay movimientos registrados...
                //    //mensajes.MostrarMensaje(this, "No hay movimientos registrados...", "Default.aspx");
                //    lblUpload.Text = "No hay movimientos registrados...";
                //    lblUpload.Visible = true;
                //    return;
                //}

                //if (ddtt.Rows.Count > 0)
                //{
                //    blnExisteMovimiento = false;
                //    foreach (DataRow dr in ddtt.Rows)
                //    {
                //        archivoPoliza = manejo_sesion.Usuarios.ClavePromotoria + "_" + dr[3].ToString().TrimStart(new Char[] { '0' }) + "_" + dr[4].ToString() + "_" + dr[2].ToString() + ".pdf";
                //        if (archivoPoliza.ToUpper() == nombreArchivo.ToUpper())
                //        {
                //            blnExisteMovimiento = true;
                //            dr[5] = nombreArchivo;
                //            break;
                //        }
                //    }

                //    if (blnExisteMovimiento)
                //    {
                //        AjaxFileUpload1.SaveAs(Server.MapPath("~/ArchivosTemporales/" + nombreArchivo));
                //        Session["RegistrosTemporales"] = ddtt;

                //        GVRegistros.DataSource = ddtt;
                //        GVRegistros.DataBind();
                //    }
                //    else
                //    {
                //        // No se encontró el movimiento de la póliza asociada a la carta de instrucción.
                //        mensajes.MostrarMensaje(this, "No se encontró el movimiento de la póliza asociada a la carta de instrucción.*/", "Default.aspx");
                //        lblUpload.Text = "No se encontró el movimiento de la póliza asociada a la carta de instrucción.";
                //        lblUpload.Visible = true;
                //    }
                //}
                //else
                //{
                //    // No hay movimientos registrados...
                //    //mensajes.MostrarMensaje(this, "No hay movimientos registrados...", "Default.aspx");
                //    lblUpload.Text = "No hay movimientos registrados...";
                //    lblUpload.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                log.AgregarError(ex.InnerException.ToString());
                log.Agregar(ex);
            }
        }
    }
}