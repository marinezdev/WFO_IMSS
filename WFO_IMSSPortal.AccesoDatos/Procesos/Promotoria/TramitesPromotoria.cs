using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Promotoria
{
    public class TramitesPromotoria
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.TramitesPromotoria> ConsultaTramitesPromotoria(int IdUsuario,int IdTramite)
        {
            b.ExecuteCommandSP("Tramite_Promotoria_PorUsuario");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["Folio"].ToString(),
                    Estatus = reader["StatusTramite"].ToString(),
                    Poliza = reader["Poliza"].ToString(),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimiento = reader["TipoMovimiento"].ToString(),
                    UnidadPago = reader["UnidadPago"].ToString(),
                    Quincena = reader["Quincena"].ToString(),
                    Importe = reader["Importe"].ToString(),

                    Matricula = reader["Matricula"].ToString(),
                    Usr_Servicio = reader["Usr_Servicio"].ToString(),
                    Nombre_Trabajador = reader["Nombre_Trabajador"].ToString(),
                    Prom_Origen = reader["Prom_Origen"].ToString(),
                    Prom_Respon = reader["Prom_Respon"].ToString(),
                    Prom_U_Serv = reader["Prom_U_Serv"].ToString(),

                    // Archivo = reader["Archivo"].ToString(),
                    ArchivoNombre = reader["Nombre"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        
        public List<prop.TramitesPromotoria> ListaTramitesPromotoria(int Id)
        {
            b.ExecuteCommandSP("Tramites_Promotoria_Seleccionar_Por_IdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    Poliza = reader["Poliza"].ToString(),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimiento = reader["TipoMovimiento"].ToString(),
                    UnidadPago = reader["UnidadPago"].ToString(),
                    Quincena = reader["Quincena"].ToString(),
                    Importe = reader["Importe"].ToString(),

                    Matricula = reader["Matricula"].ToString(),
                    Usr_Servicio = reader["Usr_Servicio"].ToString(),
                    Nombre_Trabajador = reader["Nombre_Trabajador"].ToString(),
                    Prom_Origen = reader["Prom_Origen"].ToString(),
                    Prom_Respon = reader["Prom_Respon"].ToString(),
                    Prom_U_Serv = reader["Prom_U_Serv"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaFechas(int Id, int IdStatusTramite, DateTime Fecha_Inicio, DateTime Fecha_Termino)
        {
            b.ExecuteCommandSP("Tramites_Promotoria_Seleccionar_Fechas_Por_IdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@IdStatusTramite", IdStatusTramite, SqlDbType.Int);
            b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);
            b.AddParameter("@Fecha_Termino", Fecha_Termino, SqlDbType.DateTime);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    Poliza = reader["Poliza"].ToString(),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimiento = reader["TipoMovimiento"].ToString(),
                    UnidadPago = reader["UnidadPago"].ToString(),
                    Quincena = reader["Quincena"].ToString(),
                    Importe = reader["Importe"].ToString(),

                    Matricula = reader["Matricula"].ToString(),
                    Usr_Servicio = reader["Usr_Servicio"].ToString(),
                    Nombre_Trabajador = reader["Nombre_Trabajador"].ToString(),
                    Prom_Origen = reader["Prom_Origen"].ToString(),
                    Prom_Respon = reader["Prom_Respon"].ToString(),
                    Prom_U_Serv = reader["Prom_U_Serv"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaEstado(string quincena, string tiponomina, string estado)
        {
            b.ExecuteCommandSP("Indicador_General_Promotoria_PorUsuarioEstado");
            b.AddParameter("@quincena", quincena, SqlDbType.Int);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 2);
            b.AddParameter("@estado", estado, SqlDbType.NVarChar);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    Poliza = reader["Poliza"].ToString(),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimiento = reader["TipoMovimiento"].ToString(),
                    UnidadPago = reader["UnidadPago"].ToString(),
                    Quincena = reader["Quincena"].ToString(),
                    Importe = reader["Importe"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            
            return resultado;
        }

        public List<prop.TramitesPromotoria> ListaTramitesPromotoriaPendientes(int Id)
        {
            b.ExecuteCommandSP("Indicador_General_Promotoria_PorUsuarioPendientes");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            List<prop.TramitesPromotoria> resultado = new List<prop.TramitesPromotoria>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramitesPromotoria item = new prop.TramitesPromotoria()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto = reader["FolioCompuesto"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    Poliza = reader["Poliza"].ToString(),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimiento = reader["TipoMovimiento"].ToString(),
                    UnidadPago = reader["UnidadPago"].ToString(),
                    Quincena = reader["Quincena"].ToString(),
                    Importe = reader["Importe"].ToString(),

                    Matricula = reader["Matricula"].ToString(),
                    Usr_Servicio = reader["Usr_Servicio"].ToString(),
                    Nombre_Trabajador = reader["Nombre_Trabajador"].ToString(),
                    Prom_Origen = reader["Prom_Origen"].ToString(),
                    Prom_Respon = reader["Prom_Respon"].ToString(),
                    Prom_U_Serv = reader["Prom_U_Serv"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
