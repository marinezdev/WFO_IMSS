using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class TramiteN1
    {
        AccesoDatos.Procesos.Promotoria.NuevoTramite nuevoTramite = new AccesoDatos.Procesos.Promotoria.NuevoTramite();

        public List<prop.RespuestaNuevoTramiteN1> NuevoTramiteN1(prop.TramiteN1 tramiteN1, byte[] archivo)
        {
            return nuevoTramite.NuevoTramiteN1(tramiteN1, archivo);
        }

        public bool LogError(string Tipo, string Numero, string Severidad, string Estado, string Procedimiento, string Linea, string Mensaje)
        {
            return nuevoTramite.LogError(Tipo, Numero, Severidad, Estado, Procedimiento, Linea, Mensaje);
        }
    }
}
