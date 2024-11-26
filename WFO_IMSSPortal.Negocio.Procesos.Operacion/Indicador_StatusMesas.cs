using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class Indicador_StatusMesas
    {
        AccesoDatos.Procesos.Operacion.Indicador_StatusMesas indicador = new AccesoDatos.Procesos.Operacion.Indicador_StatusMesas();

        public List<prop.Indicador_StatusMesas> StatusMesas(int pIdTramite)
        {
            return indicador.StatusMesas(pIdTramite);
        }
    }
}
