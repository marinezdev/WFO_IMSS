using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Procesos
{
    public class Mesa
    {
        ManejoDatos b = new ManejoDatos();
        public DataTable Mesas()
        {
           string consulta = "SELECT DISTINCT Nombre FROM mesa WHERE Activo=1 AND Nombre<>'PROMOTORÍA'";
           b.ExecuteCommandQuery(consulta);
           return b.Select();
        }
        public DataTable DatosReporteSabana(string fechaDesde, string fechaHasta, string idFlujo)
        {
            string consulta = "EXEC SABANA_Generar_Reporte @fechaDesde,@fechaHasta,@idFlujo";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("fechaDesde", fechaDesde, SqlDbType.Date);
            b.AddParameter("fechaHasta", fechaHasta, SqlDbType.Date);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            return b.Select();
        }

        public DataTable DatosReporteGeneralMesa(string fechaDesde, string fechaHasta,string idFlujo)
        {
            DataTable dt = new DataTable();
            DataTable mesa = new DataTable();
            DataTable mesaTranspuesta = new DataTable();
            DataTable Suspendidos = new DataTable();
            DataTable SuspendidosTrans = new DataTable();
            DataTable Hold = new DataTable();
            DataTable Rechazado = new DataTable();
            DataTable Ejecucion = new DataTable();
            DataTable Registrado = new DataTable();
            DataTable Proceso = new DataTable();

            string qMesa = "SELECT DISTINCT Nombre as ESTATUS FROM mesa WHERE Activo=1 AND IdFlujo=@idFlujo";
            b.ExecuteCommandQuery(qMesa);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            mesa = b.Select();
            mesa.Rows.Add("TOTAL");

            string tSuspendido = string.Empty;
            string tHold = string.Empty;
            string tRechazado = string.Empty;
            string tEjecucion = string.Empty;
            string tProceso = string.Empty;
            int indice;

            foreach (DataRow mesaNombre in mesa.Rows)
            {
                if (!string.Equals("TOTAL", mesaNombre[0]))
                {
                    string MesaNombre = mesaNombre[0].ToString();
                    tSuspendido += "SELECT ISNULL(SUM(Total),0) as Suspendidos FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'"+MesaNombre+"','9',"+ idFlujo + ") " +
                                   "UNION ALL ";
                    tHold += "SELECT ISNULL(SUM(Total),0) as Hold FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'"+MesaNombre+"','6',"+idFlujo +") " +
                             "UNION ALL ";
                    tRechazado += "SELECT ISNULL(SUM(Total),0) as Rechazados FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'"+MesaNombre+"','18',"+ idFlujo+") " +
                                  "UNION ALL ";
                    tEjecucion += "SELECT ISNULL(SUM(Total),0) as Ejecucion FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'"+MesaNombre+"','2,7,8,12,13,16,10,11',"+idFlujo +") " +
                                  "UNION ALL ";
                    tProceso += "SELECT ISNULL(SUM(Total),0) as Procesado FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'"+MesaNombre+"','17',"+ idFlujo+") " +
                                "UNION ALL ";
                }
            }

            //Totales
            tSuspendido += "SELECT ISNULL(SUM(Total),0) as Suspendidos FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'%','9',@idFlujo)";
            tHold += "SELECT ISNULL(SUM(Total),0) as Hold FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'%','6',@idFlujo)";
            tRechazado += "SELECT ISNULL(SUM(Total),0) as Rechazados FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'%','18',@idFlujo)";
            tEjecucion += "SELECT ISNULL(SUM(Total),0) as Ejecucion FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'%','2,7,8,12,13,16,10,11',@idFlujo)";
            tProceso += "SELECT ISNULL(SUM(Total),0) as Procesado FROM FN_TotalMesa(@fechaDesde,@fechaHasta,'%','17',@idFlujo)";

            mesaTranspuesta = GenerateTransposedTable(mesa);

            b.ExecuteCommandQuery(tSuspendido);
            b.AddParameter("fechaDesde", fechaDesde, SqlDbType.DateTime);
            b.AddParameter("fechaHasta", fechaHasta, SqlDbType.DateTime);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            Suspendidos = b.Select();
          
            b.ExecuteCommandQuery(tHold);
            b.AddParameter("fechaDesde", fechaDesde, SqlDbType.DateTime);
            b.AddParameter("fechaHasta", fechaHasta, SqlDbType.DateTime);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            Hold = b.Select();

            b.ExecuteCommandQuery(tRechazado);
            b.AddParameter("fechaDesde", fechaDesde, SqlDbType.DateTime);
            b.AddParameter("fechaHasta", fechaHasta, SqlDbType.DateTime);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            Rechazado = b.Select();

            b.ExecuteCommandQuery(tEjecucion);
            b.AddParameter("fechaDesde", fechaDesde, SqlDbType.DateTime);
            b.AddParameter("fechaHasta", fechaHasta, SqlDbType.DateTime);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            Ejecucion = b.Select();

            b.ExecuteCommandQuery(tProceso);
            b.AddParameter("fechaDesde", fechaDesde, SqlDbType.DateTime);
            b.AddParameter("fechaHasta", fechaHasta, SqlDbType.DateTime);
            b.AddParameter("idFlujo", idFlujo, SqlDbType.Int);
            Proceso = b.Select();

            foreach (DataColumn NMesa in mesaTranspuesta.Columns)
            {
                if (!string.Equals(NMesa.Caption, "ESTATUS"))
                {
                    dt.Columns.Add(NMesa.Caption, typeof(Int32));
                }
                else dt.Columns.Add(NMesa.Caption);
            }

            DataRow OSupendidos = dt.NewRow();
            indice = 0;
            foreach (DataColumn HeaderDG in dt.Columns)
            {
                if (string.Equals("ESTATUS", HeaderDG.ColumnName))
                {
                    OSupendidos[HeaderDG.ColumnName] = "SUSPENDIDOS";
                }
                else
                {
                    OSupendidos[HeaderDG.ColumnName] = Suspendidos.Rows[indice][0];
                    indice++;
                }
            }
            dt.Rows.Add(OSupendidos);

            DataRow OHold = dt.NewRow();
            indice = 0;
            foreach (DataColumn HeaderDG in dt.Columns)
            {
                if (string.Equals("ESTATUS", HeaderDG.ColumnName))
                {
                    OHold[HeaderDG.ColumnName] = "HOLD";
                }
                else
                {
                    OHold[HeaderDG.ColumnName] = Hold.Rows[indice][0];
                    indice++;
                }

            }
            dt.Rows.Add(OHold);

            DataRow ORechazados = dt.NewRow();
            indice = 0;
            foreach (DataColumn HeaderDG in dt.Columns)
            {
                if (string.Equals("ESTATUS", HeaderDG.ColumnName))
                {
                    ORechazados[HeaderDG.ColumnName] = "RECHAZADOS";
                }
                else
                {
                    ORechazados[HeaderDG.ColumnName] = Rechazado.Rows[indice][0];
                    indice++;
                }

            }
            dt.Rows.Add(ORechazados);

            DataRow OEjecutados = dt.NewRow();
            indice = 0;
            foreach (DataColumn HeaderDG in dt.Columns)
            {
                if (string.Equals("ESTATUS", HeaderDG.ColumnName))
                {
                    OEjecutados[HeaderDG.ColumnName] = "EN ATENCIÓN";
                }
                else
                {
                    OEjecutados[HeaderDG.ColumnName] = Ejecucion.Rows[indice][0];
                    indice++;
                }

            }
            dt.Rows.Add(OEjecutados);
            DataRow OProcesados = dt.NewRow();
            indice = 0;
            foreach (DataColumn HeaderDG in dt.Columns)
            {
                if (string.Equals("ESTATUS", HeaderDG.ColumnName))
                {
                    OProcesados[HeaderDG.ColumnName] = "PROCESADOS";
                }
                else
                {
                    OProcesados[HeaderDG.ColumnName] = Proceso.Rows[indice][0];
                    indice++;
                }

            }
            dt.Rows.Add(OProcesados);
            return dt;
        }
        private DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();
            // Se agregan las columnas haciendo un ciclo para cada fila
            // El encabezado de la primera columna es el mismo. 
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());
            // El encabezado para las demas columnas
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }
            // Se agregan las columnas por cada renglón        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }
            return outputTable;
        }

        public List<WFO_IMSSPortal.Propiedades.Procesos.SupervisionGeneral.Mesa> SeleccionarPorFlujo(string id)
        {
            List<Propiedades.Procesos.SupervisionGeneral.Mesa> resultado = new List<Propiedades.Procesos.SupervisionGeneral.Mesa>();
            try
            {

                b.ExecuteCommandSP("Mesa_Seleccionar");
                b.AddParameter("@idtramite", id, SqlDbType.Int);
                
                var reader = b.ExecuteReader();
                while (reader.Read())
                {
                    Propiedades.Procesos.SupervisionGeneral.Mesa item = new Propiedades.Procesos.SupervisionGeneral.Mesa()
                    {
                        _IdTramiteMesa = string.IsNullOrEmpty(reader["IdTramiteMesa"].ToString()) ? 0 : int.Parse(reader["IdTramiteMesa"].ToString()),
                        _Mesa = reader["Mesa"].ToString(),
                        _Estado = string.IsNullOrEmpty(reader["Estado"].ToString()) ? "" : reader["Estado"].ToString(),
                        _Usuario = string.IsNullOrEmpty(reader["Usuario"].ToString()) ? "" : reader["Usuario"].ToString()
                    };
                    resultado.Add(item);
                }
            }
            catch (Exception )
            {

            }
            finally
            {
                //reader = null;
                b.ConnectionCloseToTransaction();
            }
            return resultado;
        }

    }
}
