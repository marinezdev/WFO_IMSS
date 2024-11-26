using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.OleDb;

namespace PruebasLocales
{
    public partial class ExportarADBF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Uno");
            dt.Columns.Add("Dos");
            dt.Rows.Add("1", "2");
            dt.Rows.Add("3", "4");
            dt.Rows.Add("5", "6");
            dt.Rows.Add("7", "8");
            dt.Rows.Add("9", "0");
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            DataSetIntoDBF("prueba", ds);
            
        }

        public void DataSetIntoDBF(string fileName, DataSet dataSet)
        {
            ArrayList list = new ArrayList();

            string rutaArchivo = Server.MapPath("~\\Archivos\\");
            if (File.Exists(rutaArchivo + fileName + ".dbf"))
            {
                File.Delete(rutaArchivo + fileName + ".dbf");
            }

            string createSql = "create table " + fileName + " (";

            foreach (DataColumn dc in dataSet.Tables[0].Columns)
            {
                string fieldName = dc.ColumnName;

                string type = dc.DataType.ToString();

                switch (type)
                {
                    case "System.String":
                        type = "varchar(100)";
                        break;

                    case "System.Boolean":
                        type = "varchar(10)";
                        break;

                    case "System.Int32":
                        type = "int";
                        break;

                    case "System.Double":
                        type = "Double";
                        break;

                    case "System.DateTime":
                        type = "TimeStamp";
                        break;
                }

                createSql = createSql + "[" + fieldName + "]" + " " + type + ",";

                list.Add(fieldName);
            }

            createSql = createSql.Substring(0, createSql.Length - 1) + ")";

            OleDbConnection con = new OleDbConnection(GetConnection(rutaArchivo));

            OleDbCommand cmd = new OleDbCommand();

            cmd.Connection = con;

            con.Open();

            cmd.CommandText = createSql;

            cmd.ExecuteNonQuery();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                string insertSql = "insert into " + fileName + " values(";

                for (int i = 0; i < list.Count; i++)
                {
                    insertSql = insertSql + "'" + ReplaceEscape(row[list[i].ToString()].ToString()) + "',";
                }

                insertSql = insertSql.Substring(0, insertSql.Length - 1) + ")";

                cmd.CommandText = insertSql;

                cmd.ExecuteNonQuery();
            }

            con.Close();
        }

        private static string GetConnection(string path)
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=dBASE IV;";
        }

        public static string ReplaceEscape(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }
    }
}