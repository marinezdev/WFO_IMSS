using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using WFO_IMSSPortal.Funciones;
using prop = WFO_IMSSPortal.Propiedades.Procesos.SupervisionGeneral;
using DevExpress.Web;
using System.IO;
using System.Drawing;
using System.Web;
using System.Text;
using System.Web.UI;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Net;

namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class Tramite
    {
        AccesoDatos.SupervisionGeneral.Tramite tramite = new AccesoDatos.SupervisionGeneral.Tramite();
        AccesoDatos.SupervisionGeneral.TramiteBitacora tramitebitacora = new AccesoDatos.SupervisionGeneral.TramiteBitacora();

        public void Seleccionar(ref GridView gridview)
        {
            LlenarControles.LlenarGridView(ref gridview, tramite.Seleccionar());
        }

        public prop.Tramite SeleccionarPorId(string id)
        {
            return tramite.SeleccionarPorId(id);
        }

        public void ModificarPrioridad(string id, string usuariocambio, string usuarioanterior, string idtramite, string idprioridadanterior)
        {
            tramite.ModificarPrioridad(id);
            tramitebitacora.Agregar(usuariocambio, usuarioanterior, idtramite, idprioridadanterior);
        }

        public void Buscar(ref GridView gridview, string foliocompuesto, string fecharegistrodel, string fecharegistroal, string fechasolicituddel, string fechasolicitudal, string idpromotoria, string estado)
        {
            LlenarControles.LlenarGridView(ref gridview, tramite.Buscar(foliocompuesto, fecharegistrodel, fecharegistroal, fechasolicituddel, fechasolicitudal, idpromotoria, estado));
        }

        public void Tramite_LlenarGridView(ref GridView gridview, string fase)
        {
            LlenarControles.LlenarGridView(ref gridview, tramite.SeleccionarTramitesPorMesa(fase));
        }

        public void TramiteConsultaX_LlenarGridView(ref GridView gridview)
        {
            LlenarControles.LlenarGridView(ref gridview, tramite.SeleccionarTramiteConsultaX());
        }

        public void ListadoTramitesOperacion(ref ASPxGridView aspxgridview)
        {
            LlenarControles.LlenaraAspxGridView(ref aspxgridview, tramite.ListadoTramitesOperacion());
        }

        public void TramiteConsultaX_LlenarAspxGridView(ref ASPxGridView aspxgridview)
        {
            LlenarControles.LlenaraAspxGridView(ref aspxgridview, tramite.SeleccionarTramiteConsultaX());
        }

        public DataSet qryListadoTramitesOperacion()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(tramite.ListadoTramitesOperacion());
            return ds;

        }

        public DataSet qryListadoTramitesOperacionN3()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(tramite.ListadoTramitesOperacionN3());
            return ds;

        }

        public DataSet TramiteConsultaX()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(tramite.SeleccionarTramiteConsultaX());
            return ds;

        }

        public List<prop.Tramite> prueba(int Id, DateTime Fecha_Inicio, DateTime Fecha_Termino, string Folio, string RFC, string Nombre, string ApPaterno, string ApMaterno)
        {
            return tramite.TramiteSupervicionGeneralSelecionar(Id, Fecha_Inicio, Fecha_Termino, Folio, RFC, Nombre, ApPaterno, ApMaterno);
        }

        public bool EnlaceListadoActivar(string Quincena, string TipoNomina, int IdAplicarEnlace)
        {
            return tramite.EnlaceListadoActivar(Quincena, TipoNomina, IdAplicarEnlace);
        }

        public List<prop.EnlaceListado> EnlaceListado(string Quincena, string TipoNomina)
        {
            return tramite.EnlaceListado(Quincena, TipoNomina);
        }

        public bool ExtraccionDuplicadosDelete(string Quincena, string TipoNomina, int IdExtraccion, int IdUsuario)
        {
            return tramite.ExtraccionDuplicadosDelete(Quincena, TipoNomina, IdExtraccion, IdUsuario);
        }

        public List<prop.Extraccion> ExtraccionDuplicados(string Quincena, string TipoNomina)
        {
            return tramite.ExtraccionDuplicados(Quincena, TipoNomina);
        }

        public bool EnlaceGenerarMasivo(
            string Quincena1, string TNAA1, string TNEA1, string TNMM1, string TNJJ1, string TMAlta1, string TMModif1, string TMBaja1,
            string Quincena2, string TNAA2, string TNEA2, string TNMM2, string TNJJ2, string TMAlta2, string TMModif2, string TMBaja2,
            string Quincena3, string TNAA3, string TNEA3, string TNMM3, string TNJJ3, string TMAlta3, string TMModif3, string TMBaja3,
            string Quincena4, string TNAA4, string TNEA4, string TNMM4, string TNJJ4, string TMAlta4, string TMModif4, string TMBaja4,
            string Quincena5, string TNAA5, string TNEA5, string TNMM5, string TNJJ5, string TMAlta5, string TMModif5, string TMBaja5,
            string Quincena6, string TNAA6, string TNEA6, string TNMM6, string TNJJ6, string TMAlta6, string TMModif6, string TMBaja6,
            string QuincenaResultante, ref string error
        )
        {
            bool blnResultado = false;
            DataSet dsEnlace = null;

            dsEnlace = tramite.EnlaceGenerarMasivo(
                Quincena1, TNAA1, TNEA1, TNMM1, TNJJ1, TMAlta1, TMModif1, TMBaja1,
                Quincena2, TNAA2, TNEA2, TNMM2, TNJJ2, TMAlta2, TMModif2, TMBaja2,
                Quincena3, TNAA3, TNEA3, TNMM3, TNJJ3, TMAlta3, TMModif3, TMBaja3,
                Quincena4, TNAA4, TNEA4, TNMM4, TNJJ4, TMAlta4, TMModif4, TMBaja4,
                Quincena5, TNAA5, TNEA5, TNMM5, TNJJ5, TMAlta5, TMModif5, TMBaja5,
                Quincena6, TNAA6, TNEA6, TNMM6, TNJJ6, TMAlta6, TMModif6, TMBaja6,
                QuincenaResultante, ref error);

            // Declaración de Variables
            DataView dvUnidadesPago = null;
            DataView dvResumen = null;
            DataView dvResumenAcuses = null;
            DataView dvReporteNomina = null;
            DataView dvResumenNomina = null;
            string RutaEntregable = "";
            string TipoNomina = "";
            string Abreviatura = "";
            double totalMovimientosAlta = 0;
            double totalMovimientosBaja = 0;
            double totalMovimientosModi = 0;
            double totalImporteAlta = 0;
            double totalImporteBaja = 0;
            double totalImporteModi = 0;

            RutaEntregable = @"C:\IMSSPortal\Entregables\" + QuincenaResultante + "_Enlace";
            if (Directory.Exists(RutaEntregable))
            {
                var dir = new DirectoryInfo(RutaEntregable);
                dir.Attributes = dir.Attributes & FileAttributes.ReadOnly;
                dir.Delete(true);
            }

            Directory.CreateDirectory(RutaEntregable);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable4SACI");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable5IMAGENES");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable5IMAGENES\\Imagenes");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\General");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\ACTIVOS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\ESTATUTO A");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\MANDO");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\JUBILADOS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\ACTIVOS " + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\ACTIVOS " + QuincenaResultante + "\\AA" + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\ESTATUTO A " + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\ESTATUTO A " + QuincenaResultante + "\\EA" + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\MANDO " + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\MANDO " + QuincenaResultante + "\\MM" + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\JUBILADOS " + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\JUBILADOS " + QuincenaResultante + "\\JJ" + QuincenaResultante);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\ACTIVOS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\ESTATUTO A");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\MANDO");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\JUBILADOS");


            // Generamos el Enlace para Activos
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "ACTIVOS ";
            Abreviatura = "AA";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 201 AND [UNIDAD DE PAGO] <= 238", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante + "\\" + Abreviatura + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaResultante, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaResultante, TipoNomina.Trim(), Abreviatura);

            // Generamos el Enlace para Estatuo A
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "ESTATUTO A ";
            Abreviatura = "EA";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 401 AND [UNIDAD DE PAGO] <= 436", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante + "\\" + Abreviatura + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaResultante, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaResultante, TipoNomina.Trim(), Abreviatura);

            // Generamos el Enlace para MANDOS
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "MANDO ";
            Abreviatura = "MM";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 239 AND [UNIDAD DE PAGO] <= 239", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante + "\\" + Abreviatura + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaResultante, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaResultante, TipoNomina.Trim(), Abreviatura);


            // Generamos el Enlace para JUBILADOS
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "JUBILADOS ";
            Abreviatura = "JJ";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 001 AND [UNIDAD DE PAGO] <= 038", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante + "\\" + Abreviatura + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaResultante + "\\" + TipoNomina + QuincenaResultante, QuincenaResultante, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaResultante, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaResultante + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaResultante, TipoNomina.Trim(), Abreviatura);


            // Reporte General
            EnlaceGenerarReportesGralXLSMasivo(dsEnlace.Tables[9], dsEnlace.Tables[8], RutaEntregable + "\\Entregable7Reportes\\General\\", QuincenaResultante, "AA");

            // Generamos el DBF(Activos, Estatutos, Mandos)
            string logError = "";
            EnlaceGenerarTipoNominaOutSACI_Masivos(dsEnlace.Tables[4], RutaEntregable + "\\Entregable4SACI", RutaEntregable + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado", QuincenaResultante, "ACTIVOS", "AA", ref logError);

            // Liberamos los recursos
            dsEnlace = null;
            dvUnidadesPago = null;
            dvResumen = null;
            dvResumenAcuses = null;
            dvReporteNomina = null;
            dvResumenNomina = null;

            // Regresamos Solicitud
            blnResultado = true;
            return blnResultado;
        }

        public bool EnlaceGenerarMasivo_V2(string QuincenaEnlace, ref string error)
        {
            bool blnResultado = false;
            DataSet dsEnlace = null;
            
            dsEnlace = tramite.EnlaceGenerarMasivo_V2(QuincenaEnlace, ref error);

            // Declaración de Variables
            DataView dvUnidadesPago = null;
            DataView dvResumen = null;
            DataView dvResumenAcuses = null;
            DataView dvReporteNomina = null;
            DataView dvResumenNomina = null;
            string RutaEntregable = "";
            string TipoNomina = "";
            string Abreviatura = "";
            double totalMovimientosAlta = 0;
            double totalMovimientosBaja = 0;
            double totalMovimientosModi = 0;
            double totalImporteAlta = 0;
            double totalImporteBaja = 0;
            double totalImporteModi = 0;

            RutaEntregable = @"C:\IMSSPortal\Entregables\" + QuincenaEnlace + "_Enlace";
            if (Directory.Exists(RutaEntregable))
            {
                var dir = new DirectoryInfo(RutaEntregable);
                dir.Attributes = dir.Attributes & FileAttributes.ReadOnly;
                dir.Delete(true);
            }

            Directory.CreateDirectory(RutaEntregable);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable4SACI");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable5IMAGENES");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable5IMAGENES\\Imagenes");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\General");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS\\ACTIVOS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS\\ESTATUTO A");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS\\MANDO");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\ACTIVOS " + QuincenaEnlace);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\ACTIVOS " + QuincenaEnlace + "\\AA" + QuincenaEnlace);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\ESTATUTO A " + QuincenaEnlace);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\ESTATUTO A " + QuincenaEnlace + "\\EA" + QuincenaEnlace);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\MANDO " + QuincenaEnlace);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\MANDO " + QuincenaEnlace + "\\MM" + QuincenaEnlace);
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\ACTIVOS");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\ESTATUTO A");
            Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\MANDO");

            


            // Generamos el Enlace para Activos
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "ACTIVOS ";
            Abreviatura = "AA";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 201 AND [UNIDAD DE PAGO] <= 238", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'" , "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace + "\\" + Abreviatura + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaEnlace, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaEnlace, TipoNomina.Trim(), Abreviatura);

            // Generamos el Enlace para Estatuo A
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "ESTATUTO A ";
            Abreviatura = "EA";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 401 AND [UNIDAD DE PAGO] <= 438", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace + "\\" + Abreviatura + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaEnlace, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaEnlace, TipoNomina.Trim(), Abreviatura);

            // Generamos el Enlace para MANDOS
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "MANDO ";
            Abreviatura = "MM";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 239 AND [UNIDAD DE PAGO] <= 239", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
            dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
            dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
            EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace + "\\" + Abreviatura + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura);
            EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + QuincenaEnlace + "\\" + TipoNomina + QuincenaEnlace, QuincenaEnlace, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, QuincenaEnlace, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + QuincenaEnlace + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), QuincenaEnlace, TipoNomina.Trim(), Abreviatura);


            // Generamos el Enlace para JUBILADOS
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            TipoNomina = "JUBILADOS ";
            Abreviatura = "JJ";
            dvUnidadesPago = new DataView(dsEnlace.Tables[0], "Abreviatura = '" + Abreviatura + "'", "Abreviatura", DataViewRowState.CurrentRows);
            dvResumen = new DataView(dsEnlace.Tables[2], "[UNIDAD DE PAGO] >= 001 AND [UNIDAD DE PAGO] <= 038", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);

            if (dvResumen.Count > 0)
            {
                foreach (DataRowView rowJJ in dvResumen)
                {
                    DataRow rowEnlaceJJ = rowJJ.Row;
                    string _QuincenaJJ = rowEnlaceJJ["AÑO QUINCENA"].ToString();
                    string _Quincena = string.Format("{0:00}", (int.Parse(_QuincenaJJ.Substring(4, 2)) / 2));
                    string _QuincenaJJ_Files = _QuincenaJJ.Substring(0,4) + _Quincena ;

                    Directory.CreateDirectory(RutaEntregable + "\\Entregable3Acuses\\JUBILADOS");
                    Directory.CreateDirectory(RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ_Files + "_Reporte de efectividad IMSS\\JUBILADOS");
                    Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ_Files + "\\JUBILADOS " + _QuincenaJJ_Files);
                    Directory.CreateDirectory(RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ_Files + "\\JUBILADOS " + _QuincenaJJ_Files + "\\JJ" + _QuincenaJJ_Files);

                    dvResumenAcuses = new DataView(dsEnlace.Tables[5], "TipoNomina = '" + Abreviatura + "'", "TipoNomina", DataViewRowState.CurrentRows);
                    dvReporteNomina = new DataView(dsEnlace.Tables[6], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);
                    dvResumenNomina = new DataView(dsEnlace.Tables[7], "TIPO_NOMINA = '" + Abreviatura + "'", "TIPO_NOMINA", DataViewRowState.CurrentRows);

                    EnlaceGenerarMasivoTipoNominaOutFileTXT(dsEnlace.Tables[1], dvUnidadesPago, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ_Files + "\\" + TipoNomina + _QuincenaJJ_Files + "\\" + Abreviatura + _QuincenaJJ_Files, _QuincenaJJ, TipoNomina.Trim(), Abreviatura);
                    EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(dvResumen, RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ_Files + "\\" + TipoNomina + _QuincenaJJ_Files, _QuincenaJJ_Files, TipoNomina.Trim(), Abreviatura);
                    EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(dvUnidadesPago, dsEnlace.Tables[3], RutaEntregable + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ_Files + "\\" + TipoNomina + _QuincenaJJ_Files, _QuincenaJJ_Files, TipoNomina.Trim(), Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
                    EnlaceGenerarMasivoTipoNominaResumenXLS(dvResumenAcuses, RutaEntregable + "\\Entregable3Acuses\\" + TipoNomina, _QuincenaJJ_Files, TipoNomina, Abreviatura, ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
                    EnlaceGenerarTipoNominaReportesXLSMasivo(dvResumenNomina, dvReporteNomina, RutaEntregable + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ_Files + "_Reporte de efectividad IMSS\\" + TipoNomina.Trim(), _QuincenaJJ, TipoNomina.Trim(), Abreviatura);
                    break;
                }
            }

            // Reporte General
            EnlaceGenerarReportesGralXLSMasivo(dsEnlace.Tables[9], dsEnlace.Tables[8], RutaEntregable + "\\Entregable7Reportes\\General\\", QuincenaEnlace, "AA");

            // Generamos el DBF(Activos, Estatutos, Mandos)
            string logError = "";
            EnlaceGenerarTipoNominaOutSACI_Masivos(dsEnlace.Tables[4], RutaEntregable + "\\Entregable4SACI", RutaEntregable + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado", QuincenaEnlace, "ACTIVOS", "AA", ref logError);

            // Liberamos los recursos
            dsEnlace = null;
            dvUnidadesPago = null;
            dvResumen = null;
            dvResumenAcuses = null;
            dvReporteNomina = null;
            dvResumenNomina = null;

            // Regresamos Solicitud
            blnResultado = true;
            return blnResultado;
        }

        public bool EnlaceGenerar(string Quincena, string TipoNomina, ref string logError)
        {
            DataSet dsJubilados = null;
            DataSet dsActivos = null;
            DataSet dsEstatuto = null;
            DataSet dsMando = null;
            bool resultado = false;
            string RutaEntregableJJ = "";
            string RutaEntregableAA = "";
            string _QuincenaJJ = "";
            string _QuincenaAA = "";
            int intQuincenaTemp = 0;
            double totalMovimientosAlta = 0;
            double totalMovimientosBaja = 0;
            double totalMovimientosModi = 0;
            double totalImporteAlta = 0;
            double totalImporteBaja = 0;
            double totalImporteModi = 0;

            int intQuincena = int.Parse(Quincena.Substring(4, 2));
            if ((intQuincena % 2) == 0)
            {
                intQuincenaTemp = (int.Parse(Quincena.Substring(4, 2)) + 4);
                if (intQuincenaTemp > 24)
                {
                    intQuincenaTemp = intQuincenaTemp - 24;
                    _QuincenaJJ = (int.Parse(Quincena.Substring(0, 4)) + 1).ToString() + string.Format("{0:00}", intQuincenaTemp);
                }
                else
                {
                    _QuincenaJJ = Quincena.Substring(0, 4) + string.Format("{0:00}", intQuincenaTemp);
                }

                
                dsJubilados = tramite.EnlaceGenerar(_QuincenaJJ, "JJ");

                _QuincenaJJ = _QuincenaJJ.Substring(0, 4) + string.Format("{0:00}", (intQuincenaTemp/2) );
                RutaEntregableJJ = @"C:\IMSSPortal\Entregables\" + _QuincenaJJ + "_Enlace";
                if (Directory.Exists(RutaEntregableJJ))
                {
                    var dir = new DirectoryInfo(RutaEntregableJJ);
                    dir.Attributes = dir.Attributes & FileAttributes.ReadOnly;
                    dir.Delete(true);
                }

                Directory.CreateDirectory(RutaEntregableJJ);
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable1ZIP");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable3Acuses");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable4SACI");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable5IMAGENES");
                Directory.CreateDirectory(RutaEntregableAA + "\\Entregable5IMAGENES\\Imagenes");
                Directory.CreateDirectory(RutaEntregableAA + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\General");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\Nominas");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ + "_Reporte de efectividad IMSS");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ + "_Reporte de efectividad IMSS\\ACTIVOS");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ + "_Reporte de efectividad IMSS\\ESTATUTO A");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ + "_Reporte de efectividad IMSS\\MANDO");
            }

            _QuincenaAA = Quincena;
            dsActivos = tramite.EnlaceGenerar(_QuincenaAA, "AA");
            dsEstatuto = tramite.EnlaceGenerar(_QuincenaAA, "EA");
            dsMando = tramite.EnlaceGenerar(_QuincenaAA, "MM");

            intQuincenaTemp = (int.Parse(Quincena.Substring(4, 2)) + 2);
            if (intQuincenaTemp > 24)
            {
                intQuincenaTemp = intQuincenaTemp - 24;
                _QuincenaAA = (int.Parse(Quincena.Substring(0, 4))+1).ToString() + string.Format("{0:00}", intQuincenaTemp);
            }
            else
            {
                _QuincenaAA = Quincena.Substring(0, 4) + string.Format("{0:00}", intQuincenaTemp);
            }

            

            RutaEntregableAA = @"C:\IMSSPortal\Entregables\" + _QuincenaAA.ToString() + "_Enlace";

            if (Directory.Exists(RutaEntregableAA))
            {
                var dir = new DirectoryInfo(RutaEntregableAA);
                dir.Attributes = dir.Attributes & FileAttributes.ReadOnly;
                dir.Delete(true);
            }
            
            Directory.CreateDirectory(RutaEntregableAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable3Acuses");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable4SACI");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable5IMAGENES");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable5IMAGENES\\Imagenes");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes\\General");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes\\Nominas");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS\\ACTIVOS");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS\\ESTATUTO A");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS\\MANDO");

            if ((intQuincena % 2) == 0)
            {
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ + "\\JUBILADOS " + _QuincenaJJ);
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ + "\\JUBILADOS " + _QuincenaJJ + "\\JJ" + _QuincenaJJ);
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable3Acuses\\JUBILADOS");
                Directory.CreateDirectory(RutaEntregableJJ + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ + "_Reporte de efectividad IMSS\\JUBILADOS");

                totalMovimientosAlta = 0;
                totalMovimientosBaja = 0;
                totalMovimientosModi = 0;
                totalImporteAlta = 0;
                totalImporteBaja = 0;
                totalImporteModi = 0;
                EnlaceGenerarTipoNominaOutFileTXT(dsJubilados.Tables[1], dsJubilados.Tables[0], RutaEntregableJJ + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ + "\\JUBILADOS " + _QuincenaJJ + "\\JJ" + _QuincenaJJ, _QuincenaJJ, "JUBILADOS", "JJ");
                EnlaceGenerarTipoNominaOutFileTXTResumen(dsJubilados.Tables[2], RutaEntregableJJ + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ + "\\JUBILADOS " + _QuincenaJJ, _QuincenaJJ, "JUBILADOS", "JJ");
                EnlaceGenerarTipoNominaOutFileTXTCifras(dsJubilados.Tables[0], dsJubilados.Tables[3], RutaEntregableJJ + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaJJ + "\\JUBILADOS " + _QuincenaJJ, _QuincenaJJ, "JUBILADOS", "JJ", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
                EnlaceGenerarTipoNominaResumenXLS(dsJubilados, RutaEntregableJJ + "\\Entregable3Acuses\\JUBILADOS", _QuincenaJJ, "JUBILADOS", "JJ", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
                EnlaceGenerarTipoNominaReportesXLS(dsJubilados.Tables[7], dsJubilados.Tables[6], RutaEntregableJJ + "\\Entregable7Reportes\\Nominas\\" + _QuincenaJJ + "_Reporte de efectividad IMSS\\JUBILADOS", _QuincenaJJ, "JUBILADOS", "JJ");
                EnlaceGenerarReportesGralXLS(dsJubilados.Tables[9], dsJubilados.Tables[8], RutaEntregableJJ + "\\Entregable7Reportes\\General\\", _QuincenaJJ, "JJ");
            }
            
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ACTIVOS " + _QuincenaAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ACTIVOS " + _QuincenaAA + "\\AA" + _QuincenaAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ESTATUTO A " + _QuincenaAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ESTATUTO A " + _QuincenaAA + "\\EA" + _QuincenaAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\MANDO " + _QuincenaAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\MANDO " + _QuincenaAA + "\\MM" + _QuincenaAA);
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable3Acuses\\ACTIVOS");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable3Acuses\\ESTATUTO");
            Directory.CreateDirectory(RutaEntregableAA + "\\Entregable3Acuses\\MANDO");
                
            // Creamos los directorios de los Tipos de Nominas ACTIVOS
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0; 
            totalImporteModi = 0;
            EnlaceGenerarTipoNominaOutFileTXT(dsActivos.Tables[1], dsActivos.Tables[0], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ACTIVOS " + _QuincenaAA + "\\AA" + _QuincenaAA, _QuincenaAA, "ACTIVOS", "AA");
            EnlaceGenerarTipoNominaOutFileTXTResumen(dsActivos.Tables[2], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ACTIVOS " + _QuincenaAA, _QuincenaAA, "ACTIVOS", "AA");
            EnlaceGenerarTipoNominaOutFileTXTCifras(dsActivos.Tables[0], dsActivos.Tables[3], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ACTIVOS " + _QuincenaAA, _QuincenaAA, "ACTIVOS", "AA", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaResumenXLS(dsActivos, RutaEntregableAA + "\\Entregable3Acuses\\ACTIVOS", _QuincenaAA, "ACTIVOS", "AA", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLS(dsActivos.Tables[7], dsActivos.Tables[6], RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS\\ACTIVOS", _QuincenaAA, "ACTIVOS", "AA");

            // Creamos los directorios de los Tipos de Nominas ESTATUTO
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            EnlaceGenerarTipoNominaOutFileTXT(dsEstatuto.Tables[1], dsEstatuto.Tables[0], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ESTATUTO A " + _QuincenaAA + "\\EA" + _QuincenaAA, _QuincenaAA, "ESTATUTO A", "EA");
            EnlaceGenerarTipoNominaOutFileTXTResumen(dsEstatuto.Tables[2], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ESTATUTO A " + _QuincenaAA, _QuincenaAA, "ESTATUTO A", "EA");
            EnlaceGenerarTipoNominaOutFileTXTCifras(dsEstatuto.Tables[0], dsEstatuto.Tables[3], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\ESTATUTO A " + _QuincenaAA, _QuincenaAA, "ESTATUTO A", "EA", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaResumenXLS(dsEstatuto, RutaEntregableAA + "\\Entregable3Acuses\\ESTATUTO", _QuincenaAA, "ESTATUTO A", "EA", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLS(dsEstatuto.Tables[7], dsEstatuto.Tables[6], RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS\\ESTATUTO A", _QuincenaAA, "ESTATUTO A", "EA");

            // Creamos los directorios de los Tipos de Nominas MANDO
            totalMovimientosAlta = 0;
            totalMovimientosBaja = 0;
            totalMovimientosModi = 0;
            totalImporteAlta = 0;
            totalImporteBaja = 0;
            totalImporteModi = 0;
            EnlaceGenerarTipoNominaOutFileTXT(dsMando.Tables[1], dsMando.Tables[0], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\MANDO " + _QuincenaAA + "\\MM" + _QuincenaAA, _QuincenaAA, "MANDO", "MM");
            EnlaceGenerarTipoNominaOutFileTXTResumen(dsMando.Tables[2], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\MANDO " + _QuincenaAA, _QuincenaAA, "MANDO", "MM");
            EnlaceGenerarTipoNominaOutFileTXTCifras(dsMando.Tables[0], dsMando.Tables[3], RutaEntregableAA + "\\Entregable1ZIP\\Envio IMSS " + _QuincenaAA + "\\MANDO " + _QuincenaAA, _QuincenaAA, "MANDO", "MM", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaResumenXLS(dsMando, RutaEntregableAA + "\\Entregable3Acuses\\MANDO", _QuincenaAA, "MANDO", "MM", ref totalMovimientosAlta, ref totalMovimientosBaja, ref totalMovimientosModi, ref totalImporteAlta, ref totalImporteBaja, ref totalImporteModi);
            EnlaceGenerarTipoNominaReportesXLS(dsMando.Tables[7], dsMando.Tables[6], RutaEntregableAA + "\\Entregable7Reportes\\Nominas\\" + _QuincenaAA + "_Reporte de efectividad IMSS\\MANDO", _QuincenaAA, "MANDO", "MM");

            // Reporte General
            EnlaceGenerarReportesGralXLS(dsMando.Tables[9], dsMando.Tables[8], RutaEntregableAA + "\\Entregable7Reportes\\General\\", _QuincenaAA, "AA");


            if (_QuincenaAA == _QuincenaJJ)
            {
                EnlaceGenerarTipoNominaOutSACI_TiposNominasALL(dsActivos.Tables[4], dsEstatuto.Tables[4], dsMando.Tables[4], dsJubilados.Tables[4], RutaEntregableAA + "\\Entregable4SACI", RutaEntregableAA + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado", _QuincenaJJ, "ACTIVOS", "AA", ref logError);
            }
            else
            {
                if ((intQuincena % 2) == 0)
                {
                    EnlaceGenerarTipoNominaOutSACI_Jubilados(dsJubilados.Tables[4], RutaEntregableJJ + "\\Entregable4SACI", RutaEntregableJJ + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado", _QuincenaJJ, "JUBILADOS", "JJ", ref logError);
                }
                else
                {
                    EnlaceGenerarTipoNominaOutSACI_Activos(dsActivos.Tables[4], dsEstatuto.Tables[4], dsMando.Tables[4], RutaEntregableAA + "\\Entregable4SACI", RutaEntregableAA + "\\Entregable5IMAGENES\\Imagenes\\Img_Identificado", _QuincenaJJ, "ACTIVOS", "AA", ref logError);
                }
            }

            resultado = true;
            return resultado;
        }

        private void EnlaceGenerarReportesGralXLSMasivo(DataTable dtResumen, DataTable dtReporte, string RutaEntregable, string Quincena, string Abreviatura)
        {
            string newFilePath = RutaEntregable + "\\Reporte de efectividad de Cartas Instrucción IMSS " + Quincena + ".xlsx";
            int TotalCartasEsperadas = 0;
            int TotalCartasFaltantes = 0;
            int TotalMovimientos = 0;
            float Efectividad = 0;

            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }

            FileInfo newFile = new FileInfo(newFilePath);
            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                // ======================================================================================================= \\
                // RESUMEN...
                excel.Workbook.Worksheets.Add("Resumen");
                var worksheet = excel.Workbook.Worksheets["Resumen"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z3000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:E1"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Value = "IMSS NOMINA DE TRABAJADORES QUINCENA " + Quincena.Substring(0, 4) + "-" + Quincena.Substring(4, 2);
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A2:A2"])
                {
                    Rng.Value = "Promotoría último servicio";
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B2:B2"])
                {
                    Rng.Value = "Identificado";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["C2:C2"])
                {
                    Rng.Value = "Sin Carta";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["D2:D2"])
                {
                    Rng.Value = "Total de movimientos que requieren carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["E2:E2"])
                {
                    Rng.Value = "Efectividad";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#92D050"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                int NFilas = 3;
                foreach (DataRow row in dtResumen.Rows)
                {
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["Promotoría último servicio"];
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        TotalCartasEsperadas += int.Parse(row["Identificado"].ToString());
                        CeldaDato.Value = int.Parse(row["Identificado"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        if (row["Sin Carta"].ToString().Length != 0)
                            TotalCartasFaltantes += int.Parse(row["Sin Carta"].ToString());

                        CeldaDato.Value = int.Parse(row["Sin Carta"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                        TotalMovimientos += int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                        CeldaDato.Value = int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                        Efectividad = float.Parse(row["Efectividad"].ToString());
                        CeldaDato.Value = Efectividad;
                    }
                    NFilas += 1;
                }

                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Total General";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasEsperadas;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasFaltantes;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = TotalMovimientos;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                    double porcentaje = 0;
                    try
                    {
                        porcentaje = (TotalMovimientos * 100 / TotalCartasEsperadas);
                    }
                    catch { }
                    CeldaDato.Value = porcentaje;
                }

                NFilas += 2;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Nota: ";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que se reportan con inconsistencia en llenado y con diferencia en prima deberán ser nuevamente enviadas con los datos correctos y reprogramar los movimientos";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que no llegaron en tiempo, deberán solicitar la reprogramación de los movimientos hasta que contemos con las Cartas en MetLife";
                }

                // estilos de Columnas y Renglones.
                worksheet.Row(1).Style.WrapText = true;
                worksheet.Row(2).Style.WrapText = true;
                worksheet.Row(1).Height = 27;
                worksheet.Row(2).Height = 60;
                worksheet.Column(1).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(2).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(3).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(4).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(5).Width = GetTrueColumnWidth(13.57);

                // ======================================================================================================= \\
                // DETALLE...
                excel.Workbook.Worksheets.Add("Reporte");
                var wsReporte = excel.Workbook.Worksheets["Reporte"];
                wsReporte.CustomHeight = true;

                using (ExcelRange Rng = wsReporte.Cells["A1:Z5000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                }
                using (ExcelRange Rng = wsReporte.Cells["A1:A1"])
                {
                    Rng.Value = "Matrícula";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["B1:B1"])
                {
                    Rng.Value = "Importe";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["C1:C1"])
                {
                    Rng.Value = "Póliza";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["D1:D1"])
                {
                    Rng.Value = "Promotoría de origen";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["E1:E1"])
                {
                    Rng.Value = "Usuario de Servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["F1:F1"])
                {
                    Rng.Value = "Promotoría de último servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FF0000"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["G1:G1"])
                {
                    Rng.Value = "Promotoría responsable";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["H1:H1"])
                {
                    Rng.Value = "Tipo de Movimiento";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["I1:I1"])
                {
                    Rng.Value = "Nombre del Trabajador";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["J1:J1"])
                {
                    Rng.Value = "Unidad de pago";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["K1:K1"])
                {
                    Rng.Value = "Tipo de nómina";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["L1:L1"])
                {
                    Rng.Value = "Año / Quincena";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["M1:M1"])
                {
                    Rng.Value = "Estatus de la carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["N1:N1"])
                {
                    Rng.Value = "Motivo de Rechazo";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                NFilas = 2;
                foreach (DataRow row in dtReporte.Rows)
                {
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["MATRICULA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Value = row["IMPORTE"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Value = row["POLIZA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Value = row["PROM_ORIGEN"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Value = row["USR_SERVICIO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 6, NFilas, 6])
                    {
                        CeldaDato.Value = row["PROM_U_SERV"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 7, NFilas, 7])
                    {
                        CeldaDato.Value = row["PROM_RESPON"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 8, NFilas, 8])
                    {
                        CeldaDato.Value = row["TIPO_MOVIMIENTO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 9, NFilas, 9])
                    {
                        CeldaDato.Value = row["NOMBRE_TRABAJADOR"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 10, NFilas, 10])
                    {
                        CeldaDato.Value = row["UNIDAD_PAGO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 11, NFilas, 11])
                    {
                        CeldaDato.Value = row["TIPO_NOMINA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 12, NFilas, 12])
                    {
                        CeldaDato.Value = row["ANO_QUINCENA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 13, NFilas, 13])
                    {
                        CeldaDato.Value = "IDENTIFICADO";
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 14, NFilas, 14])
                    {
                        CeldaDato.Value = "OK";
                    }
                    NFilas += 1;
                }

                wsReporte.Row(1).Style.WrapText = true;
                wsReporte.Row(1).Height = 33.75;

                wsReporte.Column(1).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(2).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(3).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(4).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(5).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(6).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(7).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(8).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(9).Width = GetTrueColumnWidth(42.43);
                wsReporte.Column(10).Width = GetTrueColumnWidth(8.00);
                wsReporte.Column(11).Width = GetTrueColumnWidth(6.14);
                wsReporte.Column(12).Width = GetTrueColumnWidth(11.14);
                wsReporte.Column(13).Width = GetTrueColumnWidth(12.57);
                wsReporte.Column(14).Width = GetTrueColumnWidth(41.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarReportesGralXLS(DataTable dtResumen, DataTable dtReporte, string RutaEntregable, string Quincena, string Abreviatura)
        {
            string newFilePath = RutaEntregable + "\\Reporte de efectividad de Cartas Instrucción IMSS " + Quincena + ".xlsx";
            int TotalCartasEsperadas = 0;
            int TotalCartasFaltantes = 0;
            int TotalMovimientos = 0;
            float Efectividad = 0;

            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }

            FileInfo newFile = new FileInfo(newFilePath);
            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                // ======================================================================================================= \\
                // RESUMEN...
                excel.Workbook.Worksheets.Add("Resumen");
                var worksheet = excel.Workbook.Worksheets["Resumen"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z3000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:E1"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Value = "IMSS NOMINA DE TRABAJADORES QUINCENA " + Quincena.Substring(0, 4) + "-" + Quincena.Substring(4, 2);
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A2:A2"])
                {
                    Rng.Value = "Promotoría último servicio";
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B2:B2"])
                {
                    Rng.Value = "Identificado";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["C2:C2"])
                {
                    Rng.Value = "Sin Carta";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["D2:D2"])
                {
                    Rng.Value = "Total de movimientos que requieren carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["E2:E2"])
                {
                    Rng.Value = "Efectividad";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#92D050"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                int NFilas = 3;
                foreach (DataRow row in dtResumen.Rows)
                {
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["Promotoría último servicio"];
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        TotalCartasEsperadas += int.Parse(row["Identificado"].ToString());
                        CeldaDato.Value = int.Parse(row["Identificado"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        if (row["Sin Carta"].ToString().Length != 0)
                            TotalCartasFaltantes += int.Parse(row["Sin Carta"].ToString());

                        CeldaDato.Value = int.Parse(row["Sin Carta"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                        TotalMovimientos += int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                        CeldaDato.Value = int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                        Efectividad = float.Parse(row["Efectividad"].ToString());
                        CeldaDato.Value = Efectividad;
                    }
                    NFilas += 1;
                }

                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Total General";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasEsperadas;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasFaltantes;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = TotalMovimientos;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                    double porcentaje = 0;
                    try
                    {
                        porcentaje = (TotalMovimientos * 100 / TotalCartasEsperadas);
                    }
                    catch{ }
                    CeldaDato.Value = porcentaje;
                }

                NFilas += 2;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Nota: ";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que se reportan con inconsistencia en llenado y con diferencia en prima deberán ser nuevamente enviadas con los datos correctos y reprogramar los movimientos";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que no llegaron en tiempo, deberán solicitar la reprogramación de los movimientos hasta que contemos con las Cartas en MetLife";
                }

                // estilos de Columnas y Renglones.
                worksheet.Row(1).Style.WrapText = true;
                worksheet.Row(2).Style.WrapText = true;
                worksheet.Row(1).Height = 27;
                worksheet.Row(2).Height = 60;
                worksheet.Column(1).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(2).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(3).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(4).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(5).Width = GetTrueColumnWidth(13.57);

                // ======================================================================================================= \\
                // DETALLE...
                excel.Workbook.Worksheets.Add("Reporte");
                var wsReporte = excel.Workbook.Worksheets["Reporte"];
                wsReporte.CustomHeight = true;

                using (ExcelRange Rng = wsReporte.Cells["A1:Z5000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                }
                using (ExcelRange Rng = wsReporte.Cells["A1:A1"])
                {
                    Rng.Value = "Matrícula";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["B1:B1"])
                {
                    Rng.Value = "Importe";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["C1:C1"])
                {
                    Rng.Value = "Póliza";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["D1:D1"])
                {
                    Rng.Value = "Promotoría de origen";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["E1:E1"])
                {
                    Rng.Value = "Usuario de Servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["F1:F1"])
                {
                    Rng.Value = "Promotoría de último servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FF0000"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["G1:G1"])
                {
                    Rng.Value = "Promotoría responsable";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["H1:H1"])
                {
                    Rng.Value = "Tipo de Movimiento";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["I1:I1"])
                {
                    Rng.Value = "Nombre del Trabajador";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["J1:J1"])
                {
                    Rng.Value = "Unidad de pago";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["K1:K1"])
                {
                    Rng.Value = "Tipo de nómina";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["L1:L1"])
                {
                    Rng.Value = "Año / Quincena";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["M1:M1"])
                {
                    Rng.Value = "Estatus de la carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["N1:N1"])
                {
                    Rng.Value = "Motivo de Rechazo";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                NFilas = 2;
                foreach (DataRow row in dtReporte.Rows)
                {
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["MATRICULA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Value = row["IMPORTE"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Value = row["POLIZA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Value = row["PROM_ORIGEN"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Value = row["USR_SERVICIO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 6, NFilas, 6])
                    {
                        CeldaDato.Value = row["PROM_U_SERV"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 7, NFilas, 7])
                    {
                        CeldaDato.Value = row["PROM_RESPON"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 8, NFilas, 8])
                    {
                        CeldaDato.Value = row["TIPO_MOVIMIENTO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 9, NFilas, 9])
                    {
                        CeldaDato.Value = row["NOMBRE_TRABAJADOR"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 10, NFilas, 10])
                    {
                        CeldaDato.Value = row["UNIDAD_PAGO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 11, NFilas, 11])
                    {
                        CeldaDato.Value = row["TIPO_NOMINA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 12, NFilas, 12])
                    {
                        CeldaDato.Value = row["ANO_QUINCENA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 13, NFilas, 13])
                    {
                        CeldaDato.Value = "IDENTIFICADO";
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 14, NFilas, 14])
                    {
                        CeldaDato.Value = "OK";
                    }
                    NFilas += 1;
                }

                wsReporte.Row(1).Style.WrapText = true;
                wsReporte.Row(1).Height = 33.75;

                wsReporte.Column(1).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(2).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(3).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(4).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(5).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(6).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(7).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(8).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(9).Width = GetTrueColumnWidth(42.43);
                wsReporte.Column(10).Width = GetTrueColumnWidth(8.00);
                wsReporte.Column(11).Width = GetTrueColumnWidth(6.14);
                wsReporte.Column(12).Width = GetTrueColumnWidth(11.14);
                wsReporte.Column(13).Width = GetTrueColumnWidth(12.57);
                wsReporte.Column(14).Width = GetTrueColumnWidth(41.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarTipoNominaReportesXLSMasivo(DataView dvResumen, DataView dvReporte, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura)
        {
            string newFilePath = RutaEntregable + "\\Reporte de efectividad de Cartas Instrucción IMSS " + Abreviatura + " " + Quincena + ".xlsx";
            int TotalCartasEsperadas = 0;
            int TotalCartasFaltantes = 0;
            int TotalMovimientos = 0;
            float Efectividad = 0;

            if (File.Exists(newFilePath))
                File.Delete(newFilePath);

            FileInfo newFile = new FileInfo(newFilePath);
            using (ExcelPackage excel = new ExcelPackage(newFile))
            {

                // ======================================================================================================= \\
                // RESUMEN...
                excel.Workbook.Worksheets.Add("Resumen");
                var worksheet = excel.Workbook.Worksheets["Resumen"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z3000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:E1"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Value = "IMSS NOMINA DE TRABAJADORES QUINCENA " + Quincena.Substring(0, 4) + "-" + Quincena.Substring(4, 2);
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A2:A2"])
                {
                    Rng.Value = "Promotoría último servicio";
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B2:B2"])
                {
                    Rng.Value = "Identificado";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["C2:C2"])
                {
                    Rng.Value = "Sin Carta";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["D2:D2"])
                {
                    Rng.Value = "Total de movimientos que requieren carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["E2:E2"])
                {
                    Rng.Value = "Efectividad";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#92D050"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                int NFilas = 3;
                foreach (DataRowView rowView in dvResumen)
                {
                    DataRow row = rowView.Row;

                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["Promotoría último servicio"];
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        TotalCartasEsperadas += int.Parse(row["Identificado"].ToString());
                        CeldaDato.Value = int.Parse(row["Identificado"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        if (row["Sin Carta"].ToString().Length != 0)
                            TotalCartasFaltantes += int.Parse(row["Sin Carta"].ToString());

                        CeldaDato.Value = int.Parse(row["Sin Carta"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                        TotalMovimientos += int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                        CeldaDato.Value = int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                        Efectividad = float.Parse(row["Efectividad"].ToString());
                        CeldaDato.Value = Efectividad;
                    }
                    NFilas += 1;
                }

                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Total General";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasEsperadas;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasFaltantes;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = TotalMovimientos;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                {
                    try
                    {
                        CeldaDato.Style.Font.Bold = true;
                        CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                        CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                        CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                        double porcentaje = (TotalMovimientos * 100 / TotalCartasEsperadas);
                        CeldaDato.Value = porcentaje;
                    }
                    catch
                    {
                    }
                }

                NFilas += 2;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Nota: ";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que se reportan con inconsistencia en llenado y con diferencia en prima deberán ser nuevamente enviadas con los datos correctos y reprogramar los movimientos";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que no llegaron en tiempo, deberán solicitar la reprogramación de los movimientos hasta que contemos con las Cartas en MetLife";
                }

                // estilos de Columnas y Renglones.
                worksheet.Row(1).Style.WrapText = true;
                worksheet.Row(2).Style.WrapText = true;
                worksheet.Row(1).Height = 27;
                worksheet.Row(2).Height = 60;
                worksheet.Column(1).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(2).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(3).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(4).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(5).Width = GetTrueColumnWidth(13.57);

                // ======================================================================================================= \\
                // DETALLE...
                excel.Workbook.Worksheets.Add("Reporte");
                var wsReporte = excel.Workbook.Worksheets["Reporte"];
                wsReporte.CustomHeight = true;

                using (ExcelRange Rng = wsReporte.Cells["A1:Z5000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                }
                using (ExcelRange Rng = wsReporte.Cells["A1:A1"])
                {
                    Rng.Value = "Matrícula";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["B1:B1"])
                {
                    Rng.Value = "Importe";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["C1:C1"])
                {
                    Rng.Value = "Póliza";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["D1:D1"])
                {
                    Rng.Value = "Promotoría de origen";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["E1:E1"])
                {
                    Rng.Value = "Usuario de Servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["F1:F1"])
                {
                    Rng.Value = "Promotoría de último servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FF0000"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["G1:G1"])
                {
                    Rng.Value = "Promotoría responsable";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["H1:H1"])
                {
                    Rng.Value = "Tipo de Movimiento";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["I1:I1"])
                {
                    Rng.Value = "Nombre del Trabajador";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["J1:J1"])
                {
                    Rng.Value = "Unidad de pago";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["K1:K1"])
                {
                    Rng.Value = "Tipo de nómina";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["L1:L1"])
                {
                    Rng.Value = "Año / Quincena";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["M1:M1"])
                {
                    Rng.Value = "Estatus de la carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["N1:N1"])
                {
                    Rng.Value = "Motivo de Rechazo";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                NFilas = 2;
                foreach (DataRowView rowView in dvReporte)
                {
                    DataRow row = rowView.Row;
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["MATRICULA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Value = row["IMPORTE"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Value = row["POLIZA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Value = row["PROM_ORIGEN"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Value = row["USR_SERVICIO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 6, NFilas, 6])
                    {
                        CeldaDato.Value = row["PROM_U_SERV"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 7, NFilas, 7])
                    {
                        CeldaDato.Value = row["PROM_RESPON"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 8, NFilas, 8])
                    {
                        CeldaDato.Value = row["TIPO_MOVIMIENTO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 9, NFilas, 9])
                    {
                        CeldaDato.Value = row["NOMBRE_TRABAJADOR"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 10, NFilas, 10])
                    {
                        CeldaDato.Value = row["UNIDAD_PAGO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 11, NFilas, 11])
                    {
                        CeldaDato.Value = row["TIPO_NOMINA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 12, NFilas, 12])
                    {
                        CeldaDato.Value = row["ANO_QUINCENA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 13, NFilas, 13])
                    {
                        CeldaDato.Value = "IDENTIFICADO";
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 14, NFilas, 14])
                    {
                        CeldaDato.Value = "OK";
                    }
                    NFilas += 1;
                }

                wsReporte.Row(1).Style.WrapText = true;
                wsReporte.Row(1).Height = 33.75;

                wsReporte.Column(1).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(2).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(3).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(4).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(5).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(6).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(7).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(8).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(9).Width = GetTrueColumnWidth(42.43);
                wsReporte.Column(10).Width = GetTrueColumnWidth(8.00);
                wsReporte.Column(11).Width = GetTrueColumnWidth(6.14);
                wsReporte.Column(12).Width = GetTrueColumnWidth(11.14);
                wsReporte.Column(13).Width = GetTrueColumnWidth(12.57);
                wsReporte.Column(14).Width = GetTrueColumnWidth(41.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarTipoNominaReportesXLS(DataTable dtResumen, DataTable dtReporte, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura)
        {
            string newFilePath = RutaEntregable + "\\Reporte de efectividad de Cartas Instrucción IMSS " + Abreviatura + " " + Quincena + ".xlsx";
            int TotalCartasEsperadas = 0;
            int TotalCartasFaltantes = 0;
            int TotalMovimientos = 0;
            float Efectividad = 0;

            if (File.Exists(newFilePath))
                File.Delete(newFilePath);

            FileInfo newFile = new FileInfo(newFilePath);
            using (ExcelPackage excel = new ExcelPackage(newFile))
            {

                // ======================================================================================================= \\
                // RESUMEN...
                excel.Workbook.Worksheets.Add("Resumen");
                var worksheet = excel.Workbook.Worksheets["Resumen"];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z3000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:E1"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Value = "IMSS NOMINA DE TRABAJADORES QUINCENA " + Quincena.Substring(0, 4) + "-" + Quincena.Substring(4, 2);
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A2:A2"])
                {
                    Rng.Value = "Promotoría último servicio";
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B2:B2"])
                {
                    Rng.Value = "Identificado";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["C2:C2"])
                {
                    Rng.Value = "Sin Carta";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["D2:D2"])
                {
                    Rng.Value = "Total de movimientos que requieren carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#0070C0"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["E2:E2"])
                {
                    Rng.Value = "Efectividad";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#92D050"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                int NFilas = 3;
                foreach (DataRow row in dtResumen.Rows)
                {
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["Promotoría último servicio"];
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        TotalCartasEsperadas += int.Parse(row["Identificado"].ToString());
                        CeldaDato.Value = int.Parse(row["Identificado"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        if (row["Sin Carta"].ToString().Length != 0)
                            TotalCartasFaltantes += int.Parse(row["Sin Carta"].ToString());

                        CeldaDato.Value = int.Parse(row["Sin Carta"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                        TotalMovimientos += int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                        CeldaDato.Value = int.Parse(row["Total de movimientos que requieren carta instrucción"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                        Efectividad = float.Parse(row["Efectividad"].ToString());
                        CeldaDato.Value = Efectividad;
                    }
                    NFilas += 1;
                }

                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Total General";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasEsperadas;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = TotalCartasFaltantes;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = TotalMovimientos;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                {
                    try
                    {
                        CeldaDato.Style.Font.Bold = true;
                        CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                        CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                        CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        CeldaDato.Style.Numberformat.Format = "#0\\.00%";
                        double porcentaje = (TotalMovimientos * 100 / TotalCartasEsperadas);
                        CeldaDato.Value = porcentaje;
                    }
                    catch
                    { 
                    }
                }

                NFilas += 2;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Nota: ";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que se reportan con inconsistencia en llenado y con diferencia en prima deberán ser nuevamente enviadas con los datos correctos y reprogramar los movimientos";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    CeldaDato.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    CeldaDato.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    CeldaDato.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    CeldaDato.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    CeldaDato.Value = "Las Cartas que no llegaron en tiempo, deberán solicitar la reprogramación de los movimientos hasta que contemos con las Cartas en MetLife";
                }

                // estilos de Columnas y Renglones.
                worksheet.Row(1).Style.WrapText = true;
                worksheet.Row(2).Style.WrapText = true;
                worksheet.Row(1).Height = 27;
                worksheet.Row(2).Height = 60;
                worksheet.Column(1).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(2).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(3).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(4).Width = GetTrueColumnWidth(13.57);
                worksheet.Column(5).Width = GetTrueColumnWidth(13.57);

                // ======================================================================================================= \\
                // DETALLE...
                excel.Workbook.Worksheets.Add("Reporte");
                var wsReporte = excel.Workbook.Worksheets["Reporte"];
                wsReporte.CustomHeight = true;

                using (ExcelRange Rng = wsReporte.Cells["A1:Z5000"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                }
                using (ExcelRange Rng = wsReporte.Cells["A1:A1"])
                {
                    Rng.Value = "Matrícula";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["B1:B1"])
                {
                    Rng.Value = "Importe";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["C1:C1"])
                {
                    Rng.Value = "Póliza";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["D1:D1"])
                {
                    Rng.Value = "Promotoría de origen";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["E1:E1"])
                {
                    Rng.Value = "Usuario de Servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["F1:F1"])
                {
                    Rng.Value = "Promotoría de último servicio";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FF0000"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["G1:G1"])
                {
                    Rng.Value = "Promotoría responsable";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["H1:H1"])
                {
                    Rng.Value = "Tipo de Movimiento";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["I1:I1"])
                {
                    Rng.Value = "Nombre del Trabajador";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["J1:J1"])
                {
                    Rng.Value = "Unidad de pago";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["K1:K1"])
                {
                    Rng.Value = "Tipo de nómina";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["L1:L1"])
                {
                    Rng.Value = "Año / Quincena";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["M1:M1"])
                {
                    Rng.Value = "Estatus de la carta instrucción";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = wsReporte.Cells["N1:N1"])
                {
                    Rng.Value = "Motivo de Rechazo";
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                NFilas = 2;
                foreach (DataRow row in dtReporte.Rows)
                {
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Value = row["MATRICULA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Value = row["IMPORTE"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Value = row["POLIZA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Value = row["PROM_ORIGEN"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Value = row["USR_SERVICIO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 6, NFilas, 6])
                    {
                        CeldaDato.Value = row["PROM_U_SERV"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 7, NFilas, 7])
                    {
                        CeldaDato.Value = row["PROM_RESPON"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 8, NFilas, 8])
                    {
                        CeldaDato.Value = row["TIPO_MOVIMIENTO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 9, NFilas, 9])
                    {
                        CeldaDato.Value = row["NOMBRE_TRABAJADOR"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 10, NFilas, 10])
                    {
                        CeldaDato.Value = row["UNIDAD_PAGO"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 11, NFilas, 11])
                    {
                        CeldaDato.Value = row["TIPO_NOMINA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 12, NFilas, 12])
                    {
                        CeldaDato.Value = row["ANO_QUINCENA"].ToString();
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 13, NFilas, 13])
                    {
                        CeldaDato.Value = "IDENTIFICADO";
                    }
                    using (ExcelRange CeldaDato = wsReporte.Cells[NFilas, 14, NFilas, 14])
                    {
                        CeldaDato.Value = "OK";
                    }
                    NFilas += 1;
                }

                wsReporte.Row(1).Style.WrapText = true;
                wsReporte.Row(1).Height = 33.75;

                wsReporte.Column(1).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(2).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(3).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(4).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(5).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(6).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(7).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(8).Width = GetTrueColumnWidth(10.57);
                wsReporte.Column(9).Width = GetTrueColumnWidth(42.43);
                wsReporte.Column(10).Width = GetTrueColumnWidth(8.00);
                wsReporte.Column(11).Width = GetTrueColumnWidth(6.14);
                wsReporte.Column(12).Width = GetTrueColumnWidth(11.14);
                wsReporte.Column(13).Width = GetTrueColumnWidth(12.57);
                wsReporte.Column(14).Width = GetTrueColumnWidth(41.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarMasivoTipoNominaOutFileTXTResumen(DataView dvResumen, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura)
        {
            // Creación de Archivos de Resumen.

            // ========================================================================================================================== \\
            // Generamos el Resumen - [Quincena]_Resumen IMSS [TipoNomina].xlsx
            int totalRegistros = 0;
            double totalImporte = 0;
            string strQuincena = Quincena;

            //if (Abreviatura == "JJ")
            //    strQuincena = Quincena.Substring(0, 4) + (int.Parse(Quincena.Substring(4, 2)) / 2).ToString("00");

            string newFilePath = RutaEntregable + "\\" + strQuincena + "_Resumen IMSS " + TipoNomina + ".xlsx";

            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            FileInfo newFile = new FileInfo(newFilePath);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                excel.Workbook.Worksheets.Add("Resumen" + Abreviatura.ToUpper());
                var worksheet = excel.Workbook.Worksheets["Resumen" + Abreviatura.ToUpper()];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z500"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B3:I3"])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "RESUMEN DEL ENLACE DE ENTRADA IMSS " + Quincena.Substring(4, 2) + "/" + Quincena.Substring(0, 4) + " " + TipoNomina;
                }
                using (ExcelRange Rng = worksheet.Cells["B4:I4"])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange CeldaDato = worksheet.Cells["B4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Prom.";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["C4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Ret";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["D4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "UP";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["E4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Concepto";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["F4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Qna";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["G4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Registros";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["H4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Importe";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["I4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Reprog.";
                }


                string promotoriaAnterior = "";
                bool blnMismaPromo = false;
                int registros = 0;
                double importe = 0;

                int NFilas = 5;
                foreach (DataRowView rowView in dvResumen)
                {
                    DataRow row = rowView.Row;

                    
                    if (promotoriaAnterior == row["UNIDAD DE PAGO"].ToString())
                    {
                        blnMismaPromo = true;
                        NFilas = NFilas - 1;
                    }
                    else
                    {
                        promotoriaAnterior = row["UNIDAD DE PAGO"].ToString();
                        blnMismaPromo = false;
                        registros = 0;     
                    }

                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                        if (NFilas == 5) 
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    
                        CeldaDato.Value = row["PROM."].ToString();
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        
                        CeldaDato.Value = int.Parse(row["RETENEDOR"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        
                        CeldaDato.Value = int.Parse(row["UNIDAD DE PAGO"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        
                        CeldaDato.Value = int.Parse(row["Concepto"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6, NFilas, 6])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        
                        //CeldaDato.Value = int.Parse(row["AÑO QUINCENA"].ToString());
                        CeldaDato.Value = int.Parse(Quincena);
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7, NFilas, 7])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;

                        if (blnMismaPromo)
                        {
                            registros += int.Parse(row["REGISTROS"].ToString());
                        }
                        else
                        {
                            registros = int.Parse(row["REGISTROS"].ToString());
                        }

                        totalRegistros += int.Parse(row["REGISTROS"].ToString());
                        CeldaDato.Value = registros;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8, NFilas, 8])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;

                        if (blnMismaPromo)
                        {
                            importe += double.Parse(row["IMPORTE"].ToString());
                        }
                        else
                        {
                            importe = double.Parse(row["IMPORTE"].ToString());
                        }

                        totalImporte += double.Parse(row["IMPORTE"].ToString());
                        CeldaDato.Value = importe;
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9, NFilas, 9])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        else
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Value = int.Parse(row["REPROG."].ToString());
                    }
                    NFilas += 1;
                }


                using (ExcelRange Rng = worksheet.Cells[NFilas, 2, NFilas, 6])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Total";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = totalRegistros;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8, NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "$ #,##0.00";
                    CeldaDato.Value = totalImporte;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9, NFilas, 9])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    //CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = 0;
                }

                worksheet.Column(1).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(2).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(3).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(4).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(5).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(6).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(7).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(8).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(9).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(10).Width = GetTrueColumnWidth(10.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarTipoNominaOutFileTXTResumen(DataTable dtResumen, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura)
        {
            // Creación de Archivos de Resumen.

            // ========================================================================================================================== \\
            // Generamos el Resumen - [Quincena]_Resumen IMSS [TipoNomina].xlsx
            int totalRegistros = 0;
            double totalImporte = 0;
            string strQuincena =  Quincena;

            if (Abreviatura == "JJ")
                strQuincena = Quincena.Substring(0, 4) + (int.Parse(Quincena.Substring(4, 2)) / 2).ToString("00");

            string newFilePath = RutaEntregable + "\\" + strQuincena + "_Resumen IMSS " + TipoNomina + ".xlsx";

            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            FileInfo newFile = new FileInfo(newFilePath);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                excel.Workbook.Worksheets.Add("Resumen" + Abreviatura.ToUpper());
                var worksheet = excel.Workbook.Worksheets["Resumen" + Abreviatura.ToUpper()];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z500"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B3:I3"])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "RESUMEN DEL ENLACE DE ENTRADA IMSS " + Quincena.Substring(4, 2) + "/" + Quincena.Substring(0, 4) + " " + TipoNomina;
                }
                using (ExcelRange Rng = worksheet.Cells["B4:I4"])
                {
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }

                using (ExcelRange CeldaDato = worksheet.Cells["B4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Prom.";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["C4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Ret";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["D4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "UP";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["E4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Concepto";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["F4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Qna";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["G4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Registros";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["H4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Importe";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["I4"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "Reprog.";
                }

                int NFilas = 5;
                foreach (DataRow row in dtResumen.Rows)
                {
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Value = row["PROM."].ToString();
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Value = int.Parse(row["RETENEDOR"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Value = int.Parse(row["UNIDAD DE PAGO"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                    {
                        CeldaDato.Value = int.Parse(row["Concepto"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6, NFilas, 6])
                    {
                        CeldaDato.Value = int.Parse(row["AÑO QUINCENA"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7, NFilas, 7])
                    {
                        totalRegistros += int.Parse(row["REGISTROS"].ToString());
                        CeldaDato.Value = int.Parse(row["REGISTROS"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8, NFilas, 8])
                    {
                        totalImporte += double.Parse(row["IMPORTE"].ToString());
                        CeldaDato.Value = double.Parse(row["IMPORTE"].ToString());
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9, NFilas, 9])
                    {
                        CeldaDato.Value = int.Parse(row["REPROG."].ToString());
                    }
                    NFilas += 1;
                }

                using (ExcelRange Rng = worksheet.Cells[NFilas, 2, NFilas, 6])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Total";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-*  - ??_-;_-@_-";
                    CeldaDato.Value = totalRegistros;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8, NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "$ #,##0.00";
                    CeldaDato.Value = totalImporte;
                }


                worksheet.Column(1).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(2).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(3).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(4).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(5).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(6).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(7).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(8).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(9).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(10).Width = GetTrueColumnWidth(10.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarMasivoTipoNominaOutFileTXTCifras(DataView dvUnidadesPago, DataTable dtResumen, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura, ref double totalMovimientosAlta, ref double totalMovimientosBaja, ref double totalMovimientosModi, ref double totalImporteAlta, ref double totalImporteBaja, ref double totalImporteModi)
        {
            // Creación de Archivos de Cifras.

            // ========================================================================================================================== \\
            // Generamos el Resumen - [Quincena]_Resumen IMSS [TipoNomina].xlsx
            //double totalMovimientosAlta = 0;
            //double totalMovimientosBaja = 0;
            //double totalMovimientosModi = 0;
            //double totalImporteAlta = 0;
            //double totalImporteBaja = 0;
            //double totalImporteModi = 0;

            string strQuincena = Quincena;
            //if (Abreviatura == "JJ")
            //    strQuincena = Quincena.Substring(0, 4) + (int.Parse(Quincena.Substring(4, 2)) / 2).ToString("00");


            string newFilePath = RutaEntregable + "\\" + strQuincena + "_Cifras IMSS " + TipoNomina + ".xlsx";
            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            FileInfo newFile = new FileInfo(newFilePath);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                excel.Workbook.Worksheets.Add("Cifras" + Abreviatura.ToUpper());
                var worksheet = excel.Workbook.Worksheets["Cifras" + Abreviatura.ToUpper()];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z300"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B2:J2"])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "CIFRAS CONTROL DE MOVIMIENTOS POR DELEGACION - METLIFE " + TipoNomina.ToUpper() + ": " + Quincena.Substring(0, 4) + "-" + Quincena.Substring(4, 2);
                }
                using (ExcelRange Rng = worksheet.Cells["B3:J3"])
                {
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.WrapText = true;
                }

                using (ExcelRange CeldaDato = worksheet.Cells["B3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "PROM.";
                    CeldaDato.Style.WrapText = true;
                }
                using (ExcelRange CeldaDato = worksheet.Cells["C3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "RETENEDOR";
                    CeldaDato.Style.WrapText = true;
                }
                using (ExcelRange CeldaDato = worksheet.Cells["D3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "UNIDAD DE PAGO";
                    CeldaDato.Style.WrapText = true;
                }
                using (ExcelRange CeldaDato = worksheet.Cells["E3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "CONCEPTO";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["F3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "TIPO MOV.";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["G3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "REGISTROS";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["H3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "IMPORTE";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["I3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "AÑO QUINCENA";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["J3"])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "REPROG.";
                }

                int NFilas = 4;
                dvUnidadesPago.Sort = "UnidadPago_Extraccion";
                foreach (DataRowView rowViewUP in dvUnidadesPago)
                {
                    DataRow rUP = rowViewUP.Row;
                    double _TotalRegistroUP = 0;
                    double _TotalImporteUP = 0.00;
                    double _Importe = 0.00;
                    double _Registros = 0;
                    string strUnidadPago = rUP["UnidadPago_Extraccion"].ToString();


                    DataView dvDatosAlta = new DataView(dtResumen, "[UNIDAD DE PAGO] = '" + strUnidadPago + "' AND [TIPO MOV.] = 'A'", "[UNIDAD DE PAGO], [TIPO MOV.]", DataViewRowState.CurrentRows);
                    DataView dvDatosBaja = new DataView(dtResumen, "[UNIDAD DE PAGO] = '" + strUnidadPago + "' AND ([TIPO MOV.] = 'V' OR [TIPO MOV.] = 'B')", "[UNIDAD DE PAGO], [TIPO MOV.]", DataViewRowState.CurrentRows);
                    DataView dvDatosModi = new DataView(dtResumen, "[UNIDAD DE PAGO] = '" + strUnidadPago + "' AND [TIPO MOV.] = 'M'", "[UNIDAD DE PAGO], [TIPO MOV.]", DataViewRowState.CurrentRows);

                    if (dvDatosAlta.Count > 0 || dvDatosBaja.Count > 0 || dvDatosModi.Count > 0)
                    {
                        // Altas
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                        {
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Value = rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                        {
                            CeldaDato.Value = 257;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                        {
                            CeldaDato.Value = int.Parse(rUP["UnidadPago_Extraccion"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                        {
                            CeldaDato.Value = int.Parse(rUP["Clave"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6, NFilas, 6])
                        {
                            CeldaDato.Value = "A";
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7, NFilas, 7])
                        {
                            if (dvDatosAlta.Count > 0)
                            {
                                _Registros = 0;

                                foreach (DataRowView rowView in dvDatosAlta)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalMovimientosAlta += double.Parse(rowEnlace["Registros"].ToString()); 
                                    _TotalRegistroUP += double.Parse(rowEnlace["Registros"].ToString());
                                    _Registros += double.Parse(rowEnlace["Registros"].ToString());
                                }
                            }
                            else
                            {
                                _TotalRegistroUP += 0;
                                _Registros = 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalRegistroUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8, NFilas, 8])
                        {
                            if (dvDatosAlta.Count > 0)
                            {
                                _Importe = 0;

                                foreach (DataRowView rowView in dvDatosAlta)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalImporteAlta += double.Parse(rowEnlace["Importe"].ToString());
                                    _TotalImporteUP += double.Parse(rowEnlace["Importe"].ToString());
                                    _Importe += double.Parse(rowEnlace["Importe"].ToString());
                                }
                            }
                            else
                            {
                                _TotalImporteUP += 0;
                                _Importe = 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _Importe;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9, NFilas, 9])
                        {
                            CeldaDato.Style.Numberformat.Format = "0";
                            CeldaDato.Value = int.Parse(Quincena);
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 10, NFilas, 10])
                        {
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = 0;
                        }

                        // Bajas
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 2, NFilas + 1, 2])
                        {
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Value = rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 3, NFilas + 1, 3])
                        {
                            CeldaDato.Value = 257;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 4, NFilas + 1, 4])
                        {
                            CeldaDato.Value = int.Parse(rUP["UnidadPago_Extraccion"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 5, NFilas + 1, 5])
                        {
                            CeldaDato.Value = int.Parse(rUP["Clave"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 6, NFilas + 1, 6])
                        {
                            CeldaDato.Value = "B";
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 7, NFilas + 1, 7])
                        {
                            if (dvDatosBaja.Count > 0)
                            {
                                _Registros = 0;

                                foreach (DataRowView rowView in dvDatosBaja)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalMovimientosBaja += double.Parse(rowEnlace["Registros"].ToString());
                                    _TotalRegistroUP += double.Parse(rowEnlace["Registros"].ToString());
                                    _Registros += double.Parse(rowEnlace["Registros"].ToString());
                                }
                            }
                            else
                            {
                                _TotalRegistroUP += 0;
                                _Registros = 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _Registros;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 8, NFilas + 1, 8])
                        {
                            if (dvDatosBaja.Count > 0)
                            {
                                _Importe = 0;   //20200409RMF

                                foreach (DataRowView rowView in dvDatosBaja)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalImporteBaja += double.Parse(rowEnlace["Importe"].ToString());
                                    _TotalImporteUP += double.Parse(rowEnlace["Importe"].ToString());
                                    _Importe += double.Parse(rowEnlace["Importe"].ToString());                   //20200409RMF se agrego el +=
                                }
                            }
                            else
                            {
                                _TotalImporteUP += 0;
                                _Importe = 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _Importe;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 9, NFilas + 1, 9])
                        {
                            CeldaDato.Value = int.Parse(Quincena);
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 10, NFilas + 1, 10])
                        {
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = 0;
                        }

                        // Modificaciones
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 2, NFilas + 2, 2])
                        {
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Value = rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 3, NFilas + 2, 3])
                        {
                            CeldaDato.Value = 257;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 4, NFilas + 2, 4])
                        {
                            CeldaDato.Value = int.Parse(rUP["UnidadPago_Extraccion"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 5, NFilas + 2, 5])
                        {
                            CeldaDato.Value = int.Parse(rUP["Clave"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 6, NFilas + 2, 6])
                        {
                            CeldaDato.Value = "M";
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 7, NFilas + 2, 7])
                        {
                            if (dvDatosModi.Count > 0)
                            {
                                _Registros = 0; //20200409RMF

                                foreach (DataRowView rowView in dvDatosModi)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalMovimientosModi += double.Parse(rowEnlace["Registros"].ToString());
                                    _TotalRegistroUP += double.Parse(rowEnlace["Registros"].ToString());
                                    _Registros += double.Parse(rowEnlace["Registros"].ToString());           //20200409RMF se agrego el +=
                                }
                            }
                            else
                            {
                                _TotalRegistroUP += 0;
                                _Registros = 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _Registros;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 8, NFilas + 2, 8])
                        {
                            if (dvDatosModi.Count > 0)
                            {
                                _Importe = 0;       //20200409RMF

                                foreach (DataRowView rowView in dvDatosModi)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalImporteModi += double.Parse(rowEnlace["Importe"].ToString());
                                    _TotalImporteUP += double.Parse(rowEnlace["Importe"].ToString());
                                    _Importe += double.Parse(rowEnlace["Importe"].ToString());           //20200409RMF se agrego el +=
                                }
                            }
                            else
                            {
                                _TotalImporteUP += 0;
                                _Importe = 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _Importe;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 9, NFilas + 2, 9])
                        {
                            CeldaDato.Value = int.Parse(Quincena);
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 10, NFilas + 2, 10])
                        {
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = 0;
                        }

                        // Totales.
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 2, NFilas + 3, 2])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Value = "Total" + rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 3, NFilas + 3, 3])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 4, NFilas + 3, 4])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 5, NFilas + 3, 5])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 6, NFilas + 3, 6])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 7, NFilas + 3, 7])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalRegistroUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 8, NFilas + 3, 8])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalImporteUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 9, NFilas + 3, 9])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 10, NFilas + 3, 10])
                        {
                            CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                        }
                        NFilas += 4;
                    }
                }

                using (ExcelRange Rng = worksheet.Cells[NFilas, 6, NFilas, 6])
                {
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                using (ExcelRange Rng = worksheet.Cells[NFilas, 7, NFilas, 7])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Movimientos";
                }
                using (ExcelRange Rng = worksheet.Cells[NFilas, 8, NFilas, 8])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Importe";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "A";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosAlta;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteAlta;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "B";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosBaja;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteBaja;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "M";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosModi;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteModi;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "Total";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosAlta + totalMovimientosBaja + totalMovimientosModi;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteAlta + totalImporteBaja + totalImporteModi;
                }

                // ======================================================================= \\
                NFilas += 4;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                }
                using (ExcelRange Rng = worksheet.Cells[NFilas, 7, NFilas, 7])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Reprogramacion";
                }
                using (ExcelRange Rng = worksheet.Cells[NFilas, 8, NFilas, 8])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "%";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "A";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "B";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "M";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "Total";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                //worksheet.Cells.AutoFitColumns(0);
                worksheet.Column(1).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(2).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(3).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(4).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(5).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(6).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(7).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(8).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(9).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(10).Width = GetTrueColumnWidth(10.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarTipoNominaOutFileTXTCifras(DataTable dtUnidadesPago, DataTable dtResumen, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura, ref double totalMovimientosAlta, ref double totalMovimientosBaja, ref double totalMovimientosModi, ref double totalImporteAlta, ref double totalImporteBaja, ref double totalImporteModi)
        {
            // Creación de Archivos de Cifras.

            // ========================================================================================================================== \\
            // Generamos el Resumen - [Quincena]_Resumen IMSS [TipoNomina].xlsx
            //double totalMovimientosAlta = 0;
            //double totalMovimientosBaja = 0;
            //double totalMovimientosModi = 0;
            //double totalImporteAlta = 0;
            //double totalImporteBaja = 0;
            //double totalImporteModi = 0;

            string strQuincena = Quincena;
            if (Abreviatura == "JJ")
                strQuincena = Quincena.Substring(0, 4) + (int.Parse(Quincena.Substring(4, 2)) / 2).ToString("00");


            string newFilePath = RutaEntregable + "\\" + strQuincena + "_Cifras IMSS " + TipoNomina + ".xlsx";
            if (File.Exists(newFilePath))
            {
                File.Delete(newFilePath);
            }
            FileInfo newFile = new FileInfo(newFilePath);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                excel.Workbook.Worksheets.Add("Cifras" + Abreviatura.ToUpper());
                var worksheet = excel.Workbook.Worksheets["Cifras" + Abreviatura.ToUpper()];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z300"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["B2:J2"])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "CIFRAS CONTROL DE MOVIMIENTOS POR DELEGACION - METLIFE " + TipoNomina.ToUpper() + ": " + Quincena.Substring(0, 4) + "-" + Quincena.Substring(4, 2);
                }
                using (ExcelRange Rng = worksheet.Cells["B3:J3"])
                {
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Style.WrapText = true;
                }

                using (ExcelRange CeldaDato = worksheet.Cells["B3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "PROM.";
                    CeldaDato.Style.WrapText = true;
                }
                using (ExcelRange CeldaDato = worksheet.Cells["C3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "RETENEDOR";
                    CeldaDato.Style.WrapText = true;
                }
                using (ExcelRange CeldaDato = worksheet.Cells["D3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "UNIDAD DE PAGO";
                    CeldaDato.Style.WrapText = true;
                }
                using (ExcelRange CeldaDato = worksheet.Cells["E3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "CONCEPTO";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["F3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "TIPO MOV.";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["G3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "REGISTROS";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["H3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "IMPORTE";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["I3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "AÑO QUINCENA";
                }
                using (ExcelRange CeldaDato = worksheet.Cells["J3"])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Value = "REPROG.";
                }

                int NFilas = 4;
                foreach (DataRow rUP in dtUnidadesPago.Rows)
                {
                    double _TotalRegistroUP = 0;
                    double _TotalImporteUP = 0.00;

                    DataView dvDatosAlta = new DataView(dtResumen, "[UNIDAD DE PAGO] = " + rUP["UnidadPago_Extraccion"].ToString() + " AND [TIPO MOV.] = 'A'", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
                    DataView dvDatosBaja = new DataView(dtResumen, "[UNIDAD DE PAGO] = " + rUP["UnidadPago_Extraccion"].ToString() + " AND [TIPO MOV.] = 'B'", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);
                    DataView dvDatosModi = new DataView(dtResumen, "[UNIDAD DE PAGO] = " + rUP["UnidadPago_Extraccion"].ToString() + " AND [TIPO MOV.] = 'M'", "[UNIDAD DE PAGO]", DataViewRowState.CurrentRows);

                    if (dvDatosAlta.Count > 0 || dvDatosBaja.Count > 0 || dvDatosModi.Count > 0)
                    {
                        // Altas
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                        {
                            CeldaDato.Value = rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                        {
                            CeldaDato.Value = 257;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                        {
                            CeldaDato.Value = int.Parse(rUP["UnidadPago_Extraccion"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 5, NFilas, 5])
                        {
                            CeldaDato.Value = int.Parse(rUP["Clave"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6, NFilas, 6])
                        {
                            CeldaDato.Value = "A";
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7, NFilas, 7])
                        {
                            if (dvDatosAlta.Count > 0)
                            {
                                foreach (DataRowView rowView in dvDatosAlta)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    _TotalRegistroUP += double.Parse(rowEnlace["Registros"].ToString());
                                }
                            }
                            else
                            {
                                _TotalRegistroUP += 0;
                            }

                            totalMovimientosAlta += _TotalRegistroUP;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalRegistroUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8, NFilas, 8])
                        {
                            if (dvDatosAlta.Count > 0)
                            {
                                foreach (DataRowView rowView in dvDatosAlta)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalImporteAlta += double.Parse(rowEnlace["Importe"].ToString());
                                    _TotalRegistroUP += double.Parse(rowEnlace["Importe"].ToString());
                                }
                            }
                            else
                            {
                                _TotalImporteUP += 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalImporteUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 9, NFilas, 9])
                        {
                            CeldaDato.Style.Numberformat.Format = "0";
                            CeldaDato.Value = int.Parse(Quincena);
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 10, NFilas, 10])
                        {
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = 0;
                        }

                        // Bajas
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 2, NFilas + 1, 2])
                        {
                            CeldaDato.Value = rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 3, NFilas + 1, 3])
                        {
                            CeldaDato.Value = 257;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 4, NFilas + 1, 4])
                        {
                            CeldaDato.Value = int.Parse(rUP["UnidadPago_Extraccion"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 5, NFilas + 1, 5])
                        {
                            CeldaDato.Value = int.Parse(rUP["Clave"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 6, NFilas + 1, 6])
                        {
                            CeldaDato.Value = "B";
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 7, NFilas + 1, 7])
                        {
                            if (dvDatosBaja.Count > 0)
                            {
                                foreach (DataRowView rowView in dvDatosBaja)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    _TotalRegistroUP += double.Parse(rowEnlace["Registros"].ToString());
                                }
                            }
                            else
                            {
                                _TotalRegistroUP += 0;
                            }

                            totalMovimientosBaja += _TotalRegistroUP;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalRegistroUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 8, NFilas + 1, 8])
                        {
                            if (dvDatosBaja.Count > 0)
                            {
                                foreach (DataRowView rowView in dvDatosBaja)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalImporteBaja += double.Parse(rowEnlace["Importe"].ToString());
                                    _TotalRegistroUP += double.Parse(rowEnlace["Importe"].ToString());
                                }
                            }
                            else
                            {
                                _TotalImporteUP += 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalImporteUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 9, NFilas + 1, 9])
                        {
                            CeldaDato.Value = int.Parse(Quincena);
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 1, 10, NFilas + 1, 10])
                        {
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = 0;
                        }

                        // Modificaciones
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 2, NFilas + 2, 2])
                        {
                            CeldaDato.Value = rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 3, NFilas + 2, 3])
                        {
                            CeldaDato.Value = 257;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 4, NFilas + 2, 4])
                        {
                            CeldaDato.Value = int.Parse(rUP["UnidadPago_Extraccion"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 5, NFilas + 2, 5])
                        {
                            CeldaDato.Value = int.Parse(rUP["Clave"].ToString());
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 6, NFilas + 2, 6])
                        {
                            CeldaDato.Value = "M";
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 7, NFilas + 2, 7])
                        {
                            if (dvDatosModi.Count > 0)
                            {
                                foreach (DataRowView rowView in dvDatosModi)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    _TotalRegistroUP += double.Parse(rowEnlace["Registros"].ToString());
                                }
                            }
                            else
                            {
                                _TotalRegistroUP += 0;
                            }

                            totalMovimientosModi += _TotalRegistroUP;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalRegistroUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 8, NFilas + 2, 8])
                        {
                            if (dvDatosModi.Count > 0)
                            {
                                foreach (DataRowView rowView in dvDatosModi)
                                {
                                    DataRow rowEnlace = rowView.Row;
                                    totalImporteModi += double.Parse(rowEnlace["Importe"].ToString());
                                    _TotalImporteUP += double.Parse(rowEnlace["Importe"].ToString());
                                }
                            }
                            else
                            {
                                _TotalImporteUP += 0;
                            }

                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalImporteUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 9, NFilas + 2, 9])
                        {
                            CeldaDato.Value = int.Parse(Quincena);
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 2, 10, NFilas + 2, 10])
                        {
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = 0;
                        }


                        // Totales.
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 2, NFilas + 3, 2])
                        {
                            CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Value = "Total" + rUP["PromoResonponsable"].ToString();
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 7, NFilas + 3, 7])
                        {
                            CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalRegistroUP;
                        }
                        using (ExcelRange CeldaDato = worksheet.Cells[NFilas + 3, 8, NFilas + 3, 8])
                        {
                            CeldaDato.Style.Font.Bold = true;
                            CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                            CeldaDato.Value = _TotalImporteUP;
                        }

                        NFilas += 4;
                    }
                }

                using (ExcelRange Rng = worksheet.Cells[NFilas, 7, NFilas, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Movimientos";
                }
                using (ExcelRange Rng = worksheet.Cells[NFilas, 8, NFilas, 8])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Importe";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "A";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosAlta;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteAlta;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "B";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosBaja;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteBaja;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "M";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosModi;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteModi;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "Total";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0_-;-* #,##0_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalMovimientosAlta + totalMovimientosBaja + totalMovimientosModi;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* -??_-;_-@_-";
                    CeldaDato.Value = totalImporteAlta + totalImporteBaja + totalImporteModi;
                }

                // ======================================================================= \\
                NFilas += 4;
                using (ExcelRange Rng = worksheet.Cells[NFilas, 7, NFilas, 7])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Reprogramacion";
                }
                using (ExcelRange Rng = worksheet.Cells[NFilas, 8, NFilas, 8])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "%";
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "A";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "B";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "M";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                NFilas += 1;
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 6])
                {
                    CeldaDato.Style.Font.Bold = false;
                    CeldaDato.Value = "Total";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 7])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "0";
                    CeldaDato.Value = 0;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 8])
                {
                    CeldaDato.Style.Font.Bold = true;
                    CeldaDato.Style.Numberformat.Format = "#0\\%";
                    CeldaDato.Value = 0;
                }

                //worksheet.Cells.AutoFitColumns(0);
                worksheet.Column(1).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(2).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(3).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(4).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(5).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(6).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(7).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(8).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(9).Width = GetTrueColumnWidth(10.29);
                worksheet.Column(10).Width = GetTrueColumnWidth(10.29);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarMasivoTipoNominaResumenXLS(DataView dvResumenAcuses, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura, ref double totalMovimientosAlta, ref double totalMovimientosBaja, ref double totalMovimientosModi, ref double totalImporteAlta, ref double totalImporteBaja, ref double totalImporteModi)
        {
            // Declaración de Variables
            string strRuta = RutaEntregable;

            // Creamos los Archivos XLS.    // Acuses de entrega de imágenes.xlsx
            GenerarReporteXLS_AcusesEntregaImagenesMasivo(dvResumenAcuses, strRuta, TipoNomina, Quincena);
            //GenerarCartaEntrega_Acuse(strRuta, TipoNomina, Quincena, totalMovimientosAlta, totalMovimientosBaja, totalMovimientosModi, totalImporteAlta, totalImporteBaja, totalImporteModi);
            GenerarCartaEntrega_AcuseV2(strRuta, TipoNomina, Quincena, totalMovimientosAlta, totalMovimientosBaja, totalMovimientosModi, totalImporteAlta, totalImporteBaja, totalImporteModi);
        }

        private void EnlaceGenerarTipoNominaResumenXLS(DataSet dsEnlace, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura, ref double totalMovimientosAlta, ref double totalMovimientosBaja, ref double totalMovimientosModi, ref double totalImporteAlta, ref double totalImporteBaja, ref double totalImporteModi)
        {
            // Declaración de Variables
            string strRuta = RutaEntregable;

            // Creamos los Archivos XLS.    // Acuses de entrega de imágenes.xlsx
            GenerarReporteXLS_AcusesEntregaImagenes(dsEnlace.Tables[5], strRuta, TipoNomina, Quincena);
            //GenerarCartaEntrega_Acuse(strRuta, TipoNomina, Quincena, totalMovimientosAlta, totalMovimientosBaja, totalMovimientosModi, totalImporteAlta, totalImporteBaja, totalImporteModi);
            GenerarCartaEntrega_AcuseV2(strRuta, TipoNomina, Quincena, totalMovimientosAlta, totalMovimientosBaja, totalMovimientosModi, totalImporteAlta, totalImporteBaja, totalImporteModi);
        }

        private static DocumentFormat.OpenXml.Wordprocessing.Drawing DrawingManager(string relationshipId, string name, DocumentFormat.OpenXml.Int64Value cxVal, DocumentFormat.OpenXml.Int64Value cyVal, string impPosition)
        {
            string haPosition = impPosition;
            if (string.IsNullOrEmpty(haPosition))
            {
                haPosition = "left";
            }
            // Define the reference of the image.
            DW.Anchor anchor = new DW.Anchor();
            anchor.Append(new DW.SimplePosition() { X = 0L, Y = 0L });
            anchor.Append(
                new DW.HorizontalPosition(
                    new DW.HorizontalAlignment(haPosition)
                )
                {
                    RelativeFrom =
                      DW.HorizontalRelativePositionValues.Margin
                }
            );
            anchor.Append(
                new DW.VerticalPosition(
                    new DW.PositionOffset("0")
                )
                {
                    RelativeFrom =
                    DW.VerticalRelativePositionValues.Paragraph
                }
            );
            anchor.Append(
                new DW.Extent()
                {
                    Cx = cxVal,
                    Cy = cyVal
                }
            );
            anchor.Append(
                new DW.EffectExtent()
                {
                    LeftEdge = 0L,
                    TopEdge = 0L,
                    RightEdge = 0L,
                    BottomEdge = 0L
                }
            );
            if (!string.IsNullOrEmpty(impPosition))
            {
                anchor.Append(new DW.WrapSquare() { WrapText = DW.WrapTextValues.BothSides });
            }
            else
            {
                anchor.Append(new DW.WrapTopBottom());
            }
            anchor.Append(
                new DW.DocProperties()
                {
                    Id = (DocumentFormat.OpenXml.UInt32Value)1U,
                    Name = name
                }
            );
            anchor.Append(
                new DW.NonVisualGraphicFrameDrawingProperties(
                      new A.GraphicFrameLocks() { NoChangeAspect = true })
            );
            anchor.Append(
                new A.Graphic(
                      new A.GraphicData(
                        new PIC.Picture(

                          new PIC.NonVisualPictureProperties(
                            new PIC.NonVisualDrawingProperties()
                            {
                                Id = (DocumentFormat.OpenXml.UInt32Value)0U,
                                Name = name + ".jpg"
                            },
                            new PIC.NonVisualPictureDrawingProperties()),

                            new PIC.BlipFill(
                                new A.Blip(
                                    new A.BlipExtensionList(
                                        new A.BlipExtension()
                                        {
                                            Uri =
                                            "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                        })
                                )
                                {
                                    Embed = relationshipId,
                                    CompressionState =
                                    A.BlipCompressionValues.Print
                                },
                                new A.Stretch(
                                    new A.FillRectangle())),

                          new PIC.ShapeProperties(

                            new A.Transform2D(
                              new A.Offset() { X = 0L, Y = 0L },

                              new A.Extents()
                              {
                                  Cx = cxVal,
                                  Cy = cyVal
                              }),

                            new A.PresetGeometry(
                              new A.AdjustValueList()
                            )
                            { Preset = A.ShapeTypeValues.Rectangle }
                          )
                        )
                  )
                      { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
            );

            anchor.DistanceFromTop = (DocumentFormat.OpenXml.UInt32Value)0U;
            anchor.DistanceFromBottom = (DocumentFormat.OpenXml.UInt32Value)0U;
            anchor.DistanceFromLeft = (DocumentFormat.OpenXml.UInt32Value)114300U;
            anchor.DistanceFromRight = (DocumentFormat.OpenXml.UInt32Value)114300U;
            anchor.SimplePos = false;
            anchor.RelativeHeight = (DocumentFormat.OpenXml.UInt32Value)251658240U;
            anchor.BehindDoc = true;
            anchor.Locked = false;
            anchor.LayoutInCell = true;
            anchor.AllowOverlap = true;

            DocumentFormat.OpenXml.Wordprocessing.Drawing element = new DocumentFormat.OpenXml.Wordprocessing.Drawing();
            element.Append(anchor);

            return element;
        }

        private void GenerarCartaEntrega_AcuseV2(string rutaArchivo, string TipoNomina, string Quincena, double TotalAltas, double TotalBajas, double TotalModificaciones, double TotalAltasMonto, double TotalBajasMonto, double TotalModificacionesMonto)
        {
            using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument doc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Create(rutaArchivo + "\\Carta_Intercambio_Informacion_IMSS_.docx", DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                Editor editor = new Editor();
                //string strTitulos = "Century Gothic";
                string strTitulos = "Calibri";
                string strTextos = "Calibri";
                string tamTitulos = "24";
                string tamTextos = "22";
                string tamTextoVacio = "10";


                // Agregar la parte del documento principal.
                DocumentFormat.OpenXml.Packaging.MainDocumentPart mainPart = doc.AddMainDocumentPart();

                // Crear la estructura del documento y agregar los parrafos y los textos.
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                DocumentFormat.OpenXml.Wordprocessing.SectionProperties sc = new DocumentFormat.OpenXml.Wordprocessing.SectionProperties();
                DocumentFormat.OpenXml.Wordprocessing.PageSize ps = new DocumentFormat.OpenXml.Wordprocessing.PageSize();
                ps.Width = 12000;
                ps.Height = 16000;
                sc.Append(ps);
                body.Append(sc);

                //// Imagen
                //DocumentFormat.OpenXml.Wordprocessing.Paragraph pImg = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                //DocumentFormat.OpenXml.Packaging.ImagePart imagePart = mainPart.AddImagePart(DocumentFormat.OpenXml.Packaging.ImagePartType.Jpeg);
                //string imgPath = "https://cloud-asae.com.mx/WFO/Imagenes/logo_grap.jpg";
                //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(imgPath);
                //req.UseDefaultCredentials = true;
                //req.PreAuthenticate = true;
                //req.Credentials = CredentialCache.DefaultCredentials;
                //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                //imagePart.FeedData(resp.GetResponseStream());
                //// 1500000 y 400000 son el ancho y alto de la imagen
                //DocumentFormat.OpenXml.Wordprocessing.Run rImg = new DocumentFormat.OpenXml.Wordprocessing.Run(DrawingManager(mainPart.GetIdOfPart(imagePart), "PictureName", 1500000, 400000, string.Empty));
                //pImg.Append(rImg);
                //body.Append(pImg);

                // Título
                body.Append(editor.Parrafo("Carta de Entrega de Intercambio de", tamTitulos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, true, strTitulos));
                body.Append(editor.Parrafo("información de movimientos para incorporar al proceso de nómina.", tamTitulos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, true, strTitulos));
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTitulos));

                string strTrabajadores = "";
                switch (TipoNomina.ToUpper().Trim())
                {
                    case "ACTIVOS":
                    case "JUBILADOS":
                        strTrabajadores = " Trabajadores " + TipoNomina;
                        break;

                    case "MANDO":
                        strTrabajadores = "Mando";
                        break;

                    case "ESTATUTO A":
                        strTrabajadores = "Activos Contratación " + (char)34 + "0" + (char)34 + " (Estatuto " + (char)34 + "A" + (char)34 + ")";
                        break;

                    default:
                        strTrabajadores = "NA";
                        break;
                }

                // Información Principal de la Cartal
                body.Append(editor.ParrafoConcatenado("Nómina a procesar: ", strTrabajadores, tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, true, false, false));
                body.Append(editor.ParrafoConcatenado("Quincena a procesar: ", Quincena.Substring(0,4) + "-" + Quincena.Substring(4,2), tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, true, false, false));
                body.Append(editor.ParrafoConcatenado("Clave de dependencia: ", "257", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, true, false, false));
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));

                // Título Tabla de Resumen
                body.Append(editor.Parrafo("CIFRAS CONTROL ENDOSO", tamTitulos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, true, strTitulos));
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));

                // Tabla de Resumen
                DocumentFormat.OpenXml.Wordprocessing.TableCell[] celda1 = {
                    editor.Celda("Tipo de Movimiento", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left,true,"548DD4",tamTextos), 
                    editor.Celda("Registros", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, true, "548DD4", tamTextos), 
                    editor.Celda("Monto", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, true, "548DD4", tamTextos) 
                };
                DocumentFormat.OpenXml.Wordprocessing.TableCell[] celda2 = { 
                    editor.Celda("Altas", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, "FFFFFF", tamTextos), 
                    editor.Celda(TotalAltas.ToString(), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, false, "FFFFFF", tamTextos), 
                    editor.Celda("$" + TotalAltasMonto.ToString("#,##0.00"), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right, false, "FFFFFF", tamTextos) 
                };
                DocumentFormat.OpenXml.Wordprocessing.TableCell[] celda3 = { 
                    editor.Celda("Bajas", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, "FFFFFF", tamTextos), 
                    editor.Celda(TotalBajas.ToString(), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, false, "FFFFFF", tamTextos), 
                    editor.Celda("$" + TotalBajasMonto.ToString("#,##0.00"), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right, false, "FFFFFF", tamTextos) 
                };
                DocumentFormat.OpenXml.Wordprocessing.TableCell[] celda4 = { 
                    editor.Celda("Modificaciones", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, "FFFFFF", tamTextos), 
                    editor.Celda(TotalModificaciones.ToString(), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, false, "FFFFFF", tamTextos), 
                    editor.Celda("$" + TotalModificacionesMonto.ToString("#,##0.00"), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right, false, "FFFFFF", tamTextos) 
                };
                DocumentFormat.OpenXml.Wordprocessing.TableCell[] celda5 = { 
                    editor.Celda("TOTAL", DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, true, "FFFFFF", tamTextos), 
                    editor.Celda((TotalAltas + TotalBajas + TotalModificaciones).ToString(), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, false, "FFFFFF", tamTextos), 
                    editor.Celda("$" + (TotalAltasMonto + TotalBajasMonto + TotalModificacionesMonto).ToString("#,##0.00"), DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Right, false, "FFFFFF", tamTextos) 
                };
                body.Append(editor.Tabla(editor.FilaTabla(celda1)));
                body.Append(editor.Tabla(editor.FilaTabla(celda2)));
                body.Append(editor.Tabla(editor.FilaTabla(celda3)));
                body.Append(editor.Tabla(editor.FilaTabla(celda4)));
                body.Append(editor.Tabla(editor.FilaTabla(celda5)));

                // Condiciones
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
                body.Append(editor.ParrafoConcatenado("Se adjunta información de ", (TotalAltas + TotalModificaciones).ToString(), " cartas instrucción digitalizadas, que se han agregado a SACI para su actualización.", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, true, false, false));
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));

                body.Append(editor.Parrafo("Sello y Fecha de Recibido de Retenedor", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center, false, strTextos));
                body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));

                body.Append(editor.Parrafo("Observaciones", tamTitulos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, true, strTitulos));
                body.Append(editor.Parrafo("* Se anexan documentos que detallan la información.", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
                body.Append(editor.Parrafo("* En caso de que la información se reciba fuera del cierre del calendario, favor de aplicar en el proceso inmediato de nómina, no aplicar dobles descuentos.", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
                body.Append(editor.Parrafo("* Al ser incorporados en nómina, se solicita la entrega de un informe detallado de los movimientos rechazados.", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
                body.Append(editor.Parrafo("* De presentarse algún problema de lectura del archivo, se solicita sea reportado de manera inmediata a los teléfonos (55) 5328.9000 Ext. 7662 con Jesús Alberto Santos Guzmán o al (55) 5328.9000 Ext. 6360 con Guillermo Joachin", tamTextos, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
                //body.Append(editor.Parrafo("", tamTextoVacio, DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left, false, strTextos));
            }
        }

        private void GenerarCartaEntrega_Acuse(string rutaArchivo, string TipoNomina, string Quincena, double TotalAltas, double TotalBajas, double TotalModificaciones, double TotalAltasMonto, double TotalBajasMonto, double TotalModificacionesMonto)
        {
            double TotalMovimientos = 0;
            double TotalMovimientosMonto = 0.00;
            // RMF

            using (DocumentFormat.OpenXml.Packaging.WordprocessingDocument doc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Create(rutaArchivo + "\\Carta_Intercambio_Informacion_IMSS_.docx", DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Agregar la parte del documento principal.
                DocumentFormat.OpenXml.Packaging.MainDocumentPart mainPart = doc.AddMainDocumentPart();

                // Crear la estructura del documento y agregar los parrafos y los textos.
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                DocumentFormat.OpenXml.Wordprocessing.SectionProperties sc = new DocumentFormat.OpenXml.Wordprocessing.SectionProperties();
                DocumentFormat.OpenXml.Wordprocessing.PageSize ps = new DocumentFormat.OpenXml.Wordprocessing.PageSize();
                ps.Width = 11000;
                ps.Height = 15000;
                sc.Append(ps);
                body.Append(sc);

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                para.Append(pp);

                DocumentFormat.OpenXml.Wordprocessing.Run run = para.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                
                runpro.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run.Append(runpro);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties rpTipoLetra01 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = "Agency FB" });
                run.Append(rpTipoLetra01);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro7a = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro7a.FontSize = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "25" };
                run.Append(runpro7a);
                run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Carta de Entrega de Intercambio de información de movimientos para incorporar al proceso de nómina."));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt1 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                //DocumentFormat.OpenXml.Wordprocessing.Paragraph para2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                //DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp2 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                //pp2.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                //para2.Append(pp2);
                //DocumentFormat.OpenXml.Wordprocessing.Run run2 = para2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                //DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro2 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                //runpro2.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                //run2.Append(runpro2);
                //DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro7b = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                //runpro7b.FontSize = new DocumentFormat.OpenXml.Wordprocessing.FontSize() { Val = "25" };
                //run2.Append(runpro7b);
                //run2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("información de movimientos para incorporar al proceso de nómina."));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                //DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt3 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                //DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt4 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para3 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp3 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp3.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para3.Append(pp3);
                
                DocumentFormat.OpenXml.Wordprocessing.Run run3 = para3.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run3.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Nómina a procesar: ") { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro3a = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro3a.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run3.Append(runpro3a);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties rpTipoLetra02 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = "Agency FB" });
                run3.Append(rpTipoLetra02);


                string strTrabajadores = "";
                switch (TipoNomina.ToUpper())
                {
                    case "ACTIVOS":
                    case "JUBILADOS":
                        strTrabajadores = " Trabajadores " + TipoNomina;
                        break;

                    case "MANDO":
                        strTrabajadores = "Mando";
                        break;

                    case "ESTATUTO A":
                        strTrabajadores = "Activos Contratación " + (char)34 + "0" + (char)34 + " (Estatuto " + (char)34 + "A" + (char)34 + ")";
                        break;
                }
                run3.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(strTrabajadores));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para4 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp4 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp4.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para4.Append(pp4);
                DocumentFormat.OpenXml.Wordprocessing.Run run4 = para4.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run4.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Quincena a procesar: ") { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro4a = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro4a.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run4.Append(runpro4a);
                run4.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(Quincena.Substring(0,4) + "-" + Quincena.Substring(4,2)));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para5 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp5 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp5.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para5.Append(pp5);
                DocumentFormat.OpenXml.Wordprocessing.Run run5 = para5.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run5.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Clave de dependencia: ") { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro5a = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro5a.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run5.Append(runpro5a);
                run5.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("257"));


                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt5 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para6 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp6 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp6.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                para6.Append(pp6);
                DocumentFormat.OpenXml.Wordprocessing.Run run6 = para6.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro6 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro6.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run6.Append(runpro6);
                run6.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("CIFRAS CONTROL ENDOSO"));

                #region Tabla
                DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();
                DocumentFormat.OpenXml.Wordprocessing.TableProperties tableprop = new DocumentFormat.OpenXml.Wordprocessing.TableProperties(
                    new DocumentFormat.OpenXml.Wordprocessing.TableBorders(new DocumentFormat.OpenXml.Wordprocessing.TopBorder()
                    { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Sawtooth), Size = 5 },
                        new DocumentFormat.OpenXml.Wordprocessing.BottomBorder()
                        { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Sawtooth), Size = 5 },
                        new DocumentFormat.OpenXml.Wordprocessing.LeftBorder()
                        { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Sawtooth), Size = 5 },
                        new DocumentFormat.OpenXml.Wordprocessing.RightBorder()
                        { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Sawtooth), Size = 5 },
                        new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder()
                        { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Sawtooth), Size = 5 },
                        new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder()
                        { Val = new DocumentFormat.OpenXml.EnumValue<DocumentFormat.OpenXml.Wordprocessing.BorderValues>(DocumentFormat.OpenXml.Wordprocessing.BorderValues.Sawtooth), Size = 5 })
                );


                table.AppendChild(tableprop);

                //Encabezados
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr1 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc11 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc11.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp11 = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties();
                tcp11.Append(new DocumentFormat.OpenXml.Wordprocessing.Shading() { Val = DocumentFormat.OpenXml.Wordprocessing.ShadingPatternValues.Clear, Color = "auto", Fill = "548DD4" });
                tc11.Append(tcp11);
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p11 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.Run r11 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp11 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp11.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r11.Append(rp11);
                r11.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("Tipo de Movimiento"));
                p11.Append(r11);

                tc11.Append(p11);
                tr1.Append(tc11);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc12 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc12.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp12 = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties();
                tcp12.Append(new DocumentFormat.OpenXml.Wordprocessing.Shading() { Val = DocumentFormat.OpenXml.Wordprocessing.ShadingPatternValues.Clear, Color = "auto", Fill = "548DD4" });
                tc12.Append(tcp12);
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p12 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp12 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp12.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                p12.Append(pp12);
                DocumentFormat.OpenXml.Wordprocessing.Run r12 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp12 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp12.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r12.Append(rp12);
                r12.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("Registros"));
                p12.Append(r12);
                tc12.Append(p12);
                tr1.Append(tc12);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc13 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc13.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tcp13 = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties();
                tcp13.Append(new DocumentFormat.OpenXml.Wordprocessing.Shading() { Val = DocumentFormat.OpenXml.Wordprocessing.ShadingPatternValues.Clear, Color = "auto", Fill = "548DD4" });
                tc13.Append(tcp13);
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p13 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp13 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp13.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                p13.Append(pp13);
                DocumentFormat.OpenXml.Wordprocessing.Run r13 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp13 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp13.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r13.Append(rp13);
                r13.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("Monto"));
                p13.Append(r13);
                tc13.Append(p13);
                tr1.Append(tc13);

                table.Append(tr1);

                //Fila 2
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr2 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc21 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc21.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p21 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Altas")));
                tc21.Append(p21);
                tr2.Append(tc21);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc22 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc22.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p22 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp22 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp22.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r22 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp22 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp22.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r22.Append(rp22);
                r22.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(TotalAltas.ToString()));
                p22.Append(r22);
                p22.Append(pp22);
                tc22.Append(p22);
                tr2.Append(tc22);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc23 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc23.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p23 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp23 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp23.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r23 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp23 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp23.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r23.Append(rp23);
                r23.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("$ " + TotalAltasMonto.ToString("#,##0.00")));
                p23.Append(r23);
                p23.Append(pp23);
                tc23.Append(p23);
                tr2.Append(tc23);

                table.Append(tr2);

                //Fila 3
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr3 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc31 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc31.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p31 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Bajas")));
                tc31.Append(p31);
                tr3.Append(tc31);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc32 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc32.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p32 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp32 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp32.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r32 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp32 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp32.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r32.Append(rp32);
                r32.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(TotalBajas.ToString()));
                p32.Append(r32);
                p32.Append(pp32);
                tc32.Append(p32);
                tr3.Append(tc32);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc33 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc33.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p33 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp33 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp33.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r33 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp33 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp33.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r33.Append(rp33);
                r33.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("$ " + TotalBajasMonto.ToString("#,##0.00")));
                p33.Append(r33);
                p33.Append(pp33);
                tc33.Append(p33);
                tr3.Append(tc33);

                table.Append(tr3);

                //Fila 4
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr4 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc41 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc41.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p41 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Modificaciones")));
                tc41.Append(p41);
                tr4.Append(tc41);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc42 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc42.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p42 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp42 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp42.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r42 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp42 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp42.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r42.Append(rp42);
                r42.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(TotalModificaciones.ToString()));
                p42.Append(r42);
                p42.Append(pp42);
                tc42.Append(p42);
                tr4.Append(tc42);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc43 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc43.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p43 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp43 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp43.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r43 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp43 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp43.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r43.Append(rp43);
                r43.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("$ " + TotalModificacionesMonto.ToString("#,##0.00")));
                p43.Append(r43);
                p43.Append(pp43);
                tc43.Append(p43);
                tr4.Append(tc43);

                table.Append(tr4);

                // Calculamos totales.
                TotalMovimientos = TotalAltas + TotalBajas + TotalModificaciones;
                TotalMovimientosMonto = TotalAltasMonto + TotalBajasMonto + TotalModificacionesMonto;

                //Fila 5
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr5 = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc51 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc51.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p51 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp51 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp51.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r51 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp51 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp51.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r51.Append(rp51);
                r51.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("Total"));
                p51.Append(r51);
                p51.Append(pp51);
                tc51.Append(p51);
                tr5.Append(tc51);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc52 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc52.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p52 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp52 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp52.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r52 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp52 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp52.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r52.Append(rp52);
                r52.Append(new DocumentFormat.OpenXml.Wordprocessing.Text(TotalMovimientos.ToString()));
                p52.Append(r52);
                p52.Append(pp52);
                tc52.Append(p52);
                tr5.Append(tc52);

                DocumentFormat.OpenXml.Wordprocessing.TableCell tc53 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
                tc53.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(new DocumentFormat.OpenXml.Wordprocessing.TableCellWidth() { Type = DocumentFormat.OpenXml.Wordprocessing.TableWidthUnitValues.Dxa, Width = "3000" }));
                DocumentFormat.OpenXml.Wordprocessing.Paragraph p53 = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp53 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp53.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                DocumentFormat.OpenXml.Wordprocessing.Run r53 = new DocumentFormat.OpenXml.Wordprocessing.Run();
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp53 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                rp53.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                r53.Append(rp53);
                r53.Append(new DocumentFormat.OpenXml.Wordprocessing.Text("$ " + TotalMovimientosMonto.ToString("#,##0.00")));
                p53.Append(r53);
                p53.Append(pp53);
                tc53.Append(p53);
                tr5.Append(tc53);

                table.Append(tr5);

                // Agrega la tabla al cuerpo del documento docx
                body.Append(table);

                #endregion Fin tabla

                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt6 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para7 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp7 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp7.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para7.Append(pp7);
                DocumentFormat.OpenXml.Wordprocessing.Run run7 = para7.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run7.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Se adjunta información de ") { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });

                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro7 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro7.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run7.Append(runpro7);
                run7.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(TotalMovimientos.ToString()));


                run7.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(" cartas instrucción digitalizadas, que se han agregado a SACI para su actualización.") { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });

                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt8 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt9 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para8 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp8 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp8.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                para8.Append(pp8);
                DocumentFormat.OpenXml.Wordprocessing.Run run8 = para8.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run8.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Sello y Fecha de Recibido de Retenedor"));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt10 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt11 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para9 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp9 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp9.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para9.Append(pp9);
                DocumentFormat.OpenXml.Wordprocessing.Run run9 = para9.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties runpro9 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                runpro9.Bold = new DocumentFormat.OpenXml.Wordprocessing.Bold();
                run9.Append(runpro9);
                run9.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("Observaciones"));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph paraInt12 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para10 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp10 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp10.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para10.Append(pp10);
                DocumentFormat.OpenXml.Wordprocessing.Run run10 = para10.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp10 = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = "Courier" });
                run10.Append(rp10);
                run10.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("* Se anexan documentos que detallan la información."));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para11 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp11 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp11.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para11.Append(pp11);
                DocumentFormat.OpenXml.Wordprocessing.Run run11 = para11.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp11b = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = "Courier" });
                run11.Append(rp11b);
                run11.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("* En caso de que la información se reciba fuera del cierre del calendario, favor de aplicar en el proceso inmediato de nómina, no aplicar dobles descuentos."));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para12 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp14 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp14.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para12.Append(pp14);
                DocumentFormat.OpenXml.Wordprocessing.Run run12 = para12.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp12b = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = "Courier" });
                run12.Append(rp12b);
                run12.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("* Al ser incorporados en nómina, se solicita la entrega de un informe detallado de los movimientos rechazados."));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para13 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties pp15 = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                pp15.Justification = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Left };
                para13.Append(pp15);
                DocumentFormat.OpenXml.Wordprocessing.Run run13 = para13.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                DocumentFormat.OpenXml.Wordprocessing.RunProperties rp13b = new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new DocumentFormat.OpenXml.Wordprocessing.RunFonts() { Ascii = "Courier" });
                run13.Append(rp13b);
                run13.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("* De presentarse algún problema de lectura del archivo, se solicita sea reportado de manera inmediata a los teléfonos (55) 5328.9000 Ext. 7662 con Jesús Alberto Santos Guzmán o al (55) 5328.9000 Ext. 6360 con Gullermo Joachin  "));
            }
        }

        public void GenerarReporteXLS_AcusesEntregaImagenesMasivo(DataView dvDatos, string strRuta, string TipoNomina, string Quincena)
        {
            // string newFilePath = Server.MapPath("/Archivos/AcusesEntregaImagenesActivos.xlsx");
            // string newFilePath = System.Web.HttpContext.Current.Server.MapPath("~\\ArchivosDBF\\");
            string newFilePath = strRuta + "\\Acuses de entrega de imágenes.xlsx";
            float totalMovimientos = 0;

            if (File.Exists(newFilePath))
                File.Delete(newFilePath);

            FileInfo newFile = new FileInfo(newFilePath);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                excel.Workbook.Worksheets.Add(TipoNomina.ToUpper());
                var worksheet = excel.Workbook.Worksheets[TipoNomina.ToUpper()];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z100"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:D1"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "INSTITUTO MEXICANO DEL SEGURO SOCIAL-METLIFE";
                }
                using (ExcelRange Rng = worksheet.Cells["A2:D2"])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "REPORTE DE CARTAS DE INSTRUCCION " + TipoNomina + " QUINCENA " + Quincena + " METLIFE";
                }
                using (ExcelRange Rng = worksheet.Cells["A3:D3"])
                {
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A3:B3"])
                {
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Cartas de Instrucción";
                }
                using (ExcelRange Rng = worksheet.Cells["C3"])
                {
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                }
                using (ExcelRange Rng = worksheet.Cells["D3"])
                {
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                }
                using (ExcelRange Rng = worksheet.Cells["A4"])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Proveedor";
                }
                using (ExcelRange Rng = worksheet.Cells["B4"])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Delegación";
                }
                using (ExcelRange Rng = worksheet.Cells["C4"])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Nombre de la Delegación";
                }
                using (ExcelRange Rng = worksheet.Cells["D4"])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Total";
                }

                int NFilas = 5;
                foreach (DataRowView rowView in dvDatos)
                {
                    DataRow row = rowView.Row;

                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;

                        if (NFilas == 5)
                        {
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                            CeldaDato.Value = int.Parse(row["Proveedor"].ToString());
                        }
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;

                        CeldaDato.Value = row["Delegacion"];
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;

                        CeldaDato.Value = row["NombreDelegacion"].ToString();
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                        CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        if (NFilas == 5)
                            CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Medium;

                        CeldaDato.Style.Numberformat.Format = "0";
                        totalMovimientos += int.Parse(row["Total"].ToString());
                        CeldaDato.Value = row["Total"];
                    }
                    NFilas += 1;
                }

                using (ExcelRange Rng = worksheet.Cells[NFilas, 1, NFilas, 4])
                {
                    Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    CeldaDato.Value = "Total General";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                {
                    CeldaDato.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    CeldaDato.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    CeldaDato.Style.Border.Top.Style = ExcelBorderStyle.Thin;

                    CeldaDato.Style.Numberformat.Format = "#,##0";
                    CeldaDato.Value = totalMovimientos;
                }

                worksheet.Column(1).Width = GetTrueColumnWidth(12);
                worksheet.Column(2).Width = GetTrueColumnWidth(12);
                worksheet.Column(3).Width = GetTrueColumnWidth(35);
                worksheet.Column(4).Width = GetTrueColumnWidth(12);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        public void GenerarReporteXLS_AcusesEntregaImagenes(DataTable dtDatos, string strRuta, string TipoNomina, string Quincena)
        {
            // string newFilePath = Server.MapPath("/Archivos/AcusesEntregaImagenesActivos.xlsx");
            // string newFilePath = System.Web.HttpContext.Current.Server.MapPath("~\\ArchivosDBF\\");
            string newFilePath = strRuta + "\\Acuses de entrega de imágenes.xlsx";
            float totalMovimientos = 0;

            if (File.Exists(newFilePath))
                File.Delete(newFilePath);

            FileInfo newFile = new FileInfo(newFilePath);

            using (ExcelPackage excel = new ExcelPackage(newFile))
            {
                excel.Workbook.Worksheets.Add(TipoNomina.ToUpper());
                var worksheet = excel.Workbook.Worksheets[TipoNomina.ToUpper()];
                worksheet.CustomHeight = true;

                using (ExcelRange Rng = worksheet.Cells["A1:Z100"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 8));
                    //Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A1:D1"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    //     Rng.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "INSTITUTO MEXICANO DEL SEGURO SOCIAL-METLIFE";
                }
                using (ExcelRange Rng = worksheet.Cells["A2:D2"])
                {
                    Rng.Style.Font.SetFromFont(new Font("Arial", 9));
                    Rng.Merge = true;
                    //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                    //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "REPORTE DE CARTAS DE INSTRUCCION " + TipoNomina + " QUINCENA " + Quincena + " METLIFE";
                }
                using (ExcelRange Rng = worksheet.Cells["A3:D3"])
                {
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange Rng = worksheet.Cells["A3:B3"])
                {
                    Rng.Merge = true;
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Cartas de Instruccion";
                }
                using (ExcelRange Rng = worksheet.Cells["A4"])
                {
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Proveedor";
                }
                using (ExcelRange Rng = worksheet.Cells["B4"])
                {
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Delegación";
                }
                using (ExcelRange Rng = worksheet.Cells["C4"])
                {
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Nombre de la Delegación";
                }
                using (ExcelRange Rng = worksheet.Cells["D4"])
                {
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    Rng.Value = "Total";
                }

                int NFilas = 5;
                foreach (DataRow row in dtDatos.Rows)
                {
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                    {
                        if (NFilas == 5)
                        {
                            CeldaDato.Value = int.Parse(row["Proveedor"].ToString());
                        }
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 2, NFilas, 2])
                    {
                        CeldaDato.Value = row["Delegacion"];
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 3, NFilas, 3])
                    {
                        CeldaDato.Value = row["NombreDelegacion"].ToString();
                    }
                    using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                    {
                        CeldaDato.Style.Numberformat.Format = "0";
                        totalMovimientos += int.Parse(row["Total"].ToString());
                        CeldaDato.Value = row["Total"];
                    }
                    NFilas += 1;
                }

                using (ExcelRange Rng = worksheet.Cells[NFilas, 1, NFilas, 4])
                {
                    Rng.Style.Font.Bold = true;
                    Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                    Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#366092"));
                    Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 1, NFilas, 1])
                {
                    CeldaDato.Value = "Total General";
                }
                using (ExcelRange CeldaDato = worksheet.Cells[NFilas, 4, NFilas, 4])
                {
                    CeldaDato.Style.Numberformat.Format = "#,##0";
                    CeldaDato.Value = totalMovimientos;
                }

                worksheet.Column(1).Width = GetTrueColumnWidth(12);
                worksheet.Column(2).Width = GetTrueColumnWidth(12);
                worksheet.Column(3).Width = GetTrueColumnWidth(35);
                worksheet.Column(4).Width = GetTrueColumnWidth(12);

                var ms = new System.IO.MemoryStream();
                excel.Save();
                ms.WriteTo(ms);
            }
        }

        private void EnlaceGenerarMasivoTipoNominaOutFileTXT(DataTable ArchivosTXT, DataView UnidadesPago, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura)
        {
            // Declaración de Variables.
            FileInfo fi = null;
            DataView dvDatos = null;
            DataView dvDatosAlta = null;
            DataView dvDatosModi = null;
            DataView dvDatosBaja = null;
            string strNombreArchivo = "";
            string strUnidadPago = "";
            string strRetenedor = "0257";
            string strConcepto = "";
            string strTipoNomina = "";
            string strQuincena = Quincena;
            string strContenido = "";

            // Establecemos la equivalencia del Tipo de Nomina.
            switch (Abreviatura)
            {
                case "AA":
                case "EA":
                    strTipoNomina = "T";
                    break;

                case "JJ":
                    strTipoNomina = "J";
                    strQuincena = Quincena.Substring(0, 4) + (int.Parse(Quincena.Substring(4, 2)) / 2).ToString("00");
                    break;

                case "MM":
                    strTipoNomina = "M";
                    break;

                default:
                    strTipoNomina = "-";
                    break;
            }

            // Recorremos las unidades de Pago.
            foreach (DataRowView drvUnidadPago in UnidadesPago)
            {
                DataRow rowUnidadPago = drvUnidadPago.Row;

                strUnidadPago = rowUnidadPago["UnidadPago_Concentrado"].ToString();
                strConcepto = rowUnidadPago["Clave"].ToString();

                dvDatos = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND TipoNomina = '" + Abreviatura + "'", "UnidadPago", DataViewRowState.CurrentRows);
                dvDatosAlta = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND TipoNomina = '" + Abreviatura + "'" + " AND [Tipo de Movimiento] = 'A'", "UnidadPago", DataViewRowState.CurrentRows);
                dvDatosModi = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND TipoNomina = '" + Abreviatura + "'" + " AND [Tipo de Movimiento] = 'M'", "UnidadPago", DataViewRowState.CurrentRows);
                dvDatosBaja = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND TipoNomina = '" + Abreviatura + "'" + " AND ([Tipo de Movimiento] = 'V' OR [Tipo de Movimiento] = 'B')", "UnidadPago", DataViewRowState.CurrentRows);

                dvDatos.Sort = "OrdenData ASC";
                if (dvDatos.Count > 0)
                {
                    // Creamos el archivo.
                    strNombreArchivo = RutaEntregable + "\\"
                                    + strUnidadPago
                                    + strRetenedor
                                    + strConcepto
                                    + strTipoNomina
                                    + strQuincena.Substring(4, 2) + ".TXT";
                    fi = new FileInfo(strNombreArchivo);

                    if (File.Exists(strNombreArchivo))
                        File.Delete(strNombreArchivo);

                    // Create a new file     
                    //using (StreamWriter fs = fi.CreateText())
                    //{

                    StreamWriter streamWriter = new StreamWriter(strNombreArchivo, true, Encoding.GetEncoding(1252));
                    foreach (DataRowView rowView in dvDatos)
                    {
                        DataRow rowEnlace = rowView.Row;

                        string _tipoMovimiento = rowEnlace["Tipo de Movimiento"].ToString();
                        if (_tipoMovimiento == "B")
                        {
                            _tipoMovimiento = "V";
                        }

                        strContenido = "";
                        strContenido += rowEnlace["Tipo de prestamo"].ToString();
                        strContenido += rowEnlace["Matrícula"].ToString();
                        strContenido += rowEnlace["Concepto"].ToString();
                        strContenido += rowEnlace["Importe"].ToString();
                        strContenido += rowEnlace["Plazo"].ToString();
                        strContenido += rowEnlace["Numero de Control"].ToString();

                        if (rowEnlace["CasoEspecial"].ToString() != "3")
                        {
                            //strContenido += rowEnlace["Numero de Crédito (Póliza)"].ToString();  anteriormente aplicaba solo para casos especiales, ahora aplica para todas las polizas porque es posible que no tengan 10 digitos
                            string strPoliza = rowEnlace["Numero de Crédito (Póliza)"].ToString();
                            if (strPoliza.Length < 10)
                            {
                                strPoliza = strPoliza.PadLeft(10, ' ');
                            }
                            strContenido += strPoliza;

                        }
                        else
                        {
                            string strPoliza = rowEnlace["Numero de Crédito (Póliza)"].ToString();
                            if (strPoliza.Length < 10)
                            {
                                strPoliza = strPoliza.PadLeft(10, ' ');
                            }
                            strContenido += strPoliza;
                        }

                        strContenido += rowEnlace["Cifra Control (Importe)"].ToString();
                        strContenido += _tipoMovimiento;                         //strContenido += rowEnlace["Tipo de Movimiento"].ToString();
                        strContenido += rowEnlace["Nombre del Trabajador"].ToString();
                        strContenido += rowEnlace["Numero de Provedor (Retenedor)"].ToString();
                        strContenido += rowEnlace["Carácter"].ToString();
                        //fs.WriteLine(strContenido, Encoding.Default);           // Escribimos el archivo en ANSI.

                        streamWriter.WriteLine(strContenido, Encoding.GetEncoding(1252));
                    }

                    //    // Generamos el Resumen.
                    //    fs.WriteLine(new string('9', 18) + new string(' ', 5) + dvDatosAlta.Count.ToString("0000000000"), Encoding.Default);
                    //    fs.WriteLine(new string('9', 18) + new string(' ', 5) + dvDatosBaja.Count.ToString("0000000000"), Encoding.Default);
                    //    fs.Write(new string('9', 18) + new string(' ', 5) + dvDatosModi.Count.ToString("0000000000"), Encoding.Default);

                    streamWriter.WriteLine(new string('9', 18) + new string(' ', 5) + dvDatosBaja.Count.ToString("0000000000"), Encoding.GetEncoding(1252));
                    streamWriter.WriteLine(new string('9', 18) + new string(' ', 5) + dvDatosAlta.Count.ToString("0000000000"), Encoding.GetEncoding(1252));
                    streamWriter.Write(new string('9', 18) + new string(' ', 5) + dvDatosModi.Count.ToString("0000000000"), Encoding.GetEncoding(1252));
                    streamWriter.Close();
                    //}
                }

                dvDatos = null;
                dvDatosAlta = null;
                dvDatosModi = null;
                dvDatosBaja = null;
                fi = null;
            }
        }

        private void EnlaceGenerarTipoNominaOutFileTXT(DataTable ArchivosTXT, DataTable UnidadesPago, string RutaEntregable, string Quincena, string TipoNomina, string Abreviatura)
        {
            // Declaración de Variables.
            FileInfo fi = null;
            DataView dvDatos = null;
            DataView dvDatosAlta = null;
            DataView dvDatosModi = null;
            DataView dvDatosBaja = null;
            string strNombreArchivo = "";
            string strUnidadPago = "";
            string strRetenedor = "0257";
            string strConcepto = "";
            string strTipoNomina = "";
            string strQuincena = Quincena;
            string strContenido = "";

            // Establecemos la equivalencia del Tipo de Nomina.
            switch (Abreviatura)
            {
                case "AA":
                case "EA":
                    strTipoNomina = "T";
                    break;

                case "JJ":
                    strTipoNomina = "J";
                    strQuincena = Quincena.Substring(0, 4) + (int.Parse(Quincena.Substring(4, 2)) / 2).ToString("00");
                    break;

                case "MM":
                    strTipoNomina = "M";
                    break;

                default:
                    strTipoNomina = "-";
                    break;
            }

            // Recorremos las unidades de Pago.
            foreach (DataRow rowUnidadPago in UnidadesPago.Rows)
            {
                strUnidadPago = rowUnidadPago["UnidadPago_Concentrado"].ToString();
                strConcepto = rowUnidadPago["Clave"].ToString();

                dvDatos = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago, "UnidadPago", DataViewRowState.CurrentRows);
                dvDatosAlta = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND [Tipo de Movimiento] = 'A'", "UnidadPago", DataViewRowState.CurrentRows);
                dvDatosModi = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND [Tipo de Movimiento] = 'M'", "UnidadPago", DataViewRowState.CurrentRows);
                dvDatosBaja = new DataView(ArchivosTXT, "UnidadPago = " + strUnidadPago + " AND [Tipo de Movimiento] = 'V'", "UnidadPago", DataViewRowState.CurrentRows);

                if (dvDatos.Count > 0)
                {
                    // Creamos el archivo.
                    strNombreArchivo = RutaEntregable + "\\" 
                                    + strUnidadPago 
                                    + strRetenedor 
                                    + strConcepto 
                                    + strTipoNomina 
                                    + strQuincena.Substring(4,2) + ".TXT";
                    fi = new FileInfo(strNombreArchivo);

                    if (File.Exists(strNombreArchivo))
                        File.Delete(strNombreArchivo);

                    // Create a new file     
                    using (StreamWriter fs = fi.CreateText())
                    {
                        foreach (DataRowView rowView in dvDatos)
                        {
                            DataRow rowEnlace = rowView.Row;

                            strContenido = "";
                            strContenido += rowEnlace["Tipo de prestamo"].ToString();
                            strContenido += rowEnlace["Matrícula"].ToString();
                            strContenido += rowEnlace["Concepto"].ToString();
                            strContenido += rowEnlace["Importe"].ToString();
                            strContenido += rowEnlace["Plazo"].ToString();
                            strContenido += rowEnlace["Numero de Control"].ToString();
                            strContenido += rowEnlace["Numero de Crédito (Póliza)"].ToString();
                            strContenido += rowEnlace["Cifra Control (Importe)"].ToString();
                            strContenido += rowEnlace["Tipo de Movimiento"].ToString();
                            strContenido += rowEnlace["Nombre del Trabajador"].ToString();
                            strContenido += rowEnlace["Numero de Provedor (Retenedor)"].ToString();
                            strContenido += rowEnlace["Carácter"].ToString();
                            fs.WriteLine(strContenido, Encoding.Default);           // Escribimos el archivo en ANSI.
                        }

                        // Generamos el Resumen.
                        fs.WriteLine(new string('9', 18) + new string(' ', 5) + dvDatosAlta.Count.ToString("0000000000"), Encoding.Default);
                        fs.WriteLine(new string('9', 18) + new string(' ', 5) + dvDatosBaja.Count.ToString("0000000000"), Encoding.Default);
                        fs.Write(new string('9', 18) + new string(' ', 5) + dvDatosModi.Count.ToString("0000000000"), Encoding.Default);
                    }
                }

                dvDatos = null;
                dvDatosAlta = null;
                dvDatosModi = null;
                dvDatosBaja = null;
                fi = null;
            }
        }

        private void EnlaceGenerarTipoNominaOutSACI_Jubilados(DataTable dtJubilados, string RutaEntregable, string RutaImagenes, string Quincena, string TipoNomina, string Abreviatura, ref string logError)
        {
            // Declaración de Variables
            string origen = HttpContext.Current.Server.MapPath("~/PDF/");

            // Realiza la exportación del DBF...
            DataSetIntoDBF(RutaEntregable, "T25_MAIN", dtJubilados, ref logError);
            EnlaceCartas(origen, RutaImagenes, dtJubilados, ref logError);
        }

        private void EnlaceGenerarTipoNominaOutSACI_Masivos(DataTable dtInformacion, string RutaEntregable, string RutaImagenes, string Quincena, string TipoNomina, string Abreviatura, ref string logError)
        {
            // Declaración de Variables
            //string origen = HttpContext.Current.Server.MapPath("~/PDF/");
            string origen = @"D:\backup\IBM\WEBSITES\WFO_IMSSPortal\PDF";


            // Realiza la exportación del DBF...
            DataSetIntoDBF_Masivos(RutaEntregable, "T25_MAIN", dtInformacion, ref logError);

            // Generamos las Cartas Necesarias
            EnlaceCartas_Masivos(origen, RutaImagenes, dtInformacion, ref logError);
        }

        private void EnlaceGenerarTipoNominaOutSACI_TiposNominasALL(DataTable dtActivos, DataTable dtEstatuto, DataTable dtMando, DataTable dtJubilados, string RutaEntregable, string RutaImagenes, string Quincena, string TipoNomina, string Abreviatura, ref string logError)
        {
            // Declaración de Variables
            string origen = HttpContext.Current.Server.MapPath("~/PDF/");

            // Realiza la exportación del DBF...
            DataSetIntoDBF_TiposNominasAll(RutaEntregable, "T25_MAIN", dtActivos, dtEstatuto, dtMando, dtJubilados, ref logError);

            // Generamos las Cartas Necesarias
            EnlaceCartas(origen, RutaImagenes, dtActivos, ref logError);
            EnlaceCartas(origen, RutaImagenes, dtEstatuto, ref logError);
            EnlaceCartas(origen, RutaImagenes, dtMando, ref logError);
            EnlaceCartas(origen, RutaImagenes, dtJubilados, ref logError);
        }

        private void EnlaceGenerarTipoNominaOutSACI_Activos(DataTable dtActivos, DataTable dtEstatuto, DataTable dtMando, string RutaEntregable, string RutaImagenes, string Quincena, string TipoNomina, string Abreviatura, ref string logError)
        {
            // Declaración de Variables
            string origen = HttpContext.Current.Server.MapPath("~/PDF/");

            // Realiza la exportación del DBF...
            DataSetIntoDBF_Activos(RutaEntregable, "T25_MAIN", dtActivos, dtEstatuto, dtMando, ref logError);
            
            // Generamos las Cartas Necesarias
            EnlaceCartas(origen, RutaImagenes, dtActivos, ref logError);
            EnlaceCartas(origen, RutaImagenes, dtEstatuto, ref logError);
            EnlaceCartas(origen, RutaImagenes, dtMando, ref logError);
        }

        private void EnlaceCartas_Masivos(string rutaOrigen, string rutaDestino, DataTable dtEnlace, ref string logError)
        {
            try
            {
                double contador = 0;
                double TotalBajas = 0;
                double cartaNoAsignada = 0;

                //copiar los archivos con el nuevo nombre
                string ArchivoNoEncontrado = "";
                int totalArchivos = 0;
                
                foreach (DataRow row in dtEnlace.Rows)
                {
                    contador += 1;

                    if (row["imgorigin"].ToString().Length > 0)
                    {

                        string[] archivoorigen = row["imgorigin"].ToString().Split('\\');
                        string[] archivodestino = row["imgvincul"].ToString().Split('\\');

                        if (!Directory.Exists(rutaDestino + "\\" + archivodestino[3].ToString().Trim()))
                        {
                            Directory.CreateDirectory(rutaDestino + "\\" + archivodestino[3].ToString().Trim());
                        }

                        if (!archivoorigen[3].ToString().Trim().Contains("CartaBaja.PDF"))
                        {
                            if (File.Exists(rutaOrigen + "\\" + archivoorigen[3].ToString().Trim()))
                            {
                                File.Copy(
                                    rutaOrigen + "\\" + archivoorigen[3].ToString().Trim(),
                                    rutaDestino + "\\" + archivodestino[3].ToString().Trim() + "\\" + archivodestino[4].ToString().Trim(), true
                                    );

                                if (!File.Exists(rutaDestino + "\\" + archivodestino[3].ToString().Trim() + "\\" + archivodestino[4].ToString().Trim()))
                                {
                                    ArchivoNoEncontrado = "Detino: " + rutaDestino + "\\" + archivodestino[4].ToString().Trim() + "[" + archivoorigen[3].ToString().Trim() + "]";

                                    StreamWriter sw = new StreamWriter(@"C:\IMSSPortal\Entregables\Archivos Faltantes\log_filesEnlaceKO.rmf", true);
                                    sw.Write("// " + archivoorigen[4].ToString().Trim() + Environment.NewLine);
                                    sw.Close();
                                }
                                else
                                {
                                    totalArchivos += 1;
                                }
                            }
                            else
                            {
                                //El problema al buscar los archivos de los casos especiales es que no almacena correctamente el nombre de la carta para poder realiza la búsqueda de la misma y que se haga la copia al directorio de manera correcta
                                if (File.Exists(rutaOrigen.Replace("\\PDF\\", "\\EnlaceCasosEspeciales\\") + archivoorigen[3].ToString().Trim().ToUpper().Replace(".PDF", "") + ".pdf"))
                                {
                                    File.Copy(
                                        rutaOrigen.Replace("\\PDF\\", "\\EnlaceCasosEspeciales\\") + archivoorigen[3].ToString().Trim(),
                                        rutaDestino + "\\" + archivodestino[3].ToString().Trim() + "\\" + archivodestino[4].ToString().Trim(), true
                                    );

                                    if (!File.Exists(rutaDestino + "\\" + archivodestino[3].ToString().Trim() + "\\" + archivodestino[4].ToString().Trim()))
                                    {
                                        ArchivoNoEncontrado = "Detino: " + rutaDestino + "\\" + archivodestino[4].ToString().Trim() + "[" + archivoorigen[3].ToString().Trim() + "]";

                                        StreamWriter sw = new StreamWriter(@"C:\IMSSPortal\Entregables\Archivos Faltantes\log_filesEnlaceKO.rmf", true);
                                        sw.Write("== " + archivoorigen[4].ToString().Trim() + Environment.NewLine);
                                        sw.Close();
                                    }
                                    else
                                    {
                                        totalArchivos += 1;
                                    }
                                }
                                else
                                {
                                    ArchivoNoEncontrado = "Origen: " + rutaOrigen + archivoorigen[3].ToString().Trim();
                                    //agrega al log archivo que no existe
                                    //logError += archivoorigen[3].ToString();

                                    StreamWriter sw = new StreamWriter(@"C:\IMSSPortal\Entregables\Archivos Faltantes\log_filesEnlaceKO.rmf", true);
                                    sw.Write("-- " + archivoorigen[3].ToString().Trim() + Environment.NewLine);
                                    sw.Close();
                                }
                            }
                        }
                        else
                        {
                            // Incrementamos las bajas
                            TotalBajas += 1;
                        }
                    }
                    else
                    {
                        // DatoNo Encontrado
                        cartaNoAsignada += 1;


                        StreamWriter sw = new StreamWriter(@"C:\IMSSPortal\Entregables\Archivos Faltantes\log_filesEnlaceKO.rmf", true);
                        sw.Write(row["anumpol"].ToString().Trim() + Environment.NewLine);
                        sw.Close();
                    }
                }

                System.Diagnostics.Debug.WriteLine("Total de Registros procesados: " + contador.ToString());
                System.Diagnostics.Debug.WriteLine("Total de CARTAS FALTATES: " + cartaNoAsignada.ToString());
                System.Diagnostics.Debug.WriteLine("Total de Bajas: " + TotalBajas.ToString());
                System.Diagnostics.Debug.WriteLine("Total de Archivos Enlace: " + totalArchivos.ToString());

                //hay que revisar el nombramiento de los archivos
                //    no los esta guardando en la carpeta
                //    no los renombra bien
                //    revisar bien el formato del nombre - que quincena se pone
            }

            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
        }

        private void EnlaceCartas(string rutaOrigen, string rutaDestino, DataTable dtEnlace, ref string logError)
        {
            try
            {
                //copiar los archivos con el nuevo nombre
                string ArchivoNoEncontrado = "";
                foreach (DataRow row in dtEnlace.Rows)
                {
                    string[] archivoorigen = row["imgorigin"].ToString().Split('\\');
                    string[] archivodestino = row["imgvincul"].ToString().Split('\\');

                    if (!Directory.Exists(rutaDestino + archivodestino[3].ToString().Trim()))
                    {
                        Directory.CreateDirectory(rutaDestino + "\\" + archivodestino[3].ToString().Trim());
                    }

                    if (File.Exists(rutaOrigen + archivoorigen[3].ToString().Trim()))
                    {
                        File.Copy(
                            rutaOrigen + archivoorigen[3].ToString().Trim(),
                            rutaDestino + "\\" + archivodestino[3].ToString().Trim() + "\\" + archivodestino[4].ToString().Trim(), true
                            );

                        if (!File.Exists(rutaDestino + "\\" + archivodestino[3].ToString().Trim() + "\\" + archivodestino[4].ToString().Trim()))
                        {
                            ArchivoNoEncontrado = "Detino: " + rutaDestino + "\\" + archivodestino[3].ToString().Trim();
                        }
                    }
                    else
                    {
                        ArchivoNoEncontrado = "Origen: " + rutaOrigen + archivoorigen[3].ToString().Trim();
                        //agrega al log archivo que no existe
                        //logError += archivoorigen[3].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string _error = ex.Message.ToString();
            }
        }

        private void DataSetIntoDBF_Masivos(string rutaDestino, string fileName, DataTable dtInformacion, ref string logError)
        {
            ArrayList list = new ArrayList();
            string rutaArchivo = System.Web.HttpContext.Current.Server.MapPath("~\\ArchivosDBF\\");
            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Delete(rutaArchivo + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Delete(rutaArchivo + fileName + ".XLSX");
            }

            FileInfo newFile = new FileInfo(rutaArchivo + fileName + ".XLSX");

            ExcelPackage archivoExcelDBF = new ExcelPackage(newFile);
            archivoExcelDBF.Workbook.Worksheets.Add(fileName.ToUpper());
            var hojaTrabajo = archivoExcelDBF.Workbook.Worksheets[fileName.ToUpper()];
            hojaTrabajo.CustomHeight = true;

            using (ExcelRange Rng = hojaTrabajo.Cells["A1:BA10000"])
            {
                Rng.Style.Font.SetFromFont(new Font("Calibri", 11));
                Rng.Style.Font.Size = 11;
                Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            using (ExcelRange Rng = hojaTrabajo.Cells["A1:ZZ"])
            {
                Rng.AutoFitColumns(100, 1000);
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 1])
            {
                CeldaDato.Value = "id";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 2])
            {
                CeldaDato.Value = "movimiento";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 3])
            {
                CeldaDato.Value = "atiprest";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 4])
            {
                CeldaDato.Value = "amatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 5])
            {
                CeldaDato.Value = "aconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 6])
            {
                CeldaDato.Value = "aimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 7])
            {
                CeldaDato.Value = "aplazo";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 8])
            {
                CeldaDato.Value = "acontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 9])
            {
                CeldaDato.Value = "anumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 10])
            {
                CeldaDato.Value = "apromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 11])
            {
                CeldaDato.Value = "accontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 12])
            {
                CeldaDato.Value = "atipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 13])
            {
                CeldaDato.Value = "anomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 14])
            {
                CeldaDato.Value = "anumprov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 15])
            {
                CeldaDato.Value = "acaracter";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 16])
            {
                CeldaDato.Value = "aup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 17])
            {
                CeldaDato.Value = "atipnomina";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 18])
            {
                CeldaDato.Value = "aaq";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 19])
            {
                CeldaDato.Value = "bnumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 20])
            {
                CeldaDato.Value = "bnomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 21])
            {
                CeldaDato.Value = "bmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 22])
            {
                CeldaDato.Value = "bup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 23])
            {
                CeldaDato.Value = "bimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 24])
            {
                CeldaDato.Value = "bimgstatus";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 25])
            {
                CeldaDato.Value = "ctipreg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 26])
            {
                CeldaDato.Value = "cconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 27])
            {
                CeldaDato.Value = "ctipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 28])
            {
                CeldaDato.Value = "cimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 29])
            {
                CeldaDato.Value = "crfc";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 30])
            {
                CeldaDato.Value = "cup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 31])
            {
                CeldaDato.Value = "cmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 32])
            {
                CeldaDato.Value = "cveadscrip";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 33])
            {
                CeldaDato.Value = "carearesp";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 34])
            {
                CeldaDato.Value = "cvigen";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 35])
            {
                CeldaDato.Value = "ctipcontra";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 36])
            {
                CeldaDato.Value = "cpromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 37])
            {
                CeldaDato.Value = "ccvedeleg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 38])
            {
                CeldaDato.Value = "imgorigin";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 39])
            {
                CeldaDato.Value = "imgvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 40])
            {
                CeldaDato.Value = "fvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 41])
            {
                CeldaDato.Value = "general";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 42])
            {
                CeldaDato.Value = "nomcarpaq";
            }

            int NFilas = 2;
            string createSql = "create table " + fileName + " (";
            createSql += "[id] VARCHAR(25) ";
            createSql += ",[movimiento] VARCHAR(20) ";
            createSql += ",[atiprest] INT ";
            createSql += ",[amatricula] VARCHAR(10) ";
            createSql += ",[aconcepto] INT ";
            createSql += ",[aimporte] FLOAT ";
            createSql += ",[aplazo] INT ";
            createSql += ",[acontrol] INT ";
            createSql += ",[anumpol] VARCHAR(8) ";
            createSql += ",[apromot] VARCHAR(4) ";
            createSql += ",[accontrol] INT ";
            createSql += ",[atipmov] VARCHAR(1) ";
            createSql += ",[anomtrabaj] VARCHAR(47) ";
            createSql += ",[anumprov] INT ";
            createSql += ",[acaracter] VARCHAR(1) ";
            createSql += ",[aup] VARCHAR(2) ";
            createSql += ",[atipnomina] VARCHAR(2) ";
            createSql += ",[aaq] VARCHAR(6) ";
            createSql += ",[bnumpol] VARCHAR(8) ";
            createSql += ",[bnomtrabaj] VARCHAR(100) ";
            createSql += ",[bmatricula] VARCHAR(10) ";
            createSql += ",[bup] VARCHAR(2) ";
            createSql += ",[bimporte] FLOAT ";
            createSql += ",[bimgstatus] VARCHAR(15) ";
            createSql += ",[ctipreg] INT ";
            createSql += ",[cconcepto] INT ";
            createSql += ",[ctipmov] INT ";
            createSql += ",[cimporte] FLOAT ";
            createSql += ",[crfc] VARCHAR(10) ";
            createSql += ",[cup] VARCHAR(2) ";
            createSql += ",[cmatricula] INT ";
            createSql += ",[cveadscrip] VARCHAR(10) ";
            createSql += ",[carearesp] VARCHAR(3) ";
            createSql += ",[cvigen] VARCHAR(2) ";
            createSql += ",[ctipcontra] INT ";
            createSql += ",[cpromot] VARCHAR(4) ";
            createSql += ",[ccvedeleg] INT ";
            createSql += ",[imgorigin] VARCHAR(254) ";
            createSql += ",[imgvincul] VARCHAR(254) ";
            createSql += ",[fvincul] DATE ";
            createSql += ",[general] VARCHAR(254) ";
            createSql += ",[nomcarpaq] VARCHAR(40)";
            createSql += ")";

            OleDbConnection con = new OleDbConnection(GetConnection(rutaArchivo));
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();

            foreach (DataRow row in dtInformacion.Rows)
            {
                if (row["acontrol"].ToString() == "")
                {
                    if (row["anumpol"].ToString() == "00LXN001")
                    {
                        row["acontrol"] = "011015";
                    }
                    else
                    {
                        row["acontrol"] = "011095";
                    }
                }

                if (row["accontrol"].ToString() == "")
                {
                    if (row["anumpol"].ToString() == "00LXN001")
                    {
                        row["accontrol"] = "00150440";
                    }
                    else
                    {
                        row["accontrol"] = "00195044";
                    }

                   
                }


                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            con.Close();

            var ms = new System.IO.MemoryStream();
            archivoExcelDBF.Save();
            ms.WriteTo(ms);

            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Move(rutaArchivo + fileName + ".DBF", rutaDestino + "\\" + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Move(rutaArchivo + fileName + ".XLSX", rutaDestino + "\\" + fileName + ".XLSX");
            }
        }

        private void DataSetIntoDBF_TiposNominasAll(string rutaDestino, string fileName, DataTable dtActivos, DataTable dtEstatuto, DataTable dtMando, DataTable dtJubilados, ref string logError)
        {
            ArrayList list = new ArrayList();
            string rutaArchivo = System.Web.HttpContext.Current.Server.MapPath("~\\ArchivosDBF\\");
            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Delete(rutaArchivo + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Delete(rutaArchivo + fileName + ".XLSX");
            }

            FileInfo newFile = new FileInfo(rutaArchivo + fileName + ".XLSX");

            ExcelPackage archivoExcelDBF = new ExcelPackage(newFile);
            archivoExcelDBF.Workbook.Worksheets.Add(fileName.ToUpper());
            var hojaTrabajo = archivoExcelDBF.Workbook.Worksheets[fileName.ToUpper()];
            hojaTrabajo.CustomHeight = true;


            using (ExcelRange Rng = hojaTrabajo.Cells["A1:BA10000"])
            {
                Rng.Style.Font.SetFromFont(new Font("Calibri", 11));
                //Rng.Merge = true;
                //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Font.Bold = true;
                Rng.Style.Font.Size = 11;
                Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            using (ExcelRange Rng = hojaTrabajo.Cells["A1:ZZ"])
            {
                Rng.AutoFitColumns(100, 1000);
                //Rng.Style.Font.Bold = true;
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 1])
            {
                CeldaDato.Value = "id";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 2])
            {
                CeldaDato.Value = "movimiento";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 3])
            {
                CeldaDato.Value = "atiprest";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 4])
            {
                CeldaDato.Value = "amatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 5])
            {
                CeldaDato.Value = "aconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 6])
            {
                CeldaDato.Value = "aimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 7])
            {
                CeldaDato.Value = "aplazo";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 8])
            {
                CeldaDato.Value = "acontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 9])
            {
                CeldaDato.Value = "anumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 10])
            {
                CeldaDato.Value = "apromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 11])
            {
                CeldaDato.Value = "accontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 12])
            {
                CeldaDato.Value = "atipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 13])
            {
                CeldaDato.Value = "anomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 14])
            {
                CeldaDato.Value = "anumprov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 15])
            {
                CeldaDato.Value = "acaracter";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 16])
            {
                CeldaDato.Value = "aup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 17])
            {
                CeldaDato.Value = "atipnomina";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 18])
            {
                CeldaDato.Value = "aaq";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 19])
            {
                CeldaDato.Value = "bnumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 20])
            {
                CeldaDato.Value = "bnomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 21])
            {
                CeldaDato.Value = "bmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 22])
            {
                CeldaDato.Value = "bup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 23])
            {
                CeldaDato.Value = "bimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 24])
            {
                CeldaDato.Value = "bimgstatus";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 25])
            {
                CeldaDato.Value = "ctipreg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 26])
            {
                CeldaDato.Value = "cconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 27])
            {
                CeldaDato.Value = "ctipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 28])
            {
                CeldaDato.Value = "cimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 29])
            {
                CeldaDato.Value = "crfc";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 30])
            {
                CeldaDato.Value = "cup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 31])
            {
                CeldaDato.Value = "cmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 32])
            {
                CeldaDato.Value = "cveadscrip";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 33])
            {
                CeldaDato.Value = "carearesp";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 34])
            {
                CeldaDato.Value = "cvigen";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 35])
            {
                CeldaDato.Value = "ctipcontra";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 36])
            {
                CeldaDato.Value = "cpromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 37])
            {
                CeldaDato.Value = "ccvedeleg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 38])
            {
                CeldaDato.Value = "imgorigin";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 39])
            {
                CeldaDato.Value = "imgvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 40])
            {
                CeldaDato.Value = "fvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 41])
            {
                CeldaDato.Value = "general";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 42])
            {
                CeldaDato.Value = "nomcarpaq";
            }

            int NFilas = 2;
            string createSql = "create table " + fileName + " (";
            createSql += "[id] VARCHAR(25) ";
            createSql += ",[movimiento] VARCHAR(20) ";
            createSql += ",[atiprest] INT ";
            createSql += ",[amatricula] VARCHAR(10) ";
            createSql += ",[aconcepto] INT ";
            createSql += ",[aimporte] FLOAT ";
            createSql += ",[aplazo] INT ";
            createSql += ",[acontrol] INT ";
            createSql += ",[anumpol] VARCHAR(8) ";
            createSql += ",[apromot] VARCHAR(4) ";
            createSql += ",[accontrol] INT ";
            createSql += ",[atipmov] VARCHAR(1) ";
            createSql += ",[anomtrabaj] VARCHAR(47) ";
            createSql += ",[anumprov] INT ";
            createSql += ",[acaracter] VARCHAR(1) ";
            createSql += ",[aup] VARCHAR(2) ";
            createSql += ",[atipnomina] VARCHAR(2) ";
            createSql += ",[aaq] VARCHAR(6) ";
            createSql += ",[bnumpol] VARCHAR(8) ";
            createSql += ",[bnomtrabaj] VARCHAR(100) ";
            createSql += ",[bmatricula] VARCHAR(10) ";
            createSql += ",[bup] VARCHAR(2) ";
            createSql += ",[bimporte] FLOAT ";
            createSql += ",[bimgstatus] VARCHAR(15) ";
            createSql += ",[ctipreg] INT ";
            createSql += ",[cconcepto] INT ";
            createSql += ",[ctipmov] INT ";
            createSql += ",[cimporte] FLOAT ";
            createSql += ",[crfc] VARCHAR(10) ";
            createSql += ",[cup] VARCHAR(2) ";
            createSql += ",[cmatricula] INT ";
            createSql += ",[cveadscrip] VARCHAR(10) ";
            createSql += ",[carearesp] VARCHAR(3) ";
            createSql += ",[cvigen] VARCHAR(2) ";
            createSql += ",[ctipcontra] INT ";
            createSql += ",[cpromot] VARCHAR(4) ";
            createSql += ",[ccvedeleg] INT ";
            createSql += ",[imgorigin] VARCHAR(254) ";
            createSql += ",[imgvincul] VARCHAR(254) ";
            createSql += ",[fvincul] DATE ";
            createSql += ",[general] VARCHAR(254) ";
            createSql += ",[nomcarpaq] VARCHAR(40)";
            createSql += ")";

            OleDbConnection con = new OleDbConnection(GetConnection(rutaArchivo));
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();

            foreach (DataRow row in dtActivos.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            foreach (DataRow row in dtEstatuto.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            foreach (DataRow row in dtMando.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            foreach (DataRow row in dtJubilados.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }
                NFilas += 1;
            }

            con.Close();

            var ms = new System.IO.MemoryStream();
            archivoExcelDBF.Save();
            ms.WriteTo(ms);

            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Move(rutaArchivo + fileName + ".DBF", rutaDestino + "\\" + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Move(rutaArchivo + fileName + ".XLSX", rutaDestino + "\\" + fileName + ".XLSX");
            }
        }

        private void DataSetIntoDBF_Activos(string rutaDestino, string fileName, DataTable dtActivos, DataTable dtEstatuto, DataTable dtMando, ref string logError)
        {
            ArrayList list = new ArrayList();
            string rutaArchivo = System.Web.HttpContext.Current.Server.MapPath("~\\ArchivosDBF\\");
            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Delete(rutaArchivo + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Delete(rutaArchivo + fileName + ".XLSX");
            }

            FileInfo newFile = new FileInfo(rutaArchivo + fileName + ".XLSX");

            ExcelPackage archivoExcelDBF = new ExcelPackage(newFile);
            archivoExcelDBF.Workbook.Worksheets.Add(fileName.ToUpper());
            var hojaTrabajo = archivoExcelDBF.Workbook.Worksheets[fileName.ToUpper()];
            hojaTrabajo.CustomHeight = true;


            using (ExcelRange Rng = hojaTrabajo.Cells["A1:BA10000"])
            {
                Rng.Style.Font.SetFromFont(new Font("Calibri", 11));
                //Rng.Merge = true;
                //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Font.Bold = true;
                Rng.Style.Font.Size = 11;
                Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            using (ExcelRange Rng = hojaTrabajo.Cells["A1:ZZ"])
            {
                Rng.AutoFitColumns(100, 1000);
                Rng.Style.Font.Bold = true;
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 1])
            {
                CeldaDato.Value = "id";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 2])
            {
                CeldaDato.Value = "movimiento";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 3])
            {
                CeldaDato.Value = "atiprest";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 4])
            {
                CeldaDato.Value = "amatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 5])
            {
                CeldaDato.Value = "aconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 6])
            {
                CeldaDato.Value = "aimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 7])
            {
                CeldaDato.Value = "aplazo";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 8])
            {
                CeldaDato.Value = "acontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 9])
            {
                CeldaDato.Value = "anumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 10])
            {
                CeldaDato.Value = "apromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 11])
            {
                CeldaDato.Value = "accontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 12])
            {
                CeldaDato.Value = "atipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 13])
            {
                CeldaDato.Value = "anomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 14])
            {
                CeldaDato.Value = "anumprov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 15])
            {
                CeldaDato.Value = "acaracter";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 16])
            {
                CeldaDato.Value = "aup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 17])
            {
                CeldaDato.Value = "atipnomina";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 18])
            {
                CeldaDato.Value = "aaq";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 19])
            {
                CeldaDato.Value = "bnumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 20])
            {
                CeldaDato.Value = "bnomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 21])
            {
                CeldaDato.Value = "bmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 22])
            {
                CeldaDato.Value = "bup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 23])
            {
                CeldaDato.Value = "bimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 24])
            {
                CeldaDato.Value = "bimgstatus";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 25])
            {
                CeldaDato.Value = "ctipreg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 26])
            {
                CeldaDato.Value = "cconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 27])
            {
                CeldaDato.Value = "ctipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 28])
            {
                CeldaDato.Value = "cimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 29])
            {
                CeldaDato.Value = "crfc";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 30])
            {
                CeldaDato.Value = "cup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 31])
            {
                CeldaDato.Value = "cmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 32])
            {
                CeldaDato.Value = "cveadscrip";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 33])
            {
                CeldaDato.Value = "carearesp";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 34])
            {
                CeldaDato.Value = "cvigen";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 35])
            {
                CeldaDato.Value = "ctipcontra";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 36])
            {
                CeldaDato.Value = "cpromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 37])
            {
                CeldaDato.Value = "ccvedeleg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 38])
            {
                CeldaDato.Value = "imgorigin";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 39])
            {
                CeldaDato.Value = "imgvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 40])
            {
                CeldaDato.Value = "fvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 41])
            {
                CeldaDato.Value = "general";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 42])
            {
                CeldaDato.Value = "nomcarpaq";
            }

            int NFilas = 2;

            string createSql = "create table " + fileName + " (";
            createSql += "[id] VARCHAR(25) ";
            createSql += ",[movimiento] VARCHAR(20) ";
            createSql += ",[atiprest] INT ";
            createSql += ",[amatricula] VARCHAR(10) ";
            createSql += ",[aconcepto] INT ";
            createSql += ",[aimporte] FLOAT ";
            createSql += ",[aplazo] INT ";
            createSql += ",[acontrol] INT ";
            createSql += ",[anumpol] VARCHAR(8) ";
            createSql += ",[apromot] VARCHAR(4) ";
            createSql += ",[accontrol] INT ";
            createSql += ",[atipmov] VARCHAR(1) ";
            createSql += ",[anomtrabaj] VARCHAR(47) ";
            createSql += ",[anumprov] INT ";
            createSql += ",[acaracter] VARCHAR(1) ";
            createSql += ",[aup] VARCHAR(2) ";
            createSql += ",[atipnomina] VARCHAR(2) ";
            createSql += ",[aaq] VARCHAR(6) ";
            createSql += ",[bnumpol] VARCHAR(8) ";
            createSql += ",[bnomtrabaj] VARCHAR(100) ";
            createSql += ",[bmatricula] VARCHAR(10) ";
            createSql += ",[bup] VARCHAR(2) ";
            createSql += ",[bimporte] FLOAT ";
            createSql += ",[bimgstatus] VARCHAR(15) ";
            createSql += ",[ctipreg] INT ";
            createSql += ",[cconcepto] INT ";
            createSql += ",[ctipmov] INT ";
            createSql += ",[cimporte] FLOAT ";
            createSql += ",[crfc] VARCHAR(10) ";
            createSql += ",[cup] VARCHAR(2) ";
            createSql += ",[cmatricula] INT ";
            createSql += ",[cveadscrip] VARCHAR(10) ";
            createSql += ",[carearesp] VARCHAR(3) ";
            createSql += ",[cvigen] VARCHAR(2) ";
            createSql += ",[ctipcontra] INT ";
            createSql += ",[cpromot] VARCHAR(4) ";
            createSql += ",[ccvedeleg] INT ";
            createSql += ",[imgorigin] VARCHAR(254) ";
            createSql += ",[imgvincul] VARCHAR(254) ";
            createSql += ",[fvincul] DATE ";
            createSql += ",[general] VARCHAR(254) ";
            createSql += ",[nomcarpaq] VARCHAR(40)";
            createSql += ")";

            OleDbConnection con = new OleDbConnection(GetConnection(rutaArchivo));
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();

            foreach (DataRow row in dtActivos.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            foreach (DataRow row in dtEstatuto.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            foreach (DataRow row in dtMando.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            con.Close();

            var ms = new System.IO.MemoryStream();
            archivoExcelDBF.Save();
            ms.WriteTo(ms);

            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Move(rutaArchivo + fileName + ".DBF", rutaDestino + "\\" + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Move(rutaArchivo + fileName + ".XLSX", rutaDestino + "\\" + fileName + ".XLSX");
            }
        }

        private void DataSetIntoDBF(string rutaDestino, string fileName, DataTable dtEnlace, ref string logError)
        {
            ArrayList list = new ArrayList();
            string rutaArchivo = System.Web.HttpContext.Current.Server.MapPath("~\\ArchivosDBF\\");
            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Delete(rutaArchivo + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Delete(rutaArchivo + fileName + ".XLSX");
            }

            FileInfo newFile = new FileInfo(rutaArchivo + fileName + ".XLSX");

            ExcelPackage archivoExcelDBF = new ExcelPackage(newFile);
            archivoExcelDBF.Workbook.Worksheets.Add(fileName.ToUpper());
            var hojaTrabajo = archivoExcelDBF.Workbook.Worksheets[fileName.ToUpper()];
            hojaTrabajo.CustomHeight = true;
            
            using (ExcelRange Rng = hojaTrabajo.Cells["A1:BA10000"])
            {
                Rng.Style.Font.SetFromFont(new Font("Calibri", 11));
                //Rng.Merge = true;
                //Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Right.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Left.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Border.Top.Style = ExcelBorderStyle.Medium;
                //Rng.Style.Font.Bold = true;
                Rng.Style.Font.Size = 11;
                Rng.Style.Font.Color.SetColor(System.Drawing.ColorTranslator.FromHtml("#000000"));
                Rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                Rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#FFFFFF"));
                Rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                Rng.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }
            using (ExcelRange Rng = hojaTrabajo.Cells["A1:ZZ"])
            {
                Rng.AutoFitColumns(100,1000);
                Rng.Style.Font.Bold = true;
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 1])
            {
                CeldaDato.Value = "id";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 2])
            {
                CeldaDato.Value = "movimiento";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 3])
            {
                CeldaDato.Value = "atiprest";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 4])
            {
                CeldaDato.Value = "amatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 5])
            {
                CeldaDato.Value = "aconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 6])
            {
                CeldaDato.Value = "aimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 7])
            {
                CeldaDato.Value = "aplazo";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 8])
            {
                CeldaDato.Value = "acontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 9])
            {
                CeldaDato.Value = "anumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 10])
            {
                CeldaDato.Value = "apromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 11])
            {
                CeldaDato.Value = "accontrol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 12])
            {
                CeldaDato.Value = "atipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 13])
            {
                CeldaDato.Value = "anomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 14])
            {
                CeldaDato.Value = "anumprov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 15])
            {
                CeldaDato.Value = "acaracter";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 16])
            {
                CeldaDato.Value = "aup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 17])
            {
                CeldaDato.Value = "atipnomina";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 18])
            {
                CeldaDato.Value = "aaq";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 19])
            {
                CeldaDato.Value = "bnumpol";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 20])
            {
                CeldaDato.Value = "bnomtrabaj";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 21])
            {
                CeldaDato.Value = "bmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 22])
            {
                CeldaDato.Value = "bup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 23])
            {
                CeldaDato.Value = "bimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 24])
            {
                CeldaDato.Value = "bimgstatus";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 25])
            {
                CeldaDato.Value = "ctipreg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 26])
            {
                CeldaDato.Value = "cconcepto";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 27])
            {
                CeldaDato.Value = "ctipmov";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 28])
            {
                CeldaDato.Value = "cimporte";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 29])
            {
                CeldaDato.Value = "crfc";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 30])
            {
                CeldaDato.Value = "cup";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 31])
            {
                CeldaDato.Value = "cmatricula";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 32])
            {
                CeldaDato.Value = "cveadscrip";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 33])
            {
                CeldaDato.Value = "carearesp";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 34])
            {
                CeldaDato.Value = "cvigen";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 35])
            {
                CeldaDato.Value = "ctipcontra";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 36])
            {
                CeldaDato.Value = "cpromot";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 37])
            {
                CeldaDato.Value = "ccvedeleg";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 38])
            {
                CeldaDato.Value = "imgorigin";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 39])
            {
                CeldaDato.Value = "imgvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 40])
            {
                CeldaDato.Value = "fvincul";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 41])
            {
                CeldaDato.Value = "general";
            }
            using (ExcelRange CeldaDato = hojaTrabajo.Cells[1, 42])
            {
                CeldaDato.Value = "nomcarpaq";
            }

            int NFilas = 2;

            string createSql = "create table " + fileName + " (";
            createSql += "[id] VARCHAR(25) ";
            createSql += ",[movimiento] VARCHAR(20) ";
            createSql += ",[atiprest] INT ";
            createSql += ",[amatricula] VARCHAR(10) ";
            createSql += ",[aconcepto] INT ";
            createSql += ",[aimporte] FLOAT ";
            createSql += ",[aplazo] INT ";
            createSql += ",[acontrol] INT ";
            createSql += ",[anumpol] VARCHAR(8) ";
            createSql += ",[apromot] VARCHAR(4) ";
            createSql += ",[accontrol] INT ";
            createSql += ",[atipmov] VARCHAR(1) ";
            createSql += ",[anomtrabaj] VARCHAR(47) ";
            createSql += ",[anumprov] INT ";
            createSql += ",[acaracter] VARCHAR(1) ";
            createSql += ",[aup] VARCHAR(2) ";
            createSql += ",[atipnomina] VARCHAR(2) ";
            createSql += ",[aaq] VARCHAR(6) ";
            createSql += ",[bnumpol] VARCHAR(8) ";
            createSql += ",[bnomtrabaj] VARCHAR(100) ";
            createSql += ",[bmatricula] VARCHAR(10) ";
            createSql += ",[bup] VARCHAR(2) ";
            createSql += ",[bimporte] FLOAT ";
            createSql += ",[bimgstatus] VARCHAR(15) ";
            createSql += ",[ctipreg] INT ";
            createSql += ",[cconcepto] INT ";
            createSql += ",[ctipmov] INT ";
            createSql += ",[cimporte] FLOAT ";
            createSql += ",[crfc] VARCHAR(10) ";
            createSql += ",[cup] VARCHAR(2) ";
            createSql += ",[cmatricula] INT ";
            createSql += ",[cveadscrip] VARCHAR(10) ";
            createSql += ",[carearesp] VARCHAR(3) ";
            createSql += ",[cvigen] VARCHAR(2) ";
            createSql += ",[ctipcontra] INT ";
            createSql += ",[cpromot] VARCHAR(4) ";
            createSql += ",[ccvedeleg] INT ";
            createSql += ",[imgorigin] VARCHAR(254) ";
            createSql += ",[imgvincul] VARCHAR(254) ";
            createSql += ",[fvincul] DATE ";
            createSql += ",[general] VARCHAR(254) ";
            createSql += ",[nomcarpaq] VARCHAR(40)";
            createSql += ")";

            OleDbConnection con = new OleDbConnection(GetConnection(rutaArchivo));
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = createSql;
            cmd.ExecuteNonQuery();

            foreach (DataRow row in dtEnlace.Rows)
            {
                string insertSql = "INSERT INTO " + fileName + " VALUES(";
                insertSql += "'" + row["id"] + "'";
                insertSql += ",'" + row["movimiento"] + "'";
                insertSql += "," + row["atiprest"] + "";
                insertSql += ",'" + row["amatricula"] + "'";
                insertSql += "," + row["aconcepto"] + "";
                insertSql += ",'" + row["aimporte"] + "'";
                insertSql += "," + row["aplazo"] + "";
                insertSql += "," + row["acontrol"];
                insertSql += ",'" + row["anumpol"] + "'";
                insertSql += ",'" + row["apromot"] + "'";
                insertSql += "," + row["accontrol"];
                insertSql += ",'" + row["atipmov"] + "'";
                insertSql += ",'" + row["anomtrabaj"] + "'";
                insertSql += "," + row["anumprov"];
                insertSql += ",'" + row["acaracter"] + "'";
                insertSql += ",'" + row["aup"] + "'";
                insertSql += ",'" + row["atipnomina"] + "'";
                insertSql += ",'" + row["aaq"] + "'";
                insertSql += ",'" + row["bnumpol"] + "'";
                insertSql += ",'" + row["bnomtrabaj"] + "'";
                insertSql += ",'" + row["bmatricula"] + "'";
                insertSql += ",'" + row["bup"] + "'";
                insertSql += ",'" + row["bimporte"] + "'";
                insertSql += ",'" + row["bimgstatus"] + "'";
                insertSql += "," + row["ctipreg"];
                insertSql += "," + row["cconcepto"];
                insertSql += "," + row["ctipmov"];
                insertSql += ",'" + row["cimporte"] + "'";
                insertSql += ",'" + row["crfc"] + "'";
                insertSql += ",'" + row["cup"] + "'";
                insertSql += "," + row["cmatricula"] + "";
                insertSql += ",'" + row["cveadscrip"] + "'";
                insertSql += ",'" + row["carearesp"] + "'";
                insertSql += ",'" + row["cvigen"] + "'";
                insertSql += "," + row["ctipcontra"];
                insertSql += ",'" + row["cpromot"] + "'";
                insertSql += "," + row["ccvedeleg"];
                insertSql += ",'" + row["imgorigin"] + "'";
                insertSql += ",'" + row["imgvincul"] + "'";
                insertSql += ",'" + row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                insertSql += ",'" + row["general"] + "'";
                insertSql += ",'" + row["nomcarpaq"] + "'";
                insertSql += ")";
                cmd.CommandText = insertSql;
                cmd.ExecuteNonQuery();

                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 1])
                {
                    CeldaDato.Value = row["id"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 2])
                {
                    CeldaDato.Value = row["movimiento"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 3])
                {
                    CeldaDato.Value = row["atiprest"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 4])
                {
                    CeldaDato.Value = row["amatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 5])
                {
                    CeldaDato.Value = row["aconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 6])
                {
                    CeldaDato.Value = row["aimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 7])
                {
                    CeldaDato.Value = row["aplazo"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 8])
                {
                    CeldaDato.Value = row["acontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 9])
                {
                    CeldaDato.Value = row["anumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 10])
                {
                    CeldaDato.Value = row["apromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 11])
                {
                    CeldaDato.Value = row["accontrol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 12])
                {
                    CeldaDato.Value = row["atipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 13])
                {
                    CeldaDato.Value = row["anomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 14])
                {
                    CeldaDato.Value = row["anumprov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 15])
                {
                    CeldaDato.Value = row["acaracter"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 16])
                {
                    CeldaDato.Value = row["aup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 17])
                {
                    CeldaDato.Value = row["atipnomina"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 18])
                {
                    CeldaDato.Value = row["aaq"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 19])
                {
                    CeldaDato.Value = row["bnumpol"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 20])
                {
                    CeldaDato.Value = row["bnomtrabaj"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 21])
                {
                    CeldaDato.Value = row["bmatricula"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 22])
                {
                    CeldaDato.Value = row["bup"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 23])
                {
                    CeldaDato.Value = row["bimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 24])
                {
                    CeldaDato.Value = row["bimgstatus"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 25])
                {
                    CeldaDato.Value = row["ctipreg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 26])
                {
                    CeldaDato.Value = row["cconcepto"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 27])
                {
                    CeldaDato.Value = row["ctipmov"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 28])
                {
                    CeldaDato.Value = row["cimporte"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 29])
                {
                    CeldaDato.Value = row["crfc"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 30])
                {
                    CeldaDato.Value = row["cup"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 31])
                {
                    CeldaDato.Value = row["cmatricula"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 32])
                {
                    CeldaDato.Value = row["cveadscrip"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 33])
                {
                    CeldaDato.Value = row["carearesp"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 34])
                {
                    CeldaDato.Value = row["cvigen"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 35])
                {
                    CeldaDato.Value = row["ctipcontra"];
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 36])
                {
                    CeldaDato.Value = row["cpromot"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 37])
                {
                    CeldaDato.Value = row["ccvedeleg"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 38])
                {
                    CeldaDato.Value = row["imgorigin"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 39])
                {
                    CeldaDato.Value = row["imgvincul"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 40])
                {
                    CeldaDato.Value = row["fvincul"].ToString().Substring(3, 3) + row["fvincul"].ToString().Substring(0, 3) + row["fvincul"].ToString().Substring(8, 2) + "'";
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 41])
                {
                    CeldaDato.Value = row["general"].ToString();
                }
                using (ExcelRange CeldaDato = hojaTrabajo.Cells[NFilas, 42])
                {
                    CeldaDato.Value = row["nomcarpaq"].ToString();
                }

                NFilas += 1;
            }

            con.Close();

            var ms = new System.IO.MemoryStream();
            archivoExcelDBF.Save();
            ms.WriteTo(ms);


            if (File.Exists(rutaArchivo + fileName + ".DBF"))
            {
                File.Move(rutaArchivo + fileName + ".DBF", rutaDestino + "\\" + fileName + ".DBF");
            }

            if (File.Exists(rutaArchivo + fileName + ".XLSX"))
            {
                File.Move(rutaArchivo + fileName + ".XLSX", rutaDestino + "\\" + fileName + ".XLSX");
            }
        }

        private static string GetConnection(string path)
        {
            //return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=dBASE IV;";
            //return "Provider=Microsoft.Jet.OLEDB.12.0;Data Source=" + path + ";Extended Properties=dBASE IV;";
            return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=dBASE IV;";
        }

        public static string ReplaceEscape(string str)
        {
            str = str.Replace("'", "''");
            return str;
        }

        public static double GetTrueColumnWidth(double width)
        {
            //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
            double z = 1d;
            if (width >= (1 + 2 / 3))
            {
                z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
            }
            else
            {
                z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
            }

            //HOW FAR OFF? (WILL BE LESS THAN 1)
            double errorAmt = width - z;

            //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
            double adj = 0d;
            if (width >= (1 + 2 / 3))
            {
                adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
            }
            else
            {
                adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
            }

            //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
            if (z > 0)
            {
                return width + adj;
            }

            return 0d;
        }

        private void creararchivo()
        {
            //string fileName = @"C:\Temp\MaheshTX.txt";
            //try
            //{
            //    // Check if file already exists. If yes, delete it.     
            //    if (File.Exists(fileName))
            //    {
            //        File.Delete(fileName);
            //    }
            //    // Create a new file     
            //    using (StreamWriter sw = File.CreateText(fileName))
            //    {
            //        sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
            //        sw.WriteLine("Author: Mahesh Chand");
            //        sw.WriteLine("Add one more line ");
            //        sw.WriteLine("Add one more line ");
            //        sw.WriteLine("Done! ");
            //    }
            //    // Write file contents on console.     
            //    using (StreamReader sr = File.OpenText(fileName))
            //    {
            //        string s = "";
            //        while ((s = sr.ReadLine()) != null)
            //        {
            //            Console.WriteLine(s);
            //        }
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    Console.WriteLine(Ex.ToString());
            //}
        }
    }
}