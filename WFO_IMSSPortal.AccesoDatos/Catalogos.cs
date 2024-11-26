using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using prop = WFO_IMSSPortal.Propiedades;

namespace WFO_IMSSPortal.AccesoDatos
{
    public class Catalogos
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Catalogos> Seleccionar(string tabla)
        {
            string consulta = string.Format("SELECT * FROM {0}", tabla);
            b.ExecuteCommandQuery(consulta);
            List<prop.Catalogos> resultado = new List<prop.Catalogos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Catalogos item = new prop.Catalogos
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public prop.Catalogos SeleccionarPorId(string tabla, string idNombre, string id)
        {
            string consulta = string.Format("SELECT * FROM {0} WHERE {1}=@id", tabla, idNombre);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            prop.Catalogos resultado = new prop.Catalogos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader[0].ToString());
                resultado.Nombre = reader[1].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Guarda dos valores dos columnas sin especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="columna2">Nombre de la columna 2</param>
        public void Guardar(string tabla, string valor1, string valor2)
        {
            string consulta = string.Format("INSERT INTO {0} VALUES(@valor1, @valor2)", tabla);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Guarda dos valores dos columnas con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="columna2">Nombre de la columna 2</param>
        /// <param name="valor1">Valor para el campo 1</param>
        /// <param name="valor2">Valor para el campo 2</param>
        public void Guardar(string tabla, string columna1, string columna2, string valor1, string valor2)
        {
            string consulta = string.Format("INSERT INTO {0} ({1}, {2}) VALUES(@valor1, @valor2)", tabla, columna1, columna2);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Guarda tres valores tres columnas con especificación de identidad
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre de la columna 1</param>
        /// <param name="columna2">Nombre de la columna 2</param>
        /// <param name="columna3">Nombre de la columna 3</param>
        /// <param name="valor1">Valor para el campo 1</param>
        /// <param name="valor2">Valor para el campo 2</param>
        /// <param name="valor3">Valor para el campo 3</param>
        public void Guardar(string tabla, string columna1, string columna2, string columna3, string valor1, string valor2, string valor3)
        {
            string consulta = string.Format("INSERT INTO {0} ({1}, {2}, {3}) VALUES(@valor1, @valor2, @valor3)", tabla, columna1, columna2, columna3);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.AddParameter("@valor3", valor3, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con dos valores, uno para un valor, otro para un id
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="columnaid"></param>
        /// <param name="valorcolumnaid"></param>
        /// <param name="columnanombre"></param>
        public void Modificar(string tabla, string columna1, string valor1, string valor2)
        {
            string consulta = string.Format("UPDATE {0} SET Nombre=@valor2 WHERE {1}=@valor1", tabla, columna1);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con tres valores, dos para dos campos, uno para Id
        /// </summary>
        /// <param name="tabla">Nombre de la tabla</param>
        /// <param name="columna1">Nombre del campo Id</param>
        /// <param name="valor1">Valor del campo Id</param>
        /// <param name="columna2">Nombre de la columna2</param>
        /// <param name="valor2">Valor de la columma2</param>
        /// <param name="columna3">Nombre de la columna3</param>
        /// <param name="valor3">Valor de la columna 3</param>
        public void Modificar(string tabla, string columna1, string valor1, string columna2, string valor2, string columna3, string valor3)
        {
            string consulta = string.Format("UPDATE {0} SET {2}=@valor2, {3}=@valor3 WHERE {1}=@valor1", tabla, columna1, columna2, columna3);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", valor1, SqlDbType.NVarChar);
            b.AddParameter("@valor2", valor2, SqlDbType.NVarChar);
            b.AddParameter("@valor3", valor3, SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }

        /// <summary>
        /// Modifica tabla con tres valores, dos para campos, uno para Id
        /// </summary>
        /// <param name="prms">Todos los parámetros (cuidar el orden): nombre de la tabla, nombre del campo id, valor del campo id, nombre columna 2, valor columna 2
        /// nombre columna 3, valor columna 3</param>
        public void Modificar(params string[] prms)
        {
            string consulta = string.Format("UPDATE {0} SET {2}=@valor2, {3}=@valor3 WHERE {1}=@valor1", prms[0], prms[1], prms[3], prms[5]);
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@valor1", prms[2], SqlDbType.NVarChar);
            b.AddParameter("@valor2", prms[4], SqlDbType.NVarChar);
            b.AddParameter("@valor3", prms[6], SqlDbType.NVarChar);
            b.InsertUpdateDelete();
        }
    }
}
