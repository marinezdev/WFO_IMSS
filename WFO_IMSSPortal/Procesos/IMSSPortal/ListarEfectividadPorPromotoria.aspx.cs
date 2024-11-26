using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ListarEfectividadPorPromotoria : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref DDLQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }

        protected void lnkExportar_Click(object sender, EventArgs e)
        {
            DataSet dsEfectividad = null;

            try
            {
                dsEfectividad = i.imssportal.tramites.EfectividadPromotoriaExportarAExcel(RBLNomina.SelectedValue, DDLQuincena.SelectedValue, manejo_sesion.Usuarios.ClavePromotoria);

                //Funciones.ManejoExcel.ExportarDataSetAExcel(this, dsEfectividad);
                //Efectividad_GenerarXLS(dsEfectividad, DDLQuincena.SelectedValue.ToString(), RBLNomina.SelectedValue.ToString());

                myXLSExport(dsEfectividad);
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                log.Agregar("Error en el detalle de x");
            }
        }

        protected void myXLSExport(DataSet dsDatos)
        {
            // dsDatos = i.imssportal.tramites.ObtenerEfectividad_DataSet(DDLTipoNomina.SelectedValue, DDLQuincena.SelectedValue);
            // Funciones.ManejoExcel.ExportarDataSetAExcel(this, dsDatos);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dsDatos);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                for (int i = 1; i < dsDatos.Tables.Count; i++)
                {
                    wb.Worksheets.Worksheet(i);
                }

                this.Response.Clear();
                this.Response.Buffer = true;
                this.Response.Charset = "";
                this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                this.Response.AddHeader("content-disposition", "attachment;filename=ASAE_Consultores.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(this.Response.OutputStream);
                    this.Response.Flush();
                    this.Response.End();
                }
            }
        }

        protected void Efectividad_GenerarXLS(DataSet dsEfectividad, string Quincena, string TipoNomina)
        {
            string newFilePath = @"C:\TEMP\Archivo.xlsx";
            //int TotalCartasEsperadas = 0;
            //int TotalCartasFaltantes = 0;
            //int TotalMovimientos = 0;
            //float Efectividad = 0;

            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }

            FileInfo newFile = new FileInfo(newFilePath);
            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                // ======================================================================================================= \\
                // RESUMEN...
                excel.Workbook.Worksheets.Add("Resumen");
                var worksheet = excel.Workbook.Worksheets["Resumen"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z3000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:A1"])
                {
                    Rng.Value = "Promotoría último servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["B1:B1"])
                {
                    Rng.Value = "Cartas de  Instrucción Esperadas";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["C1:C1"])
                {
                    Rng.Value = "Cartas de  Instrucción Recibidas";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["D1:D1"])
                {
                    Rng.Value = "Cartas de  Instrucción identificadas";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["E1:E1"])
                {
                    Rng.Value = "Cartas de  Instrucción Rechazadas";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["F1:F1"])
                {
                    Rng.Value = "Efectividad de Cartas (Esperadas/ Identificadas)";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#538DD5"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["G1:G1"])
                {
                    Rng.Value = "Procedio en Portal ";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["H1:H1"])
                {
                    Rng.Value = "NO Procedio en Portal ";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["I1:I1"])
                {
                    Rng.Value = "Efectividad Portal Altas/Modific";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#538DD5"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["J1:J1"])
                {
                    Rng.Value = "Procedio en Portal Baja";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["K1:K1"])
                {
                    Rng.Value = "No Procedio en Portal Baja";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells["L1:L1"])
                {
                    Rng.Value = "Efectividad Portal Bajas";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#538DD5"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }

                int NFilas = 2;
                foreach (DataRow row in dsEfectividad.Tables[1].Rows)
                {
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1])
                    {
                        CeldaDato.Value = row["Promotoría último servicio"];
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2])
                    {

                        CeldaDato.Value = double.Parse(row["Cartas de  Instrucción Esperadas"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3])
                    {
                        CeldaDato.Value = double.Parse(row["Cartas de  Instrucción Recibidas"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4])
                    {
                        CeldaDato.Value = double.Parse(row["Cartas de  Instrucción identificadas"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5])
                    {
                        CeldaDato.Value = double.Parse(row["Cartas de  Instrucción Rechazadas"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                    {
                        CeldaDato.Value = double.Parse(row["Efectividad de Cartas (Esperadas/ Identificadas)"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                    {
                        CeldaDato.Value = double.Parse(row["Procedio en Portal Alta/Modif"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                    {
                        CeldaDato.Value = double.Parse(row["NO Procedio en Portal Alta/Modif"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9])
                    {
                        CeldaDato.Value = double.Parse(row["Efectividad Portal Altas/Modific"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 10])
                    {
                        CeldaDato.Value = double.Parse(row["Procedio en Portal Baja"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 11])
                    {
                        CeldaDato.Value = double.Parse(row["No Procedio en Portal Baja"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 12])
                    {
                        CeldaDato.Value = double.Parse(row["Efectividad Portal Bajas"].ToString());
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                    }
                    NFilas += 1;
                }

                NFilas -= 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1])
                {
                    CeldaDato.Value = dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Promotoría último servicio"].ToString();
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Cartas de  Instrucción Esperadas"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Cartas de  Instrucción Recibidas"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Cartas de  Instrucción identificadas"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Cartas de  Instrucción Rechazadas"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Efectividad de Cartas (Esperadas/ Identificadas)"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Procedio en Portal Alta/Modif"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["NO Procedio en Portal Alta/Modif"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Efectividad Portal Altas/Modific"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 10])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Procedio en Portal Baja"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 11])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["No Procedio en Portal Baja"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 12])
                {
                    CeldaDato.Value = double.Parse(dsEfectividad.Tables[1].Rows[dsEfectividad.Tables[1].Rows.Count - 1]["Efectividad Portal Bajas"].ToString());
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                }

                // estilos de Columnas y Renglones.
                worksheet.Row(1).Style.WrapText = true;
                worksheet.Row(1).Height = 65.25;
                worksheet.Column(1).Width = GetTrueColumnWidth(14.57);
                worksheet.Column(2).Width = GetTrueColumnWidth(11.86);
                worksheet.Column(3).Width = GetTrueColumnWidth(17.14);
                worksheet.Column(4).Width = GetTrueColumnWidth(11.57);
                worksheet.Column(5).Width = GetTrueColumnWidth(10.86);
                worksheet.Column(6).Width = GetTrueColumnWidth(17.43);
                worksheet.Column(7).Width = GetTrueColumnWidth(17.57);
                worksheet.Column(8).Width = GetTrueColumnWidth(17.43);
                worksheet.Column(9).Width = GetTrueColumnWidth(17.29);
                worksheet.Column(10).Width = GetTrueColumnWidth(11.14);
                worksheet.Column(11).Width = GetTrueColumnWidth(13.14);
                worksheet.Column(12).Width = GetTrueColumnWidth(17.43);

                // ======================================================================================================= \\
                // DETALLE...
                excel.Workbook.Worksheets.Add("Reporte");
                var wsReporte = excel.Workbook.Worksheets["Reporte"];
                wsReporte.CustomHeight = true;

                using (ExcelRange Rng = wsReporte.Cells["A1:Z5000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Calibri", 9));
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["A1:A1"])
                {
                    Rng.Value = "Matrícula";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["B1:B1"])
                {
                    Rng.Value = "Importe";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["C1:C1"])
                {
                    Rng.Value = "Póliza";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["D1:D1"])
                {
                    Rng.Value = "Promotoría de origen";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["E1:E1"])
                {
                    Rng.Value = "Usuario de Servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["F1:F1"])
                {
                    Rng.Value = "Promotoría de último servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FF0000"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["G1:G1"])
                {
                    Rng.Value = "Promotoría responsable";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["H1:H1"])
                {
                    Rng.Value = "Tipo de Movimiento";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["I1:I1"])
                {
                    Rng.Value = "Nombre del Trabajador";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["J1:J1"])
                {
                    Rng.Value = "Unidad de pago";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["K1:K1"])
                {
                    Rng.Value = "Tipo de nómina";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["L1:L1"])
                {
                    Rng.Value = "Año/Qna";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["M1:M1"])
                {
                    Rng.Value = "Estatus de la carta instrucción: OK";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["N1:N1"])
                {
                    Rng.Value = "Estatus de la carta instrucción: NO APLICA";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["O1:O1"])
                {
                    Rng.Value = "Estatus de la carta instrucción: RECHAZO";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#CCC0DA"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["P1:P1"])
                {
                    Rng.Value = "Motivo de Rechazo/Resultado Analisis o  Portal";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange Rng = wsReporte.Cells["Q1:Q1"])
                {
                    Rng.Value = "Póliza Portal";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                NFilas = 2;
                foreach (DataRow row in dsEfectividad.Tables[0].Rows)
                {
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 1])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Matricula"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 2])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = double.Parse(row["Importe"].ToString());
                        CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                        CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 3])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Póliza"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 4])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Promotoría de origen"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 5])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Usuario de Servicio"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 6])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Promotoría de último servicio"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 7])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Promotoría responsable"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 8])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Tipo de Movimiento"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 9])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Nombre del Trabajador"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 10])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Unidad de pago"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 11])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Tipo de nómina"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 12])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = double.Parse(row["Año/Qna"].ToString());
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 13])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Estatus de la carta instrucción: OK"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 14])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Estatus de la carta instrucción: NO APLICA"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 15])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Estatus de la carta instrucción: RECHAZO"];
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 16])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Motivo de Rechazo/Resultado Analisis o  Portal"];
                    }

                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 17])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Dotted;
                        CeldaDato.Value = row["Póliza Portal"];
                    }

                    NFilas += 1;
                }

                wsReporte.Row(1).Style.WrapText = true;
                wsReporte.Row(1).Height = 33.75;

                wsReporte.Column(1).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(2).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(3).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(4).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(5).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(6).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(7).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(8).Width = GetTrueColumnWidth(11.57);
                wsReporte.Column(9).Width = GetTrueColumnWidth(42.43);
                wsReporte.Column(10).Width = GetTrueColumnWidth(8.00);
                wsReporte.Column(11).Width = GetTrueColumnWidth(6.14);
                wsReporte.Column(12).Width = GetTrueColumnWidth(11.14);
                wsReporte.Column(13).Width = GetTrueColumnWidth(12.57);
                wsReporte.Column(14).Width = GetTrueColumnWidth(41.29);
                wsReporte.Column(15).Width = GetTrueColumnWidth(34.43);
                wsReporte.Column(16).Width = GetTrueColumnWidth(67.86);
                wsReporte.Column(17).Width = GetTrueColumnWidth(11.57);


                // ======================================================================================================= \\
                // Catálogo de Rechazo...
                excel.Workbook.Worksheets.Add("Catálogo de Rechazos");
                var wsCR = excel.Workbook.Worksheets["Catálogo de Rechazos"];
                wsCR.CustomHeight = true;

                using (ExcelRange Rng = wsCR.Cells["A1:Z3000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Calibri", 8));
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsCR.Cells["B1:B1"])
                {
                    Rng.Value = "Rechazo";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = wsCR.Cells["C1:C1"])
                {
                    Rng.Value = "Leyenda Reporte Efectividad";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#16365C"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                }

                NFilas = 2;
                foreach (DataRow row in dsEfectividad.Tables[2].Rows)
                {
                    using (ExcelRange CeldaDato = wsCR.Cells[NFilas, 2])
                    {
                        CeldaDato.Value = row["Rechazo"];
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    using (ExcelRange CeldaDato = wsCR.Cells[NFilas, 3])
                    {
                        CeldaDato.Value = row["Leyenda"];
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    }
                    NFilas += 1;
                }

                wsCR.Column(2).Width = GetTrueColumnWidth(60.71);
                wsCR.Column(3).Width = GetTrueColumnWidth(36.71);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);

                if (File.Exists(newFilePath))
                {
                    File.Delete(newFilePath);
                }

                string strReporteEfectividad = "";

                if (TipoNomina == "GG")
                {
                    strReporteEfectividad = "Reporte de efectividad de Cartas Instrucción IMSS " + Quincena + " GENERAL.XLSX";
                }
                else
                {
                    strReporteEfectividad = "Reporte de efectividad de Cartas Instrucción IMSS " + Quincena + " " + TipoNomina.ToUpper() + ".XLSX";
                }

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;  filename=" + strReporteEfectividad + ".xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.BinaryWrite(excel.GetAsByteArray());
                Response.End();
            }

        }

        private double GetTrueColumnWidth(double width)
        {
            //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
            double z = 1d;
            if (width >= (1 + 2 / 3))
            {
                z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
            }
            else
            {
                z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
            }

            //HOW FAR OFF? (WILL BE LESS THAN 1)
            double errorAmt = width - z;

            //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
            double adj = 0d;
            if (width >= (1 + 2 / 3))
            {
                adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
            }
            else
            {
                adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
            }

            //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
            if (z > 0)
            {
                return width + adj;
            }

            return 0d;
        }

        protected void lnkExportarConcentrado_Click(object sender, EventArgs e)
        {
            gridConcentrado.ExportXlsxToResponse("ASAEConsultores.xlsx", new XlsxExportOptionsEx() { ExportType = ExportType.WYSIWYG });
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(RBLNomina.SelectedValue) || string.IsNullOrEmpty(DDLQuincena.SelectedValue))
                return;

            try
            {
                lnkExportarResumen.Visible = true;
                gridEfectividad.Visible = true;
                gridConcentrado.Visible = true;

                i.imssportal.tramites.ObtenerEfectividadPorPromotoria_aspxGridview(ref gridEfectividad, ref gridConcentrado, RBLNomina.SelectedValue, DDLQuincena.SelectedValue, manejo_sesion.Usuarios.ClavePromotoria);
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }

    }
}