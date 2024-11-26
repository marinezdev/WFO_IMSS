namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class TramiteBitacora
    {
        AccesoDatos.SupervisionGeneral.TramiteBitacora tramitebitacora = new AccesoDatos.SupervisionGeneral.TramiteBitacora();

        public int Agregar(string usuariocambio, string usuarioanterior, string tramite, string idpriodidadanterior)
        {
            return tramitebitacora.Agregar(usuariocambio, usuarioanterior, tramite, idpriodidadanterior);
        }


    }
}
