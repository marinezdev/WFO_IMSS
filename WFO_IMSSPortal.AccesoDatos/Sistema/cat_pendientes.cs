using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class cat_pendientes
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Seleccionar()
        {
            string consulta = "SELECT * FROM cat_pendientes";
            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public int Modificar(string id, string nombre, string tipo, string icono, string activo, string fecharegistro)
        {
            string consulta = "UPDATE cat_pendientes SET nombre=@nombre, tipo=@tipo, icono=@icono, activo=@activo, fecha_registro=@fecharegistro WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 150);
            b.AddParameter("@tipo", tipo, SqlDbType.NChar, 250);
            b.AddParameter("@icono", icono, SqlDbType.VarChar, 20);
            b.AddParameter("@activo", activo, SqlDbType.Bit);
            b.AddParameter("@fecharegistro", fecharegistro, SqlDbType.DateTime);
            return b.InsertUpdateDelete();
        }

    }
}
