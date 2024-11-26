using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class RevisionConcentrado : Utilerias.Comun
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
            Busqueda();
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            i.imssportal.tramites.EliminarRegistroConcentrado(e.Keys[grid.KeyFieldName].ToString());
            Busqueda();
            e.Cancel = true;
        }


        private void Busqueda()
        {
            string strFolio = txtFolio.Text.Trim();
            //string strFechaI = dtFechaInicio.Text.Trim();
            //string strFechaF = dtFechaFin.Text.Trim();

            lblMensaje.Visible = false;
            lblMensaje.Text = "";

            grid.Visible = true;

            //if (strFechaI.Length > 0 && strFechaF.Length > 0)
            //{
            //    strFechaI = dtFechaInicio.Text + " 00:00:00";
            //    strFechaF = dtFechaFin.Text + " 23:59:59";

            //    try
            //    {
            //        DateTime dt1 = DateTime.ParseExact(strFechaI, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //        DateTime dt2 = DateTime.ParseExact(strFechaF, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            //        if (dt1 >= dt2)
            //        {
            //            lblMensaje.Visible = true;
            //            lblMensaje.Text = "La Fecha Inicial no debe ser mayor que la final.";
            //        }
            //        else
            //        {
            //            strFechaI = dt1.ToString("yyyy/MM/dd HH:mm:ss");
            //            strFechaF = dt2.ToString("yyyy/MM/dd HH:mm:ss");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        lblMensaje.Visible = true;
            //        lblMensaje.Text = "Formato de fechas inválido [ dd/MM/yyyy ].";
            //    }

            i.imssportal.tramites.ObtenerConcentrado_AspxGridView(ref grid, RBLNomina.SelectedValue, DDLQuincena.SelectedValue);
            //}
        }


    }
}