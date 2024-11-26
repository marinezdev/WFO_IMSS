using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Text;
using System.Web;

namespace PruebasLocales.Reportes
{
    public partial class EfectividadCartasInstruccionEA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        public void GenerarReporte()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                #region Hoja 1

                excel.Workbook.Worksheets.Add("Resumen");
                var worksheet = excel.Workbook.Worksheets["Resumen"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:E1"])
                {
                    Rng.Value = "IMSS NOMINA DE TRABAJADORES QUINCENA 2019-13";
                    Rng.Merge = true;
                    Rng.AutoFitColumns();
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 9;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["A2"])
                {
                    Rng.Value = "Promotoría último servicio";
                    Rng.Merge = true;
                    Rng.AutoFitColumns();
                    Rng.AutoFitColumns(15);
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.WrapText = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 8;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                worksheet.Row(2).Height = 40;

                using (ExcelRange Rng = worksheet.Cells["B2"])
                {
                    Rng.Value = "Identificado";
                    Rng.Merge = true;
                    Rng.AutoFitColumns(12);
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 8;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["C2"])
                {
                    Rng.Value = "Sin Carta";
                    Rng.Merge = true;
                    Rng.AutoFitColumns(12);
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 8;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["D2"])
                {
                    Rng.Value = "Total de movimientos que requieren carta instrucción";
                    Rng.Merge = true;
                    Rng.AutoFitColumns();
                    Rng.AutoFitColumns(15);
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.WrapText = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 8;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["E2"])
                {
                    Rng.Value = "Efectividad";
                    Rng.Merge = true;
                    Rng.AutoFitColumns(12);
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 8;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#92D050"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                DataTable dt = new DataTable();
                DataTable DatosSiniestros = dt; // el.SeleccionarExcelExportado(IdArchivoCarga);
                int NFilas = 2;
                foreach (DataRow row in DatosSiniestros.Rows)
                {
                    NFilas += 1;
                    int Datos = 0;
                    for (int i = 1; i <= 64; i++)
                    {
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, i, NFilas, i])
                        {
                            CeldaDato.Value = row[Datos].ToString();
                            //CeldaDato.Value = row[0].ToString();
                            CeldaDato.Merge = true;
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                            //CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Style.Font.Size = 10;
                            CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                            CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;

                            if (row["SolicitudCredito"].ToString() == "SIN IMAGEN" && row["Identificacion"].ToString() == "SIN IMAGEN" && row["TalonPago"].ToString() == "SIN IMAGEN" && row["AutCredito"].ToString() == "SIN IMAGEN")
                            {
                                if (row["Contrato"].ToString().Length > 0)
                                {
                                    //CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#EADB20"));
                                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#EADB20"));
                                }
                                else
                                {
                                    //CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#EA3C20"));
                                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#EA3C20"));
                                }
                            }
                            else
                            {
                                CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                            }



                            CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        }
                        Datos += 1;

                        /*  CAMPO DE IGUALDA CON RFC, POR POSICIONES DEL EXCEL */
                        if (row[10].ToString() != row[18].ToString() && row[10].ToString() != row[25].ToString())
                        {
                            using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 65, NFilas, 65])
                            {
                                CeldaDato.Value = "Diferente RFC";
                                //CeldaDato.Value = row[0].ToString();
                                CeldaDato.Merge = true;
                                CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                //CeldaDato.Style.Font.Bold = true;
                                CeldaDato.Style.Font.Size = 10;
                                CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#AF1616"));
                                CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            }
                        }

                        /* CAMPO DE IGUALDA CON CURP, POR POSICIONES DEL EXCEL */
                        if (row[11].ToString() != row[16].ToString() && row[11].ToString() != row[19].ToString())
                        {
                            using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 66, NFilas, 66])
                            {
                                CeldaDato.Value = "Diferente CURP";
                                //CeldaDato.Value = row[0].ToString();
                                CeldaDato.Merge = true;
                                CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                //CeldaDato.Style.Font.Bold = true;
                                CeldaDato.Style.Font.Size = 10;
                                CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#AF1616"));
                                CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                            }
                        }

                        if (row["SolicitudCredito"].ToString() == "SIN IMAGEN" && row["Identificacion"].ToString() == "SIN IMAGEN" && row["TalonPago"].ToString() == "SIN IMAGEN" && row["AutCredito"].ToString() == "SIN IMAGEN")
                        {
                            if (row["Contrato"].ToString().Length > 0)
                            {
                                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 67, NFilas, 67])
                                {
                                    CeldaDato.Value = "Contiene Imagen";
                                    //CeldaDato.Value = row[0].ToString();
                                    CeldaDato.Merge = true;
                                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                    //CeldaDato.Style.Font.Bold = true;
                                    CeldaDato.Style.Font.Size = 10;
                                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#AF1616"));
                                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                }
                            }
                        }
                    }
                }

                #endregion

                #region Hoja 2

                excel.Workbook.Worksheets.Add("Reporte");
                var worksheet2 = excel.Workbook.Worksheets["Reporte"];
                worksheet2.CustomHeight = true;

                #endregion

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode("EfectividadCartasIntruccionEA.xlsx", Encoding.UTF8));
                var ms = new System.IO.MemoryStream();
                excel.SaveAs(ms);
                ms.WriteTo(Response.OutputStream);
            }
        }
    }
}