using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class ObtenerArchivo : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Obtener el archivo deseado de la tabla
            i.imssportal.archivos.Buscar(ref GVArchivos, txtArchivo.Text);

        }

        protected void LigaVisualizar_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                try
                {
                    LinkButton btn = sender as LinkButton;
                    GridViewRow row = btn.NamingContainer as GridViewRow;
                    //Mostrar el archivo

                    //Procedimientos para visualizar un PDF
                    byte[] fileData = i.imssportal.archivos.ArchivoCrear(row.Cells[0].Text);
                    FileStream file = File.Create(Server.MapPath("\\PDF\\") + row.Cells[0].Text);
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                    ltMuestraPdf.Text = "";
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + row.Cells[0].Text + "' style='width:100%; height:100%' type='application/pdf'>";
                }
                catch (Exception ex)
                {
                    log.Agregar(ex);
                }
            }
        }
    }
}