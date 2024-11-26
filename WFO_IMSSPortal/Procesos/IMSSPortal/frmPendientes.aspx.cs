using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.IMSSPortal
{
    public partial class frmPendientes : Utilerias.Comun
    {
        #region Eventos *********************************************************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["Sesion"] == null)
                //    Response.Redirect("../Default.aspx");
                manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

                if (!IsPostBack)
                {
                    Funciones.LlenarControles.LlenarDropDownList(ref ddlAnnQuincena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al iniciar la página, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }

        }

        protected void ddlAnnQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Poliza");
                dt.Columns.Add("Unidad");
                dt.Columns.Add("Estatus");
                dt.Columns.Add("Resultado");
                dt.Columns.Add("Folio");
                dt.Columns.Add("FechaEnvio");

                dt.Rows.Add("FAZ502", "214", "", "", "JA201801200001", "10-10-2018");
                dt.Rows.Add("FAZ502", "214", "", "", "JA201801200027", "12-10-2018");
                dt.Rows.Add("ATT217", "217", "", "", "JA201801200027", "12-10-2018");
                dt.Rows.Add("AXM506", "217", "", "", "JA201801200027", "12-10-2018");
                dt.Rows.Add("EVC270", "217", "", "", "JA201801200027", "12-10-2018");
                dt.Rows.Add("MLI867", "217", "", "", "JA201801200027", "12-10-2018");

                GVDetalle.DataSource = dt;
                GVDetalle.DataBind();
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al seleccionar una opción, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }

        }

        #endregion

        #region Metodos *********************************************************************************************



        #endregion

    }
}