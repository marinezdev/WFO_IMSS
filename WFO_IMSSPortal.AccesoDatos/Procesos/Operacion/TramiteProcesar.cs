using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using promotoria = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Operacion
{
    public class TramiteProcesar
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.TramiteProcesar> ObtenerTramite(int pIdTramite)
        {
            b.ExecuteCommandSP("Tramite_Selecionar_PorIdTramite");
            b.AddParameter("@IdTramite", pIdTramite, SqlDbType.Int);
            
            List<prop.TramiteProcesar> resultado = new List<prop.TramiteProcesar>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteProcesar item = new prop.TramiteProcesar()
                {
                    IdTramite           = Convert.ToInt32(reader["Id"].ToString()),
                    IdTipoTramite       = Convert.ToInt32(reader["IdTipoTramite"].ToString()),
                    FechaRegistro       = reader["FechaRegistro"].ToString(),
                    FechaTermino        = reader["FechaTermino"].ToString(),
                    IdStatus            = Convert.ToInt32(reader["IdStatus"].ToString()),
                    StatusTramite       = reader["StatusTramite"].ToString(),
                    IdPromotoria        = Convert.ToInt32(reader["IdPromotoria"].ToString()),
                    Promotoria          = reader["Promotoria"].ToString(),
                    //Archivo = (byte[])reader["IdArchivo"],
                    //ArchivoNombre = reader["Nombre"].ToString(),
                    Poliza              = reader["Poliza"].ToString(),
                    TipoNomina          = reader["TipoNomina"].ToString(),
                    TipoMovimiento      = reader["TipoMovimiento"].ToString(),
                    UnidadPago          = reader["UnidadPago"].ToString(),
                    Quincena            = reader["Quincena"].ToString(),
                    Importe             = reader["Importe"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramiteProcesar> ObtenerTramite(int pIdUsuario, int pIdMesa, int pIdTramite)
        {
            b.ExecuteCommandSP("spWFOTramiteAsignar");
            b.AddParameter("@IdMesa", pIdMesa, SqlDbType.Int);
            b.AddParameter("@IdUsuario", pIdUsuario, SqlDbType.Int);
            b.AddParameter("@IdTramite", pIdTramite, SqlDbType.Int);

            List<prop.TramiteProcesar> resultado = new List<prop.TramiteProcesar>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["Id"].ToString()) <= 0)
                {
                    prop.TramiteProcesar item = new prop.TramiteProcesar()
                    {
                        IdTramite = -1
                    };
                    resultado.Add(item);
                }
                else
                {
                    prop.TramiteProcesar item = new prop.TramiteProcesar()
                    {
                        IdTramite           = Convert.ToInt32(reader["Id"].ToString()),
                        Folio               = reader["Folio"].ToString(),
                        IdTipoTramite       = Convert.ToInt32(reader["IdTipoTramite"].ToString()),
                        FechaRegistro       = reader["FechaRegistro"].ToString(),
                        FechaTermino        = reader["FechaTermino"].ToString(),
                        IdStatus            = Convert.ToInt32(reader["IdStatus"].ToString()),
                        StatusTramite       = reader["StatusTramite"].ToString(),
                        IdPromotoria        = Convert.ToInt32(reader["IdPromotoria"].ToString()),
                        Promotoria          = reader["Promotoria"].ToString(),
                        IdUsuario           = Convert.ToInt32(reader["IdUsuario"].ToString()),
                        Usuario             = reader["Usuario"].ToString(),
                        ArchivoNombre       = reader["Nombre"].ToString(),
                        Poliza              = reader["Poliza"].ToString(),
                        TipoNomina          = reader["TipoNomina"].ToString(),
                        TipoMovimiento      = reader["TipoMovimiento"].ToString(),
                        UnidadPago          = reader["UnidadPago"].ToString(),
                        Quincena            = reader["Quincena"].ToString(),
                        Importe             = reader["Importe"].ToString(),
                        Matricula           = reader["Matricula"].ToString(),
                        Usr_Servicio        = reader["Usr_Servicio"].ToString(),
                        Nombre_Trabajador   = reader["Nombre_Trabajador"].ToString(),
                        Prom_Origen         = reader["Prom_Origen"].ToString(),
                        Prom_Respon         = reader["Prom_Respon"].ToString(),
                        Prom_U_Serv         = reader["Prom_U_Serv"].ToString(),
                        StatusConcentrado   = reader["Estado"].ToString(),
                    };
                    resultado.Add(item);
                }
                
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        
        public List<prop.TramiteProcesado> PromotoriaAcepta(int IdTramite, bool StatusPoliza, int IdUsuario, string ObservacionPublica, string ObservacionPrivada)
        {
            b.ExecuteCommandSP("spWFOPromoRevisa");
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@PolizaAceptada", StatusPoliza, SqlDbType.Bit);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Observacion", ObservacionPublica, SqlDbType.NChar);
            
            List<prop.TramiteProcesado> resultado = new List<prop.TramiteProcesado>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteProcesado item = new prop.TramiteProcesado()
                {
                    IdTramite = Convert.ToInt32(reader["IdTramite"].ToString()),
                    Accion = reader["Accion"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramiteProcesado> ReingresarTramite(int IdTramite, int IdUsuario, string ObservacionPublica, string ObservacionPrivada)
        {
            b.ExecuteCommandSP("spWFOTramiteReingresar");
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@ObservacionPub", ObservacionPublica, SqlDbType.NChar);
            b.AddParameter("@ObservacionPriv", ObservacionPrivada, SqlDbType.NChar);

            List<prop.TramiteProcesado> resultado = new List<prop.TramiteProcesado>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteProcesado item = new prop.TramiteProcesado()
                {
                    IdTramite = Convert.ToInt32(reader["IdTramite"].ToString()),
                    Accion = reader["Accion"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramiteProcesado> ProcesarTramite(int IdTramite, int IdMesa, int IdUsuario, Funciones.VariablesGlobales.StatusMesa IdStatusMesa, string ObsPublica, string ObsPrivada, string MotivosRechazo, string Importe, string PolizaPortal)
        {
            int intStatusMesa = (int)IdStatusMesa;

            b.ExecuteCommandSP("spWFOTramiteProcesar");
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@IdStatusMesa", intStatusMesa, SqlDbType.Int);
            b.AddParameter("@ObservacionPub", ObsPublica.Replace(System.Environment.NewLine, ""), SqlDbType.VarChar);
            b.AddParameter("@ObservacionPriv", ObsPrivada.Replace(System.Environment.NewLine, ""), SqlDbType.VarChar);
            b.AddParameter("@MotivosRechazo", MotivosRechazo, SqlDbType.VarChar);
            b.AddParameter("@PolizaPortal", PolizaPortal, SqlDbType.VarChar);
            b.AddParameter("@Importe", Importe, SqlDbType.VarChar);

            List<prop.TramiteProcesado> resultado = new List<prop.TramiteProcesado>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteProcesado item = new prop.TramiteProcesado()
                {
                    IdTramite = Convert.ToInt32(reader["IdTramite"].ToString()),
                    Accion = reader["Accion"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.TramiteProcesado> EnviarTramite(int IdTramite, int IdMesa, int IdMesaToSend, int IdUsuario, string observacionesPublicas, string observacionesPrivadas)
        {
            b.ExecuteCommandSP("spWFOTramiteEnviar");
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@IdMesaEnvia", IdMesa, SqlDbType.Int);
            b.AddParameter("@IdMesaRecibe", IdMesaToSend, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@ObservacionPublica", observacionesPublicas, SqlDbType.VarChar);
            b.AddParameter("@ObservacionPrivada", observacionesPrivadas, SqlDbType.VarChar);
            
            List<prop.TramiteProcesado> resultado = new List<prop.TramiteProcesado>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.TramiteProcesado item = new prop.TramiteProcesado()
                {
                    IdTramite = Convert.ToInt32(reader["IdTramite"].ToString()),
                    Accion = reader["Accion"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.RespuestaTramite> ActualizarTramite(int IdUsuario, int IdTramite, promotoria.TramiteN1 tramite)
        {
            //b.ExecuteCommandSP("spWFOTramiteActualizar");
            //b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            //b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            //b.AddParameter("@IdMoneda", tramite.IdMoneda, SqlDbType.Int);
            //b.AddParameter("@IdTipoTramite", tramite.IdTipoTramite, SqlDbType.Int);
            //b.AddParameter("@IdRiesgo", tramite.IdRiesgo, SqlDbType.Int);
            //b.AddParameter("@PrimaCotizacion", tramite.PrimaCotizacion, SqlDbType.Float);
            //b.AddParameter("@NumeroOrden", tramite.NumeroOrden, SqlDbType.NVarChar);
            //b.AddParameter("@FechaSolicitud", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramite.FechaSolicitud)), SqlDbType.DateTime);
            //b.AddParameter("@TipoPersona", tramite.TipoPersona, SqlDbType.Int);
            //b.AddParameter("@Nombre", tramite.Nombre, SqlDbType.NVarChar);
            //b.AddParameter("@ApPaterno", tramite.ApPaterno, SqlDbType.NVarChar);
            //b.AddParameter("@ApMaterno", tramite.ApMaterno, SqlDbType.NVarChar);
            //b.AddParameter("@Sexo", tramite.Sexo, SqlDbType.NVarChar);
            //b.AddParameter("@FechaNacimiento", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramite.FechaNacimiento)), SqlDbType.DateTime);
            //b.AddParameter("@RFC", tramite.RFC, SqlDbType.NVarChar);
            //b.AddParameter("@IdNacionalidad", tramite.IdNacionalidad, SqlDbType.Int);
            //b.AddParameter("@FechaConst", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramite.FechaConst)), SqlDbType.DateTime);
            //b.AddParameter("@TitularContratante", tramite.TitularContratante, SqlDbType.Int);
            //b.AddParameter("@TitularNombre", tramite.TitularNombre, SqlDbType.NVarChar);
            //b.AddParameter("@TitularApPat", tramite.TitularApPat, SqlDbType.NVarChar);
            //b.AddParameter("@TitularApMat", tramite.TitularApMat, SqlDbType.NVarChar);
            //b.AddParameter("@IdTitularNacionalidad", tramite.IdTitularNacionalidad, SqlDbType.Int);
            //b.AddParameter("@TitularSexo", tramite.TitularSexo, SqlDbType.NVarChar);
            //b.AddParameter("@TitularFechaNacimiento", string.Format("{0:yyyy/MM/dd}", DateTime.Parse(tramite.TitularFechaNacimiento)), SqlDbType.DateTime);
            //List<prop.RespuestaTramite> resultado = new List<prop.RespuestaTramite>();
            //var reader = b.ExecuteReader();
            //while (reader.Read())
            //{
            //    prop.RespuestaTramite item = new prop.RespuestaTramite()
            //    {
            //        Id = Convert.ToInt32(reader["Id"].ToString()),
            //        Folio = reader["Folio"].ToString(),
            //    };
            //    resultado.Add(item);
            //}
            //reader = null;
            //b.ConnectionCloseToTransaction();
            //return resultado;
            return null;
        }

        public prop.TipoTramite ObtenerTipoTramite(int pIdTramite)
        {
            b.ExecuteCommandSP("Tramite_Consulta_TipoTramite");
            b.AddParameter("@IdTramite", pIdTramite, SqlDbType.Int);

            prop.TipoTramite resultado = new prop.TipoTramite();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public promotoria.cat_riesgos ObtenerRiesgoTramite(int pIdTramite)
        {
            b.ExecuteCommandSP("Tramite_Consulta_IdRiesgo");
            b.AddParameter("@IdTramite", pIdTramite, SqlDbType.Int);

            promotoria.cat_riesgos resultado = new promotoria.cat_riesgos();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["IdRiesgo"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}