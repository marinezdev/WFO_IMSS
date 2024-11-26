using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Procesos.Supervision
{
    public class Sabana
    {
        AccesoDatos.Procesos.Mesa mM = new AccesoDatos.Procesos.Mesa();
        public void MostrarDatosMesa(ref DevExpress.Web.ASPxGridView aSPxGridView, string fechaDesde, string fechaHasta, string idFlujo)
        {
            DataTable datos = new DataTable();
            aSPxGridView.Columns.Clear();
            datos = mM.DatosReporteSabana(fechaDesde, fechaHasta, idFlujo);
            aSPxGridView.DataSource = datos;
            aSPxGridView.DataBind();
            int Index = 1;

            foreach (DataColumn Campo in datos.Columns)
            {
                GridViewDataColumn Col = new GridViewDataColumn();
                Col.VisibleIndex = Index;
                if (Index == 1) Col.Visible = false;
                Col.Width = 200;
                Col.Caption = Campo.ColumnName;
                Col.FieldName = Campo.ColumnName;
                aSPxGridView.Columns.Add(Col);
                Index++;
            }
        }

    }
}
