﻿using DocumentFormat.OpenXml.EMMA;
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
    public partial class EnlaceListar : Utilerias.Comun
    {
        WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral.Tramite tramite = new Negocio.Procesos.SupervisionGeneral.Tramite();

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref cboQuicena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                comun.CargaInicialdllTipoNomina(ref cboTipoNomina);


                if (!String.IsNullOrEmpty(Request.QueryString["Quincena"]) && !String.IsNullOrEmpty(Request.QueryString["TipoNimina"]) && !String.IsNullOrEmpty(Request.QueryString["Activar"]))
                {
                    string Quincena = Request.QueryString["Quincena"].ToString();
                    string TipoNomina = Request.QueryString["TipoNimina"].ToString();
                    string IdAplicarEnlace = Request.QueryString["Activar"].ToString();

                    // Activamos / Desactivamos elemento para enlace.
                    i.supervisiongeneral.tramite.EnlaceListadoActivar(Quincena, TipoNomina, int.Parse(IdAplicarEnlace) );

                    cboQuicena.SelectedValue = Quincena;
                    cboTipoNomina.SelectedValue = TipoNomina;
                    Enlace();

                }
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

            if (cboTipoNomina.SelectedValue == "AA" || cboTipoNomina.SelectedValue == "EA" || cboTipoNomina.SelectedValue == "JJ" || cboTipoNomina.SelectedValue == "MM")
            {
                // Validación correcta
            }
            else
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "Debe seleccionar un tipo de nomina válida.";
                return;
            }

            RepeaterFechas.DataSource = i.supervisiongeneral.tramite.EnlaceListado(cboQuicena.SelectedValue, cboTipoNomina.SelectedValue);
            RepeaterFechas.DataBind();
            RepeaterFechas.Visible = true;
            string script2 = "";
            script2 = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);

            //if (RepeaterFechas.Items.Count > 0)
            //    btnGuardarEnlace.Visible = true;
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