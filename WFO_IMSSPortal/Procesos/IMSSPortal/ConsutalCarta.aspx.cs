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
    public partial class ConsutalCarta : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                comun.CargaInicialdllTipoNomina(ref ddlTipoNomina);
                //comun.CargaInicialddlAnnQuincena(ref ddlAnnQuincena);
                Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
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
                    DataTable dtCartaAsociada = i.imssportal.extraccion.ObtenerTramiteProcesadoCarta(TipoNomina, Quincena, Poliza);

                    if (dtCartaAsociada.Rows.Count > 0)
                    {
                        CargarPFD(dtCartaAsociada.Rows[0]["NombreArchivo"].ToString());
                        this.CartaPDF.Visible = true;
                    }
                    else
                    {
                        lblBuscar.Text = "Carta no encontrada!";
                        lblBuscar.Visible = true;
                        ltMuestraPdf.Text = "";
                        this.CartaPDF.Visible = false;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                //string errormessage = ex.Message.ToString();
            }
        }

        private void CargarPFD(string Archivo)
        {
            //Procedimientos para visualizar un PDF
            string ToSaveFileTo = Server.MapPath("~" + "//PDF//" + Archivo);
            ltMuestraPdf.Text = "";

            if (File.Exists(ToSaveFileTo))
            {
                if (Archivo == "CartaBaja.PDF")
                {
                    //hfArchivoNombre.Value = Server.MapPath("~" + "//PDF//" + Archivo);
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + Archivo + "' style='width:100%; height:300px' type='application/pdf'>";
                }
                else
                {
                    //hfArchivoNombre.Value = Server.MapPath("~" + "//PDF//" + Archivo.Substring(0, 20) + ".pdf");
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + Archivo + "' style='width:100%; height:300px' type='application/pdf'>";
                }
            }
            else
            {
                if (File.Exists(Server.MapPath("~" + "//PDF//" + Archivo.Substring(0, 20) + ".pdf")))
                {
                    //hfArchivoNombre.Value = Server.MapPath("~" + "//PDF//" + Archivo.Substring(0, 20) + ".pdf");
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + Archivo.Substring(0, 20) + ".pdf" + "' style='width:300px; height:100%' type='application/pdf'>";
                }
                else
                {
                    log.Agregar(" ==> Archivo no econtrado: " + ToSaveFileTo.ToString());
                    ltMuestraPdf.Text = "<embed src='..\\..\\ArchivosDefinitivos\\404.pdf' style='width:100%; height:300px' type='application/pdf'>";
                }
            }
        }

    }
}