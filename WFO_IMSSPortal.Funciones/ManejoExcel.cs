using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using ClosedXML.Excel;
using System.Web.UI;

namespace WFO_IMSSPortal.Funciones
{
    public static class ManejoExcel
    {
        public static DataTable Excel_A_TablaDeDatos(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable table = new DataTable();
            //foreach (var firstRowCell in workSheet.Cells[1, 1, 1, 60])
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                //var row = workSheet.Cells[rowNumber, 1, rowNumber, 60];
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                table.Rows.Add(newRow);
            }
            return table;
        }

        public static DataTable Excel_A_TablaDeDatosConcentrado(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable table = new DataTable();
            int intColumna = 0;
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                intColumna += 1;
                if (firstRowCell.Text.ToString().Trim().Length == 0)
                    table.Columns.Add(intColumna.ToString());
                else
                    table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                //var row = workSheet.Cells[rowNumber, 1, rowNumber, 60];
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text.ToString().Trim();
                }
                table.Rows.Add(newRow);
            }
            return table;
        }

        public static DataTable Excel_A_TablaDeDatosPromotoria(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable table = new DataTable();
            int intColumna = 0;
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                intColumna += 1;
                if (firstRowCell.Text.ToString().Trim().Length == 0)
                    table.Columns.Add(intColumna.ToString());
                else
                    table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                //var row = workSheet.Cells[rowNumber, 1, rowNumber, 60];
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text.ToString().Trim();
                }
                table.Rows.Add(newRow);
            }
            return table;
        }

        /// <summary>
        /// Procesa los datos de un dataset para exportarlos a excel
        /// </summary>
        /// <param name="Pagina">this</param>
        /// <param name="dataset">Dataset con las tablas que procesará</param>
        public static void ExportarDataSetAExcel(Page Pagina, DataSet dataset)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataset);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                for (int i = 1; i < dataset.Tables.Count; i++)
                {
                    wb.Worksheets.Worksheet(i);
                }

                Pagina.Response.Clear();
                Pagina.Response.Buffer = true;
                Pagina.Response.Charset = "";
                Pagina.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Pagina.Response.AddHeader("content-disposition", "attachment;filename=ASAE_Consultores.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Pagina.Response.OutputStream);
                    Pagina.Response.Flush();
                    Pagina.Response.End();
                }
            }
        }
    }
}
