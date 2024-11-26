using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class EnlaceImportar : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            DataTable ddtt = new DataTable();
            ddtt = (DataTable)Session["RegistrosTemporales"];
            string nombreArchivo = Path.GetFileName(e.FileName);
            AjaxFileUpload1.SaveAs(Server.MapPath("/EnlaceImportarTxt/" + nombreArchivo));

            using (StreamReader sr = new StreamReader(Server.MapPath("/EnlaceImportarTxt/" + nombreArchivo)))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Replace('�', 'N').Replace('/', ' ').Replace('-', ' ').Replace('_', ' ').ToUpper().Split('\t');
                    if (parts[0].Length == 103)
                    {
                        Propiedades.EnlaceImportarTxt items = new Propiedades.EnlaceImportarTxt
                        {
                            TipoPrestamo            = parts[0].ToString().Substring(0, 1),
                            Matricula               = parts[0].ToString().Substring(1, 10),
                            Concepto                = parts[0].ToString().Substring(11, 3),
                            Importe                 = parts[0].ToString().Substring(14, 7),
                            Plazo                   = parts[0].ToString().Substring(21, 3),
                            NumControl              = parts[0].ToString().Substring(24, 6),
                            NumCreditoPoliza        = parts[0].ToString().Substring(30, 8),
                            Promotoria              = parts[0].ToString().Substring(38, 4),
                            CifraControlImporte     = parts[0].ToString().Substring(42, 8),
                            TipoMovimiento          = parts[0].ToString().Substring(50, 1),
                            NombreTrabajador        = parts[0].ToString().Substring(51, 47),
                            NumProveedor            = parts[0].ToString().Substring(98, 4),
                            Caracter                = parts[0].ToString().Substring(102, 1),
                            CifraControl            = "******************",
                            EspaciosEnBlanco        = "*****",
                            Casos                   = "**********",
                            xUnidadPago             = nombreArchivo.Substring(0, 2),
                            xRetenedor              = nombreArchivo.Substring(2, 4),
                            xConcepto               = nombreArchivo.Substring(6, 3),
                            xTipoNomina             = nombreArchivo.Substring(9, 1),
                            xQuincena               = nombreArchivo.Substring(10, 2),
                            IdUsuario               = manejo_sesion.Usuarios.IdUsuario,
                            Archivo                 = nombreArchivo.ToString(),
                            Quincena                = Session["Quincena"].ToString(),
                            TipoNomina              = Session["TipoNomina"].ToString()
                        };
                        i.imssportal.enlaceimportartxt.AgregarDatos(items);
                    }
                }
            }

            string rutaServidor1 = Server.MapPath("/EnlaceImportarTxt/");
            string rutaServidor2 = Server.MapPath("/ArchivosTXT/");

            File.Copy(
                (rutaServidor1 + nombreArchivo), 
                (rutaServidor2 + DateTime.Now.ToString("yyMMddHHmmss") + manejo_sesion.Usuarios.IdUsuario.ToString() + Session["TipoNomina"].ToString() + Session["Quincena"].ToString() + nombreArchivo)
            );

            // File.Delete(Server.MapPath("/EnlaceImportarTxt/" + nombreArchivo));
        }

        protected void ddlTipoNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["TipoNomina"] = ddlTipoNomina.SelectedValue;
        }

        protected void ddlAnnQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Quincena"] = ddlAnnQuincena.SelectedValue;
        }
    }
}