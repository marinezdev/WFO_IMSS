using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class Sesion 
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(Propiedades.Sesion sesion)
        {
            b.ExecuteCommandSP("Sesion_Agregar");
            b.AddParameter("@id", sesion.IdUsuario, SqlDbType.Int);
            return b.SelectWithReturnValue();
        }

        public int Modificar(Propiedades.Sesion sesion)
        {
            b.ExecuteCommandSP("Sesion_Modificar_Cerrar");
            b.AddParameter("@Id", sesion.Id, SqlDbType.Int);
            b.AddParameter("@IdUsuario", sesion.IdUsuario, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
