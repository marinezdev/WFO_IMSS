using DevExpress.Web;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;
using prop = WFO_IMSSPortal.Propiedades;

namespace WFO_IMSSPortal.Funciones
{
    /// <summary>
    /// Llena un control con datos
    /// </summary>
    public static class LlenarControles
    {
        /// <summary>
        /// Llena un gridview con una lista
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gridview"></param>
        /// <param name="list"></param>
        public static void LlenarGridView<T>(ref GridView gridview, List<T> list)
        {
            gridview.DataSource = list;
            gridview.CellPadding = 5;
            gridview.CellSpacing = 5;
            gridview.HeaderStyle.Font.Bold = true;
            gridview.EmptyDataText = "Ningún dato para mostrar";
            gridview.DataBind();
            //gridview.SelectedRowStyle.BackColor = Color.Gray;
        }

        /// <summary>
        /// Llena un gridview con un datatable
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="datatable"></param>
        public static void LlenarGridView(ref GridView gridview, DataTable datatable)
        {
            gridview.DataSource = datatable;
            gridview.CellPadding = 5;
            gridview.CellSpacing = 5;
            gridview.BorderStyle = BorderStyle.None;
            gridview.BorderWidth = 0;
            gridview.HeaderStyle.Font.Bold = true;
            gridview.EmptyDataText = "Ningún dato para mostrar";
            //gridview.SelectedRowStyle.BackColor = Color.Gray;
            gridview.DataBind();
        }

        public static void LlenarRepeater<T>(ref Repeater repeater, List<T> list)
        {
            repeater.DataSource = list;
            repeater.DataBind();
        }

        public static void LlenarAspxGridView<T>(ref ASPxGridView aspxgridview, List<T> list)
        {
            aspxgridview.DataSource = list;
            aspxgridview.DataBind();
        }

        public static void LlenaraAspxGridView(ref ASPxGridView aspxgridview, DataTable datatable)
        {
            aspxgridview.DataSource = datatable;
            aspxgridview.DataBind();
        }

        public static void LlenarGridViewASPx(ref DevExpress.Web.ASPxGridView aspxgridview, DataTable datatable)
        {
            aspxgridview.DataSource = datatable;
            aspxgridview.SettingsText.EmptyDataRow = "No existen bajas a procesar...";
            aspxgridview.DataBind();
        }

        /// <summary>
        /// Llena un AspxTreeList (Expandido a nivel 3)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aspxtreelist"></param>
        /// <param name="lista"></param>
        public static void LlenarAspxTreeList<T>(ref ASPxTreeList aspxtreelist, List<T> lista)
        {
            aspxtreelist.ClearNodes();
            aspxtreelist.DataSource = lista;
            aspxtreelist.DataBind();
            aspxtreelist.ExpandToLevel(3);
        }

        public static void LlenarAspxComboBox<T>(ref ASPxComboBox combobox, List<T> lista, string nombre, string valor)
        {
            combobox.DataSource = lista;
            combobox.TextField = nombre;
            combobox.ValueField = valor;
            combobox.DataBind();
        }

        public static void LlenarDetailsView(ref DetailsView detailsview, DataTable datatable)
        {
            detailsview.DataSource = datatable;
            detailsview.CellPadding = 5;
            detailsview.CellSpacing = 5;
            detailsview.HeaderStyle.Font.Bold = true;
            detailsview.EmptyDataText = "Ningún dato para mostrar";
            detailsview.DataBind();
        }

        public static void LlenarDropDownList<T>(ref DropDownList dropdownlist, List<T> list, string text, string value)
        {
            dropdownlist.DataSource = list;
            dropdownlist.DataTextField = text;
            dropdownlist.DataValueField = value;
            dropdownlist.DataBind();
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }

        public static void LlenarDropDownList(ref DropDownList dropdownlist, DataTable datatable, string texto, string valor)
        {
            dropdownlist.DataSource = datatable;
            dropdownlist.DataTextField = texto;
            dropdownlist.DataValueField = valor;
            dropdownlist.DataBind();
            dropdownlist.Items.Insert(0, new ListItem("SELECCIONAR", "0"));
        }

        public static void LlenarCheckBoxList<T>(ref CheckBoxList checkboxlist, List<T> lista, string texto, string valor)
        {
            checkboxlist.DataSource = lista;
            checkboxlist.DataTextField = texto;
            checkboxlist.DataValueField = valor;
            checkboxlist.DataBind();
        }

        public static void LlenarListBox<T>(ref ListBox listbox, List<T> lista, string texto, string valor)
        {
            listbox.DataSource = lista;
            listbox.DataValueField = texto;
            listbox.DataTextField = valor;
            listbox.DataBind();
        }

        /// <summary>
        /// Llena un treeview de forma recursiva e infita para menú
        /// </summary>
        /// <param name="lista">List<> con los datos</param>
        /// <param name="nodoPadre">Al inicio con null</param>
        /// <param name="treeview">control referenciado</param>
        public static void LlenarTreeViewMenu(IEnumerable<prop.PermisosMenuRol> lista, TreeNode nodoPadre, ref TreeView treeview)
        {
            var nodos = lista.Where(nodosInternos => nodoPadre == null ? nodosInternos.Pertenecea == 0 : nodosInternos.Pertenecea == int.Parse(nodoPadre.Value));
            foreach (var node in nodos)
            {
                TreeNode nuevoNodo = new TreeNode(node.Descripcion, node.IdMenu.ToString());
                if (nodoPadre == null)
                {
                    nuevoNodo.Checked = node.Activo;
                    treeview.Nodes.Add(nuevoNodo);
                    //if (node.Idrol==1)
                    //    treeview.ForeColor = System.Drawing.Color.Red;
                    //else
                    //    treeview.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    nuevoNodo.Checked = node.Activo;
                    nodoPadre.ChildNodes.Add(nuevoNodo);
                }
                LlenarTreeViewMenu(lista, nuevoNodo, ref treeview);
            }
        }

        

    }
}
