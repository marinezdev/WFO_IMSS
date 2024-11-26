using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class ProcesadoArchivos : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicial();
            }
        }

        protected void ProcesarArchivos_Click(object sender, EventArgs e)
        {
            //cambia el nombre anterior del archivo por el nuevo y se guarda en otro directorio

            foreach (GridViewRow row in GVArchivosEncontrados.Rows)
            {
                File.Move(Server.MapPath("/DocsUp/" + row.Cells[0].Text), Server.MapPath("/Enlace/" + row.Cells[1].Text + ".PDF"));
            }

            //cargar de nuevo el grid
            GVArchivosEncontrados.DataSource = null;
            GVArchivosEncontrados.DataBind();
            ProcesarArchivos.Enabled = false;
        }

        protected void Inicial()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Encontrados");
            dt.Columns.Add("NuevoNombre");

            string[] listFiles = Directory.GetFiles(Server.MapPath("/DocsUp/"), "*.*");

            int a = 1;
            foreach (string file in listFiles)
            {
                //listbox1.Items.Add(Path.GetFileName(file));
                dt.Rows.Add(Path.GetFileName(file), "A0000" + a);
                a += 1;
            }

            GVArchivosEncontrados.DataSource = dt;
            GVArchivosEncontrados.DataBind();
        }









    }
}