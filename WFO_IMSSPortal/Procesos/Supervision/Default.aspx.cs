using System;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class Default : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                i.operacion.mesas.SelecionarMesasSupervisor(ref MesasLiteral);
            }
        }


    }
}