using System;
using System.Collections.Generic;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class TramitesPromotoria
    {
        AccesoDatos.Procesos.Promotoria.TramitesPromotoria tramitesPromotoria = new AccesoDatos.Procesos.Promotoria.TramitesPromotoria();

        public List<prop.TramitesPromotoria> ConsultaTramitesPromotoria(int IdUsuario, int IdTramite)
        {
            return tramitesPromotoria.ConsultaTramitesPromotoria(IdUsuario, IdTramite);
        }

        public void ListaTramitesPromotoria(ref Repeater repeater, int Id)
        {
            Funciones.LlenarControles.LlenarRepeater(ref repeater, tramitesPromotoria.ListaTramitesPromotoria(Id));
            //repeater.DataSource = tramitesPromotoria.ListaTramitesPromotoria(Id);
            //repeater.DataBind();
        }

        public void ListaTramitesPromotoriaFechas(ref Repeater repeater, int Id, int IdStatusTramite, DateTime Fecha_Inicio, DateTime Fecha_Termino)
        {
            Funciones.LlenarControles.LlenarRepeater(ref repeater, tramitesPromotoria.ListaTramitesPromotoriaFechas(Id, IdStatusTramite, Fecha_Inicio, Fecha_Termino));
            //repeater.DataSource = tramitesPromotoria.ListaTramitesPromotoriaFechas(Id, IdStatusTramite, Fecha_Inicio, Fecha_Termino);
            //repeater.DataBind();
        }

        public void ListaTramitesPromotoriaEstado(ref Repeater repeater, string quincena, string tiponomina, string estado)
        {
            Funciones.LlenarControles.LlenarRepeater(ref repeater, tramitesPromotoria.ListaTramitesPromotoriaEstado(quincena, tiponomina, estado));
            //repeater.DataSource = tramitesPromotoria.ListaTramitesPromotoriaEstado(Funciones.Nums.TextoAEntero(idpromotoria), Funciones.Nums.TextoAEntero(quincena), estado);
            //repeater.DataBind();
        }

        public void ListaTramitesPromotoriaPendientes(ref Repeater repeater, int Id)
        {
            //return tramitesPromotoria.ListaTramitesPromotoriaPendientes(Id);

            Funciones.LlenarControles.LlenarRepeater(ref repeater, tramitesPromotoria.ListaTramitesPromotoriaPendientes(Id));
        }
    }
}
