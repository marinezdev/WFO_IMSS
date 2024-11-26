using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades;
using f = WFO_IMSSPortal.Funciones;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmRoles : Utilerias.Comun
    {
        #region Eventos ******************************************************************************************************

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                try
                {
                    CargarRoles();
                }
                catch (Exception ex)
                {
                    log.Agregar(ex);
                    mensajes.MostrarMensaje(this, "Ha habido un error al inicio de la página, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
                }
            }
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardar ó modificar el nuevo registro
                prop.Roles rls = new prop.Roles();
                if (ViewState["Id"] != null)
                    rls.IdRol = Funciones.Nums.TextoAEntero(ViewState["Id"].ToString());
                rls.Nombre = txtNombre.Text;
                rls.Acceso = txtAcceso.Text;

                if (ViewState["Editar"] == null)
                {
                    if (i.administracion.roles.Agregar(rls) > 0)
                        mensajes.MostrarMensaje(this, "Se guardó el nuevo Rol");
                    else
                        mensajes.MostrarMensaje(this, "hubo un error al tratar de guardar, avisar al administrador.");
                }
                else
                {
                    if (i.administracion.roles.Modificar(rls) == 1)
                        mensajes.MostrarMensaje(this, "Se guaradó el registro modificado.");
                    else
                        mensajes.MostrarMensaje(this, "hubo un error al tratar de guardar la modificación, avisar al administrador.");
                }
                txtNombre.Text = "";
                txtAcceso.Text = "";
                CargarRoles();
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al guardar un registro, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }
        }

        protected void LigaEditar_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                try
                {
                    mp1.Show();
                    LinkButton btn = sender as LinkButton;
                    GridViewRow row = btn.NamingContainer as GridViewRow;
                    //Obtener detalle del registro
                    prop.Roles detalle = new prop.Roles();
                    detalle = i.administracion.roles.SeleccionarPorId(f.Nums.TextoAEntero(row.Cells[1].Text));
                    txtNombre.Text = detalle.Nombre;
                    txtAcceso.Text = detalle.Acceso;
                    ViewState["Id"] = row.Cells[1].Text;
                    ViewState["Editar"] = "1";
                }
                catch (Exception ex)
                {
                    log.Agregar(ex);
                    mensajes.MostrarMensaje(this, "Ha habido un error al seleccionar un registro de la tabla, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
                }
            }
        }

        #endregion

        #region Metodos ******************************************************************************************************

        protected void CargarRoles()
        {
            i.administracion.roles.Roles_Gridview(ref GridView1);
        }




        #endregion


    }
}