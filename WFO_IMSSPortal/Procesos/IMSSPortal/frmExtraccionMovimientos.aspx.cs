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
    public partial class frmExtraccionMovimientos : Utilerias.Comun
    {
        public string ddl
        {
            get { return ddlAnnQuincena.SelectedValue; }
        }

        #region Eventos *********************************************************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            try
            {                
                if (!IsPostBack)
                {
                    CargaInicialddlAnnQuincena();
                }
            }
            catch
            {

            }
        }

        protected void BtnExcelAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage pagina = new ExcelPackage(AsyncFileUpload1.FileContent);
                i.imssportal.extraccionmovimientos.ProcesarExcel(pagina);
                lblProcesadoExcel.Text = "Se guardó el archivo exitosamente.";
            }
            catch (Exception ex)
            {
                log.AgregarError(ex.Message.ToString());
                log.Agregar(ex);
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string nombreArchivo = Path.GetFileName(e.FileName);
            AjaxFileUpload1.SaveAs(Server.MapPath("~/Archivos/" + nombreArchivo));
            string rutaArchivo = Server.MapPath("~/Archivos/" + nombreArchivo);

            try
            {
                i.imssportal.extraccionmovimientos.ProcesarLineasArchivoTexto(rutaArchivo, nombreArchivo, Session["Valor1"].ToString(), Session["Valor2"].ToString());
            }
            catch (Exception ex)
            {
                log.AgregarError(ex.InnerException.ToString());
                log.Agregar(ex);
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var x = ddlAnnQuincena.SelectedValue;

            }
            catch
            { }
        }

        protected void ddlAnnQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Valor1"] = ddlAnnQuincena.SelectedValue;
        }

        protected void rblEstructura_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Valor2"] = rblEstructura.SelectedValue;
        }

        #endregion

        #region Metodos *********************************************************************************************
        protected void CargaInicialddlAnnQuincena()
        {
            Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
        }
        #endregion


    }
}