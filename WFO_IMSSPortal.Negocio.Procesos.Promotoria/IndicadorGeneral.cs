using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class IndicadorGeneral
    {
        AccesoDatos.Procesos.Promotoria.IndicadorGeneral indicadorGeneral = new AccesoDatos.Procesos.Promotoria.IndicadorGeneral();

        public void SeleccionaEstatusTotales(ref Chart chart, string quincena, string tiponomina)
        {
            chart.ChartAreas["GrupoUno"].AxisX.Interval = 1;
            chart.ChartAreas["GrupoUno"].AxisY.Interval = 50;

            chart.DataSource = indicadorGeneral.SeleccionaEstatusTotales(Funciones.Nums.TextoAEntero(quincena), tiponomina); // TramitesTotales;

            // Add serie Totales
            Series serieTotales = chart.Series.Add("totales");
            serieTotales.ChartArea = "GrupoUno";
            serieTotales.Font = new Font("Arial", 6.5F);
            serieTotales.ChartType = SeriesChartType.Column;
            serieTotales.IsValueShownAsLabel = true;
            serieTotales.XValueMember = "Estado";
            serieTotales.YValueMembers = "Totales";
            serieTotales.CustomProperties = "ShowMarkerLines=true";
            //serieTotales.PostBackValue = "item";
            serieTotales.PostBackValue = "#VALX";
            serieTotales.IsValueShownAsLabel = true;

            chart.DataBind();
        }
    }
}
