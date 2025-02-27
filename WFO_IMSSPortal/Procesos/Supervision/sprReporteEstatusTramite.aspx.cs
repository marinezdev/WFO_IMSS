﻿using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class sprReporteEstatusTramite : Utilerias.Comun
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CalDesde.EditFormatString = "dd/MM/yyyy";
            CalDesde.Date = DateTime.Today;
            CalHasta.EditFormatString = "dd/MM/yyyy";
            CalHasta.Date = DateTime.Today;
            cmbFlujo.DataSource = i.supervision.default_.DatosComboFlujo();
            cmbFlujo.DataTextField = "Nombre";
            cmbFlujo.DataValueField = "Id";
            cmbFlujo.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            i.supervision.reporteestatustramite.DatosEstatusTramite(ref dvgdEstatusTramite, ref cmbEstatus, CalDesde.Date.ToString(), CalHasta.Date.ToString(), cmbFlujo.SelectedValue.ToString());
        }
        protected void lnkExportar_Click(object sender, EventArgs e)
        {

            dvgdEstatusTramite.ExportXlsToResponse();
            // grdExport.WriteXlsToResponse();
        }

        protected void listaEstatus_Init(object sender, EventArgs e)
        {
            ASPxListBox listaEstatus = (ASPxListBox)sender;
            DataTable dtET = i.supervision.reporteestatustramite.EstatusTramite();
            foreach (DataRow estatus in dtET.Rows)
            {
                listaEstatus.Items.Add(estatus["Nombre"].ToString());
            }
        }
    }
}