using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades;
using f = WFO_IMSSPortal.Funciones;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmMenu : Utilerias.Comun
    {
        #region Eventos ******************************************************************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

                if (!IsPostBack)
                {
                    CargarOpcionesMenu();
                    CargaPertenencias();
                    i.administracion.menu.SeleccionarIconos_DropDownList(ref DDLIconos);
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al iniciar la página, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "")
                    return;
                int idmenu = 0;
                //Guardar ó modificar el nuevo registro
                if (ViewState["Id"] != null)
                    idmenu = int.Parse(ViewState["Id"].ToString());

                if (ViewState["Editar"] == null)
                {
                    if (i.administracion.menu.Agregar(txtNombre.Text, txtUrl.Text, DDLIconos.SelectedValue, f.Nums.TextoAEntero(ddlPerteneceA.SelectedValue), txtCategoria.Text, f.Nums.TextoAEntero(txtOrden.Text)) > 0)
                        mensajes.MostrarMensaje(this, "Se guardó la nueva opción.");
                    else
                        mensajes.MostrarMensaje(this, "Hubo un error al tratar de guardar, avisar al administrador.");
                }
                else
                {
                    if (i.administracion.menu.Modificar(txtNombre.Text, txtUrl.Text, DDLIconos.SelectedValue, f.Nums.TextoAEntero(ddlPerteneceA.SelectedValue), txtCategoria.Text, f.Nums.TextoAEntero(txtOrden.Text), idmenu) == 1)
                        mensajes.MostrarMensaje(this, "Se guardó el registro modificado.");
                    else
                        mensajes.MostrarMensaje(this, "Hubo un error al tratar de guardar la modificación, avisar al administrador.");
                }
                txtNombre.Text = "";
                txtUrl.Text = "";
                DDLIconos.SelectedIndex = 0;
                ddlPerteneceA.SelectedIndex = 0;
                txtCategoria.Text = "";
                txtOrden.Text = "";
                CargarOpcionesMenu();
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al guardar ó modificar el registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void LigaEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is LinkButton)
                {
                    mp1.Show();
                    LinkButton btn = sender as LinkButton;
                    GridViewRow row = btn.NamingContainer as GridViewRow;
                    CargaPertenencias();
                    i.administracion.menu.SeleccionarIconos_DropDownList(ref DDLIconos);
                    //Obtener detalle del registro
                    prop.Menu detalle = new prop.Menu();
                    detalle = i.administracion.menu.SeleccionarPorId(f.Nums.TextoAEntero(row.Cells[1].Text));
                    txtNombre.Text = detalle.Descripcion;
                    txtUrl.Text = detalle.URL;
                    DDLIconos.SelectedValue = detalle.Icono;
                    ddlPerteneceA.SelectedValue = detalle.PerteneceA.ToString();
                    txtCategoria.Text = detalle.Categoria;
                    txtOrden.Text = detalle.Orden.ToString();
                    ViewState["Id"] = row.Cells[1].Text;
                    ViewState["Editar"] = "1";
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al seleccionar el registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        #endregion

        #region Metodos ******************************************************************************************************

        protected void CargaPertenencias()
        {
            i.administracion.menu.SeleccionarPertenencia(ref ddlPerteneceA);
        }

        protected void CargarOpcionesMenu()
        {
            i.administracion.menu.Seleccionar_GridView(ref GridView1);
        }


        #endregion

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow grv = e.Row;
            if (grv.Cells[7].Text.Equals("Administraci&#243;n"))
            {
                e.Row.BackColor = Color.Aquamarine;
            }
            if (grv.Cells[7].Text.Equals("Imss Portal MetLife"))
            {
                e.Row.BackColor = Color.Bisque;
            }
            if (grv.Cells[7].Text.Equals("Imss Portal Operador"))
            {
                e.Row.BackColor = Color.Coral;
                e.Row.ForeColor = Color.Black;
            }
            if (grv.Cells[7].Text.Equals("Imss Portal Promotoria"))
            {
                e.Row.BackColor = Color.DodgerBlue;
                e.Row.ForeColor = Color.Black;
            }
            if (grv.Cells[7].Text.Equals("Imss Portal Supervisor"))
            {
                e.Row.BackColor = Color.LightCyan;
                e.Row.ForeColor = Color.Black;
            }
            if (grv.Cells[7].Text.Equals("Supervisi&#243;n"))
            {
                e.Row.BackColor = Color.ForestGreen;
                e.Row.ForeColor = Color.Black;
            }
        }
    }
}