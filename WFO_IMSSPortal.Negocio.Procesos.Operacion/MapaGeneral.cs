using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class MapaGeneral
    {
        AccesoDatos.Procesos.Operacion.MapaGeneral mapageneral = new AccesoDatos.Procesos.Operacion.MapaGeneral();

        public void getTramitesPendientesQuincena(ref Literal literal, int IdCalndario)
        {
            int IdFlujo = 3;
            List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna> Dashboard = mapageneral.getTramitesPendientesQuincena(IdCalndario);

            for (int i = 0; i < Dashboard.Count; i++)
            {
                int Tramites = Dashboard[i].TramitesDisponibles;

                literal.Text += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                            "<div class='x_panel text-center'>" +
                                "<a href='MapaGeneralDetalleProd.aspx?IdFlujo=" + IdFlujo.ToString() + "&IdMesa=" + Dashboard[i].IdMesa.ToString() + "&IdCalendario=" + IdCalndario.ToString() + "'>" +
                                    "<table style='border: 0px solid #5A738E; width:100%'>" +
                                        "<tr style='vertical-align: center; text-align: center; '>" +
                                            "<td>" +
                                                "<i class='fa " + Dashboard[i].Icono + " fa-5x'></i>" +
                                                "<div class='form-group text-center'>" +
                                                    "<hr />" +
                                                    "<h2><small>" + Dashboard[i].Mesa + "</small></h2><br/>" +
                                                "</div>" +
                                            "</td>" +
                                            "<td>" +
                                                "<div class='form-group text-center'>" +
                                                    "<i class='fa fa-book fa-2x'></i>   <strong style='font-size: 20px;'>" + Tramites.ToString() + "<strong/>" +
                                                 "</div>" +
                                            "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</a>" +
                            "</div>" +
                         "</div>";
            }
            //mapageneral.getDashboard(IdFlujo);
        }

        public void Dashboard(ref Literal literal, int IdFlujo)
        {
            List<Propiedades.Procesos.Operacion.MapaGeneral> Dashboard = mapageneral.getDashboard(IdFlujo);

            for (int i = 0; i < Dashboard.Count; i++)
            {
                int Tramites = Dashboard[i].TramitesDisponibles + Dashboard[i].TramitesReingresos;

                literal.Text += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                            "<div class='x_panel text-center'>" +
                                "<a href='MapaGeneralDetalle.aspx?IdFlujo=" + IdFlujo.ToString() + "&IdMesa=" + Dashboard[i].IdMesa.ToString() + "'>" +
                                    "<table style='border: 0px solid #5A738E; width:100%'>" +
                                        "<tr style='vertical-align: center; text-align: center; '>" +
                                            "<td>" +
                                                "<i class='fa " + Dashboard[i].Icono + " fa-5x'></i>" +
                                                "<div class='form-group text-center'>" +
                                                    "<hr />" +
                                                    "<h2><small>" + Dashboard[i].Mesa + "</small></h2><br/>" +
                                                "</div>" +
                                            "</td>" +
                                            "<td>" +
                                                "<div class='form-group text-center'>" +
                                                    "<i class='fa fa-male fa-3x'></i>   <strong style='font-size: 20px;'>" + Dashboard[i].UsuariosConectados.ToString() + "<strong/><br/><br/>" +
                                                    "<i class='fa fa-book fa-2x'></i>   <strong style='font-size: 20px;'>" + Tramites.ToString() + "<strong/>" +
                                                 "</div>" +
                                            "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</a>" +
                            "</div>" +
                         "</div>";
            }



            //mapageneral.getDashboard(IdFlujo);
        }

        public void DashboardMesaProd(ref Label label, ref Repeater repeater, int IdCalendario, int idflujo, int idmesa)
        {
            List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna> WFODashboard = mapageneral.getDashboardMesaProd(IdCalendario, idflujo, idmesa);
            label.Text = "Mapa General. Mesas de " + WFODashboard[0].Mesa;
            repeater.DataSource = WFODashboard;
            repeater.DataBind();
            repeater.Visible = true;
        }

        public void DashboardMesa(ref Label label, ref Repeater repeater, int idflujo, int idmesa)
        {
            List<Propiedades.Procesos.Operacion.MapaGeneral> WFODashboard = mapageneral.getDashboardMesa(idflujo, idmesa);
            label.Text = "Mapa General. Mesas de " + WFODashboard[0].Mesa;
            repeater.DataSource = WFODashboard;
            repeater.DataBind();
            repeater.Visible = true;
        }

        public void DashboardMesaDetalle(ref Repeater repeater, int idflujo, int idmesa)
        {
            List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> WFODashboard = mapageneral.getDashboardMesaDetalleTramite(idflujo, idmesa);
            repeater.DataSource = WFODashboard;
            repeater.DataBind();
            repeater.Visible = true;
        }

        

        public void getDashboardMesaDetalleTramiteProd(ref Repeater repeater, int IdCalendario, int idflujo, int idmesa)
        {
            List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> WFODashboard = mapageneral.getDashboardMesaDetalleTramiteProd(IdCalendario, idflujo, idmesa);
            repeater.DataSource = WFODashboard;
            repeater.DataBind();
            repeater.Visible = true;
        }


        public void getDashboardMesaDetalleTramite(ref Repeater repeater, int idflujo, int idmesa)
        {
            List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> WFODashboard = mapageneral.getDashboardMesaDetalleTramite(idflujo, idmesa);
            repeater.DataSource = WFODashboard;
            repeater.DataBind();
            repeater.Visible = true;
        }



    }
}
