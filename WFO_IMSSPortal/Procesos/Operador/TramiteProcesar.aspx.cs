using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using promotoria = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
//using captura = WFO_IMSSPortal.Propiedades.Procesos.Operacion.Captura;
using DevExpress.Web.ASPxTreeList;
using System.IO;
//using DevExpress.Web;
//using System.Web.Configuration;

namespace WFO_IMSSPortal.Procesos.Operador
{
    public partial class TramiteProcesar : Utilerias.Comun
    {
        List<prop.TramiteProcesar> Tramite_a_Procesar;

        protected void Page_Init(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            hfIdMesa.Value = Request.QueryString["IdMesa"].ToString();
            if (!String.IsNullOrEmpty(Request.QueryString["Procesable"]))
                hfIdTramite.Value = Request.QueryString["Procesable"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MotivosSuspension();
            if (int.Parse(hfIdMesa.Value) > 0)
            {
                //if (!IsPostBack || int.Parse(hfIdTramite.Value) > 0)
                if (!IsPostBack)
                {
                    PostBack(int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario);
                }
            }
        }

        private void MostrarAdvertencia(string Titulo, string Mensaje)
        {
            string script = "";
            script = "AlertaObservacionesP('" + Titulo + "','" + Mensaje + "');";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            EjecutarScript(script);
        }

        private void MotivosSuspension()
        {
            i.operacion.motivossuspension.SeleccionarMotivosSuspension(ref treeListRechazo, ref treeListSuspender, int.Parse(Request.QueryString["IdMesa"].ToString()));
            //List<prop.MotivosSuspension> lsMotivosSuspension = i.operacion.motivossuspension.SelecionarMotivos(int.Parse(Request.QueryString["IdMesa"].ToString()));

            //treeListHold.ClearNodes();
            //treeListHold.DataSource = lsMotivosSuspension.Where(MotivoSuspension => lsMotivosSuspension.FirstOrDefault(valor => MotivoSuspension.IdTramiteTipoRechazo == 2) != null);           // SELECT * FROM cat_Tramite_RechazosTipos;
            //treeListHold.DataBind();
            //treeListHold.ExpandToLevel(3);

            //treeListSuspender.ClearNodes();
            //treeListSuspender.DataSource = lsMotivosSuspension.Where(MotivoSuspension => lsMotivosSuspension.FirstOrDefault(valor => MotivoSuspension.IdTramiteTipoRechazo == 3) != null);      // SELECT * FROM cat_Tramite_RechazosTipos;
            //treeListSuspender.DataBind();
            //treeListSuspender.ExpandToLevel(3);
        }

        private void PostBack(int pIdMesa, int IdUsuario)
        {
            // Permisos de Botones
            btnHold.OnClientClick = "ShowHold(); return false;";
            btnSuspender.OnClientClick = "ShowSuspender(); return false;";
            btnRechazar.OnClientClick = "ShowRechazar(); return false;";
            btnPausa.OnClientClick = "ShowPausa(); return false;";
            btnAceptarObs.OnClientClick = "ShowAceptarObs(); return false;";

            PintaMesa(pIdMesa, IdUsuario);
            VerificaTramiteDisponible(pIdMesa);
        }

        private void PintaMesa(int pIdMesa, int IdUsuario)
        {
            List <prop.Mesa> mesa = i.operacion.mesas.SelecionarMesasUsuarioMesa(IdUsuario, pIdMesa);
            if (mesa.Count > 0)
            {
                LabelNombreMesa.Text = "MESA - " + mesa[0].nombre;
                hfNombreMesa.Value = mesa[0].nombre;

                // ###Pendiente: Optimizar
                btnAceptar.Visible = false;
                btnAceptarObs.Visible = false;
                btnPCI.Visible = false;
                btnHold.Visible = false;
                btnSelccionCompleta.Visible = false;
                btnSuspender.Visible = false;
                btnRechazar.Visible = false;
                btnPausa.Visible = false;
                btnDetener.Visible = false;
                txtImporte.Visible = false;
                txtMatricula.Visible = false;
                txtUnidadPago.Visible = false;
                txtPoliza.Visible = false; txtPoliza.Text = "";

                lblImporte.Visible = true;
                lblMatricula.Visible = true;
                lblUnidadPago.Visible = true;

                switch (mesa[0].nombre)
                {
                    case "Revisión Cartas":
                    case "Control":
                    case "Audita Control":
                        btnAceptar.Visible =  btnSuspender.Visible = btnPausa.Visible = btnDetener.Visible = true;
                        blockEnviarAMEsa.Visible = false;
                        trFirma.Visible = true;
                        trIdentificacion.Visible = true;
                        trSumaAsegurada.Visible = true;
                        trImporte.Visible = true;
                        trSello.Visible = true;
                        trSelloPromo.Visible = true;
                        trMontoActual.Visible = true;
                        txtImporte.Visible = true;      lblImporte.Visible = false;
                        txtMatricula.Visible = true;    lblMatricula.Visible = false;
                        txtUnidadPago.Visible = true;   lblUnidadPago.Visible = false;

                        //btnAceptar.Enabled = false;
                        break;
                    
                    case "Captura en Portal":
                    case "Portal Interactivo":
                    case "Calidad":
                    case "Audita Calidad":
                        btnAceptarObs.Visible = btnRechazar.Visible = btnPausa.Visible = btnDetener.Visible = true;
                        blockEnviarAMEsa.Visible = true;
                        trFirma.Visible = false;
                        trIdentificacion.Visible = false;
                        trSumaAsegurada.Visible = false;
                        trImporte.Visible = false;
                        trSello.Visible = false;
                        trSelloPromo.Visible = false;
                        trMontoActual.Visible = false;
                        btnValidarCaptura.Visible = false;
                        txtPoliza.Visible = true;
                        break;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void VerificaTramiteDisponible(int pIdMesa)                                 
        {
            try
            {
                if (Convert.ToBoolean(Session["TramitesAutomaticos"]) == false)
                {
                    Response.Redirect("Default.aspx", true);
                    return;
                }
                Tramite_a_Procesar = i.operacion.tramiteprocesar.ObtenerTramite(manejo_sesion.Usuarios.IdUsuario, pIdMesa, int.Parse(hfIdTramite.Value));

                if (Tramite_a_Procesar.Count > 0)
                {
                    for (int ii = 0; ii < Tramite_a_Procesar.Count; ii++)
                    {
                        // COLOCA EL ID DEL TRAMITE PARA SER UTILIZADO DESPUES
                        hfIdTramite.Value = Tramite_a_Procesar[ii].IdTramite.ToString();
                        hfTipoTramite.Value = Tramite_a_Procesar[ii].IdTipoTramite.ToString();

                        LabelFlujo.Text = i.operacion.tramiteprocesar.ObtenerTipoTramite(Tramite_a_Procesar[ii].IdTramite).Nombre;
                        if (Int32.Parse(hfIdTramite.Value) <= 0)
                        {
                            Response.Redirect("Default.aspx?msj=1", true);
                        }
                        else
                        {
                            List <prop.Mesa> mesaToSend = i.operacion.mesas.ObtenerMesasToSend(int.Parse(hfIdTramite.Value), manejo_sesion.Usuarios.IdUsuario, pIdMesa);
                            if (mesaToSend.Count > 0)
                            {
                                //cboToSend.DataSource = mesaToSend;
                                //cboToSend.DataValueField = "Id";
                                //cboToSend.DataTextField = "nombre";
                                //cboToSend.DataBind();
                                Funciones.LlenarControles.LlenarDropDownList(ref cboToSend, mesaToSend, "Nombre", "Id");
                                cboToSend.Visible = true;
                            }

                            //TABLA INFORMATIVA 
                            // InfoFechaRegistro.Text = Tramite_a_Procesar[i].FechaRegistro.ToString();
                            List <promotoria.promotoria_usuario> Promotoria = i.promotoria.catalogos.Promotoria_Seleccionar_PorIdTramite(Tramite_a_Procesar[ii].IdPromotoria, Tramite_a_Procesar[ii].IdTramite);
                            for (int p = 0; p < Promotoria.Count; p++)
                            {
                                //TABLA INFORMATIVA  información de la promotoría
                                // InfoClave.Text = Promotoria[p].Clave;
                            }

                            // Cargamos los motivos de suspensión dependiendo el tipo de movimiento del trámite.
                            MotivosSuspension();

                            // Información del Trámite
                            LabelFolio.Text             = Tramite_a_Procesar[ii].Folio;
                            lblPoliza.Text              = Tramite_a_Procesar[ii].Poliza;
                            lblUnidadPago.Text          = Tramite_a_Procesar[ii].UnidadPago;
                            lblArchivo.Text             = Tramite_a_Procesar[ii].ArchivoNombre;
                            lblTipoNomina.Text          = Tramite_a_Procesar[ii].TipoNomina;
                            lblTipoMovimiento.Text      = Tramite_a_Procesar[ii].TipoMovimiento;
                            lblQuincena.Text            = Tramite_a_Procesar[ii].Quincena;
                            lblImporte.Text             = Tramite_a_Procesar[ii].Importe;
                            lblMatricula.Text           = Tramite_a_Procesar[ii].Matricula;
                            lblUsuarioServicio.Text     = Tramite_a_Procesar[ii].Usr_Servicio;
                            lblTrabjador.Text           = Tramite_a_Procesar[ii].Nombre_Trabajador;
                            lblPromOrigen.Text          = Tramite_a_Procesar[ii].Prom_Origen;
                            lblPromResponsable.Text     = Tramite_a_Procesar[ii].Prom_Respon;
                            lblPromoUltimoServicio.Text = Tramite_a_Procesar[ii].Prom_U_Serv;
                            lblStausConcentrado.Text    = Tramite_a_Procesar[ii].StatusConcentrado;


                            // CARGA DE PDF
                            CargarPFD(Tramite_a_Procesar[ii].IdTramite, Tramite_a_Procesar[ii].ArchivoNombre);

                            // CARGA BITACORA PÚBLICA
                            CargaBitacoraPublica(Tramite_a_Procesar[ii].IdTramite);

                            // CARGA BITACORA PRIVADA
                            CargaBitacoraPrivada(Tramite_a_Procesar[ii].IdTramite);

                            // CARGA ARCHIVOS EXPEDIENTES
                            CargaExpedientes(Tramite_a_Procesar[ii].IdTramite);
                        }
                    }
                }
                else
                {
                    mensajes.MostrarMensaje(this, "No hay trámites disponibles...", "Default.aspx");
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
                mensajes.MostrarMensaje(this, "Error al verificar el trámite disponible: " + ex.Message);
            }
        }

        #region Eventos Controles de Mesa Admision

        protected void TramiteActualizado(object sender, EventArgs e)
        {
            TramiteTerminado();
            Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        #endregion
        
        #region CARGA DE EXPEDIENTE E INSUMOS

        protected void CheckBox_Habilita_Insumos(object sender, EventArgs e)
        {
            if (CheckBoxInsumos.Checked.Equals(true))
            {
                PanelInsumos.Visible = true;
            }
            else
            {
                PanelInsumos.Visible = false;
            }
        }

        protected void btnSubirDocumento_Click(object sender, EventArgs e)
        {
            LabRespuestaArchivosCarga.Text = "";
            /* LISTA LOS ARCHIVOS DEL DOCUMENTO */
            List<promotoria.expediente> LstArchivosDocumento = new List<promotoria.expediente>();
            // SI EXISTE LA VARIABLE DE SESION LLENA LA LISTA
            if (Session["documentos"] != null)
            {
                LstArchivosDocumento = (List<promotoria.expediente>)Session["documentos"];
            }

            if (fileUpDocumento.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(fileUpDocumento.FileName).ToLower();
                string fileExtension2 = "";
                if (".pdf".Contains(fileExtension) ^ ".jpg".Contains(fileExtension) ^ ".png".Contains(fileExtension))
                {
                    int fileSize = fileUpDocumento.PostedFile.ContentLength;
                    promotoria.expediente expedientes = new promotoria.expediente();

                    if (fileSize < 41943040)
                    {
                        List<promotoria.control_archivos> control_Archivos = i.promotoria.archivos.ControlArchivoNuevoID();
                        int IdControlArchivo = control_Archivos[0].Id;
                        string nombreArchivo = IdControlArchivo.ToString().PadLeft(8, '0');
                        string directorioTemporal = Server.MapPath("~") + "\\DocsUp\\";

                        fileUpDocumento.PostedFile.SaveAs(directorioTemporal + nombreArchivo + fileExtension);

                        if (!fileExtension.Equals(".pdf"))
                        {
                            if (Funciones.ManejoArchivos.ConviertePDF(directorioTemporal + nombreArchivo + fileExtension, directorioTemporal + nombreArchivo + ".pdf"))
                            {
                                fileExtension2 = ".pdf";
                            }
                        }

                        fileExtension2 = ".pdf";

                        bool archivoEnPdf = false;
                        if (!fileExtension2.Equals(".pdf"))
                        {
                            archivoEnPdf = false;
                        }
                        else
                        {
                            nombreArchivo = nombreArchivo + fileExtension2;
                            archivoEnPdf = true;
                        }

                        if (archivoEnPdf)
                        {
                            expedientes.Id_Archivo = IdControlArchivo;
                            expedientes.NmArchivo = nombreArchivo;
                            expedientes.NmOriginal = fileUpDocumento.FileName;
                            expedientes.Activo = 1;
                            expedientes.Fusion = 0;
                            expedientes.Descripcion = "";

                            LstArchivosDocumento.Add(expedientes);
                            //lstDocumentos.DataSource = LstArchivosDocumento;
                            //lstDocumentos.DataValueField = "Id_Archivo";
                            //lstDocumentos.DataTextField = "NmOriginal";
                            //lstDocumentos.DataBind();

                            Funciones.LlenarControles.LlenarListBox(ref lstDocumentos, LstArchivosDocumento, "NmOriginal", "Id_Archivo");

                            Session["documentos"] = LstArchivosDocumento;
                            LabRespuestaArchivosCarga.Text = "Cargado";
                        }
                        else { LabRespuestaArchivosCarga.Text = "El archivo no se puede convertir a PDF."; }
                    }
                    else
                    {
                        LabRespuestaArchivosCarga.Text = "El archivo excede el límite de 40MB.";
                    }
                }
                else
                {
                    LabRespuestaArchivosCarga.Text = "El archivo no es un PDF o JPG.";
                }
            }
            else
            {
                LabRespuestaArchivosCarga.Text = "No ha cargado ningún tipo de archivo.";
            }
        }

        protected void btnEliminaDocumento_Click(object sender, EventArgs e)
        {
            if (lstDocumentos.Items.Count > 0 && lstDocumentos.SelectedIndex > -1)
            {
                List<promotoria.expediente> LstArchExpediente = new List<promotoria.expediente>();
                List<promotoria.expediente> LstArchExpedienteTmp = new List<promotoria.expediente>();
                if (Session["documentos"] != null)
                {
                    LstArchExpediente = (List<promotoria.expediente>)Session["documentos"];
                }
                int contador = 0;
                foreach (promotoria.expediente oArchivo in LstArchExpediente)
                {
                    if (contador != lstDocumentos.SelectedIndex)
                        LstArchExpedienteTmp.Add(oArchivo); 
                    contador += 1;
                }
                //lstDocumentos.DataSource = LstArchExpedienteTmp;
                //lstDocumentos.DataValueField = "Id";
                //lstDocumentos.DataTextField = "NmOriginal";
                //lstDocumentos.DataBind();
                Funciones.LlenarControles.LlenarListBox(ref lstDocumentos, LstArchExpedienteTmp, "NmOriginal", "Id");
                Session["documentos"] = LstArchExpedienteTmp;
            }
        }

        protected void btnSubirInsumo_Click(object sender, EventArgs e)
        {
            List<promotoria.insumos> LstArchivosInsumo = new List<promotoria.insumos>();
            if (Session["insumos"] != null)
                LstArchivosInsumo = (List<promotoria.insumos>)Session["insumos"];
            if (fileUpInsumo.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(fileUpInsumo.FileName).ToLower();
                promotoria.insumos oInsumo = new promotoria.insumos();
                int fileSize = fileUpInsumo.PostedFile.ContentLength;
                if (fileSize < 41943040)
                {
                    List<promotoria.control_archivos> control_Archivos = i.promotoria.archivos.ControlArchivoNuevoID();
                    int IdArchivo = control_Archivos[0].Id;
                    string nombreArchivo = IdArchivo.ToString().PadLeft(8, '0') + fileExtension;
                    string directorioTemporal = Server.MapPath("~") + "\\DocsInsumos\\";
                    fileUpInsumo.PostedFile.SaveAs(directorioTemporal + nombreArchivo);

                    oInsumo.Id_Archivo = IdArchivo;
                    oInsumo.NmArchivo = nombreArchivo;
                    oInsumo.NmOriginal = fileUpInsumo.FileName;
                    oInsumo.Activo = 1;
                    oInsumo.Descripcion = "";
                    oInsumo.RutaTemporal = directorioTemporal;

                    LstArchivosInsumo.Add(oInsumo);
                    //lstInsumos.DataSource = LstArchivosInsumo;
                    //lstInsumos.DataValueField = "Id";
                    //lstInsumos.DataTextField = "NmOriginal";
                    //lstInsumos.DataBind();

                    Funciones.LlenarControles.LlenarListBox(ref lstInsumos, LstArchivosInsumo, "NmOriginal", "Id");

                    Session["insumos"] = LstArchivosInsumo;
                    MensajeInsumos.Text = "Cargado";
                }
                else
                {
                    MensajeInsumos.Text = "El archivo excede el límite de 40MB.";
                }
            }
            else
            {
                MensajeInsumos.Text = "No has seleccionado un archivo";
            }
        }

        protected void btnEliminaInsumo_Click(object sender, EventArgs e)
        {
            if (lstInsumos.Items.Count > 0 && lstInsumos.SelectedIndex > -1)
            {
                List<promotoria.insumos> LstArchInsumos = new List<promotoria.insumos>();
                List<promotoria.insumos> LstArchInsumosTmp = new List<promotoria.insumos>();
                if (Session["insumos"] != null)
                {
                    LstArchInsumos = (List<promotoria.insumos>)Session["insumos"];
                }
                int contador = 0;
                foreach (promotoria.insumos oInsumo in LstArchInsumos)
                {
                    if (contador != lstInsumos.SelectedIndex)
                        LstArchInsumosTmp.Add(oInsumo); 
                    contador += 1;
                }
                //lstInsumos.DataSource = LstArchInsumosTmp;
                //lstInsumos.DataValueField = "Id";
                //lstInsumos.DataTextField = "NmOriginal";
                //lstInsumos.DataBind();
                Funciones.LlenarControles.LlenarListBox(ref lstInsumos, LstArchInsumosTmp, "NmOriginal", "Id");
                Session["insumos"] = LstArchInsumosTmp;
            }
        }

        private string registraDocumentosExpediente(int pIdTramite, int TipoTramite)
        {
            string msgError = "";
            string strRutaServidor = "";
            string strArchivoOrigen = "";

            string directorioTemporal = Server.MapPath("~") + "\\DocsUp\\";

            List<promotoria.expediente> LstExpediente = new List<promotoria.expediente>();
            if (Session["documentos"] != null)
            {
                LstExpediente = (List<promotoria.expediente>)Session["documentos"];
            }

            List<string> lstArchivos = new List<string>();
            foreach (promotoria.expediente oDocumento in LstExpediente)
            {
                strArchivoOrigen = Server.MapPath("~") + "\\DocsUp\\" + oDocumento.NmArchivo;
                if (File.Exists(strArchivoOrigen))
                {
                    i.promotoria.archivos.Agregar_Expedientes_Tramite(TipoTramite, pIdTramite, oDocumento.Id_Archivo, oDocumento.NmArchivo, oDocumento.NmOriginal, oDocumento.Activo, oDocumento.Fusion, oDocumento.Descripcion);
                    lstArchivos.Add(strArchivoOrigen);
                }
            }

            // CONSULTA ID DEL EXPEDIENTE FUSIONADO
            List<promotoria.expediente> expedientes = i.promotoria.archivos.ConsultaExpediente(pIdTramite);
            string ArchFusionAnt = "";
            int Id_Expediente = 0;
            if (expedientes.Count > 0)
            {
                ArchFusionAnt = directorioTemporal + expedientes[0].NmArchivo;
                Id_Expediente = expedientes[0].Id;
            }

            List<promotoria.control_archivos> control_Archivos = i.promotoria.archivos.ControlArchivoNuevoID();
            int IdControlArchivo = control_Archivos[0].Id;
            string nombreFusion = directorioTemporal + IdControlArchivo.ToString().PadLeft(8, '0') + ".pdf";
            if (File.Exists(nombreFusion))
            {
                File.Delete(nombreFusion);
            }

            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            string nmSeparador = directorioTemporal + manejo_sesion.Usuarios.IdUsuario + ".pdf";
            string nmLogo = Server.MapPath("~\\Imagenes") + @"\logo_sep.png";

            msgError = Funciones.ManejoArchivos.Adiciona(lstArchivos, ArchFusionAnt, nombreFusion, manejo_sesion.Usuarios.Nombre, nmSeparador, nmLogo);

            if (string.IsNullOrEmpty(msgError))
            {
                i.promotoria.archivos.ModificarExpedienteFusion(Id_Expediente);
                i.promotoria.archivos.Agregar_Expedientes_Tramite(TipoTramite, pIdTramite, IdControlArchivo, IdControlArchivo.ToString().PadLeft(8, '0') + ".pdf", "Archivo Fucion Agrgacion", 1, 1, "");
                msgError = "";
            }
            else
            {
                Mensajes.Text = msgError;
            }

            return msgError;
        }

        private string registraDocumentosInsumos(int pIdTramite, int TipoTramite)
        {
            List<promotoria.insumos> LstArchivosInsumo = new List<promotoria.insumos>();
            if (Session["insumos"] != null)
            {
                LstArchivosInsumo = (List<promotoria.insumos>)Session["insumos"];
            }

            string strArchivoOrigen = "";

            foreach (promotoria.insumos oDocumento in LstArchivosInsumo)
            {
                strArchivoOrigen = Server.MapPath("~") + "\\DocsInsumos\\" + oDocumento.NmArchivo;

                if (File.Exists(strArchivoOrigen))
                {
                    i.promotoria.archivos.Agregar_Insumo_Tramite(TipoTramite, pIdTramite, oDocumento.Id_Archivo, oDocumento.NmArchivo, oDocumento.NmOriginal, oDocumento.Activo, oDocumento.Descripcion);
                }
            }

            return "";
        }

        #endregion

        private void CargaBitacoraPublica(int Id)
        {
            //List<promotoria.bitacora> bitacoras = i.operacion.bitacora.ConsultaBitacoraPublica(Id);
            //rptBitacoraPublica.DataSource = bitacoras;
            //rptBitacoraPublica.DataBind();

            Funciones.LlenarControles.LlenarRepeater(ref rptBitacoraPublica, i.operacion.bitacora.ConsultaBitacoraPublica(Id));
        }

        private void CargaBitacoraPrivada(int Id)
        {
            //List<promotoria.bitacora> bitacoras = i.operacion.bitacora.ConsultaBitacoraPrivada(Id);
            //rptBitacoraPrivada.DataSource = bitacoras;
            //rptBitacoraPrivada.DataBind();

            Funciones.LlenarControles.LlenarRepeater(ref rptBitacoraPrivada, i.operacion.bitacora.ConsultaBitacoraPrivada(Id));
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
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            EjecutarScript(script);
        }

        private void CargarPFD(int Id, string Archivo)
        {
            //Procedimientos para visualizar un PDF
            string ToSaveFileTo = Server.MapPath("~" + "//PDF//" + Archivo);
            ltMuestraPdf.Text = "";

            if (File.Exists(ToSaveFileTo))
            {
                if (Archivo == "CartaBaja.PDF")
                {
                    hfArchivoNombre.Value = Server.MapPath("~" + "//PDF//" + Archivo);
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + Archivo + "' style='width:100%; height:100%' type='application/pdf'>";
                }
                else
                {
                    hfArchivoNombre.Value = Server.MapPath("~" + "//PDF//" + Archivo.Substring(0, 20) + ".pdf");
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + Archivo + "' style='width:100%; height:100%' type='application/pdf'>";
                }
            }
            else
            {
                if (File.Exists(Server.MapPath("~" + "//PDF//" + Archivo.Substring(0, 20) + ".pdf")))
                {
                    hfArchivoNombre.Value = Server.MapPath("~" + "//PDF//" + Archivo.Substring(0, 20) + ".pdf");
                    ltMuestraPdf.Text = "<embed src='..\\..\\PDF\\" + Archivo.Substring(0, 20) + ".pdf" + "' style='width:100%; height:100%' type='application/pdf'>";
                }
                else
                {
                    log.Agregar(" ==> Archivo no econtrado: " + ToSaveFileTo.ToString());
                    ltMuestraPdf.Text = "<embed src='..\\..\\ArchivosDefinitivos\\404.pdf' style='width:100%; height:100%' type='application/pdf'>";
                }
            }
        }

        protected void BtnExpedienteAbrir_click(object sender, EventArgs e)
        {
            int IdTramite = Convert.ToInt32(hfIdTramite.Value);
            int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());

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
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            EjecutarScript(script);
        }

        protected void btnSendToMesa_Click(object sender, EventArgs e)
        {
            if (cboToSend.SelectedIndex != -1)
            {
                int IdMesaToSend = int.Parse(cboToSend.SelectedValue.ToString());
                int IdMesa = int.Parse(hfIdMesa.Value.ToString());
                int IdTramite = int.Parse(hfIdTramite.Value.ToString());
                int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());

                string observaciones = txtObservacionesPrivadas.Text.ToString().Trim();

                List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado =  i.operacion.tramiteprocesar.EnviarTramite(IdTramite, IdMesa, IdMesaToSend, manejo_sesion.Usuarios.IdUsuario, observaciones, "");
                if (objResultado[0].IdTramite > 0)
                {
                    // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                    if (Session["documentos"] != null)
                    {
                        string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                    }
                    if (Session["insumos"] != null)
                    {
                        string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                    }

                    /*
                    string script = "";
                    script = "$('#myModal').modal({backdrop: 'static', keyboard: false});";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                    TituloModal.Text = "Operación realizada";
                    MensajeModal.Text = objResultado[0].Accion;
                    */

                    TramiteTerminado();
                    Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
                }
            }
        }

        protected void btnAceptarSeleccionCompleta_Click(object sender, EventArgs e)
        {
            Funciones.VariablesGlobales.StatusMesa IdStatusMesaProcesado = Funciones.VariablesGlobales.StatusMesa.SeleccionCompleta;
            int IdTramite = Int32.Parse(hfIdTramite.Value);

            //switch (hfNombreMesa.Value.ToString())
            //{
            //    case "EJECUCIÓN":
            //        int resultado2 = Tramites.ActualizaPolizaSistemasLegados(IdTramite, manejo_sesion.Usuarios.IdUsuario, TextNumPolizaSisLegado.Text);
            //        break;
            //    case "KWIK":
            //        int resultado = Tramites.ActualizaKwik(IdTramite, manejo_sesion.Usuarios.IdUsuario, TextNumKwik.Text);
            //        break;

            //    default:
            //        break;
            //}

            
            List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesaProcesado, "", txtObservacionesPrivadas.Text, "", "", txtPoliza.Text.Trim());
            if (objResultado[0].IdTramite > 0)
            {
                int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());
                // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                if (Session["documentos"] != null)
                {
                    string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                }
                if (Session["insumos"] != null)
                {
                    string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                }
                if (objResultado[0].Accion == "KO")
                {
                    int IdMesa = int.Parse(hfIdMesa.Value.ToString());
                }
                TramiteTerminado();
                Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
            }
        }

        protected void btnCtrlAceptarTramite_Click(object sender, EventArgs e)
        {
            bool blnValidacionCheckBox = true;
            if ((chkEnviar.Checked == true && chkEnviarNo.Checked == true) || (chkEnviar.Checked == false && chkEnviarNo.Checked == false))
            {
                MostrarAdvertencia("Validación", "No se ha indicado el procesamiento para el trámite.");
            }
            else
            {
                if (
                    CheckBox0.Checked == false
                    || CheckBox1.Checked == false
                    || CheckBox2.Checked == false
                    || CheckBox3.Checked == false
                    || CheckBox4.Checked == false
                    || CheckBox5.Checked == false
                    || CheckBox6.Checked == false
                    //|| CheckBox7.Checked == false
                    //|| CheckBox8.Checked == false
                    //|| CheckBox9.Checked == false
                    //|| CheckBox10.Checked == false
                    || CheckBox11.Checked == false
                    || CheckBox12.Checked == false
                    //|| CheckBox13.Checked == false
                    //|| CheckBox14.Checked == false
                    //|| CheckBox15.Checked == false
                    || CheckBox17.Checked == false
                    || CheckBox18.Checked == false
                    || CheckBox19.Checked == false
                    || CheckBox20.Checked == false
                    || txtObservacionesPublicasAceptar.Text.Trim().Length == 0
                    )
                {
                    blnValidacionCheckBox = false;

                    if (hfIdMesa.Value.ToString() == "28" || hfIdMesa.Value.ToString() == "30" || hfIdMesa.Value.ToString() == "103")
                    {
                        blnValidacionCheckBox = true;
                    }
                    else
                    {
                        MostrarAdvertencia("Validación", "No se realizó la validación de los datos del trámite.");
                    }
                }

                
                if (hfIdMesa.Value.ToString() == "28" || hfIdMesa.Value.ToString() == "30" || hfIdMesa.Value.ToString() == "103")
                {
                    txtPoliza.Text = txtPoliza.Text.Trim();
                    int cantidadDigitosPoliza = int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PolizaDigitos"].ToString());
                    if (txtPoliza.Text.Trim().Length < cantidadDigitosPoliza)
                    {
                        blnValidacionCheckBox = false;
                        MostrarAdvertencia("Validación", "No se capturó la PÓLIZA proveniente de portal. Capturar la póliza tal cual aparecen en el Portal del IMSS");
                    }
                    else
                    {
                        string ExtraccionPoliza = lblPoliza.Text.Trim().Substring(lblPoliza.Text.Length - cantidadDigitosPoliza, cantidadDigitosPoliza);
                        string PortalPoliza = txtPoliza.Text.Trim().Substring(txtPoliza.Text.Length - cantidadDigitosPoliza, cantidadDigitosPoliza);
                        if (PortalPoliza != ExtraccionPoliza)
                        {
                            blnValidacionCheckBox = false;
                            MostrarAdvertencia("Validación", "La PÓLIZA no corresponde con Extracción. Capturar la póliza tal cual aparecen en el Portal del IMSS");
                        }
                    }
                }

                if (blnValidacionCheckBox)
                {
                    Funciones.VariablesGlobales.StatusMesa IdStatusMesaProcesado = Funciones.VariablesGlobales.StatusMesa.Procesado;
                    int IdTramite = Int32.Parse(hfIdTramite.Value);

                    if (chkEnviarNo.Checked == true)
                    {
                        int resultado = i.operacion.tramiteprocesar.AgregarInteractivo(IdTramite);
                    }

                    List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesaProcesado, txtObservacionesPublicasAceptar.Text, txtObservacionesPrivadas.Text, "", "", txtPoliza.Text.Trim());
                    if (objResultado[0].IdTramite > 0)
                    {
                        int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());
                        // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                        if (Session["documentos"] != null)
                        {
                            string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                        }
                        if (Session["insumos"] != null)
                        {
                            string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                        }
                        if (objResultado[0].Accion == "KO")
                        {
                            int IdMesa = int.Parse(hfIdMesa.Value.ToString());
                        }
                        TramiteTerminado();
                        Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
                    }
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string strObservaciones = "";
            bool blnError = false;
            Funciones.VariablesGlobales.StatusMesa IdStatusMesaProcesado = Funciones.VariablesGlobales.StatusMesa.Procesado;
            int IdTramite = Int32.Parse(hfIdTramite.Value);

            switch (hfNombreMesa.Value.ToString())
            {
                case "Revisión Cartas":
                case "Control":
                    if (
                            CheckBox0.Checked == false
                            || CheckBox1.Checked == false
                            || CheckBox2.Checked == false
                            || CheckBox3.Checked == false
                            || CheckBox4.Checked == false
                            || CheckBox5.Checked == false
                            || CheckBox6.Checked == false
                            || CheckBox7.Checked == false
                            || CheckBox8.Checked == false
                            || CheckBox9.Checked == false
                            || CheckBox10.Checked == false
                            || CheckBox11.Checked == false
                            || CheckBox12.Checked == false
                            || CheckBox13.Checked == false
                            || CheckBox14.Checked == false
                            || CheckBox15.Checked == false
                            || CheckBox17.Checked == false
                            || CheckBox18.Checked == false
                            || CheckBox19.Checked == false
                            || CheckBox20.Checked == false
                        )
                    {
                        blnError = true;
                    }
                    break;
                    
                case "Captura en Portal":
                case "Portal Interactivo":
                    if (
                            CheckBox0.Checked == false
                            || CheckBox1.Checked == false
                            || CheckBox2.Checked == false
                            || CheckBox3.Checked == false
                            || CheckBox4.Checked == false
                            || CheckBox5.Checked == false
                            || CheckBox6.Checked == false
                            //                            || CheckBox7.Checked == false
                            //                            || CheckBox8.Checked == false
                            //                            || CheckBox9.Checked == false
                            //                            || CheckBox10.Checked == false
                            || CheckBox11.Checked == false
                            || CheckBox12.Checked == false
                            //                            || CheckBox13.Checked == false
                            //                            || CheckBox14.Checked == false
                            //                            || CheckBox15.Checked == false
                            || CheckBox17.Checked == false
                            || CheckBox18.Checked == false
                            || CheckBox19.Checked == false
                            || CheckBox20.Checked == false
                        )
                    {
                        blnError = true;
                    }
                    break;

                default:
                    break;
            }

            if (!blnError)
            {
                bool blnValidaImporte = false;
                double dblImporte = 0.00;
                double dblExtraccionImporte = 0.00;
                string strImporte = "";

                //string strPolizaPortal = string.Empty;
                //strPolizaPortal = txtPoliza.Text.Trim();

                //if (lblPoliza.Text != strPolizaPortal)
                //{
                //    txtPoliza.BackColor = System.Drawing.Color.Red;
                //    txtPoliza.ForeColor = System.Drawing.Color.White;
                //    txtPoliza.Font.Bold = true;
                //    MostrarAdvertencia("Validación", "Validación de Póliza Incorrecta.");
                //    return;
                //}
                //else
                //{
                //    txtPoliza.BackColor = System.Drawing.Color.White;
                //    txtPoliza.ForeColor = System.Drawing.Color.Black;
                //    txtPoliza.Font.Bold = false;
                //}

                dblExtraccionImporte = double.Parse(lblImporte.Text.Trim());
                blnValidaImporte = double.TryParse(txtImporte.Text.Trim(), out dblImporte);
                if (blnValidaImporte)
                {
                    if (dblImporte > 0
                        && dblImporte >= (dblExtraccionImporte * .90)
                        && dblImporte <= (dblExtraccionImporte * 1.10)
                    )
                    {
                        blnValidaImporte = true;
                        strImporte = string.Format("{0:0.00}", dblImporte);

                        txtImporte.BackColor = System.Drawing.Color.White;
                        txtImporte.ForeColor = System.Drawing.Color.Black;
                        txtImporte.Font.Bold = false;

                    }
                    else
                    {
                        blnValidaImporte = false;
                        txtImporte.BackColor = System.Drawing.Color.Red;
                        txtImporte.ForeColor = System.Drawing.Color.White;
                        txtImporte.Font.Bold = true;
                    }
                }

                if (lblUnidadPago.Text.Trim().Length == 2)
                {
                    if (txtUnidadPago.Text.Trim().Substring(1, 2) != lblUnidadPago.Text.Trim())
                    {
                        blnValidaImporte = true;
                        blnValidaImporte = false;
                        txtUnidadPago.BackColor = System.Drawing.Color.Red;
                        txtUnidadPago.ForeColor = System.Drawing.Color.White;
                        txtUnidadPago.Font.Bold = true;
                    }
                    else
                    {
                        txtUnidadPago.BackColor = System.Drawing.Color.White;
                        txtUnidadPago.ForeColor = System.Drawing.Color.Black;
                        txtUnidadPago.Font.Bold = false;
                    }
                }
                else
                {
                    if (txtUnidadPago.Text.Trim() != lblUnidadPago.Text.Trim())
                    {
                        blnValidaImporte = true;
                        blnValidaImporte = false;
                        txtUnidadPago.BackColor = System.Drawing.Color.Red;
                        txtUnidadPago.ForeColor = System.Drawing.Color.White;
                        txtUnidadPago.Font.Bold = true;
                    }
                    else
                    {
                        txtUnidadPago.BackColor = System.Drawing.Color.White;
                        txtUnidadPago.ForeColor = System.Drawing.Color.Black;
                        txtUnidadPago.Font.Bold = false;
                    }
                }

                if (txtMatricula.Text.Trim() != lblMatricula.Text.Trim())
                {
                    blnValidaImporte = false;
                    txtMatricula.BackColor = System.Drawing.Color.Red;
                    txtMatricula.ForeColor = System.Drawing.Color.White;
                    txtMatricula.Font.Bold = true;
                }
                else
                {
                    txtMatricula.BackColor = System.Drawing.Color.White;
                    txtMatricula.ForeColor = System.Drawing.Color.Black;
                    txtMatricula.Font.Bold = false;
                }

                if (blnValidaImporte)
                {
                    // Agregamos la información capturada.
                    strObservaciones = "[";
                    strObservaciones += "IMPORTE : " + txtImporte.Text.Trim() ;
                    strObservaciones += "|| MATRICULA : " + txtMatricula.Text.Trim();
                    strObservaciones += "|| U. PAGO : " + txtUnidadPago.Text.Trim();
                    strObservaciones += "] " + txtObservacionesPrivadas.Text.Trim();

                    List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesaProcesado, "", strObservaciones, "", strImporte, txtPoliza.Text.Trim());
                    if (objResultado[0].IdTramite > 0)
                    {
                        int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());
                        
                        // REGISTRO DE ARCHIVOS - COLOCAR DESPUEHAYQUE HACER TIEPO PARA PODER VER MÁS VIDEOSS DE ACTUALIZAR EL TRAMITE
                        if (Session["documentos"] != null)
                        {
                            string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                        }
                        if (Session["insumos"] != null)
                        {
                            string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                        }
                        if (objResultado[0].Accion == "KO")
                        {
                            int IdMesa = int.Parse(hfIdMesa.Value.ToString());
                        }

                        if (File.Exists(hfArchivoNombre.Value))
                        {
                            File.Copy(hfArchivoNombre.Value, hfArchivoNombre.Value.ToString().Replace(".pdf", "_" + strImporte.Replace(".", "-") + ".pdf"), true);
                            //File.Delete(hfArchivoNombre.Value.ToString());
                        }

                        TramiteTerminado();
                        Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
                    }
                }
                else
                {
                    MostrarAdvertencia("Validación", "Validación de Carta Incorrecta.");
                    return;
                }
            }
            else
            {
                MostrarAdvertencia("Validación", "No se han realizado todas las validaciones necesarias.");
                //mensajes.MostrarMensaje(this, "No se han realizado todas las validaciones necesarias.");
                return;
            }
        }

        protected void btnPCI_Click(object sender, EventArgs e)
        {            
            Funciones.VariablesGlobales.StatusMesa IdStatusMesa = Funciones.VariablesGlobales.StatusMesa.PCI;
            int IdTramite = Int32.Parse(hfIdTramite.Value);
            int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());

            List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesa, txtObservacionesPublicasHold.Text.Trim(), txtObservacionesPrivadas.Text, "", "", txtPoliza.Text.Trim());
            if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "LimpiarForm();", true);
            }

            if (objResultado[0].IdTramite > 0)
            {
                // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                if (Session["documentos"] != null)
                {
                    string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                }
                if (Session["insumos"] != null)
                {
                    string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                }

                if (objResultado[0].Accion == "KO")
                {
                    int IdMesa = int.Parse(hfIdMesa.Value.ToString());
                }
                Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
            }
        }

        protected void btnAplicarHold_Click(object sender, EventArgs e)
        {
            var nodos = treeListHold.GetSelectedNodes();
            int IdMotivoRechazo = 0;
            string MotivosRechazos = "";

            if (nodos.Count > 0)
            {
                if (txtObservacionesPublicasHold.Text.Length > 0)
                {
                    MotivosRechazos = "";
                    foreach (TreeListNode node in nodos)
                    {
                        IdMotivoRechazo = Convert.ToInt32(node.GetValue("id"));
                        if (MotivosRechazos.Length > 0)
                            MotivosRechazos += ",";
                        MotivosRechazos += IdMotivoRechazo.ToString();

                        //intMotivo = Convert.ToInt32(node.GetValue("id"));
                        //oAdmTramiteRechazo.nuevoMotivo(oTramiteRechazo.Id, intMotivo);
                        //oAdmTramiteMesa.registraIdRechazo(oTramiteMesa.Id, oTramiteRechazo.Id);
                    }

                    treeListHold.UnselectAll();

                    Funciones.VariablesGlobales.StatusMesa IdStatusMesa = Funciones.VariablesGlobales.StatusMesa.Hold;
                    int IdTramite = Int32.Parse(hfIdTramite.Value);
                    int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());

                    List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesa, txtObservacionesPublicasHold.Text.Trim(), txtObservacionesPrivadas.Text, MotivosRechazos, "", txtPoliza.Text.Trim());
                    if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "LimpiarForm();", true);
                    }

                    if (objResultado[0].IdTramite > 0)
                    {
                        // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                        if (Session["documentos"] != null) { string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite); }
                        if (Session["insumos"] != null) { string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite); }

                        string script = "";
                        script = "pnlPopMotivosHold.Hide(); $('#myModal').modal({backdrop: 'static', keyboard: false}); ";
                        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        EjecutarScript(script);

                        //Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
                    }
                }
                else
                {
                    string script = "";
                    script = "AlertaObservaciones();";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    EjecutarScript(script);
                }
            }
            else
            {
                string script = "";
                script = "AlertaMotivosHold();";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                EjecutarScript(script);

                // mensajes.MostrarMensaje(this, "Debe seleccionar al menos un motivo Hold.");
            }
        }

        protected void btnValidarCaptura_Click(object sender, EventArgs e)
        {
            bool _error = false;


            if (txtUnidadPago.Text.Trim().Length != 3)
            {
                _error = true;
                txtUnidadPago.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                txtUnidadPago.BackColor = System.Drawing.Color.White;
            }

            if (txtMatricula.Text.Trim().Length != 10)
            {
                _error = true;
                txtMatricula.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                txtMatricula.BackColor = System.Drawing.Color.White;
            }

            if (txtImporte.Text.Trim().Length == 0)
            {
                _error = true;
                txtImporte.BackColor = System.Drawing.Color.Orange;
            }
            else
            {
                txtImporte.BackColor = System.Drawing.Color.White;
            }

            if (_error)
            {
                return;
            }

            _error = false;
            bool blnValidaImporte = false;
            double dblImporte = 0.00;
            double dblExtraccionImporte = 0.00;
            string strImporte = "";

            dblExtraccionImporte = double.Parse(lblImporte.Text.Trim());
            blnValidaImporte = double.TryParse(txtImporte.Text.Trim(), out dblImporte);
            if (blnValidaImporte)
            {
                if (dblImporte > 0
                    && dblImporte >= (dblExtraccionImporte * .90)
                    && dblImporte <= (dblExtraccionImporte * 1.10)
                )
                {
                    blnValidaImporte = true;
                    strImporte = string.Format("{0:0.00}", dblImporte);

                    txtImporte.BackColor = System.Drawing.Color.White;
                    txtImporte.ForeColor = System.Drawing.Color.Black;
                    txtImporte.Font.Bold = false;

                }
                else
                {
                    _error = true;
                    blnValidaImporte = false;
                    txtImporte.BackColor = System.Drawing.Color.Red;
                    txtImporte.ForeColor = System.Drawing.Color.White;
                    txtImporte.Font.Bold = true;
                }
            }


            if (lblUnidadPago.Text.Trim().Length == 2)
            {
                if (txtUnidadPago.Text.Trim().Substring(1,2) != lblUnidadPago.Text.Trim())
                {
                    _error = true;
                    blnValidaImporte = false;
                    txtUnidadPago.BackColor = System.Drawing.Color.Red;
                    txtUnidadPago.ForeColor = System.Drawing.Color.White;
                    txtUnidadPago.Font.Bold = true;
                }
                else
                {
                    txtUnidadPago.BackColor = System.Drawing.Color.White;
                    txtUnidadPago.ForeColor = System.Drawing.Color.Black;
                    txtUnidadPago.Font.Bold = false;
                }
            }
            else
            {
                if (txtUnidadPago.Text.Trim() != lblUnidadPago.Text.Trim())
                {
                    _error = true;
                    blnValidaImporte = false;
                    txtUnidadPago.BackColor = System.Drawing.Color.Red;
                    txtUnidadPago.ForeColor = System.Drawing.Color.White;
                    txtUnidadPago.Font.Bold = true;
                }
                else
                {
                    txtUnidadPago.BackColor = System.Drawing.Color.White;
                    txtUnidadPago.ForeColor = System.Drawing.Color.Black;
                    txtUnidadPago.Font.Bold = false;
                }
            }

            

            if (txtMatricula.Text.Trim() != lblMatricula.Text.Trim())
            {
                _error = true;
                blnValidaImporte = false;
                txtMatricula.BackColor = System.Drawing.Color.Red;
                txtMatricula.ForeColor = System.Drawing.Color.White;
                txtMatricula.Font.Bold = true;
            }
            else
            {
                txtMatricula.BackColor = System.Drawing.Color.White;
                txtMatricula.ForeColor = System.Drawing.Color.Black;
                txtMatricula.Font.Bold = false;
            }

            if (!_error)
            {
                btnAceptar.Enabled = true;
            }
        }

        protected void btnAplicarSuspender_Click(object sender, EventArgs e)
        {
            var nodos = treeListSuspender.GetSelectedNodes();
            int IdMotivoRechazo = 0;
            string MotivosRechazos = "";
            bool ValidaRechazo = false;
            string strObservaciones = "";

            if (nodos.Count > 0)
            {
                if (txtObservacionesPublicasSuspender.Text.Length > 0)
                {
                    MotivosRechazos = "";
                    foreach (TreeListNode node in nodos)
                    {
                        IdMotivoRechazo = Convert.ToInt32(node.GetValue("id"));


                        try
                        {
                            if (int.Parse(txtObservacionesPrivadas.Text.Substring(0, 3).Trim()) != IdMotivoRechazo)
                            {
                                txtObservacionesPublicasSuspender.Text = "";
                                treeListSuspender.UnselectAll();

                                string script = "";
                                script = "AlertaTexto('No coincide el rechazó seleccionado con el especificado.');";
                                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                                EjecutarScript(script);
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            txtObservacionesPublicasRechazara.Text = "";
                            treeListRechazo.UnselectAll();

                            txtObservacionesPublicasSuspender.Text = "";
                            treeListSuspender.UnselectAll();

                            string script = "";
                            script = "AlertaTexto('No coincide el rechazó seleccionado con el especificado. Son 3 dígitos para el motivo de rechazo 000');";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            EjecutarScript(script);
                            return;
                        }

                        if (MotivosRechazos.Length > 0)
                            MotivosRechazos += ",";
                        MotivosRechazos += IdMotivoRechazo.ToString();
                    }

                    treeListSuspender.UnselectAll();

                    Funciones.VariablesGlobales.StatusMesa IdStatusMesa = Funciones.VariablesGlobales.StatusMesa.Rechazo;
                    int IdTramite = Int32.Parse(hfIdTramite.Value);
                    int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());

                    // Agregamos la información capturada.
                    strObservaciones = "[";
                    strObservaciones += "IMPORTE : " + txtImporte.Text.Trim();
                    strObservaciones += "|| MATRICULA : " + txtMatricula.Text.Trim();
                    strObservaciones += "|| U. PAGO : " + txtUnidadPago.Text.Trim();
                    strObservaciones += "] " + txtObservacionesPrivadas.Text.Trim();

                    List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesa, txtObservacionesPublicasSuspender.Text.Trim(), strObservaciones, MotivosRechazos, "", txtPoliza.Text.Trim());
                    if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "LimpiarForm();", true);
                    }

                    if (objResultado[0].IdTramite > 0)
                    {
                        // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                        if (Session["documentos"] != null)
                        {
                            string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                        }
                        if (Session["insumos"] != null)
                        {
                            string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                        }

                        //string script = "";
                        //script = "pnlPopMotivosSuspender.Hide(); $('#myModal').modal({backdrop: 'static', keyboard: false}); ";
                        //script = "pnlPopMotivosSuspender.Hide();";
                        //EjecutarScript(script);

                        TramiteTerminado();
                        Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
                    }
                }
                else
                {
                    string script = "";
                    script = "AlertaObservaciones();";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    EjecutarScript(script);
                }
            }
            else
            {
                string script = "";
                script = "AlertaMotivosSuspencion();";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                EjecutarScript(script);
            }
        }

        protected void btnDetener_Click(object sender, EventArgs e)
        {
            Session["TramitesAutomaticos"] = false;
            btnDetener.Attributes["disabled"] = "enabled";
            mensajes.MostrarMensaje(this, "Se ha detenido la asignación de tramites para la mesa actual.");
        }

        protected void btnCtrlPausarTramite_Click(object sender, EventArgs e)
        {
            Funciones.VariablesGlobales.StatusMesa IdStatusMesa = Funciones.VariablesGlobales.StatusMesa.Pausa;
            int IdTramite = Int32.Parse(hfIdTramite.Value);
            int TipoTramite = int.Parse(hfTipoTramite.Value.ToString());

            List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesa, txtObservacionesPublicasPausar.Text.Trim(), txtObservacionesPrivadas.Text, "", "", txtPoliza.Text.Trim());
            if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "LimpiarForm();", true);
            }

            if (objResultado[0].IdTramite > 0)
            {
                // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                if (Session["documentos"] != null)
                {
                    string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                }
                if (Session["insumos"] != null)
                {
                    string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                }

                TramiteTerminado();
                Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
            }
        }

        protected void btnAplicarRechazar_Click(object sender, EventArgs e)
        {
            int IdMotivoRechazo = 0;
            string MotivosRechazos = "";
            var nodos = treeListRechazo.GetSelectedNodes();

            if (nodos.Count > 0)
            {
                if (txtObservacionesPublicasRechazara.Text.Length > 0)
                {

                    // Validación de la póliza
                    if (hfIdMesa.Value.ToString() == "28" || hfIdMesa.Value.ToString() == "30" || hfIdMesa.Value.ToString() == "103")
                    {
                        txtPoliza.Text = txtPoliza.Text.Trim();
                        int cantidadDigitosPoliza = int.Parse(System.Web.Configuration.WebConfigurationManager.AppSettings["PolizaDigitos"].ToString());
                        if (txtPoliza.Text.Trim().Length < cantidadDigitosPoliza)
                        {
                            MostrarAdvertencia("Validación", "No se capturó la PÓLIZA proveniente de portal. Capturar la póliza tal cual aparecen en el Portal del IMSS");
                            return;
                        }
                        else
                        {
                            string ExtraccionPoliza = lblPoliza.Text.Trim().Substring(lblPoliza.Text.Length - cantidadDigitosPoliza, cantidadDigitosPoliza);
                            string PortalPoliza = txtPoliza.Text.Trim().Substring(txtPoliza.Text.Length - cantidadDigitosPoliza, cantidadDigitosPoliza);
                            if (PortalPoliza != ExtraccionPoliza)
                            {
                                MostrarAdvertencia("Validación", "La PÓLIZA no corresponde con Extracción. Capturar la póliza tal cual aparecen en el Portal del IMSS");
                                return;
                            }
                        }
                    }



                    MotivosRechazos = "";
                    foreach (TreeListNode node in nodos)
                    {
                        IdMotivoRechazo = Convert.ToInt32(node.GetValue("id"));

                        if (txtObservacionesPrivadas.Text.Substring(0, 3).Trim() != IdMotivoRechazo.ToString())
                        {
                            txtObservacionesPublicasSuspender.Text = "";
                            treeListSuspender.UnselectAll();

                            string script = "";
                            script = "AlertaTexto('No coincide el rechazó seleccionado con el especificado.');";
                            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            EjecutarScript(script);
                            return;
                        }

                        if (MotivosRechazos.Length > 0)
                            MotivosRechazos += ",";
                        MotivosRechazos += IdMotivoRechazo.ToString();
                    }
                    treeListRechazo.UnselectAll();

                    Funciones.VariablesGlobales.StatusMesa IdStatusMesa = Funciones.VariablesGlobales.StatusMesa.Rechazo;
                    int IdTramite = Int32.Parse(hfIdTramite.Value);
                    int TipoTramite = int.Parse(hfTipoTramite.Value);

                    List<Propiedades.Procesos.Operacion.TramiteProcesado> objResultado = i.operacion.tramiteprocesar.ProcesarTramite(IdTramite, int.Parse(hfIdMesa.Value), manejo_sesion.Usuarios.IdUsuario, IdStatusMesa, txtObservacionesPublicasSuspender.Text.Trim(), txtObservacionesPrivadas.Text, MotivosRechazos, "", txtPoliza.Text.Trim());
                    if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "PopupScript"))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "LimpiarForm();", true);
                    }

                    if (objResultado[0].IdTramite > 0)
                    {
                        // REGISTRO DE ARCHIVOS - COLOCAR DESPUES DE ACTUALIZAR EL TRAMITE
                        if (Session["documentos"] != null)
                        {
                            string resultadoExpediente = registraDocumentosExpediente(IdTramite, TipoTramite);
                        }
                        if (Session["insumos"] != null)
                        {
                            string resultadoInsumo = registraDocumentosInsumos(IdTramite, TipoTramite);
                        }

                        string script = "";
                        script = "pnlPopMotivosRechazar.Hide(); $('#myModal').modal({backdrop: 'static', keyboard: false});";
                        //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        EjecutarScript(script);

                        TituloModal.Text = "Operación realizada";
                        MensajeModal.Text = "Trámite rechazado";
                        TramiteTerminado();
                        //Response.Redirect("TramiteProcesar.aspx?IdMesa=" + hfIdMesa.Value.ToString(), true);
                    }
                }
                else
                {
                    string script = "";
                    script = "AlertaObservaciones();";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    EjecutarScript(script);
                }
            }
            else
            {
                string script = "";
                script = "AlertaMotivosSuspencion();";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                EjecutarScript(script);
            }
        }

        protected void TramiteTerminado()
        {
            Session.Remove("documentos");
            Session.Remove("insumos");
            Session["documentos"] = null;
            Session["insumos"] = null;
        }

        #region Eventos Controles Botones Status Trámites

        protected void treeList_DataBoundHold(object sender, EventArgs e)
        {
            SetNodeSelectionSettings(ref treeListHold);
        }
        protected void treeList_CustomDataCallbackHold(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            // e.Result = treeListHold.SelectionCount.ToString();
        }
        protected void pnlCallbackMotHold_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
        }

        protected void treeList_DataBoundSuspender(object sender, EventArgs e)
        {
            SetNodeSelectionSettings(ref treeListSuspender);
        }
        protected void treeList_CustomDataCallbackSuspender(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            // e.Result = treeListSuspender.SelectionCount.ToString();
        }
        protected void pnlCallbackMotSuspender_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
        }

        protected void treeList_CustomDataCallbackRechazar(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            // e.Result = treeListSuspender.SelectionCount.ToString();
        }
        protected void pnlCallbackMotRechazar_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
        }

        protected void treeList_DataBoundRechazar(object sender, EventArgs e)
        {
            SetNodeSelectionSettings(ref treeListSuspender);
        }
        
        private void SetNodeSelectionSettings(ref ASPxTreeList Motivos)
        {
            TreeListNodeIterator iterator = Motivos.CreateNodeIterator();
            TreeListNode node;
            while (true)
            {
                node = iterator.GetNext();
                if (node == null) break;
            }
        }

        #endregion

        protected void EjecutarScript(string script)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
    }
}