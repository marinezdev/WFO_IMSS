using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Procesos.Operador
{
    public partial class Pendientes: Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                i.operacion.catpendientes.SelecionarPendientes(ref MesasLiteral, manejo_sesion.Usuarios.IdUsuario);
            }
        }

        public void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Funciones.LlenarControles.LlenarRepeater(
                    ref rptTramite, 
                    i.operacion.pendientes.SelecionarPendientes(Convert.ToInt32(hfIdPendiente.Value), manejo_sesion.Usuarios.IdUsuario));

                string script = "";
                script = "$('#myModal').modal({backdrop: 'static', keyboard: false});";
                script += "$('#datatable').DataTable({}); ";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                TituloModal.Text = "Consulta trámites";
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