using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using promotoria = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Procesos.SupervisionGeneral
{
    public partial class ConsultaTramite : Utilerias.Comun
    {
        //WFO_IMSSPortal.Negocio.Procesos.Operacion.TramiteProcesar Tramites = new WFO_IMSSPortal.Negocio.Procesos.Operacion.TramiteProcesar();
        //WFO_IMSSPortal.Negocio.Procesos.Promotoria.Archivos archivos = new Negocio.Procesos.Promotoria.Archivos();
        //WFO_IMSSPortal.Negocio.Procesos.Operacion.Bitacora bitacora = new Negocio.Procesos.Operacion.Bitacora();
        //WFO_IMSSPortal.Negocio.Procesos.Promotoria.Catalogos Catalogos = new Negocio.Procesos.Promotoria.Catalogos();
        //WFO_IMSSPortal.Negocio.Procesos.Operacion.Indicador_StatusMesas indicador = new Negocio.Procesos.Operacion.Indicador_StatusMesas();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["Procesable"]))
                hfIdTramite.Value = Request.QueryString["Procesable"].ToString();

            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(hfIdTramite.Value) > 0)
            {
                if (!IsPostBack)
                {
                    PostBack(int.Parse(hfIdTramite.Value));
                }
            }
        }

        private void PostBack(int pIdTramite)
        {
            // MUESTRA INFORMACION DEL TRÁMITE 
            PintaDatosTramite(pIdTramite);
        }

        private void PintaDatosTramite(int pIdTramite)
        {
            List<prop.TramiteProcesar> Tramite_a_Procesar;

            Tramite_a_Procesar = i.operacion.tramiteprocesar.ObtenerTramite(int.Parse(hfIdTramite.Value));
            if (Tramite_a_Procesar.Count > 0)
            {
                foreach (var datos in Tramite_a_Procesar)
                {
                    //TABLA INFORMATIVA 
                    InfoFechaRegistro.Text = datos.FechaRegistro.ToString();
                    List<promotoria.promotoria_usuario> Promotoria = i.promotoria.catalogos.Promotoria_Seleccionar_PorIdTramite(datos.IdPromotoria, datos.IdTramite);
                    for (int p = 0; p < Promotoria.Count; p++)
                    {
                        //TABLA INFORMATIVA 
                        InfoClave.Text = Promotoria[p].Clave;
                    }

                    LabelFolio.Text = datos.Folio;

                    // CARGA DE PDF
                    CargarPFD(datos.IdTramite);
                    hfIdTipoTramite.Value = datos.IdTipoTramite.ToString();
                    // CARGA BITACORA PÚBLICA
                    CargaBitacoraPublica(datos.IdTramite);

                    // CARGA BITACORA PRIVADA
                    CargaBitacoraPrivada(datos.IdTramite);

                    // CARGA ARCHIVOS EXPEDIENTES
                    CargaExpedientes(datos.IdTramite);

                    // INDICADOR STATUS MESAS
                    CargaIndicadorMesas(datos.IdTramite);
                }
            }
            else
            {
                mensajes.MostrarMensaje(this, "Trámite no disponibles...", "Pendientes.aspx");
            }
        }

        protected void BtnExpedienteOcultar_click(object sender, EventArgs e)
        {
            Expediente.Visible = false;
            LinkButtonMostrarExpediente.Visible = true;
            LinkButtonOcultarExpediente.Visible = false;
        }

        protected void BtnExpedienteAbrir_click(object sender, EventArgs e)
        {
            int IdTramite = Convert.ToInt32(hfIdTramite.Value);
            int IdTipoTramite = Convert.ToInt32(hfIdTipoTramite.Value);

            List<promotoria.expediente> expedientes = i.promotoria.archivos.ConsultaExpediente(IdTramite);
            string strDoctoWeb = "";
            string strDoctoServer = "";

            strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";

            if (expedientes.Count > 0)
            {
                foreach (promotoria.expediente oArchivo in expedientes)
                {
                    if (!string.IsNullOrEmpty(oArchivo.NmArchivo))
                    {
                        strDoctoWeb = "..\\..\\DocsUp\\" + oArchivo.NmArchivo;
                        strDoctoServer = Server.MapPath("~") + "\\DocsUp\\" + oArchivo.NmArchivo;
                        if (!File.Exists(strDoctoServer))
                        {
                            // AGREGAR ARCHIVO NO ENCONTRADO
                            strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";
                        }
                    }
                    else
                    {
                        // AGREGAR ARCHIVO NO ENCONTRADO
                        strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";
                    }
                }
            }

            string script = "window.open('" + strDoctoWeb.ToString().Replace("\\", "/") + "','Expediente', 'width = 600, height = 400');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }

        protected void BtnExpedienteMostrar_click(object sender, EventArgs e)
        {
            Expediente.Visible = true;
            LinkButtonMostrarExpediente.Visible = false;
            LinkButtonOcultarExpediente.Visible = true;
        }

        private void CargarPFD(int Id)
        {
            int IdTipoTramite = Convert.ToInt32(hfIdTipoTramite.Value);

            List<promotoria.expediente> expedientes = i.promotoria.archivos.ConsultaExpediente(Id);
            string strDoctoWeb = "";
            string strDoctoServer = "";

            strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";

            if (expedientes.Count > 0)
            {
                foreach (promotoria.expediente oArchivo in expedientes)
                {
                    if (!string.IsNullOrEmpty(oArchivo.NmArchivo))
                    {
                        strDoctoWeb = "..\\..\\DocsUp\\" + oArchivo.NmArchivo;
                        strDoctoServer = Server.MapPath("~") + "\\DocsUp\\" + oArchivo.NmArchivo;
                        if (!File.Exists(strDoctoServer))
                        {
                            // AGREGAR ARCHIVO NO ENCONTRADO
                            strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";
                        }
                    }
                    else
                    {
                        // AGREGAR ARCHIVO NO ENCONTRADO
                        strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";
                    }
                }
            }

            ltMuestraPdf.Text = "";
            ltMuestraPdf.Text = "<iframe src='" + strDoctoWeb + "' style='width:100%; height:540px' style='border: none;'></iframe>";
        }

        private void CargaBitacoraPublica(int Id)
        {
            List<promotoria.bitacora> bitacoras = i.operacion.bitacora.ConsultaBitacoraPublica(Id);
            rptBitacoraPublica.DataSource = bitacoras;
            rptBitacoraPublica.DataBind();
        }

        private void CargaBitacoraPrivada(int Id)
        {
            List<promotoria.bitacora> bitacoras = i.operacion.bitacora.ConsultaBitacoraPrivada(Id);
            rptBitacoraPrivada.DataSource = bitacoras;
            rptBitacoraPrivada.DataBind();
        }

        private void CargaIndicadorMesas(int Id)
        {
            List<prop.Indicador_StatusMesas> IndicadorDatos = i.operacion.indicadorstatusmesas.StatusMesas(Id);
            StatusMesa.DataSource = IndicadorDatos;
            StatusMesa.DataBind();
        }

        private void CargaExpedientes(int Id)
        {
            //List<promotoria.expediente> bitacoras = i.promotoria.archivos.Expediente_Consultar_PorIdTramite(Id);
            //rptExpedientes.DataSource = bitacoras;
            //rptExpedientes.DataBind();

            //Funciones.LlenarControles.LlenarRepeater(ref rptExpedientes, i.promotoria.archivos.Expediente_Consultar_PorIdTramite(Id));
            i.promotoria.archivos.Expediente_Consultar_PorIdTramite(ref rptExpedientes, Id);
        }

        protected void CargaExpedienteID(object sender, CommandEventArgs e)
        {
            int IdTramite = Convert.ToInt32(hfIdTramite.Value);
            int IdExpediente = Convert.ToInt32(e.CommandArgument.ToString());

            promotoria.expediente oArchivo = i.promotoria.archivos.Asegurados_Selecionar_PorIdTramite(IdExpediente, IdTramite);
            string strDoctoWeb = "";
            string strDoctoServer = "";

            strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";

            if (oArchivo.Id > 0)
            {

                if (!string.IsNullOrEmpty(oArchivo.NmArchivo))
                {
                    strDoctoWeb = "..\\..\\DocsUp\\" + oArchivo.NmArchivo;
                    strDoctoServer = Server.MapPath("~") + "\\DocsUp\\" + oArchivo.NmArchivo;
                    if (!File.Exists(strDoctoServer))
                    {
                        // AGREGAR ARCHIVO NO ENCONTRADO
                        strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";
                    }
                }
                else
                {
                    // AGREGAR ARCHIVO NO ENCONTRADO
                    strDoctoWeb = "..\\..\\ArchivosDefinitivos\\404.pdf";
                }
            }

            string script = "window.open('" + strDoctoWeb.ToString().Replace("\\", "/") + "','Expediente', 'width = 600, height = 400');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
    }
}