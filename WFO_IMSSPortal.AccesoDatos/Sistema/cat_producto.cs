using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class cat_producto
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Seleccionar()
        {
            string consulta = "SELECT * FROM cat_producto";
            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public int Agregar(string idtipotramite, string nombre, string descripcion, string activo)
        {
            string consulta = "INSERT INTO cat_producto (id_tipotramite, nombre, descripcion, activo, fecha_registro) VALUES(@idtipotramite, @nombre, @descripcion, @activo, GETDATE())";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idtipotramite", idtipotramite, SqlDbType.Int);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 150);
            b.AddParameter("@descripcion", descripcion, SqlDbType.NChar, 250);
            b.AddParameter("@activo", activo, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        public int Modificar(string id, string idtipotramite, string nombre, string descripcion, string activo, string fecharegistro)
        {
            string consulta = "UPDATE cat_producto SET id_tipotramite=@idtipotramite, nombre=@nombre, descripcion=@descripcion, activo=@activo, fecha_registro=@fecharegistro WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idtipotramite", idtipotramite, SqlDbType.Int);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 150);
            b.AddParameter("@descripcion", descripcion, SqlDbType.NChar, 250);
            b.AddParameter("@activo", activo, SqlDbType.Bit);
            b.AddParameter("@fecharegistro", fecharegistro, SqlDbType.DateTime);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
