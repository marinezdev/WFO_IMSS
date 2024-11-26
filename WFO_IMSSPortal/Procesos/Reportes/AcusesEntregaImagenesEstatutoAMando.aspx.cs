using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Text;
using System.Web;

namespace PruebasLocales.Reportes
{
    public partial class AcusesEntregaImagenesEstatutoAMando : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarReporte();
        }

        public void GenerarReporte()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                // NOMBRE DE LA HOJA
                excel.Workbook.Worksheets.Add("ESTATUTO A MANDO");
                var worksheet = excel.Workbook.Worksheets["ESTATUTO A MANDO"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:D1"])
                {
                    Rng.Value = "INSTITUTO MEXICANO DEL SEGURO SOCIAL-METLIFE";
                    Rng.Merge = true;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["A2:D2"])
                {
                    Rng.Value = "REPORTE DE CARTAS DE INSTRUCCION ESTATUTO A MANDO QUINCENA 201913 METLIFE";
                    Rng.Merge = true;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Worksheet.Cells.AutoFitColumns();
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["A3:D3"])
                {
                    Rng.Value = "Cartas de Instruccion";
                    Rng.Merge = true;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["A4"])
                {
                    Rng.Value = "Proveedor";
                    Rng.AutoFitColumns(15);
                    Rng.Merge = true;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["B4"])
                {
                    Rng.Value = "Delegación";
                    Rng.AutoFitColumns(15);
                    Rng.Merge = true;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["C4"])
                {
                    Rng.Value = "Nombre de la Delegación";
                    Rng.AutoFitColumns(40);
                    Rng.Merge = true;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = worksheet.Cells["D4"])
                {
                    Rng.Value = "Total";
                    Rng.AutoFitColumns(15);
                    Rng.Merge = true;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Size = 11;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
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

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode("AcusesEntregaImagenesEstatutoAMando.xlsx", Encoding.UTF8));
                var ms = new System.IO.MemoryStream();
                excel.SaveAs(ms);
                ms.WriteTo(Response.OutputStream);
            }
        }
    }
}