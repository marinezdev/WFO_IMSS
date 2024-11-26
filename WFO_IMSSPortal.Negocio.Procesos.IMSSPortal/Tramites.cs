using System.Data;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class Tramites
    {
        WFO_IMSSPortal.AccesoDatos.Tablas.Tramites cdTramites = new WFO_IMSSPortal.AccesoDatos.Tablas.Tramites();

        /// <summary>
        /// Obtenemos los trámites
        /// </summary>
        /// <param name="detailsview"></param>
        /// <param name="IdPromotoria"></param>
        public void ObtenerTramites_GridView(ref GridView gridView, int IdPromotoria)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerTramites_GridView(IdPromotoria));
        }

        public void ObtenerEfectividad_GridView(ref GridView gridView)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerEfectividad_GridView());
        }

        private DataTable ObtenerEfectividad_GridView()
        {
            return null; // cdTramites.GetEfectividad();
        }

        public void ObtenerEfectividad_AspxGridView(ref DevExpress.Web.ASPxGridView aspxgridview1, ref DevExpress.Web.ASPxGridView aspxgridview2, string tiponomina, string quincena)
        {
            DataSet ds = cdTramites.GetEfectividad(tiponomina, quincena);

            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview1, ds.Tables[0]);
            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview2, ds.Tables[1]);
        }

        public void ObtenerEfectividadOperacion_AspxGridView(ref DevExpress.Web.ASPxGridView aspxgridview1, ref DevExpress.Web.ASPxGridView aspxgridview2, string tiponomina, string quincena)
        {
            DataSet ds = cdTramites.GetEfectividadOperacion(tiponomina, quincena);

            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview1, ds.Tables[0]);
            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview2, ds.Tables[1]);
        }

        public DataSet ObtenerEfectividad_DataSet(string tiponomina, string quincena)
        {
            return cdTramites.GetEfectividad(tiponomina, quincena);
        }

        public DataSet ObtenerEfectividadOperatividad_DataSet(string tiponomina, string quincena)
        {
            return cdTramites.GetEfectividadOperacion(tiponomina, quincena);
        }

        public void ObtenerEfectividadPorPromotoria_aspxGridview(ref DevExpress.Web.ASPxGridView aspxgridview1, ref DevExpress.Web.ASPxGridView aspxgridview2, string tiponomina, string quincena, string clavepromotoria)
        {
            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview1, cdTramites.ObtenerEfectividadPorPromotoria(tiponomina, quincena, clavepromotoria).Tables[0]);
            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview2, cdTramites.ObtenerEfectividadPorPromotoria(tiponomina, quincena, clavepromotoria).Tables[1]);
        }

        public DataSet EfectividadPromotoriaExportarAExcel(string tiponomina, string quincena, string clavepromotoria)
        {
            return cdTramites.ObtenerEfectividadPorPromotoria(tiponomina, quincena, clavepromotoria);
        }

        public void ObtenerConcentradoEfectividad_AspxGridView(ref DevExpress.Web.ASPxGridView aspxgridview, string tiponomina, string annquincena)
        {
            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview, cdTramites.ObtenerConcentradoEfectividad(tiponomina, annquincena));
        }

        public void ObtenerConcentradoEfectividad_AspxGridView(ref DataTable dt, string tiponomina, string annquincena)
        {
            dt = cdTramites.ObtenerConcentradoEfectividad(tiponomina, annquincena);
        }


        public void ObtenerMovimientos_AspxGridView(ref DevExpress.Web.ASPxGridView aspxgridview, string quincena)
        {
            //Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerMovimientos_GridView());

            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview, cdTramites.ObtenerMovimientos(quincena));
        }

        public void ObtenerMovimientos_GridView(ref GridView gridview, string quincena)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, cdTramites.ObtenerMovimientos(quincena));
        }

        public void ObtenerConcentrado_Bajas_GridView(ref GridView gridView)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerConcentrado_Bajas_GridView());
        }

        public void ObtenerConcentradoBajas_AspxGridView(ref DevExpress.Web.ASPxGridView aspxgridview)
        {
            Funciones.LlenarControles.LlenarGridViewASPx(ref aspxgridview, ObtenerConcentrado_Bajas_GridView());
        }

        public void ObtenerConcentrado_AspxGridView(ref DevExpress.Web.ASPxGridView aspxgridview, string tiponomina, string annquincena)
        {
            aspxgridview.DataSource = cdTramites.ObtenerConcentrado(tiponomina, annquincena);
            aspxgridview.DataBind();
        }

        public void ObtenerConcentrado_GridView(ref GridView gridView, int IdPromotoria)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerConcentrado_GridView(IdPromotoria));
        }

        public void ObtenerConcentrado_GridView(ref GridView gridView, ref Label lblCartasEsperadas, ref Label lblCartasRecibidas, ref Label lblCartasFaltantes, int IdPromotoria)
        {
            DataTable dtDatos = ObtenerConcentrado_GridView(IdPromotoria);
            DataView dv = new DataView(dtDatos);
            dv.RowFilter = "FOLIO <> 'NA' OR TIPO_MOVIMIENTO = 'B'";
            int CartasEsperadas = dtDatos.Rows.Count;
            int CartasRecibidas = dv.ToTable().Rows.Count;
            int CartasFaltantes = CartasEsperadas - CartasRecibidas;
            lblCartasEsperadas.Text = "Cartas Esperadas: " + CartasEsperadas.ToString();
            lblCartasRecibidas.Text = "Cartas Recibidas (Incluidas Bajas): " + CartasRecibidas.ToString();
            lblCartasFaltantes.Text = "Cartas Faltantes: " + CartasFaltantes.ToString();
            Funciones.LlenarControles.LlenarGridView(ref gridView, dtDatos);
        }
        public void ObtenerConcentrado_GridView(ref GridView gridView, int IdPromotoria, string FechaInicio, string FechaFin, string tiponomina, string annquincena)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerConcentrado_GridView(IdPromotoria, "", "", tiponomina, annquincena));
        }

        public void ObtenerConcentrado_GridView(ref GridView gridView, ref Label lblCartasEsperadas, ref Label lblCartasRecibidas, ref Label lblCartasFaltantes,int IdPromotoria, string FechaInicio, string FechaFin, string tiponomina, string annquincena)
        {
            DataTable dtDatos = ObtenerConcentrado_GridView(IdPromotoria, FechaInicio, FechaFin, tiponomina, annquincena);
            DataView dv = new DataView(dtDatos);
            //dv.RowFilter = "FOLIO <> 'NA' OR TIPO_MOVIMIENTO = 'B'"; // query example = "id = 10"
            dv.RowFilter = "Carta_Recibida = 1";
            int CartasEsperadas = dtDatos.Rows.Count;
            int CartasRecibidas = dv.ToTable().Rows.Count;
            int CartasFaltantes = CartasEsperadas - CartasRecibidas;
            lblCartasEsperadas.Text = "Cartas Esperadas: " + CartasEsperadas.ToString();
            lblCartasRecibidas.Text = "Cartas Recibidas (Incluidas Bajas): " + CartasRecibidas.ToString();
            lblCartasFaltantes.Text = "Cartas Faltantes: " + CartasFaltantes.ToString();
            Funciones.LlenarControles.LlenarGridView(ref gridView, dtDatos);
        }

        public DataTable ObtenerExtraccion_dt(string ClavePromotoria, string strQuincena, string strTipoNomina, string strTipoMovimiento)
        {            
            return ObtenerExtraccion(ClavePromotoria, strQuincena, strTipoNomina, strTipoMovimiento);
        }

        public void ObtenerExtaccion_GridView(ref GridView gridView, int IdUsuario, string Folio)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridView, ObtenerExtaccion_GridView(IdUsuario, Folio));
        }

        public void ObtenerTramites_Detalle(ref int IdTramite, ref int IdMovimiento, ref DetailsView detailsview, ref string archivo, int IdUsuario)
        {
            var resumen = cdTramites.GetValidarCartaInstruccion(IdUsuario);
            if (resumen != null)
            {
                IdTramite = int.Parse(resumen["IdTramite"].ToString());
                IdMovimiento = int.Parse(resumen["Id"].ToString());
                archivo = "..\\Archivos\\" + resumen["Archivo"].ToString();
                Funciones.LlenarControles.LlenarDetailsView(ref detailsview, DatosValidaCartaInstruccion(IdMovimiento));
            }
        }

        public void ObtenerTramites_Porcesar(ref int IdTramite, ref int IdMovimiento, ref DetailsView detailsview, ref string archivo, int IdUsuario)
        {
            var resumen = cdTramites.GetProcesarTramite(IdUsuario);
            if (resumen != null)
            {
                DataTable dtTemporal = new DataTable();
                dtTemporal.Columns.Add("Id");
                dtTemporal.Columns.Add("IdTramite");
                dtTemporal.Columns.Add("Poliza");
                dtTemporal.Columns.Add("UnidadPago");
                dtTemporal.Columns.Add("Archivo");
                dtTemporal.Columns.Add("TipoNomina");
                dtTemporal.Columns.Add("TipoMovimiento");
                dtTemporal.Columns.Add("AnnQuincena");
                dtTemporal.Columns.Add("Estado");
                dtTemporal.Columns.Add("IdUsuario");
                dtTemporal.Columns.Add("Matricula");
                dtTemporal.Columns.Add("Importe");
                dtTemporal.Columns.Add("UsuarioServicio");
                dtTemporal.Columns.Add("Nombre");
                dtTemporal.Columns.Add("PromOrigen");
                dtTemporal.Columns.Add("PromUltimoSer");
                dtTemporal.Columns.Add("PromResponsable");
                DataRow row = dtTemporal.NewRow();
                row["Id"] = resumen["Id"];
                row["IdTramite"] = resumen["IdTramite"];
                row["Poliza"] = resumen["Poliza"];
                row["UnidadPago"] = resumen["UnidadPago"];
                row["Archivo"] = resumen["Archivo"];
                row["TipoNomina"] = resumen["TipoNomina"];
                row["TipoMovimiento"] = resumen["TipoMovimiento"];
                row["AnnQuincena"] = resumen["AnnQuincena"];
                row["Estado"] = resumen["Estado"];
                row["IdUsuario"] = resumen["IdUsuario"];
                row["Matricula"] = resumen["Matricula"];
                row["Importe"] = resumen["Importe"];
                row["UsuarioServicio"] = resumen["UsuarioServicio"];
                row["Nombre"] = resumen["Nombre"];
                row["PromOrigen"] = resumen["PromOrigen"];
                row["PromUltimoSer"] = resumen["PromUltimoSer"];
                row["PromResponsable"] = resumen["PromResponsable"];

                dtTemporal.Rows.Add(row);

                IdTramite = int.Parse(resumen["IdTramite"].ToString());
                IdMovimiento = int.Parse(resumen["Id"].ToString());
                archivo = "..\\Archivos\\" + resumen["Archivo"].ToString();
                Funciones.LlenarControles.LlenarDetailsView(ref detailsview, dtTemporal);
            }
        }

        public int AgregarConcentrado(string IdMovimiento, string IdTramite, string IdUsuario, string Matricula, string Importe, string Poliza, string PromOrigen, string UsuarioServicio, string PromUltimoSer, string PromResponsable, string TipoMovimiento, string UnidadPago, string TipoNomina, string AnoQuincena, string EstadoCarta, string EstadoCartaInstruccionNoAplica, string EstadoCartaInstruccionRechazo, string MotivoRechazo, string strEstado, string Nombre)
        {
            return cdTramites.AgregarConcentrado(IdMovimiento, IdTramite, IdUsuario, Matricula, Importe, Poliza, PromOrigen, UsuarioServicio, PromUltimoSer, PromResponsable, TipoMovimiento, UnidadPago, TipoNomina, AnoQuincena, EstadoCarta, EstadoCartaInstruccionNoAplica, EstadoCartaInstruccionRechazo, MotivoRechazo, strEstado, Nombre);
        }

        public int ValidarMovimiento(int IdMovimiento, int StatusValidacion, string Motivo1, string Motivo2)
        {
            return cdTramites.ValidarMovimiento(IdMovimiento, StatusValidacion, Motivo1, Motivo2);
        }

        /// <summary>
        /// Obtiene el detalle del registro
        /// </summary>
        /// <returns>Tabla con los datos obtenidos</returns>
        private DataTable ObtenerTramites_GridView(int IdPromotoria)
        {
            return cdTramites.GetTramites(IdPromotoria);
        }

        private DataTable ObtenerMovimientos_GridView()
        {
            return cdTramites.GetMovimientos();
        }

        private DataTable ObtenerConcentrado_Bajas_GridView()
        {
            return cdTramites.GetConcentrado_Bajas();
        }

        private DataTable ObtenerConcentrado_GridView()
        {
            return cdTramites.GetConcentrado();
        }

        private DataTable ObtenerConcentrado_GridView(int IdPromotoria)
        {
            return cdTramites.GetConcentrado(IdPromotoria);
        }

        private void ObtenerConcentrado_GridView(ref GridView gridview, string IdPromotoria, string FechaIncio, string FechaFin, string tiponomina, string annquincena)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, cdTramites.ObtenerConcentrado(IdPromotoria, FechaIncio, FechaFin, tiponomina, annquincena));
        }

        private DataTable ObtenerConcentrado_GridView(int IdPromotoria, string FechaIncio, string FechaFin, string tiponomina, string annquincena)
        {
            return cdTramites.GetConcentrado(IdPromotoria, tiponomina, annquincena);
        }

        private DataTable ObtenerExtraccion(string ClavePromotoria, string Quincena, string TipoNomina, string TipoMovimiento)
        {
            return cdTramites.GetExtraccion(ClavePromotoria, Quincena, TipoNomina, TipoMovimiento);
        }

        private DataTable ObtenerExtaccion_GridView(int IdUsuario, string Folio)
        {
            return cdTramites.GetExtraccion(IdUsuario, Folio);
        }

        private DataTable DatosValidaCartaInstruccion(int IdMovimiento)
        {
            return cdTramites.DatosValidaCartaInstruccion(IdMovimiento);
        }

        public void EliminarRegistroConcentrado(string id)
        {
            cdTramites.ConcentradoEliminarRegistro(id);
        }

        public void eliminarRegistroMovimientos(string id)
        {
            cdTramites.MovimientosEliminarRegistro(id);
        }
    }
}
