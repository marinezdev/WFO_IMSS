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
    public partial class frmExtraccionPolizasCanceladas : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                BtnExcelAceptar.Enabled = true;
            }
        }

        protected void BtnExcelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                BtnExcelAceptar.Enabled = false;
                string strFolio = DateTime.Now.ToString("yyMMddHHmm") + string.Format("{0:0000}", manejo_sesion.Usuarios.IdUsuario);
                string nombrearchivo = Server.MapPath("~/ArchivosTemporales/" + AsyncFileUpload1.FileName);
                AsyncFileUpload1.SaveAs(nombrearchivo);

                ExcelPackage pagina = new ExcelPackage(AsyncFileUpload1.FileContent);
               
                // Al agregar el concentrado hay que ver si existe el movimiento en extracción para poder verificar que se realice el movimiento. La asignación de trámites será en base a la extracción.
                i.imssportal.extraccion.ProcesarExcelPolizasCanceladas(pagina, manejo_sesion.Usuarios.IdUsuario, strFolio, txtObservaciones.Text.Trim());
                lblProcesadoExcel.ForeColor = System.Drawing.Color.Blue;
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
    }
}