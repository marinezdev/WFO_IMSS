﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.Procesos.Promotoria
{
    public partial class MisTramites : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                //List<prop.TramitesPromotoria> Tramites = i.promotoria.tramitespromotoria.ListaTramitesPromotoria(manejo_sesion.Usuarios.IdUsuario);
                i.promotoria.tramitespromotoria.ListaTramitesPromotoria(ref rptTramite, manejo_sesion.Usuarios.IdUsuario);

                ListaCat_StatusTramite();
                FormatosFechas();
            }
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                string IdTramite = e.CommandArgument.ToString();
                Response.Redirect("ConsultaTramite.aspx?Id=" + IdTramite);
            }
        }

        private void ListaCat_StatusTramite()
        {
            //List<prop.cat_statusTramite> cat_StatusTramites = i.promotoria.catalogos.cat_StatusTramites();
            //LisCat_StatusTramite.DataSource = i.promotoria.catalogos.cat_StatusTramites(); // cat_StatusTramites;
            //LisCat_StatusTramite.DataBind();
            //LisCat_StatusTramite.DataTextField = "Nombre";
            //LisCat_StatusTramite.DataValueField = "Id";
            //LisCat_StatusTramite.DataBind();

            i.promotoria.catalogos.cat_StatusTramites_DropDownList(ref LisCat_StatusTramite);
        }

        protected void BtnConsultar_Click(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(23, 59, 59);

            DateTime Fecha1 = Convert.ToDateTime(dtFechaInicio.Text);
            DateTime Fecha2 = Convert.ToDateTime(dtFechaTermino.Text);

            Fecha1 = Fecha1 + ts;
            Fecha2 = Fecha2 + ts;

            int IdStatus = Convert.ToInt32(LisCat_StatusTramite.SelectedValue);

            DateTime FechaCalculada = Fecha1;

            Mensajes.Text = "";

            if (Fecha1 <= Fecha2)
            {
                Mensajes.Text = "La fecha término debe ser menor a la fecha inicial";
                RepeaterFechas.Visible = false;
            }
            else
            {
                if (Fecha2 >= FechaCalculada.AddMonths(-3))
                {
                    manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
                    //List<prop.TramitesPromotoria> Tramites = i.promotoria.tramitespromotoria.ListaTramitesPromotoriaFechas(manejo_sesion.Usuarios.IdUsuario, IdStatus, Fecha1, Fecha2);
                    i.promotoria.tramitespromotoria.ListaTramitesPromotoriaFechas(ref RepeaterFechas, manejo_sesion.Usuarios.IdUsuario, IdStatus, Fecha1, Fecha2);
                    //RepeaterFechas.DataSource = Tramites; 
                    //RepeaterFechas.DataBind();
                    RepeaterFechas.Visible = true;
                    string script = "";
                    script = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                }
                else
                {
                    Mensajes.Text = "La fecha termino es mayor a los 3 meses permitidos";
                    RepeaterFechas.Visible = false;
                }
            }
        }

        protected void ActualizaFechaTermino(object sender, EventArgs e)
        {
            DateTime Fecha = Convert.ToDateTime(dtFechaInicio.Value.ToString());
            dtFechaTermino.MinDate = Fecha.AddMonths(-3);
            dtFechaTermino.MaxDate = Fecha;
            dtFechaTermino.UseMaskBehavior = true;
            dtFechaTermino.EditFormatString = Funciones.Fechas.GetFormatString("dd/MM/yyyy");
            dtFechaTermino.Date = Fecha.AddMonths(-3);
        }

        private void FormatosFechas()
        {
            // INICIO DE FECHAS
            DateTime Fecha = DateTime.Today;

            dtFechaInicio.MaxDate = Fecha;
            //dtFechaInicio.MinDate = validateFechaSolicitud.AddDays(-30);
            dtFechaInicio.UseMaskBehavior = true;
            dtFechaInicio.EditFormatString = Funciones.Fechas.GetFormatString("dd/MM/yyyy");
            dtFechaInicio.Date = Fecha;
            
            dtFechaTermino.MinDate = Fecha.AddMonths(-4);
            dtFechaTermino.MaxDate = Fecha;
            dtFechaTermino.UseMaskBehavior = true;
            dtFechaTermino.EditFormatString = Funciones.Fechas.GetFormatString("dd/MM/yyyy");
            dtFechaTermino.Date = Fecha.AddMonths(-4);
        }
    }
}