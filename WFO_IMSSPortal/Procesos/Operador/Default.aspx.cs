using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Procesos.Operador
{
    public partial class Default : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            try
            {
                if (!IsPostBack)
                {
                    Session["TramitesAutomaticos"] = true;

                    if (!String.IsNullOrEmpty(Request.QueryString["msj"]))
                    {
                        if (Request.QueryString["msj"].ToString() == "1")
                        {
                            mensajes.MostrarMensaje(this, "No hay trámites disponibles...");
                        }
                    }
                    
                    //PintaMesas(manejo_sesion.Usuarios.IdUsuario);
                    Funciones.LlenarControles.LlenarDropDownList(ref cbFlujos, i.operacion.usuariosflujo.SelecionarFlujo(manejo_sesion.Usuarios.IdUsuario), "Nombre", "Id");
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }

        protected void CargaFlujos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdFlujo = Convert.ToInt32(cbFlujos.SelectedValue.ToString());
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            PintaMesas(manejo_sesion.Usuarios.IdUsuario, IdFlujo);
        }

        protected void PintaMesas(int Id, int IdFlujo)
        {
            i.operacion.mesas.SelecionarMesasUsuario(ref MesasLiteral, Id, IdFlujo);
        }
    }
}