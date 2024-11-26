using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class Asignar
    {
        AccesoDatos.Procesos.Mesa mesa = new AccesoDatos.Procesos.Mesa();
        AccesoDatos.Procesos.TramiteMesa tramitemesa = new AccesoDatos.Procesos.TramiteMesa();
        AccesoDatos.Procesos.TramiteMesaBitacora tramitemesabitacora = new AccesoDatos.Procesos.TramiteMesaBitacora();
        AccesoDatos.Procesos.Tramite_Asigna_Futuro tramiteasignafuturo = new AccesoDatos.Procesos.Tramite_Asigna_Futuro();

        public void MostrarMesasDisponibles(ref GridView gridview, string idflujo)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, mesa.SeleccionarPorFlujo(idflujo));
        }

        public void CambiarUsuarioAnterior(string idtramitemesa, string idusuario)
        {
            tramitemesa.ModificarUsuarioAnterior(idtramitemesa, idusuario);
        }

        public void AgregarTramiteMesaBitacoraCambios(string idusuarioanterior, string idusuarionuevo, string idusuariocambio, string idtramitemesa)
        {
            tramitemesabitacora.Agregar(idusuarioanterior, idusuarionuevo, idusuariocambio, idtramitemesa);
        }

        public void AgregarUsuarioFuturo(string idusuario, string idusuarioasigna, string idtramite)
        {
            tramiteasignafuturo.AgregarUsuarioFuturo(idusuario, idusuarioasigna, idtramite);
        }

    }
}
