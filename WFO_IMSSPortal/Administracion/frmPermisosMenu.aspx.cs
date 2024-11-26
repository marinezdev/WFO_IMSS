using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using f = WFO_IMSSPortal.Funciones;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmPermisosMenu : WFO_IMSSPortal.Utilerias.Comun
    {
        #region Eventos ******************************************************************************************************

        public static DataTable dt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (WFO_IMSSPortal.IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                try
                {
                    CargarRoles();

                    //test data suppose comes from database
                    //dt = new DataTable();
                    //dt.Columns.Add("ID");
                    //dt.Columns.Add("Name");
                    //dt.Columns.Add("Order_By");
                    //dt.Rows.Add(1, "Name1", "Inicio");
                    //dt.Rows.Add(2, "Name2", "Usuarios");
                    //dt.Rows.Add(3, "Name3", "Roles");
                    //dt.Rows.Add(4, "Name4", "Menu");
                    //this.ReorderList1.DataSource = dt;
                    //this.ReorderList1.DataBind();
                }
                catch (Exception ex)
                {
                    log.Agregar(ex);
                    mensajes.MostrarMensaje(this, "Ha habido un error al inicio de la página, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
                }
            }
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                trOpciones.Visible = true;
                //Llenar treview
                tvwMenu.Nodes.Clear();
                i.administracion.menu.LlenarTreeView(ref tvwMenu, f.Nums.TextoAEntero(ddlRoles.SelectedValue)); //Se muestra todas las opciones disponibles del menu
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Ha habido un error al tratar de mostrar los registros, revise el log para ver los detalles. Fin de la operación.", "Default.aspx");
            }

        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            //guarda los valores asignados para el rol seleccionado
            foreach (TreeNode nodo in tvwMenu.Nodes)
            {
                i.administracion.permisosmenu.Actualizar(f.Nums.TextoAEntero(ddlRoles.SelectedValue), f.Nums.TextoAEntero(nodo.Value), nodo.Checked == true ? 1 : 0);
                foreach (TreeNode child in nodo.ChildNodes)
                {
                    i.administracion.permisosmenu.Actualizar(f.Nums.TextoAEntero(ddlRoles.SelectedValue), f.Nums.TextoAEntero(child.Value), child.Checked == true ? 1 : 0);
                }
            }
            mensajes.MostrarMensaje(this, "Se guardaron los cambios realizados.", "frmPermisosMenu.aspx");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            dt = null;
        }

        #endregion

        #region Metodos ******************************************************************************************************

        protected void CargarRoles()
        {
            i.administracion.roles.Roles_DropdownList(ref ddlRoles);
        }

        protected void ReorderList1_ItemReorder(object sender, AjaxControlToolkit.ReorderListItemReorderEventArgs e)
        {
            DataRow selectedRow = dt.Rows[e.OldIndex];
            DataRow newRow = dt.NewRow();
            newRow.ItemArray = selectedRow.ItemArray; // copy data
            dt.Rows.Remove(selectedRow);//delete the old row
            dt.Rows.InsertAt(newRow, e.NewIndex); //add new row
            //your code save the datatable to database
            this.ReorderList1.DataSource = dt;
            this.ReorderList1.DataBind();
        }

        #endregion
    }
}