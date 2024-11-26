using OfficeOpenXml;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class Extraccion
    {
        AccesoDatos.Tablas.Extraccion aex = new AccesoDatos.Tablas.Extraccion();

        public void ProcesarExcel_EnlaseCasosAdicionales(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones, string rutaCartas, string QuincenaEnlace, ref int TotalCasosEspeciales)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla
            foreach (DataRow fila in dt.Rows)
            {
                //  [00]    TipoPrestamo
                //  [01]    Matricula
                //  [02]    Concepto
                //  [03]    Importe
                //  [04]    Plazo
                //  [05]    NumeroControl
                //  [06]    NumeroCredito_poliza
                //  [07]    Promotoria
                //  [08]    CifraControl
                //  [09]    TipoMovimiento
                //  [10]    NombreTrabajador
                //  [11]    Retenedor
                //  [12]    Caracter
                //  [13]    UnidadPago
                //  [14]    TipoNomina
                //  [15]    Quincena
                //  [16]    UsuarioServicio
                //  [17]    PromoUServicio
                //  [18]    PromoResponsable
                //  [19]    Carta


                if (
                    string.IsNullOrEmpty(fila[0].ToString()) &&
                    string.IsNullOrEmpty(fila[1].ToString()) &&
                    string.IsNullOrEmpty(fila[2].ToString()) &&
                    string.IsNullOrEmpty(fila[3].ToString()) &&
                    string.IsNullOrEmpty(fila[4].ToString()) &&
                    string.IsNullOrEmpty(fila[5].ToString()) &&
                    string.IsNullOrEmpty(fila[6].ToString()) &&
                    string.IsNullOrEmpty(fila[7].ToString()) &&
                    string.IsNullOrEmpty(fila[8].ToString()) &&
                    string.IsNullOrEmpty(fila[9].ToString()) &&
                    string.IsNullOrEmpty(fila[10].ToString()) &&
                    string.IsNullOrEmpty(fila[11].ToString()) &&
                    string.IsNullOrEmpty(fila[12].ToString()) &&
                    string.IsNullOrEmpty(fila[13].ToString()) &&
                    string.IsNullOrEmpty(fila[14].ToString()) &&
                    string.IsNullOrEmpty(fila[15].ToString()) &&
                    string.IsNullOrEmpty(fila[16].ToString()) &&
                    string.IsNullOrEmpty(fila[17].ToString()) &&
                    string.IsNullOrEmpty(fila[18].ToString())
                )
                {
                    return;
                }

                try
                {
                    string CartaPDF = "";
                    double dblImporte = 0;
                    dblImporte = double.Parse(fila[3].ToString().Replace(",", "").Trim());
                    CartaPDF = fila[6].ToString(); // fila[19].ToString();
                    string rutaArchivo = rutaCartas + IdUsuario.ToString() + "_" + CartaPDF;
                    //if (File.Exists(rutaArchivo))
                    //{
                    Agregar_EnlaceCasosAdicionales(
                        IdUsuario,
                        Folio,
                        Observaciones,
                        CartaPDF,
                        QuincenaEnlace,
                        fila[0].ToString(),
                        fila[1].ToString(),
                        fila[2].ToString(),
                        string.Format("{0:#.00}", dblImporte),
                        fila[4].ToString(),
                        fila[5].ToString(),
                        fila[6].ToString(),
                        fila[7].ToString(),
                        fila[8].ToString(),
                        fila[9].ToString(),
                        fila[10].ToString(),
                        fila[11].ToString(),
                        fila[12].ToString(),
                        fila[13].ToString(),
                        fila[14].ToString(),
                        fila[15].ToString(),
                        fila[16].ToString(),
                        fila[17].ToString(),
                        fila[18].ToString()
                    );
                    TotalCasosEspeciales += 1;
                    //}
                    //else
                    //{
                    //    //log.AgregarError("No se pudó subir la carta de enlace : " + rutaArchivo);
                    //}
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void ProcesarExcel_EnlaseCasosEspeciales(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones, string rutaCartas, string QuincenaEnlace, ref int TotalCasosEspeciales)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla
            foreach (DataRow fila in dt.Rows)
            {
                //  [00]    TipoPrestamo
                //  [01]    Matricula
                //  [02]    Concepto
                //  [03]    Importe
                //  [04]    Plazo
                //  [05]    NumeroControl
                //  [06]    NumeroCredito_poliza
                //  [07]    Promotoria
                //  [08]    CifraControl
                //  [09]    TipoMovimiento
                //  [10]    NombreTrabajador
                //  [11]    Retenedor
                //  [12]    Caracter
                //  [13]    UnidadPago
                //  [14]    TipoNomina
                //  [15]    Quincena

                //  [16]    PromoUServicio
                //  [17]    UsuarioServicio



                //  [18]    PromoResponsable
                //  [19]    Carta


                if (
                    string.IsNullOrEmpty(fila[0].ToString()) &&
                    string.IsNullOrEmpty(fila[1].ToString()) &&
                    string.IsNullOrEmpty(fila[2].ToString()) &&
                    string.IsNullOrEmpty(fila[3].ToString()) &&
                    string.IsNullOrEmpty(fila[4].ToString()) &&
                    string.IsNullOrEmpty(fila[5].ToString()) &&
                    string.IsNullOrEmpty(fila[6].ToString()) &&
                    string.IsNullOrEmpty(fila[7].ToString()) &&
                    string.IsNullOrEmpty(fila[8].ToString()) &&
                    string.IsNullOrEmpty(fila[9].ToString()) &&
                    string.IsNullOrEmpty(fila[10].ToString()) &&
                    string.IsNullOrEmpty(fila[11].ToString()) &&
                    string.IsNullOrEmpty(fila[12].ToString()) &&
                    string.IsNullOrEmpty(fila[13].ToString()) &&
                    string.IsNullOrEmpty(fila[14].ToString()) &&
                    string.IsNullOrEmpty(fila[15].ToString()) &&
                    string.IsNullOrEmpty(fila[16].ToString()) &&
                    string.IsNullOrEmpty(fila[17].ToString()) &&
                    string.IsNullOrEmpty(fila[18].ToString())
                )
                {
                    return;
                }

                try
                {
                    string CartaPDF = "";
                    double dblImporte = 0;
                    dblImporte = double.Parse(fila[3].ToString().Replace(",", "").Trim());
                    CartaPDF =  fila[6].ToString(); // fila[19].ToString();
                    string rutaArchivo = rutaCartas + IdUsuario.ToString() + "_" + CartaPDF;
                    //if (File.Exists(rutaArchivo))
                    //{
                        Agregar_EnlaceCasosEspeciales(
                            IdUsuario,
                            Folio,
                            Observaciones,
                            CartaPDF,
                            QuincenaEnlace, 
                            fila[0].ToString(),
                            fila[1].ToString(),
                            fila[2].ToString(),
                            string.Format("{0:#.00}", dblImporte),
                            fila[4].ToString(),
                            fila[5].ToString(),
                            fila[6].ToString(),
                            fila[7].ToString(),
                            fila[8].ToString(),
                            fila[9].ToString(),
                            fila[10].ToString(),
                            fila[11].ToString(),
                            fila[12].ToString(),
                            fila[13].ToString(),
                            fila[14].ToString(),
                            fila[15].ToString(),
                            fila[17].ToString(),
                            fila[16].ToString(),
                            fila[18].ToString()
                        );
                        TotalCasosEspeciales += 1;
                    //}
                    //else
                    //{
                    //    //log.AgregarError("No se pudó subir la carta de enlace : " + rutaArchivo);
                    //}
                }
                catch (Exception ex)
                {
                    string _error = ex.Message.ToString();
                }
            }
        }

        public DataTable ObtenerTramiteProcesado(string TipoNomina, string Quincena, string Poliza)
        { 
            return aex.ObtenerTramiteProcesado(TipoNomina, Quincena, Poliza);
        }

        public DataTable ObtenerTramiteProcesadoCarta(string TipoNomina, string Quincena, string Poliza)
        {
            return aex.ObtenerTramiteProcesadoCarta(TipoNomina, Quincena, Poliza);
        }

        public void ProcesarExcel_Efectividad(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla

            foreach (DataRow fila in dt.Rows)
            {
                if (
                    string.IsNullOrEmpty(fila[0].ToString()) &&
                    string.IsNullOrEmpty(fila[1].ToString()) &&
                    string.IsNullOrEmpty(fila[2].ToString()) &&
                    string.IsNullOrEmpty(fila[3].ToString()) &&
                    string.IsNullOrEmpty(fila[4].ToString()) &&
                    string.IsNullOrEmpty(fila[5].ToString()) &&
                    string.IsNullOrEmpty(fila[6].ToString()) &&
                    string.IsNullOrEmpty(fila[7].ToString()) &&
                    string.IsNullOrEmpty(fila[8].ToString()) &&
                    string.IsNullOrEmpty(fila[9].ToString()) &&
                    string.IsNullOrEmpty(fila[10].ToString()) &&
                    string.IsNullOrEmpty(fila[11].ToString())
                )
                {
                    return;
                }

                try
                {
                    double dblImporte = 0;
                    dblImporte = double.Parse(fila[1].ToString().Replace(",", "").Trim());

                    Agregar_Efectividad(IdUsuario, Folio, Observaciones,
                        fila[0].ToString(),
                        string.Format("{0:#.00}", dblImporte),
                        fila[2].ToString(),
                        fila[3].ToString(),
                        fila[4].ToString(),
                        fila[5].ToString(),
                        fila[6].ToString(),
                        fila[7].ToString(),
                        fila[8].ToString(),
                        fila[9].ToString(),
                        fila[10].ToString(),
                        fila[11].ToString()
                   );
                }
                catch (Exception ex)
                {
                }
            }
        }

        //Métodos públicos
        public void ProcesarExcel(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla

            foreach (DataRow fila in dt.Rows)
            {
                if (
                    string.IsNullOrEmpty(fila[0].ToString()) &&
                    string.IsNullOrEmpty(fila[1].ToString()) &&
                    string.IsNullOrEmpty(fila[2].ToString()) &&
                    string.IsNullOrEmpty(fila[3].ToString()) &&
                    string.IsNullOrEmpty(fila[4].ToString()) &&
                    string.IsNullOrEmpty(fila[5].ToString()) &&
                    string.IsNullOrEmpty(fila[6].ToString()) &&
                    string.IsNullOrEmpty(fila[7].ToString()) &&
                    string.IsNullOrEmpty(fila[8].ToString()) &&
                    string.IsNullOrEmpty(fila[9].ToString()) &&
                    string.IsNullOrEmpty(fila[10].ToString()) &&
                    string.IsNullOrEmpty(fila[11].ToString())
                )
                {
                    return;
                }

                try
                {
                    double dblImporte = 0;
                    dblImporte = double.Parse(fila[1].ToString().Replace(",","").Trim());

                    Agregar(IdUsuario, Folio, Observaciones,
                        fila[0].ToString(),
                        string.Format("{0:#.00}", dblImporte),
                        fila[2].ToString(),
                        fila[3].ToString(),
                        fila[4].ToString(),
                        fila[5].ToString(),
                        fila[6].ToString(),
                        fila[7].ToString(),
                        fila[8].ToString(),
                        fila[9].ToString(),
                        fila[10].ToString(),
                        fila[11].ToString()
                   );
                }
                catch(Exception ex)
                {
                }


                
            }
        }

        public void ProcesarExcelPolizasCanceladas(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatosConcentrado(archivo);

            //Procesar la tabla
            foreach (DataRow columna in dt.Rows)
            {
                if (
                     //    string.IsNullOrEmpty(columna[0].ToString()) 
                     // && string.IsNullOrEmpty(columna[1].ToString()) 
                       string.IsNullOrEmpty(columna[2].ToString())
                    && string.IsNullOrEmpty(columna[3].ToString())
                    && string.IsNullOrEmpty(columna[4].ToString())
                    && string.IsNullOrEmpty(columna[5].ToString())
                    && string.IsNullOrEmpty(columna[6].ToString())
                    && string.IsNullOrEmpty(columna[7].ToString())
                    && string.IsNullOrEmpty(columna[8].ToString())
                    && string.IsNullOrEmpty(columna[9].ToString())
                    && string.IsNullOrEmpty(columna[10].ToString())
                 // && string.IsNullOrEmpty(columna[11].ToString())
                )
                    return;

                try
                {
                    double dblImporte = 0;
                    dblImporte = double.Parse(columna[1].ToString().Replace(",", "").Trim());

                    AgregarPolizasCanceladas(IdUsuario, Folio, Observaciones,
                        columna[0].ToString(),
                        string.Format("{0:#.00}", dblImporte),
                        columna[2].ToString(),
                        columna[3].ToString(),
                        columna[4].ToString(),
                        columna[5].ToString(),
                        columna[6].ToString(),
                        columna[7].ToString(),
                        columna[8].ToString(),
                        columna[9].ToString(),
                        columna[10].ToString(),
                        columna[11].ToString()
                    );
                }
                catch (Exception ex)
                {
                    string _error = ex.Message.ToString();
                }
            }
        }

        public void ProcesarExcelConcentrado(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatosConcentrado(archivo);

            //Procesar la tabla
            foreach (DataRow columna in dt.Rows)
            {
                if (
                     //    string.IsNullOrEmpty(columna[0].ToString()) 
                     // && string.IsNullOrEmpty(columna[1].ToString()) 
                     string.IsNullOrEmpty(columna[2].ToString())
                    && string.IsNullOrEmpty(columna[3].ToString())
                    && string.IsNullOrEmpty(columna[4].ToString())
                    && string.IsNullOrEmpty(columna[5].ToString())
                    && string.IsNullOrEmpty(columna[6].ToString())
                    && string.IsNullOrEmpty(columna[7].ToString())
                    && string.IsNullOrEmpty(columna[8].ToString())
                    && string.IsNullOrEmpty(columna[9].ToString())
                    && string.IsNullOrEmpty(columna[10].ToString())
                    // && string.IsNullOrEmpty(columna[11].ToString())
                )
                    return;

                try
                {
                    double dblImporte = 0;
                    dblImporte = double.Parse(columna[1].ToString().Replace(",", "").Trim());

                    AgregarConcentrado(IdUsuario, Folio, Observaciones,
                        columna[0].ToString(),
                        string.Format("{0:#.00}", dblImporte),
                        columna[2].ToString(),
                        columna[3].ToString(),
                        columna[4].ToString(),
                        columna[5].ToString(),
                        columna[6].ToString(),
                        columna[7].ToString(),
                        columna[8].ToString(),
                        columna[9].ToString(),
                        columna[10].ToString(),
                        columna[11].ToString(),
                        columna[12].ToString(),
                        columna[13].ToString(),
                        columna[14].ToString(),
                        columna[15].ToString(),
                        columna[16].ToString()
                    );
                }
                catch (Exception ex)
                {
                }
            }
        }

        public DataTable ProcesarExcelPromotoria(ExcelPackage archivo)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatosPromotoria(archivo);

            ////Procesar la tabla
            foreach (DataRow columna in dt.Rows)
            {
                if (
                     string.IsNullOrEmpty(columna[0].ToString())
                     && string.IsNullOrEmpty(columna[1].ToString())
                     && string.IsNullOrEmpty(columna[2].ToString())
                     && string.IsNullOrEmpty(columna[3].ToString())
                     && string.IsNullOrEmpty(columna[4].ToString())
                     && string.IsNullOrEmpty(columna[5].ToString())
                )
                    return null;

            }

            return dt;
        }

        private int Agregar_EnlaceCasosAdicionales(int IdUsuario, string Folio, string Observaciones, string CartaPDF, string QuincenaEnlace, params string[] prms)
        {
            return aex.Agregar_EnlaceCasosAdicionales(IdUsuario, Folio, Observaciones, CartaPDF, QuincenaEnlace, prms);
        }

        private int Agregar_EnlaceCasosEspeciales(int IdUsuario, string Folio, string Observaciones, string CartaPDF, string QuincenaEnlace, params string[] prms)
        {
            return aex.Agregar_EnlaceCasosEspeciales(IdUsuario, Folio, Observaciones, CartaPDF, QuincenaEnlace, prms);
        }

        private int Agregar_Efectividad(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            return aex.Agregar_Efectividad(IdUsuario, Folio, Observaciones, prms);
        }

        //Métodos privados
        private int Agregar(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            return aex.Agregar(IdUsuario, Folio, Observaciones, prms);
        }

        private int AgregarPolizasCanceladas(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            return aex.AgregarPolizasCanceladas(IdUsuario, Folio, Observaciones, prms);
        }

        private int AgregarConcentrado(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            return aex.AgregarConcentrado(IdUsuario, Folio, Observaciones, prms);
        }
    }
}
