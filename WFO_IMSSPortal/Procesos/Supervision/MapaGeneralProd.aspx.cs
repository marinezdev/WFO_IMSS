using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class MapaGeneralProd : Utilerias.Comun
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["msj"]))
                {
                    if (Request.QueryString["msj"].ToString() == "1")
                        mensajes.MostrarMensaje(this, "No hay trámites disponibles...");
                }

                CargarQuincenasPendiente(manejo_sesion.Usuarios.IdUsuario);
            }
        }

        protected void CargaFlujos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MesasLiteral.Text = "";


            int IdCalendario = Convert.ToInt32(cboQuincenas.SelectedValue.ToString());
            PintaMesas(IdCalendario);
        }

        protected void CargarQuincenasPendiente(int Id)
        {
            i.operacion.usuariosflujo.SeleccionarQuincenasPendientes_DropDownList(ref cboQuincenas, Id);
        }

        protected void PintaMesas(int IdCalendario)
        {
            i.operacion.mapageneral.getTramitesPendientesQuincena(ref MesasLiteral, IdCalendario);
        }


    }
}