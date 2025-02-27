﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WFO_IMSSPortal.Procesos.SupervisionGeneral
{
    public partial class Priorizar : Utilerias.Comun
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

        protected void LigaActualizar_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                try
                {
                    LinkButton btn = sender as LinkButton;
                    GridViewRow row = btn.NamingContainer as GridViewRow;
                    //Actualizar el registro
                    i.supervisiongeneral.tramite.ModificarPrioridad(row.Cells[1].Text, manejo_sesion.Usuarios.IdUsuario.ToString(), row.Cells[2].Text, row.Cells[1].Text, row.Cells[3].Text);
                    i.supervisiongeneral.tramite.Seleccionar(ref GVTramites);
                    GVTramites.SelectedRowStyle.BackColor = Color.Green;
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