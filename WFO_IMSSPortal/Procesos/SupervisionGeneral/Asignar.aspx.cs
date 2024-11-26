using System;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.SupervisionGeneral
{
    public partial class Asignar : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            if (!IsPostBack)
            {
                i.supervisiongeneral.catpromotoria.Seleccionar_DropdownList(ref DDLCatPromotoria);
                i.promotoria.catalogos.cat_StatusTramites_DropDownList(ref DDLEstados);
                i.supervisiongeneral.tramite.Seleccionar(ref GVTramites);
            }
        }

        protected void GVMesas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVMesas.EditIndex = e.NewEditIndex;
            i.supervisiongeneral.asignar.MostrarMesasDisponibles(ref GVMesas, ViewState["Id"].ToString());
        }

        protected void GVMesas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVMesas.EditIndex = -1;
            i.supervisiongeneral.asignar.MostrarMesasDisponibles(ref GVMesas, ViewState["Id"].ToString());
        }

        protected void GVMesas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idtramitemesa = GVMesas.DataKeys[e.RowIndex].Values["_IdTramiteMesa"].ToString();
            DropDownList valorseleccionado = (DropDownList)GVMesas.Rows[e.RowIndex].Cells[2].Controls[1];
            GVMesas.EditIndex = -1;

            //Modificaciones
            if (GVMesas.Rows[e.RowIndex].Cells[1].Text != "")
            {
                //Usuarios existentes
                i.supervisiongeneral.asignar.CambiarUsuarioAnterior(idtramitemesa, valorseleccionado.SelectedValue);
                i.supervisiongeneral.asignar.AgregarTramiteMesaBitacoraCambios(ViewState["IdUsuario"].ToString(), valorseleccionado.SelectedValue, manejo_sesion.Usuarios.IdUsuario.ToString(), idtramitemesa);
            }
            else
            {
                //agregado usuario nuevo a futuro
                i.supervisiongeneral.asignar.AgregarUsuarioFuturo(valorseleccionado.SelectedValue, manejo_sesion.Usuarios.IdUsuario.ToString(), idtramitemesa);
            }
            i.supervisiongeneral.asignar.MostrarMesasDisponibles(ref GVMesas, ViewState["Id"].ToString());
            
        }

        protected void GVMesas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GVMesas.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlUs = (DropDownList)e.Row.FindControl("ddlUsuarios");
                i.administracion.usuarios.SeleccionarUsuarios_DropDownList(ref ddlUs);
            }
        }

        protected void GVMesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sin hacer nada pero necesario para que todo funcione en esta tabla
        }   

        protected void LigaAsignar_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                try
                {
                    LinkButton btn = sender as LinkButton;
                    string[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
                    var id = commandArgs[0];

                    ViewState["Id"] = id;
                    ViewState["IdUsuario"] = commandArgs[1];
                    GridViewRow row = btn.NamingContainer as GridViewRow;
                    //Procesar el registro (obtener las mesas disponibles para ese trámite)
                    tablaBusqueda.Visible = false;
                    GVTramites.DataSource = null;
                    GVTramites.DataBind();
                    GVTramites.Visible = false;
                    tablaMesas.Visible = true;

                    //obtener el detalle del registro
                    //var detalle = supervisiongeneraltramites.SeleccionarPorId(id);

                    //Obtener las mesas disponibles para este trámite
                    i.supervisiongeneral.asignar.MostrarMesasDisponibles(ref GVMesas, id);
                }
                catch (Exception ex)
                {
                    log.Agregar("Error al intentar actualizar el usuario: " + ex.Message);
                }
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            i.supervisiongeneral.tramite.Buscar(ref GVTramites, txtFolio.Text, txtRegistroDel.Text, txtRegistroAl.Text, txtSolicitudDel.Text, txtSolicitudAl.Text, DDLCatPromotoria.SelectedValue, DDLEstados.SelectedValue);
        }


    }
}