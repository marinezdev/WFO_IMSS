using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class MapaGeneralDetalleProd : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                hfIdMesa.Value = Request.QueryString["IdMesa"].ToString();
                hfIdFlujo.Value = Request.QueryString["IdFlujo"].ToString();
                hfIdCalendario.Value = Request.QueryString["IdCalendario"].ToString();
                Resumen();
                TramitesDetalle();
            }
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                string IdTramite = e.CommandArgument.ToString();
                //Response.Redirect("../SupervisionGeneral/ConsultaTramite.aspx?Procesable=" + IdTramite, true);
            }
        }

        protected void Resumen()
        {
            i.operacion.mapageneral.DashboardMesaProd(ref lblTitulo, ref MesaResumen, int.Parse(hfIdCalendario.Value) , int.Parse(hfIdFlujo.Value), int.Parse(hfIdMesa.Value));
            string script2 = "";
            script2 = "$('#tMesaResumen').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
            mensajes.EjecutarCodigo(this, script2);
        }

        private void TramitesDetalle()
        {
            i.operacion.mapageneral.getDashboardMesaDetalleTramiteProd(ref RepeaterFechas, int.Parse(hfIdCalendario.Value), int.Parse(hfIdFlujo.Value), int.Parse(hfIdMesa.Value));
            string script2 = "";
            script2 = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
            mensajes.EjecutarCodigo(this, script2);
        }

    }
}