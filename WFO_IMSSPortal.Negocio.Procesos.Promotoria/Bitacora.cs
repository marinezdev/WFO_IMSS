using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class Bitacora
    {
        AccesoDatos.Procesos.Promotoria.Bitacora bitacora = new AccesoDatos.Procesos.Promotoria.Bitacora();

        public void ConsultaBitacora(ref Repeater repeater, int Id)
        {
            //return bitacora.ConsultaBitacora(Id);
            repeater.DataSource = bitacora.ConsultaBitacora(Id);
            repeater.DataBind();
        }

        public List<prop.bitacora> ConsultaUltimaObervacion(int Id)
        {
            return bitacora.ConsultaUltimaBitacora(Id);
        }
    }
}
