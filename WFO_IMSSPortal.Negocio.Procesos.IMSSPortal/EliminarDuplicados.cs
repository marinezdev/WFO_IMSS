using System.Data;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class EliminarDuplicados
    {
        WFO_IMSSPortal.AccesoDatos.Tablas.Concentrado concentrado = new WFO_IMSSPortal.AccesoDatos.Tablas.Concentrado();

        public DataTable EliminarRegistrosDuplicados(string polizas)
        {
            return concentrado.SeleccionarDuplicados(polizas);
        }

        public int EliminarRegistro(string id)
        {
            return concentrado.EliminarRegistro(id);
        }
    }
}
