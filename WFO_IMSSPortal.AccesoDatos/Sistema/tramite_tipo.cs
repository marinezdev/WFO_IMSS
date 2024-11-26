using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class tramite_tipo
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Seleccionar()
        {
            string consulta = "SELECT * FROM tramite_tipo";
            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public int Agregar(string idflujo, string nombre, string abrevfolio, string nivel, string alcance, string tabla, string tablabitacora, string activo)
        {
            string consulta = "INSERT INTO tramitetipo (idflujo, nombre, abrevfolio, nivel, alcance, tabla, tablabitacora, activo) " +
            "VALUES(@idflujo, @nombre, @abrevfolio, @nivel, @alcance, @tabla, @tablabitacora, @activo)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idflujo", idflujo, SqlDbType.Int);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 150);
            b.AddParameter("@abrevfolio", abrevfolio, SqlDbType.VarChar, 5);
            b.AddParameter("@nivel", nivel, SqlDbType.VarChar, 50);
            b.AddParameter("@alcance", alcance, SqlDbType.VarChar, 50);
            b.AddParameter("@tabla", tabla, SqlDbType.VarChar, 50);
            b.AddParameter("@tablabitacora", tablabitacora, SqlDbType.VarChar, 35);
            b.AddParameter("@activo", activo, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        public int Modificar(string id, string idflujo, string nombre, string abrevfolio, string nivel, string alcance, string tabla, string tablabitacora, string activo)
        {
            string consulta = "UPDATE tramitetipo SET idflujo=@idflujo, nombre=nombre, abrevfolio=@abrevfolio, nivel=@nivel, alcance=@alcance, tabla=@tabla, tablabitacora=@tablabitacora, activo=@activo WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idflujo", idflujo, SqlDbType.Int);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 150);
            b.AddParameter("@abrevfolio", abrevfolio, SqlDbType.VarChar, 5);
            b.AddParameter("@nivel", nivel, SqlDbType.VarChar, 50);
            b.AddParameter("@alcance", alcance, SqlDbType.VarChar, 50);
            b.AddParameter("@tabla", tabla, SqlDbType.VarChar, 50);
            b.AddParameter("@tablabitacora", tablabitacora, SqlDbType.VarChar, 35);
            b.AddParameter("@activo", activo, SqlDbType.Bit);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
