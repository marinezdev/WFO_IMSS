using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Sistema
{
    public class Sesion
    {
        AccesoDatos.Sistema.Sesion session = new AccesoDatos.Sistema.Sesion();
         
        public int Agregar(Propiedades.Sesion sesion)
        {
            return session.Agregar(sesion);
        }

        public int Modificar(Propiedades.Sesion sesion)
        {
            return session.Modificar(sesion);
        }

    }
}
