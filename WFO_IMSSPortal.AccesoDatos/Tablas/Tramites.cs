using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class Tramites
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable GetTramites(int IdPromotoria)
        {
            b.ExecuteCommandSP("Tramites_Obtener");
            b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
            return b.Select();
        }

        public DataSet GetEfectividad(string tiponomina, string quincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Efectividad");
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", quincena, SqlDbType.VarChar, 6);
            return b.SelectExecuteFunctions();
        }

        public DataSet GetEfectividadOperacion(string tiponomina, string quincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_EfectividadOpera");
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", quincena, SqlDbType.VarChar, 6);
            return b.SelectExecuteFunctions();
        }

        public DataSet ObtenerEfectividadPorPromotoria(string tiponomina, string quincena, string clavepromotoria)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Efectividad_PorPromotoria");
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", quincena, SqlDbType.VarChar, 6);
            b.AddParameter("@promotoriaclave", clavepromotoria, SqlDbType.VarChar, 2);
            return b.SelectExecuteFunctions();
        }

        public DataTable GetMovimientos()
        {
            b.ExecuteCommandSP("Tramites_Obtener_Movimientos");
            return b.Select();
        }

        public DataTable ObtenerMovimientos(string quincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Movimientos");
            b.AddParameter("@annquincena", quincena, SqlDbType.VarChar, 6);
            return b.Select();
        }

        public DataTable GetConcentrado_Bajas()
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado_Bajas");
            return b.Select();
        }

        public DataTable GetConcentrado()
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado");
            return b.Select();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tiponomina"></param>
        /// <param name="annquincena"></param>
        /// <returns></returns>
        /// <exception cref="">Parametros anteriores:  string FechaIncio, string FechaFin, string tiponomina, string annquincena</exception>
        public DataTable ObtenerConcentrado(string tiponomina, string annquincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado");
            //b.AddParameter("@FechaInicio", FechaIncio, SqlDbType.NVarChar, 19);
            //b.AddParameter("@FechaFin", FechaFin, SqlDbType.NVarChar, 19);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", annquincena, SqlDbType.VarChar, 100);
            return b.Select();
        }

        public DataTable ObtenerConcentradoEfectividad(string tiponomina, string annquincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado_Efectividad");
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", annquincena, SqlDbType.VarChar, 100);
            return b.Select();
        }

        public DataSet ObtenerConcentradoEfectividadPorPromotoria(string tiponomina, string annquincena, string clavepromotoria)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado_Efectividad_PorPromotoria");
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", annquincena, SqlDbType.VarChar, 100);
            b.AddParameter("@clavepromotoria", clavepromotoria, SqlDbType.NVarChar, 3);
            return b.SelectExecuteFunctions();
        }

        public DataTable GetConcentrado(int IdPromotoria)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado_Promotoria");
            b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
            return b.Select();
        }

        public DataTable GetConcentrado(int IdPromotoria, string tiponomina, string annquincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado_Promotoria");
            b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 100);
            b.AddParameter("@annquincena", annquincena, SqlDbType.VarChar, 100);
            return b.Select();
        }

        public DataTable ObtenerConcentrado(string IdPromotoria, string FechaIncio, string FechaFin, string tiponomina, string annquincena)
        {
            b.ExecuteCommandSP("Tramites_Obtener_Concentrado_Promotoria");
            b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
            return b.Select();
        }

        public DataTable GetExtraccion(string ClavePromotoria, string Quincena, string TipoNomina, string TipoMovimiento)
        {
            b.ExecuteCommandSP("Movimientos_Extraccion_MovimientosPromotoria");
            b.AddParameter("@ClavePromotoria", ClavePromotoria, SqlDbType.NChar, 10);
            b.AddParameter("@Quincena", Quincena, SqlDbType.NChar, 100);
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.NChar, 100);
            b.AddParameter("@TipoMovimiento", TipoMovimiento, SqlDbType.NChar, 100);
            return b.Select();
        }

        public DataTable GetExtraccion(int IdUsuario, string Folio)
        {
            b.ExecuteCommandSP("Movimientos_Extraccion_Query");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            return b.Select();
        }

        public DataRow GetValidarCartaInstruccion(int IdUsuario)
        {
            string strSQL = "Tramites_Validar";
            b.ExecuteCommandSP(strSQL);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            return b.SelectDataRow();
        }

        public DataRow GetProcesarTramite(int IdUsuario)
        {
            string strSQL = "Tramites_Procesar";
            b.ExecuteCommandSP(strSQL);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            return b.SelectDataRow();
        }

        public DataTable DatosValidaCartaInstruccion(int IdMovimiento)
        {
            string strSQL = "SELECT MovimientosPolizas.Id, MovimientosPolizas.IdTramite, TRAMITE_FOLIO.FOLIOCOMPUESTO AS Folio, MovimientosPolizas.Poliza, MovimientosPolizas.UnidadPago, MovimientosPolizas.Archivo, MovimientosPolizas.TipoNomina, MovimientosPolizas.TipoMovimiento, MovimientosPolizas.AnnQuincena, CONCENTRADO.MATRICULA,CONCENTRADO.IMPORTE,CONCENTRADO.USR_SERVICIO,CONCENTRADO.NOMBRE_TRABAJADOR,CONCENTRADO.PROM_ORIGEN,CONCENTRADO.PROM_U_SERV,CONCENTRADO.PROM_RESPON FROM MovimientosPolizas, CONCENTRADO, TRAMITE_FOLIO WHERE TRAMITE_FOLIO.IDTRAMITE = MovimientosPolizas.IdTramite AND ( MovimientosPolizas.AnnQuincena = CONCENTRADO.ANO_QUINCENA AND MovimientosPolizas.Poliza = CONCENTRADO.POLIZA AND MovimientosPolizas.TipoMovimiento = CONCENTRADO.TIPO_MOVIMIENTO AND MovimientosPolizas.TipoNomina = CONCENTRADO.TIPO_NOMINA AND MovimientosPolizas.UnidadPago = CONCENTRADO.UNIDAD_PAGO ) AND MovimientosPolizas.Id = @Id;";
            b.ExecuteCommandQuery(strSQL);
            b.AddParameter("@Id", IdMovimiento, SqlDbType.Int);
            return b.Select();
        }

        public int AgregarConcentrado(string IdMovimiento, string IdTramite, string IdUsuario, string Matricula, string Importe, string Poliza, string PromOrigen, string UsuarioServicio, string PromUltimoSer, string PromResponsable, string TipoMovimiento, string UnidadPago, string TipoNomina, string AnoQuincena, string EstadoCarta, string EstadoCartaInstruccionNoAplica, string EstadoCartaInstruccionRechazo, string MotivoRechazo, string strEstado, string Nombre)
        {
            b.ExecuteCommandSP("Movimientos_AddConcentrado");
            b.AddParameter("@IdMovimiento", IdMovimiento, SqlDbType.Int);
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Matricula", Matricula, SqlDbType.VarChar);
            b.AddParameter("@Importe", Importe, SqlDbType.VarChar);
            b.AddParameter("@Poliza", Poliza, SqlDbType.VarChar);
            b.AddParameter("@PromotoriaOrigen", PromOrigen, SqlDbType.VarChar);
            b.AddParameter("@UsuarioServicio", UsuarioServicio, SqlDbType.VarChar);
            b.AddParameter("@PromotoriaUltimoServicio", PromUltimoSer, SqlDbType.VarChar);
            b.AddParameter("@PromotoriaResponsable", PromResponsable, SqlDbType.VarChar);
            b.AddParameter("@TipoMovimiento", TipoMovimiento, SqlDbType.VarChar);
            b.AddParameter("@NombreTrabajador", Nombre, SqlDbType.VarChar);
            b.AddParameter("@UnidadPago", UnidadPago, SqlDbType.VarChar);
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar);
            b.AddParameter("@AnnQna", AnoQuincena, SqlDbType.VarChar);
            b.AddParameter("@EstadoCarta", EstadoCarta, SqlDbType.VarChar);
            b.AddParameter("@EstadoCartaInstruccionNoAplica", EstadoCartaInstruccionNoAplica, SqlDbType.VarChar);
            b.AddParameter("@EstadoCartaInstruccionRechazo", EstadoCartaInstruccionRechazo, SqlDbType.VarChar);
            b.AddParameter("@MotivoRechazo", MotivoRechazo, SqlDbType.VarChar);
            b.AddParameter("@Estado", strEstado, SqlDbType.VarChar);
            return b.InsertUpdateDeleteWithTransaction();
        }

        public int ValidarMovimiento(int IdMovimiento, int StatusValidacion, string Motivo1, string Motivo2)
        {
            int Resultado = 0;
            b.ExecuteCommandSP("Tramites_ValidaCartaInstruccion");
            b.AddParameter("@IdMovimiento", IdMovimiento, SqlDbType.Int);
            b.AddParameter("@StatusValidacion", StatusValidacion, SqlDbType.Int);
            b.AddParameter("@StatusRechazo1", Motivo1, SqlDbType.NVarChar);
            b.AddParameter("@StatusRechazo2", Motivo2, SqlDbType.NVarChar);
            Resultado = b.InsertUpdateDeleteWithTransaction();
            return Resultado;
        }

        public int ConcentradoEliminarRegistro(string id)
        {
            b.ExecuteCommandSP("Tramites_Eliminar_Registro_Concentrado");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int MovimientosEliminarRegistro(string id)
        {
            b.ExecuteCommandSP("Tramites_Eliminar_Registro_Movimientos");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
