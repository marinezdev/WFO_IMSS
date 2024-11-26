using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class ResumenValidar
    {
        ManejoDatos b = new ManejoDatos();

        public DataRow SeleccionarAsignarPrimerRegistrodisponible()
        {
            string consulta = "SELECT TOP 1 Poliza, UnidadPago, Archivo, TipoNomina, TipoMovimiento, AnnQuincena, Estado " +
            "FROM resumenvalidar " +
            "WHERE estado=1";
            b.ExecuteCommandQuery(consulta);
            return b.SelectDataRow();
        }

        public int Agregar(params string[] prms)
        {
            string consulta = "INSERT INTO MovimientosPolizas " +
            "(poliza, unidadpago, archivo, tiponomina, tipomovimiento, annquincena, estado, IdPromotoria) " +
            "VALUES" +
            "(@IdTramite, @poliza, @unidadpago, @archivo, @tiponomina, @tipomovimiento, @annquincena, 1)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@poliza", prms[0], SqlDbType.NChar, 10);
            b.AddParameter("@unidadpago", prms[1], SqlDbType.NChar, 3);
            b.AddParameter("@archivo", prms[2], SqlDbType.NVarChar, 50);
            b.AddParameter("@tiponomina", prms[3], SqlDbType.NChar, 1);
            b.AddParameter("@tipomovimiento", prms[4], SqlDbType.NChar, 1);
            b.AddParameter("@annquincena", prms[5], SqlDbType.NChar, 7);
            b.AddParameter("@annquincena", prms[6], SqlDbType.Int);
            //return b.InsertUpdateDelete();
            return 0;
        }

        public bool ValidarQuincena(string AnoQuincena, string TipoNomina)
        {
            b.ExecuteCommandSP("Quincena_Validar");
            b.AddParameter("@Quincena", AnoQuincena, SqlDbType.NVarChar, 10);
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.NVarChar, 5);
            var reader = b.ExecuteReader();
            if (reader.HasRows)
            {
                //while (reader.Read())
                //{
                //    usuario.IdUsuario = f.Numeros.ConvertirTextoANumeroEntero(reader["IdUsuario"].ToString());
                //    usuario.Clave = reader["Clave"].ToString();
                //    usuario.FechaRegistro = reader["FechaRegistro"].ToString();
                //    usuario.Nombre = reader["Nombre"].ToString();
                //    usuario.IdRol = f.Numeros.ConvertirTextoANumeroEntero(reader["IdRol"].ToString());
                //    usuario.Activo = bool.Parse(reader["Activo"].ToString());
                //    usuario.RolAcceso = reader["RutaAcceso"].ToString();
                //    usuario.ClavePromotoria = reader["ClavePromotoria"].ToString();
                //    usuario.IdPromotoria = f.Numeros.ConvertirTextoANumeroEntero(reader["IdPromotoria"].ToString());
                //}
                reader = null;
                b.ConnectionCloseToTransaction();
                return true;
            }
            else
                return false;
        }

        public int AgregarTramite(ref int IdTramite, int IdUsuario, int IdPromotoria, string poliza, string unidadpago, string archivo, string tiponomina, string tipomovimiento, string annquincena, ref string Folio)
        {
            int EstadoTramite = 0;
            int IdFolio = 0;
            string strSQL = "";
            string consulta = "";

            if (IdTramite == 0)
            {
                strSQL = "INSERT INTO Tramites (Registro, Estado, IdUsuario, IdPromotoria) VALUES (GETDATE(), @Estado, @IdUsuario, @IdPromotoria); ";
                strSQL += " SELECT @@Identity; ";
                b.ExecuteCommandQuery(strSQL);
                b.AddParameter("@Estado", EstadoTramite, SqlDbType.Int);
                b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
                b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
                IdTramite = b.SelectWithReturnValue();

                strSQL = "";
                strSQL = "INSERT INTO TRAMITE_FOLIO (IDTRAMITE, ANO, MES, DIA, PROMOTORIA, FOLIO, FOLIOCOMPUESTO) VALUES (@IDTRAMITE, RIGHT(YEAR(GETDATE()), 2), RIGHT('00' + CONVERT(varchar,MONTH(GETDATE())), 2), RIGHT('00' + CONVERT(varchar,DAY(GETDATE())), 2), (SELECT CAT_PROMOTORIAS.CLAVE FROM CAT_PROMOTORIAS WHERE CAT_PROMOTORIAS.ID = @IDPROMOTORIA), (SELECT ISNULL(MAX(FOLIO),0)+1 FROM TRAMITE_FOLIO WHERE PROMOTORIA = (SELECT CAT_PROMOTORIAS.CLAVE FROM CAT_PROMOTORIAS WHERE CAT_PROMOTORIAS.ID = @IDPROMOTORIA)), 'NA');";
                strSQL += " SELECT @@Identity; ";
                b.ExecuteCommandQuery(strSQL);
                b.AddParameter("@IDTRAMITE", IdTramite, SqlDbType.Int);
                b.AddParameter("@IDPROMOTORIA", IdPromotoria, SqlDbType.Int);
                IdFolio = b.SelectWithReturnValue();

                strSQL = "SELECT FOLIOCOMPUESTO FROM TRAMITE_FOLIO WHERE IDFOLIO = @IDFOLIO";
                b.ExecuteCommandQuery(strSQL);
                b.AddParameter("@IDFOLIO", IdFolio, SqlDbType.Int);
                Folio = b.SelectString();
            }

            consulta = "UPDATE CONCENTRADO SET FOLIO = @Folio, STATUS_FOLIO = 1 WHERE POLIZA = @Poliza AND UNIDAD_PAGO = @unidadpago AND TIPO_NOMINA = @tiponomina AND TIPO_MOVIMIENTO = @tipomovimiento AND ANO_QUINCENA = @annquincena; ";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 15);
            b.AddParameter("@poliza", poliza, SqlDbType.NChar, 10);
            b.AddParameter("@unidadpago", unidadpago, SqlDbType.NChar, 3);
            b.AddParameter("@archivo", archivo, SqlDbType.NVarChar, 50);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", tipomovimiento, SqlDbType.NChar, 1);
            b.AddParameter("@annquincena", annquincena, SqlDbType.NChar, 7);
            b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
            b.InsertUpdateDelete();

            consulta = "";
            consulta = "INSERT INTO MovimientosPolizas " +
            "(IdTramite, poliza, unidadpago, archivo, fecha, tiponomina, tipomovimiento, annquincena, estado, IdPromotoria) " +
            "VALUES" +
            "(@IdTramite, @poliza, @unidadpago, @archivo, GETDATE(), @tiponomina, @tipomovimiento, @annquincena, 1, @IdPromotoria)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            b.AddParameter("@poliza", poliza, SqlDbType.NChar, 10);
            b.AddParameter("@unidadpago", unidadpago, SqlDbType.NChar, 3);
            b.AddParameter("@archivo", archivo, SqlDbType.NVarChar, 50);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", tipomovimiento, SqlDbType.NChar, 1);
            b.AddParameter("@annquincena", annquincena, SqlDbType.NChar, 7);
            b.AddParameter("@IdPromotoria", IdPromotoria, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }
    }
}
