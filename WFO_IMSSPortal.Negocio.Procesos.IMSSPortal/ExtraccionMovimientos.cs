using OfficeOpenXml;
using System.Data;
using System.IO;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class ExtraccionMovimientos
    {
        AccesoDatos.Tablas.ArchivoExcel aex = new AccesoDatos.Tablas.ArchivoExcel();
        AccesoDatos.Tablas.ArchivosTexto atxt = new AccesoDatos.Tablas.ArchivosTexto();

        //Métodos públicos

        public void ProcesarExcel(ExcelPackage archivo)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla

            foreach (DataRow fila in dt.Rows)
            {
                if (string.IsNullOrEmpty(fila[0].ToString()) && string.IsNullOrEmpty(fila[1].ToString()) && string.IsNullOrEmpty(fila[2].ToString()) &&
                    string.IsNullOrEmpty(fila[3].ToString()) && string.IsNullOrEmpty(fila[4].ToString()) && string.IsNullOrEmpty(fila[5].ToString()) &&
                    string.IsNullOrEmpty(fila[6].ToString()) && string.IsNullOrEmpty(fila[7].ToString()) && string.IsNullOrEmpty(fila[8].ToString()) &&
                    string.IsNullOrEmpty(fila[9].ToString()) && string.IsNullOrEmpty(fila[10].ToString()) && string.IsNullOrEmpty(fila[11].ToString()) &&
                    string.IsNullOrEmpty(fila[12].ToString()))
                    return;
                Agregar(fila[0].ToString(),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    fila[5].ToString(),
                    fila[6].ToString(),
                    fila[7].ToString(),
                    fila[8].ToString(),
                    fila[9].ToString(),
                    fila[10].ToString(),
                    fila[11].ToString(),
                    fila[12].ToString());
            }
        }

        public void ProcesarLineasArchivoTexto(string rutaarchivo, string nombrearchivo, string annquincena, string estructura)
        {
            using (StreamReader reader = new StreamReader(rutaarchivo))
            {
                var lineas = File.ReadAllLines(rutaarchivo);

                foreach (string linea in lineas)
                {
                    if (linea.Length == 103)
                    {
                        //agregar cada linea a la bd
                        AgregarLineasArchivoTexto(
                            linea.Substring(0, 1),      //tipo prestamo
                            linea.Substring(1, 10),     //matricula
                            linea.Substring(11, 3),     //concepto
                            linea.Substring(14, 7),     //importe
                            linea.Substring(21, 3),     //plazo
                            linea.Substring(24, 6),     //Fecha emision poliza
                            linea.Substring(30, 8),     //credito poliza
                            linea.Substring(38, 4),     //promotoria
                            linea.Substring(42, 8),     //cifra control importe
                            linea.Substring(50, 1),     //tipo movimiento
                            linea.Substring(51, 47),    //nombre trabajador
                            linea.Substring(98, 4),     //proveedor
                            linea.Substring(102, 1),    //caracter
                            nombrearchivo,              //nombre del archivo
                            annquincena,                //Año quincena
                            estructura                  //estructura
                            );
                    }
                }
            }
        }

        //Métodos privados

        private int Agregar(params string[] prms)
        {
            return aex.AgregarExcel(prms);
        }

        private int AgregarLineasArchivoTexto(params string[] prms)
        {
            return atxt.AgregarExcel(prms);
        }
    }
}
