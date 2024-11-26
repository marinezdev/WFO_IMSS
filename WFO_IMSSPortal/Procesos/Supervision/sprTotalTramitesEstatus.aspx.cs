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
    public partial class sprTotalTramitesEstatus: Utilerias.Comun
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
            i.supervision.totaltramiteestatus.llenarDatos(ref dvgdEstatusTramite, CalDesde.Date.ToString(), CalHasta.Date.ToString(), cmbFlujo.SelectedValue.ToString());
        }
        
        protected void lnkExportar_Click(object sender, EventArgs e)
        {
            dvgdEstatusTramite.ExportXlsToResponse();
        }
        
    }
}