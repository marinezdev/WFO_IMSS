using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Sistema
{
    public class Unidades_Pago
    {
        AccesoDatos.Sistema.Unidades_Pago unidadespago = new AccesoDatos.Sistema.Unidades_Pago();

        public void Seleccionar(ref GridView gridview)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, unidadespago.Seleccionar());
        }

        public int Agregar(string tiponomina, string unidadpagoconcentrado, string unidadpagoextraccion)
        {
            return unidadespago.Agregar(tiponomina, unidadpagoconcentrado, unidadpagoextraccion);
        }
    }
}
