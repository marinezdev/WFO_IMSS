using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class Mesas
    {
        AccesoDatos.Procesos.Operacion.Mesas mesas = new AccesoDatos.Procesos.Operacion.Mesas();

        public DataTable MesasPorUsuario(int IdUsuario, int IdFlujo)
        {
            return mesas.SelecionarMesasDT(IdUsuario, IdFlujo);
        }

        public DataTable QuincenasActivas()
        {
            return mesas.QuincenasActivas();
        }

        public DataTable ProcesoManualTramite(string TipoNomina, string Quincena, string Poliza, int Mesa, int StatusMesa, int MotivoRechazo, int IdUsuario)
        {
            return mesas.ProcesoManualTramiteDT(TipoNomina, Quincena, Poliza, Mesa, StatusMesa, MotivoRechazo, IdUsuario);
        }

        public DataTable MesasMotivosRechazo(int IdFlujo, int IdMesa)
        {
            return mesas.MesasMotivosRechazoDT(IdFlujo, IdMesa);
        }

        public DataTable MesasStatus(int IdFlujo)
        {
            return mesas.SelecionarMesasStatusDT(IdFlujo);
        }

        /// <summary>
        /// Visualizar las mesas disponibles por usuario
        /// </summary>
        /// <param name="Id_Usuario"></param>
        /// <param name="IdFlujo"></param>
        /// <returns></returns>
        public void SelecionarMesasUsuario(ref Literal literal, int IdUsuario, int IdFlujo)
        {
            string MesaUsuario = "";
            List<prop.Mesa> MesasUsuario = mesas.SelecionarMesas(IdUsuario, IdFlujo);
            for (int i = 0; i < MesasUsuario.Count; i++)
            {
                MesaUsuario += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                            "<div class='x_panel text-center'>" +
                                "<a href='TramiteProcesar.aspx?IdMesa=" + MesasUsuario[i].Id + "'>" +
                                    "<i class='fa " + MesasUsuario[i].icono + " fa-5x'></i>" +
                                    "<div class='form-group text-center'>" +
                                        "<hr />" +
                                        "<h2><small>" + MesasUsuario[i].nombre + "</small></h2>" +
                                    "</div>" +
                                "</a>" +
                            "</div>" +
                         "</div>";
            }
            literal.Text = MesaUsuario;
        }

        /// <summary>
        /// Visualizar todas las mesas por Supervisor
        /// </summary>
        /// <returns>Cadena con el procesamiento realizado para mostrarse en un control</returns>
        public void SelecionarMesasSupervisor(ref Literal literal)
        {
            string procesado = string.Empty;
            List<prop.Mesa> mesasTodas = new List<prop.Mesa>();
            mesasTodas = mesas.SelecionarMesas();
            for (int j = 0; j < mesasTodas.Count; j++)
            {
                procesado += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                            "<div class='x_panel text-center'>" +
                                "<a href='TramiteProcesar.aspx?IdMesa=" + mesasTodas[j].Id + "'>" +
                                    "<i class='fa " + mesasTodas[j].icono + " fa-5x'></i>" +
                                    "<div class='form-group text-center'>" +
                                        "<hr />" +
                                        "<h2><small>" + mesasTodas[j].nombre + "</small></h2>" +
                                    "</div>" +
                                "</a>" +
                            "</div>" +
                         "</div>";
            }

            literal.Text = procesado;
        }

        public List<prop.Mesa> ObtenerMesasToSend(int Id_Tramite, int Id_Usuario, int Id_Mesa)
        {
            return mesas.ObtenerMesasToSend(Id_Tramite, Id_Usuario, Id_Mesa);
        }

        public List<prop.Mesa> SelecionarMesasUsuarioMesa(int Id_Usuario, int Id_Mesa)
        {
            return mesas.SelecionarMesasUsuarioMesa(Id_Usuario, Id_Mesa);
        }

        public void Mesas_DropDownList(ref DropDownList dropdownlist)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, mesas.Seleccionar(), "Nombre", "Id");
        }
    }
}
