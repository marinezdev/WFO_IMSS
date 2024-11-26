using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.SupervisionGeneral;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class EnlaceGenerar : Utilerias.Comun
    {
        WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral.Tramite tramite = new Negocio.Procesos.SupervisionGeneral.Tramite();

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref cboQuicena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                //comun.CargaInicialdllTipoNomina(ref cboTipoNomina);
            }
        }

        protected void btnGuardarEnlace_Click(object sender, EventArgs e)
        {
            //string strURL = "";
            //strURL = 
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            Enlace();
        }

        private void Enlace()
        {
            lblMensajes.Visible = false;
            lblMensajes.Text = "";

            if (cboQuicena.SelectedValue == "" || cboQuicena.SelectedValue == "00")
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "Debe seleccionar una quincena válida.";
                return;
            }

            bool ProcesarEnlace = false;
            string error = "";
            //ProcesarEnlace = i.supervisiongeneral.tramite.EnlaceGenerar(cboQuicena.SelectedValue, "XX", ref error);
            ProcesarEnlace = i.supervisiongeneral.tramite.EnlaceGenerarMasivo_V2(cboQuicena.SelectedValue, ref error);

            if (error.Length > 0)
            {
                log.Agregar(error);
            }

            if (ProcesarEnlace)
            {
                string script2 = "";
                script2 = "alert('Enlace Generado. Por favor descargar desde Servidor.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
            }
            else
            {
                string script2 = "";
                script2 = "alert('Ocurrio un problema en la generación de archivos.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
            }
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (e.CommandName.Equals("Activar"))
            //{
            //    string EnlaceClave = e.CommandArgument.ToString();
            //}
        }
    }
}