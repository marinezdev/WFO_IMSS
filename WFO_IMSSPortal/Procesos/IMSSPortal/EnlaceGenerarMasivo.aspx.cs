using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class EnlaceGenerarMasivo : Utilerias.Comun
    {
        WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral.Tramite tramite = new Negocio.Procesos.SupervisionGeneral.Tramite();

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref ddlQuincena1, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlQuincena2, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlQuincena3, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlQuincena4, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlQuincena5, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                Funciones.LlenarControles.LlenarDropDownList(ref ddlQuincena6, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }
        protected void btnVerificarEnlace_Click(object sender, EventArgs e)
        {
        }

        protected void btnGenerarEnlace_Click(object sender, EventArgs e)
        {
            string strQuincenaResultante = "''";
            string strQuincena1 = "''";
            string strTNAA1 = "''";
            string strTNEA1 = "''";
            string strTNMM1 = "''";
            string strTNJJ1 = "''";
            string strTMAlta1 = "''";
            string strTMModif1 = "''";
            string strTMBaja1 = "''";
            string strQuincena2 = "''";
            string strTNAA2 = "''";
            string strTNEA2 = "''";
            string strTNMM2 = "''";
            string strTNJJ2 = "''";
            string strTMAlta2 = "''";
            string strTMModif2 = "''";
            string strTMBaja2 = "''";
            string strQuincena3 = "''";
            string strTNAA3 = "''";
            string strTNEA3 = "''";
            string strTNMM3 = "''";
            string strTNJJ3 = "''";
            string strTMAlta3 = "''";
            string strTMModif3 = "''";
            string strTMBaja3 = "''";
            string strQuincena4 = "''";
            string strTNAA4 = "''";
            string strTNEA4 = "''";
            string strTNMM4 = "''";
            string strTNJJ4 = "''";
            string strTMAlta4 = "''";
            string strTMModif4 = "''";
            string strTMBaja4 = "''";
            string strQuincena5 = "''";
            string strTNAA5 = "''";
            string strTNEA5 = "''";
            string strTNMM5 = "''";
            string strTNJJ5 = "''";
            string strTMAlta5 = "''";
            string strTMModif5 = "''";
            string strTMBaja5 = "''";
            string strQuincena6 = "''";
            string strTNAA6 = "''";
            string strTNEA6 = "''";
            string strTNMM6 = "''";
            string strTNJJ6 = "''";
            string strTMAlta6 = "''";
            string strTMModif6 = "''";
            string strTMBaja6 = "''";


            strQuincenaResultante = txtQuincena.Text.Trim();
            strQuincena1 = ddlQuincena1.SelectedValue.ToString();
            if (strQuincena1.Length == 0) strQuincena1 = "0";
            if (chkTNAA1.Checked) strTNAA1 = "AA"; else strTNAA1 = "0";
            if (chkTNEA1.Checked) strTNEA1 = "EA"; else strTNEA1 = "0";
            if (chkTNMM1.Checked) strTNMM1 = "MM"; else strTNMM1 = "0";
            if (chkTNJJ1.Checked) strTNJJ1 = "JJ"; else strTNJJ1 = "0";
            if (chkAlata1.Checked) strTMAlta1 = "A"; else strTMAlta1 = "0";
            if (chkModif1.Checked) strTMModif1 = "M"; else strTMModif1 = "0";
            if (chkBaja1.Checked) strTMBaja1 = "B"; else strTMBaja1 = "0";

            strQuincena2 = ddlQuincena2.SelectedValue.ToString();
            if (strQuincena2.Length == 0) strQuincena2 = "0";
            if (chkTNAA2.Checked) strTNAA2 = "AA"; else strTNAA2 = "0";
            if (chkTNEA2.Checked) strTNEA2 = "EA"; else strTNEA2 = "0";
            if (chkTNMM2.Checked) strTNMM2 = "MM"; else strTNMM2 = "0";
            if (chkTNJJ2.Checked) strTNJJ2 = "JJ"; else strTNJJ2 = "0";
            if (chkAlata2.Checked) strTMAlta2 = "A"; else strTMAlta2 = "0";
            if (chkModif2.Checked) strTMModif2 = "M"; else strTMModif2 = "0";
            if (chkBaja2.Checked) strTMBaja2 = "B"; else strTMBaja2 = "0";

            strQuincena3 = ddlQuincena3.SelectedValue.ToString();
            if (strQuincena3.Length == 0) strQuincena3 = "0";
            if (chkTNAA3.Checked) strTNAA3 = "AA"; else strTNAA3 = "0";
            if (chkTNEA3.Checked) strTNEA3 = "EA"; else strTNEA3 = "0";
            if (chkTNMM3.Checked) strTNMM3 = "MM"; else strTNMM3 = "0";
            if (chkTNJJ3.Checked) strTNJJ3 = "JJ"; else strTNJJ3 = "0";
            if (chkAlata3.Checked) strTMAlta3 = "A"; else strTMAlta3 = "0";
            if (chkModif3.Checked) strTMModif3 = "M"; else strTMModif3 = "0";
            if (chkBaja3.Checked) strTMBaja3 = "B"; else strTMBaja3 = "0";

            strQuincena4 = ddlQuincena4.SelectedValue.ToString();
            if (strQuincena4.Length == 0) strQuincena4 = "0";
            if (chkTNAA4.Checked) strTNAA4 = "AA"; else strTNAA4 = "0";
            if (chkTNEA4.Checked) strTNEA4 = "EA"; else strTNEA4 = "0";
            if (chkTNMM4.Checked) strTNMM4 = "MM"; else strTNMM4 = "0";
            if (chkTNJJ4.Checked) strTNJJ4 = "JJ"; else strTNJJ4 = "0";
            if (chkAlata4.Checked) strTMAlta4 = "A"; else strTMAlta4 = "0";
            if (chkModif4.Checked) strTMModif4 = "M"; else strTMModif4 = "0";
            if (chkBaja4.Checked) strTMBaja4 = "B"; else strTMBaja4 = "0";


            strQuincena5 = ddlQuincena5.SelectedValue.ToString();
            if (strQuincena5.Length == 0) strQuincena5 = "0";
            if (chkTNAA5.Checked) strTNAA5 = "AA"; else strTNAA5 = "0";
            if (chkTNEA5.Checked) strTNEA5 = "EA"; else strTNEA5 = "0";
            if (chkTNMM5.Checked) strTNMM5 = "MM"; else strTNMM5 = "0";
            if (chkTNJJ5.Checked) strTNJJ5 = "JJ"; else strTNJJ5 = "0";
            if (chkAlata5.Checked) strTMAlta5 = "A"; else strTMAlta5 = "0";
            if (chkModif5.Checked) strTMModif5 = "M"; else strTMModif5 = "0";
            if (chkBaja5.Checked) strTMBaja5 = "B"; else strTMBaja5 = "0";


            strQuincena6 = ddlQuincena6.SelectedValue.ToString();
            if (strQuincena6.Length == 0) strQuincena6 = "0";
            if (chkTNAA6.Checked) strTNAA6 = "AA"; else strTNAA6 = "0";
            if (chkTNEA6.Checked) strTNEA6 = "EA"; else strTNEA6 = "0";
            if (chkTNMM6.Checked) strTNMM6 = "MM"; else strTNMM6 = "0";
            if (chkTNJJ6.Checked) strTNJJ6 = "JJ"; else strTNJJ6 = "0";
            if (chkAlata6.Checked) strTMAlta6 = "A"; else strTMAlta6 = "0";
            if (chkModif6.Checked) strTMModif6 = "M"; else strTMModif6 = "0";
            if (chkBaja6.Checked) strTMBaja6 = "B"; else strTMBaja6 = "0";

            GeneararEnlaceMasivo(
                strQuincena1, strTNAA1, strTNEA1, strTNMM1, strTNJJ1, strTMAlta1, strTMModif1, strTMBaja1,
                strQuincena2, strTNAA2, strTNEA2, strTNMM2, strTNJJ2, strTMAlta2, strTMModif2, strTMBaja2,
                strQuincena3, strTNAA3, strTNEA3, strTNMM3, strTNJJ3, strTMAlta3, strTMModif3, strTMBaja3,
                strQuincena4, strTNAA4, strTNEA4, strTNMM4, strTNJJ4, strTMAlta4, strTMModif4, strTMBaja4,
                strQuincena5, strTNAA5, strTNEA5, strTNMM5, strTNJJ5, strTMAlta5, strTMModif5, strTMBaja5,
                strQuincena6, strTNAA6, strTNEA6, strTNMM6, strTNJJ6, strTMAlta6, strTMModif6, strTMBaja6,
                strQuincenaResultante
            );
        }

        private void GeneararEnlaceMasivo(
            string Quincena1, string TNAA1, string TNEA1, string TNMM1, string TNJJ1, string TMAlta1, string TMModif1, string TMBaja1,
            string Quincena2, string TNAA2, string TNEA2, string TNMM2, string TNJJ2, string TMAlta2, string TMModif2, string TMBaja2,
            string Quincena3, string TNAA3, string TNEA3, string TNMM3, string TNJJ3, string TMAlta3, string TMModif3, string TMBaja3,
            string Quincena4, string TNAA4, string TNEA4, string TNMM4, string TNJJ4, string TMAlta4, string TMModif4, string TMBaja4,
            string Quincena5, string TNAA5, string TNEA5, string TNMM5, string TNJJ5, string TMAlta5, string TMModif5, string TMBaja5,
            string Quincena6, string TNAA6, string TNEA6, string TNMM6, string TNJJ6, string TMAlta6, string TMModif6, string TMBaja6,
            string QuincenaResultante
        )
        {
            //lblMensajes.Visible = false;
            //lblMensajes.Text = "";

            //if (cboQuicena.SelectedValue == "" || cboQuicena.SelectedValue == "00")
            //{
            //    lblMensajes.Visible = true;
            //    lblMensajes.Text = "Debe seleccionar una quincena válida.";
            //    return;
            //}

            bool ProcesarEnlace = false;
            string error = "";
            ProcesarEnlace = i.supervisiongeneral.tramite.EnlaceGenerarMasivo(
                Quincena1, TNAA1, TNEA1, TNMM1, TNJJ1, TMAlta1, TMModif1, TMBaja1,
                Quincena2, TNAA2, TNEA2, TNMM2, TNJJ2, TMAlta2, TMModif2, TMBaja2,
                Quincena3, TNAA3, TNEA3, TNMM3, TNJJ3, TMAlta3, TMModif3, TMBaja3,
                Quincena4, TNAA4, TNEA4, TNMM4, TNJJ4, TMAlta4, TMModif4, TMBaja4,
                Quincena5, TNAA5, TNEA5, TNMM5, TNJJ5, TMAlta5, TMModif5, TMBaja5,
                Quincena6, TNAA6, TNEA6, TNMM6, TNJJ6, TMAlta6, TMModif6, TMBaja6,
                QuincenaResultante, ref error);

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