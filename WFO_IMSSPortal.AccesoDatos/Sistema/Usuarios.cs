using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using f = WFO_IMSSPortal.Funciones;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class Usuarios
    {
        ManejoDatos b = new ManejoDatos();

        public DataSet Buscar(string usuario)
        {
            b.ExecuteCommandQuery("DECLARE @USUARIO VARCHAR(MAX); DECLARE @COUNT INT; SET @USUARIO = @usr; " +
            "SET @COUNT = (SELECT COUNT(clave) FROM Usuarios WHERE nombre LIKE @USUARIO OR clave LIKE @USUARIO); " +
            "IF @COUNT = 1 " +
            "    BEGIN " +
            "        (SELECT IdUsuario, UPPER(Nombre) AS Nombre, Clave, Conectado, Activo, FechaCambioClave FROM Usuarios WHERE nombre LIKE @USUARIO OR clave LIKE @USUARIO); " +
            "        SELECT 'Usuario encontrado.' AS Mensaje; " +
            "    END " +
            "ELSE " +
            "    BEGIN " +
            "        (SELECT IdUsuario, UPPER(Nombre) AS Nombre, Clave, Conectado, Activo, FechaCambioClave FROM Usuarios WHERE nombre LIKE @USUARIO OR clave LIKE @USUARIO); " +
            "        SELECT 'Usuarios encontrados, elija.' AS Mensaje; " +
            "    END ");
            b.AddParameter("@usr", "%" + usuario + "%", SqlDbType.VarChar, 100);
            return b.SelectExecuteFunctions();
        }

        public List<Propiedades.Usuarios> SeleccionarTodo()
        {
            b.ExecuteCommandSP("Usuarios_Seleccionar");
            List<Propiedades.Usuarios> resultado = new List<Propiedades.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Usuarios item = new Propiedades.Usuarios()
                {
                    IdUsuario       = f.Nums.TextoAEntero(reader["IdUsuario"].ToString()),
                    Clave           = reader["Clave"].ToString(),
                    FechaRegistro   = reader["FechaRegistro"].ToString(),
                    Nombre          = reader["Nombre"].ToString(),
                    RolNombre       = reader["RolNombre"].ToString(),
                    Activo          = bool.Parse(reader["Activo"].ToString())

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Propiedades.Usuarios SeleccionarPorId(int id)
        {
            b.ExecuteCommandSP("Usuarios_Seleccionar_PorId");
            b.AddParameter("@Idusuario", id, SqlDbType.Int);
            Propiedades.Usuarios resultado = new Propiedades.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdUsuario = f.Nums.TextoAEntero(reader["IdUsuario"].ToString());
                resultado.Clave = reader["Clave"].ToString();
                resultado.FechaCambioClave = reader["FechaCambioClave"].ToString();
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.IdRol = f.Nums.TextoAEntero(reader["IdRol"].ToString());
                resultado.Correo = reader["Correo"].ToString();
                resultado.Activo = bool.Parse(reader["Activo"].ToString());
                resultado.RolAcceso = reader["Acceso"].ToString();
                resultado.IdPromotoria = Funciones.Nums.TextoAEntero(reader["IdPromotoria"].ToString());
                resultado.ClavePromotoria = reader["ClavePromotoria"].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public Propiedades.Usuarios SeleccionarDetalle(string clave, string contra)
        {
            b.ExecuteCommandSP("Usuarios_Seleccionar_Detalle");
            b.AddParameter("@clave", clave, SqlDbType.VarChar, 50);
            b.AddParameter("@contrasena", Seguridad.Cifrado.Encriptar(contra), SqlDbType.VarChar, 50);
            Propiedades.Usuarios resultado = new Propiedades.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.IdUsuario = f.Nums.TextoAEntero(reader["IdUsuario"].ToString());
                resultado.Clave = reader["Clave"].ToString();
                resultado.FechaRegistro = reader["FechaRegistro"].ToString();
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.IdRol = f.Nums.TextoAEntero(reader["IdRol"].ToString());
                resultado.Activo = bool.Parse(reader["Activo"].ToString());
                resultado.IdPromotoria = f.Nums.TextoAEntero(reader["IdPromotoria"].ToString());
                resultado.ClavePromotoria = reader["ClavePromotoria"].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }

        public int SeleccionarDiasParaCambioContraseña(string usuario)
        {
            // TODO: ###Pendiente: Hay que corregir que si se vencen los días para el cambio de contraseña ya no se puede acceder al sistema
            string consulta = "SELECT DATEDIFF(DAY, GETDATE(), FechaCambioClave) FROM usuarios WHERE idusuario=@usuario";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@usuario", usuario, SqlDbType.Int);
            return int.Parse(b.SelectString());
        }

        public int SeleccionarDiasQuedanAvisoCambioContraseña(string usuario)
        {
            string consulta = "SELECT DATEDIFF(DAY, GETDATE(),(SELECT fechacambioclave FROM usuarios WHERE IdUsuario=@usuario)) AS Calculo FROM Configuracion WHERE id=3";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@usuario", usuario, SqlDbType.Int);
            return Funciones.Nums.TextoAEntero(b.SelectString());
        }

        public int Agregar(Propiedades.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Usuarios_Agregar");
            b.AddParameter("@nombre", usuarios.Nombre, SqlDbType.VarChar, 50);
            b.AddParameter("@clave", usuarios.Clave, SqlDbType.VarChar, 30);
            b.AddParameter("@contrasena", Seguridad.Cifrado.Encriptar(usuarios.Contraseña), SqlDbType.VarChar, 50);
            b.AddParameter("@idrol", usuarios.IdRol, SqlDbType.Int);
            b.AddParameter("@fechacambioclave", f.Fechas.ConvertirTextoAFecha(usuarios.FechaCambioClave), SqlDbType.DateTime);
            b.AddParameter("@correo", usuarios.Correo, SqlDbType.VarChar, 150);
            return b.InsertUpdateDelete();
        }

        public void AgregarUsuarioOperacion(string nombre, string correo, string clave)
        {
            b.ExecuteCommandSP("Usuarios_Agregar_Operacion");
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 150);
            b.AddParameter("@correo", correo, SqlDbType.VarChar, 150);
            b.AddParameter("@clave", clave, SqlDbType.VarChar, 20);
            b.InsertUpdateDelete();
        }

        public void AgregarUsuarioPromotoria(string clavepromotoria, string nombre, string correo, string clave)
        {
            b.ExecuteCommandSP("Usuarios_Agregar_Promotoria");
            b.AddParameter("@clavepromotoria", clavepromotoria, SqlDbType.VarChar, 10);
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 50);
            b.AddParameter("@correo", correo, SqlDbType.VarChar, 150);
            b.AddParameter("@clave", clave, SqlDbType.VarChar, 30);
            b.InsertUpdateDelete();
        }

        public void AgregarUsuarioSuper(string nombre, string correo, string clave)
        {
            b.ExecuteCommandSP("Usuarios_Agregar_Super");
            b.AddParameter("@nombre", nombre, SqlDbType.VarChar, 50);
            b.AddParameter("@correo", correo, SqlDbType.VarChar, 150);
            b.AddParameter("@clave", clave, SqlDbType.VarChar, 30);
            b.InsertUpdateDelete();
        }

        public int Modificar(Propiedades.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Usuarios_Actualizar");
            b.AddParameter("@idusuario", usuarios.IdUsuario, SqlDbType.Int);
            b.AddParameter("@nombre", usuarios.Nombre, SqlDbType.VarChar, 50);
            b.AddParameter("@clave", usuarios.Clave, SqlDbType.VarChar, 30);
            b.AddParameter("@fechacambioclave", f.Fechas.PrepararFechaParaAgregar(usuarios.FechaCambioClave), SqlDbType.DateTime);
            b.AddParameter("@idrol", usuarios.IdRol, SqlDbType.Int);
            b.AddParameter("@correo", usuarios.Correo, SqlDbType.VarChar, 150);
            b.AddParameter("@activo", usuarios.Activo, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        public int ModificaConectarSesion(int id, int estado)
        {
            ManejoDatos bb = new ManejoDatos();
            bb.ExecuteCommandSP("Usuarios_Actualizar_Conectar");
            bb.AddParameter("@id", id, SqlDbType.Int);
            bb.AddParameter("@conectado", estado, SqlDbType.Bit);
            return bb.InsertUpdateDelete();
        }

       public int ModificaLogSesion(string IdSesion, string IdUsuario, string InicioSesion, int Modo)
        {
            ManejoDatos bb = new ManejoDatos();
            bb.ExecuteCommandSP("Usuarios_Modificar_LogUsuarios");
            bb.AddParameter("@IdSesion", IdSesion, SqlDbType.VarChar);
            bb.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            bb.AddParameter("@InicioSesion", InicioSesion, SqlDbType.DateTime);
            bb.AddParameter("@Modo", Modo, SqlDbType.Int);
            return bb.InsertUpdateDelete();
        }

        public int ModificaDesconectarSesion(int id, int estado, int idcierresesion)
        {
            b.ExecuteCommandSP("Usuarios_Actualizar_Desconectar");
            b.AddParameter("@id", id, SqlDbType.Int);
            b.AddParameter("@conectado", estado, SqlDbType.Bit);
            b.AddParameter("@idcierresesion", idcierresesion, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int ModificarContraseña(int id, string contrasena)
        {
            b.ExecuteCommandSP("Usuarios_Actualizar_Contraseña");
            b.AddParameter("@idusuario", id, SqlDbType.Int);
            b.AddParameter("@contrasena", Seguridad.Cifrado.Encriptar(contrasena), SqlDbType.VarChar, 50);
            return b.InsertUpdateDelete();
        }

        public int ModificaDesactivar(string idusuario)
        {
            b.ExecuteCommandQuery("UPDATE Usuarios SET Conectado = 0, FechaConectado = NULL WHERE IdUsuario = @idusuario;");

            //b.ExecuteCommandQuery("IF (SELECT Conectado FROM Usuarios WHERE idusuario=@idusuario) = 0 " +
            //"BEGIN " +
            //"        UPDATE Usuarios SET Conectado = 1 WHERE IdUsuario = @idusuario " +
            //"    END " +
            //"--ELSE IF(SELECT Conectado FROM Usuarios WHERE idusuario = @idusuario) = 0 " +
            //"--    BEGIN " +
            //"--        UPDATE Usuarios SET Conectado = 1 WHERE IdUsuario = @idusuario " +
            //"--    END");
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public bool Validar(string clave, string contraseña, IU.ManejadorSesion sesion)
        {
            sesion.Inicializar();

            Propiedades.Usuarios usuario = new Propiedades.Usuarios();

            b.ExecuteCommandSP("Usuarios_Seleccionar_Validar");
            b.AddParameter("@clave", clave, SqlDbType.VarChar, 15);
            b.AddParameter("@contra", Seguridad.Cifrado.Encriptar(contraseña), SqlDbType.VarChar, 50);
            var reader = b.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    usuario.IdUsuario = f.Nums.TextoAEntero(reader["IdUsuario"].ToString());
                    usuario.Clave = reader["Clave"].ToString();
                    usuario.FechaRegistro = reader["FechaRegistro"].ToString();
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.IdRol = f.Nums.TextoAEntero(reader["IdRol"].ToString());
                    usuario.Activo = bool.Parse(reader["Activo"].ToString());
                    usuario.RutaAcceso = reader["Acceso"].ToString();
                    usuario.IdPromotoria = f.Nums.TextoAEntero(reader["IdPromotoria"].ToString());
                    usuario.ClavePromotoria = reader["ClavePromotoria"].ToString();
                }
                reader = null;
                b.ConnectionCloseToTransaction();
                sesion.Usuarios = usuario;
                return true;
            }
            else
                return false;
        }

        public int ReiniciarContraseña(string idusuario)
        {
            string consulta = "" +
                " IF (@idusuario>1) " +
                " BEGIN " +
                "      UPDATE usuarios SET contrasena='VBFeBURFGrHzDMpl3h++wQ==', FechaCambioClave=(FechaCambioclave+30) WHERE idusuario=@idusuario " +
                " END ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            return b.InsertUpdateDelete();

        }

        public int ReiniciarFechaCambioClave(string idusuario)
        {
            string consulta = "UPDATE usuarios SET FechaCambioClave=(FechaCambioclave+30) WHERE idusuario=@idusuario";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        //Modificado para simplificación
        public bool UsuariosValidarAcceso(string clave, string contra, IU.ManejadorSesion sesion, List<string> resultado)
        {
            sesion.Inicializar();

            Propiedades.Usuarios usuario = new Propiedades.Usuarios();

            b.ExecuteCommandSP("Usuarios_Seleccionar_Validacion_Acceso");
            b.AddParameter("@clave", clave, SqlDbType.VarChar, 50);
            b.AddParameter("@contr", Seguridad.Cifrado.Encriptar(contra), SqlDbType.VarChar, 50);
            var reader = b.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.FieldCount > 2)
                {
                    while (reader.Read())
                    {
                        usuario.IdUsuario = Funciones.Nums.TextoAEntero(reader["IdUsuario"].ToString());
                        usuario.Clave = reader["Clave"].ToString();
                        usuario.FechaRegistro = reader["FechaRegistro"].ToString();
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.IdRol = Funciones.Nums.TextoAEntero(reader["IdRol"].ToString());
                        usuario.Activo = bool.Parse(reader["Activo"].ToString());
                        usuario.RolAcceso = reader["RutaAcceso"].ToString();
                        usuario.IdPromotoria = Funciones.Nums.TextoAEntero(reader["IdPromotoria"].ToString());
                        usuario.ClavePromotoria = reader["ClavePromotoria"].ToString();
                    }
                    sesion.Usuarios = usuario;

                    reader.NextResult();
                    while (reader.Read())
                    {
                        resultado.Add(reader[0].ToString());
                        resultado.Add(reader[1].ToString());
                    }
                }
                else
                {
                    while (reader.Read())
                    {
                        resultado.Add(reader[0].ToString());
                        resultado.Add(reader[1].ToString());
                    }
                }

                reader = null;
                b.ConnectionCloseToTransaction();

                return true;
            }
            else
                return false;
        }

        private void Prueba(Propiedades.Usuarios2 items)
        {
            items.IdUsuario = 0;
            items.Nombre = "Juan Perez";
            items.NombreTramiteTipo = "Investigación";
        }
    }
}