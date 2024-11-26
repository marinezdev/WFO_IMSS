using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmConfiguracionGeneral : WFO_IMSSPortal.Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                CargarConfiguracion();
            }
        }


        protected void CargarConfiguracion()
        {
            i.administracion.configuracion.Seleccionar_Gridview(ref GridView1);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardar nuevo registro
                prop.Configuracion config = new prop.Configuracion();
                if (ViewState["Id"] != null)
                    config.Id = Funciones.Nums.TextoAEntero(ViewState["Id"].ToString());
                config.Nombre = txtNombre.Text;
                config.Valor = Funciones.Nums.TextoAEntero(txtValor.Text);

                if (ViewState["Editar"] == null)
                {
                    if (i.administracion.configuracion.Agregar(config.Nombre, config.Valor) > 0)
                        mensajes.MostrarMensaje(this, "Se guardó el nuevo registro.");
                    else
                        mensajes.MostrarMensaje(this, "Hubo un error al tratar de guardar, avisar al administrador.");
                }
                else
                {
                    if (i.administracion.configuracion.Actualizar(config.Id, config.Nombre, config.Valor) == 1)
                        mensajes.MostrarMensaje(this, "Se guardó el registro modificado.");
                    else
                        mensajes.MostrarMensaje(this, "Hubo un error al tratar de guardar el cambio, avisar al administrador.");
                }
                txtNombre.Text = "";
                txtValor.Text = "";
                CargarConfiguracion();
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al guardar los datos, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
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
                    prop.Configuracion detalle = new prop.Configuracion();
                    detalle = i.administracion.configuracion.SeleccionarPorId(Funciones.Nums.TextoAEntero(row.Cells[1].Text));
                    txtNombre.Text = detalle.Nombre;
                    txtValor.Text = detalle.Valor.ToString();
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

    }
}