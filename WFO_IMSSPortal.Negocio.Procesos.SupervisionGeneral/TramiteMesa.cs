using System.Web.UI.WebControls;
using WFO_IMSSPortal.Funciones;
using prop = WFO_IMSSPortal.Propiedades.Procesos.SupervisionGeneral;

namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class TramiteMesa
    {
        AccesoDatos.Procesos.TramiteMesa tramitemesa = new AccesoDatos.Procesos.TramiteMesa();

        public void TramiteMesaLLenarDetalle_GridView(ref GridView gridview, string idmesa, string statusmesa)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, tramitemesa.SeleccionarDetalle(idmesa, statusmesa));
        }
    }
}
