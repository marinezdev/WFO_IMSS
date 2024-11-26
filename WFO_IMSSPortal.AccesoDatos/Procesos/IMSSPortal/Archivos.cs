using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.IMSSPortal
{
    public class Archivos
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Buscar(string nombre)
        {
            string consulta = "SELECT * FROM archivos WHERE nombre LIKE @nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", "%" + nombre + "%", SqlDbType.VarChar, 100);
            return b.Select();
        }

        public byte[] ArchivoCrear(string nombre)
        {
            string consulta = "SELECT archivo FROM archivos WHERE nombre=@nombre";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 100);
            Propiedades.Archivos resultado = new Propiedades.Archivos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Archivo = (byte[])reader["Archivo"];
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado.Archivo;
        }


        public int Agregar(string idtipo, byte[] archivo, string nombre, string idusuario)
        {
            string consulta = "INSERT INTO archivos (IdTipo, Archivo, Nombre, Activo, IdUsuario, Fecha) VALUES(@idtipo, @archivo, @nombre, 1, @idusuario, GETDATE())";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idtipo", idtipo, System.Data.SqlDbType.Int);
            b.AddParameter("@archivo", archivo, System.Data.SqlDbType.VarBinary);
            b.AddParameter("@nombre", nombre, System.Data.SqlDbType.VarChar, 100);
            b.AddParameter("@idusuario", idusuario, System.Data.SqlDbType.Int);
            return b.InsertUpdateDelete();
        }



    }
}
