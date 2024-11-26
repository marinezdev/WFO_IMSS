using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class ListarMovimientos : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref DDLQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = true;
            i.imssportal.tramites.ObtenerMovimientos_GridView(ref GVMovmientos, DDLQuincena.SelectedValue);
            //tramites.ObtenerMovimientos_AspxGridView(ref grid, DDLQuincena.SelectedValue);
        }

        protected void DescargarArchivo(object sender, EventArgs e)
        {
            string ruta = Server.MapPath("~/Archivos/");
            string archivo = ruta + (sender as LinkButton).CommandArgument;
            try
            {
                Response.ContentType = "Application/pdf";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(archivo));
                Response.WriteFile(archivo);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                mensajes.MostrarMensaje(this, "Archivo no existe.");
            }
        }
    }
}