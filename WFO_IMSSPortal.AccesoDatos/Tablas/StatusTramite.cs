using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class StatusTramite
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Seleccionar()
        {
            b.ExecuteCommandSP("StatusTramite_Seleccionar");
            return b.Select();
        }

        public List<Propiedades.StatusTramite> SeleccionarTodo()
        {
            b.ExecuteCommandQuery("SELECT * FROM statustramite");
            List<Propiedades.StatusTramite> resultado = new List<Propiedades.StatusTramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.StatusTramite item = new Propiedades.StatusTramite()
                {
                    Id              = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre          = reader["Nombre"].ToString(),
                    Activo          = bool.Parse(reader["Activo"].ToString()),
                    Backgroundcolor = reader["BackgroundColor"].ToString(),
                    BorderColor     = reader["BorderColor"].ToString(),
                    HoverBackground = reader["HoverBackground"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Propiedades.StatusTramite SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT * FROM statustramite WHERE id=@id");
            b.AddParameter("@Id", id, SqlDbType.Int);
            Propiedades.StatusTramite resultado = new Propiedades.StatusTramite();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Activo = bool.Parse(reader["Activo"].ToString());
                resultado.Backgroundcolor = reader["BackgroundColor"].ToString();
                resultado.BorderColor = reader["BorderColor"].ToString();
                resultado.HoverBackground = reader["HoverBackground"].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public int Modificar(Propiedades.StatusTramite items)
        {
            b.ExecuteCommandQuery("UPDATE statustramite SET nombre=@nombre, activo=@activo, backgroundcolor0@backgroundcolor, bordercolor=@bordercolor, hoverbackground=hoverbackground WHERE id=@id");
            b.AddParameter("@id", items.Id, SqlDbType.Int);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.VarChar);
            b.AddParameter("@activo", items.Activo, SqlDbType.Bit);
            b.AddParameter("@backgroundcolor", items.Backgroundcolor, SqlDbType.VarChar);
            b.AddParameter("@bordercolor", items.BorderColor, SqlDbType.VarChar);
            b.AddParameter("@hoverbackground", items.HoverBackground, SqlDbType.VarChar);
            return b.InsertUpdateDelete();
        }

    }
}
