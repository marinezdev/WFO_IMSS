using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class Menu
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Menu> Seleccionar()
        {
            b.ExecuteCommandSP("Menu_Seleccionar");
            List<prop.Menu> resultado = new List<prop.Menu>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Menu item = new prop.Menu()
                {
                    IdMenu = Funciones.Nums.TextoAEntero(reader["IdMenu"].ToString()),
                    Descripcion = reader["Descripcion"].ToString(),
                    URL = reader["URL"].ToString(),
                    Icono = reader["Icono"].ToString(),
                    PerteneceA = Funciones.Nums.TextoAEntero(reader["PerteneceA"].ToString()),
                    Categoria = reader["Categoria"].ToString(),
                    Orden = Funciones.Nums.TextoAEntero(reader["Orden"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Menu> SeleccionarPertenencia()
        {
            b.ExecuteCommandSP("Menu_Seleccionar_Pertenencias");
            List<prop.Menu> resultado = new List<prop.Menu>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Menu item = new prop.Menu()
                {
                    IdMenu = Funciones.Nums.TextoAEntero(reader["IdMenu"].ToString()),
                    Descripcion = reader["Descripcion"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public prop.Menu SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Menu_Seleccionar_PorId");
            b.AddParameter("@idmenu", id, SqlDbType.Int);
            prop.Menu resultado = new prop.Menu();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Descripcion = reader["Descripcion"].ToString();
                resultado.URL = reader["URL"].ToString();
                resultado.Icono = reader["Icono"].ToString();
                resultado.PerteneceA = Funciones.Nums.TextoAEntero(reader["PerteneceA"].ToString());
                resultado.Categoria = reader["Categoria"].ToString();
                resultado.Orden = Funciones.Nums.TextoAEntero(reader["Orden"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.PermisosMenuRol> SeleccionarAsignadosPorRol(int idrol)
        {
            b.ExecuteCommandSP("Menu_Seleccionar_AsignadosPorRol");
            b.AddParameter("@idrol", idrol, SqlDbType.Int);
            List<prop.PermisosMenuRol> resultado = new List<prop.PermisosMenuRol>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.PermisosMenuRol item = new prop.PermisosMenuRol()
                {
                    IdMenu = Funciones.Nums.TextoAEntero(reader["IdMenu"].ToString()),
                    Descripcion = reader["Descripcion"].ToString(),
                    Url = reader["Url"].ToString(),
                    Pertenecea = Funciones.Nums.TextoAEntero(reader["Pertenecea"].ToString()),
                    Idrol = Funciones.Nums.TextoAEntero(reader["IdRol"].ToString()),
                    Activo = bool.Parse(reader["Activo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        // public int SeleccionarHijos(string idrol)
        public int SeleccionarHijos(string idpadre)
        {
            b.ExecuteCommandSP("Menu_seleccionar_ContarHijos");
            b.AddParameter("@idpadre", idpadre, SqlDbType.Int);
            if (b.Select().Rows.Count > 0)
                return int.Parse(b.Select().Rows[0][0].ToString());
            else
                return 0;
        }

        public List<prop.Menu> SeleccionarIconos()
        {
            b.ExecuteCommandSP("Menu_Seleccionar_Iconos");
            List<prop.Menu> resultado = new List<prop.Menu>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Menu item = new prop.Menu()
                {
                    Icono = reader["Icono"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        /// <summary>
        /// Obtiene los datos para armar un menú desde una base de datos
        /// </summary>
        /// <param name="modulo">Número de módulo</param>
        /// <param name="grupo">Número de grupo</param>
        /// <returns>Lista con los datos</returns>
        public List<prop.Menu> MenuDinamicoObtener(int idrol)
        {
            List<prop.Menu> menutotal = new List<prop.Menu>();
            b.ExecuteCommandSP("Menu_Seleccionar_Armado");
            b.AddParameter("@idrol", idrol, SqlDbType.Int);
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Menu menuitems = new prop.Menu()
                {
                    IdMenu = Funciones.Nums.TextoAEntero(reader[0].ToString()),
                    PerteneceA = int.Parse(reader[4].ToString()),
                    Icono = reader[3].ToString(),
                    Descripcion = reader[1].ToString(),
                    URL = reader[2].ToString() ?? "#"
                };
                menutotal.Add(menuitems);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return menutotal;
        }

        public int Agregar(string descripcion, string url, string icono, int pertenecea, string categoria, int orden)
        {
            b.ExecuteCommandSP("Menu_Agregar");
            b.AddParameter("@descripcion", descripcion, SqlDbType.VarChar, 150);
            b.AddParameter("@url", url, SqlDbType.VarChar, 150);
            b.AddParameter("@icono", icono, SqlDbType.VarChar);
            b.AddParameter("@pertenecea", pertenecea, SqlDbType.Int);
            b.AddParameter("@categoria", categoria, SqlDbType.VarChar);
            b.AddParameter("@orden", orden, SqlDbType.Int);
            return b.InsertUpdateDeleteWithTransaction();
        }

        public int Modificar(string descripcion, string url, string icono, int pertenecea, string categoria, int orden, int idmenu)
        {
            b.ExecuteCommandSP("Menu_Modificar");
            b.AddParameter("@descripcion", descripcion, SqlDbType.VarChar, 150);
            b.AddParameter("@url", url, SqlDbType.VarChar, 150);
            b.AddParameter("@icono", icono, SqlDbType.VarChar);
            b.AddParameter("@pertenecea", pertenecea, SqlDbType.Int);
            b.AddParameter("@categoria", categoria, SqlDbType.VarChar);
            b.AddParameter("@orden", orden, SqlDbType.Int);
            b.AddParameter("@idmenu", idmenu, SqlDbType.Int);
            return b.InsertUpdateDeleteWithTransaction();
        }

       

    }
}
