using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class TramitesProcesados : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                dtFechaInicio.Value = DateTime.Now.ToString("yyyy/MM/dd");
                //i.operacion.catpendientes.SelecionarPendientes(ref MesasLiteral, manejo_sesion.Usuarios.IdUsuario);
            }
        }

        public void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                lblMensaje.Visible = false;


                DateTime Fecha1 = Convert.ToDateTime(dtFechaInicio.Text);
                DateTime Fecha2 = Convert.ToDateTime(dtFechaTermino.Text);
                Fecha2 = Fecha2.AddHours(23);
                Fecha2 = Fecha2.AddMinutes(59);
                Fecha2 = Fecha2.AddSeconds(59);
                if (Fecha2 <= Fecha1)
                {
                    lblMensaje.Text = "El rango de Fechas Seleccionadas es incorrecto.";
                    lblMensaje.Visible = true;
                }
                else
                {

                    Funciones.LlenarControles.LlenarRepeater(
                        ref rptTramite,
                        i.operacion.pendientes.TramitesProcesados(Fecha1, Fecha2));

                    string script = "";
                    script += "$('#datatable').DataTable({}); ";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);


                    //i.operacion.tramites.TramiteOperadorSelecionar(ref RepeaterFechas, manejo_sesion.Usuarios.IdUsuario, Fecha1, Fecha2, Folio, Poliza, quincena, tiponomina);
                    //RepeaterFechas.Visible = true;
                    //script2 = "";
                    //script2 = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
                }



                //TituloModal.Text = "Consulta trámites";
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                // LECTURA DE VARIABLES 
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                int IdTramite = Convert.ToInt32(arg[0]);
                int IdMesa = Convert.ToInt32(arg[1]);

                if (String.IsNullOrEmpty(IdMesa.ToString()) || IdMesa == 0)
                {
                    Response.Redirect("ConsultaTramite.aspx?Procesable=" + IdTramite, true);
                }
                else
                {
                    Response.Redirect("TramiteProcesar.aspx?Procesable=" + IdTramite + "&IdMesa=" + IdMesa, true);
                }
            }
        }


    }
}