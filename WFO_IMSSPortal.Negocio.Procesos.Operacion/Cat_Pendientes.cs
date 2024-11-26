using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class Cat_Pendientes
    {
        AccesoDatos.Procesos.Operacion.Cat_Pendientes pendientes = new AccesoDatos.Procesos.Operacion.Cat_Pendientes();

        public void SelecionarPendientes(ref Literal literal, int Id_Usuario)
        {
            List<prop.Cat_Pendientes> PendientesUsuario = pendientes.SelecionarPendientes(Id_Usuario);

            string MesaUsuario = "";
            for (int i = 0; i < PendientesUsuario.Count; i++)
            {
                MesaUsuario += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                                    "<div class='x_panel text-center'>" +
                                        "<a onClick='Cantidades(" + PendientesUsuario[i].Id_Pendiente + ")'>" +
                                            "<i class='fa " + PendientesUsuario[i].Icono + " fa-5x'></i>" +
                                            "<div class='form-group text-center'>" +
                                                "<hr />" +
                                                "<h2><small>" + PendientesUsuario[i].Nombre + " - " + PendientesUsuario[i].Total + "</small></h2>" +
                                            "</div>" +
                                        "</a>" +
                                    "</div>" +
                                "</div>";
            }

            literal.Text = MesaUsuario;
        }
    }
}
