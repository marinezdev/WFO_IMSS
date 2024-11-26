<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="TramiteProcesar.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Operador.TramiteProcesar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v17.2" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxTreeList.v17.2" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <script>
        function Confirmar(StatusMesa) {
            var resultado = false;
            // if (Page_ClientValidate('Orden') == true) {
                resultado = confirm('¿Esta seguro que desea ' + StatusMesa + ' la orden de servicio ?');
                // if (resultado) {
                //    $("#dvBtns").hide();
                // }
            // }
            return resultado;
        }

        function soloLetras(e){
           key = e.keyCode || e.which;
           tecla = String.fromCharCode(key).toLowerCase();
           letras = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ@. = $%*_0123456789-/&?¿¡!";
           especiales = "8-37-39-46";

           tecla_especial = false
           for(var i in especiales){
                if(key == especiales[i]){
                    tecla_especial = true;
                    break;
                }
            }

            if(letras.indexOf(tecla)==-1 && !tecla_especial){
                return false;
            }
        }

        function MASK(idForm, mask, format) {
            var n = $("#" + idForm).val();
            if (format == "undefined") format = false;
            if (format || NUM(n)) {
                dec = 0, point = 0;
                x = mask.indexOf(".") + 1;
                if (x) { dec = mask.length - x; }

                if (dec) {
                    n = NUM(n, dec) + "";
                    x = n.indexOf(".") + 1;
                    if (x) { point = n.length - x; } else { n += "."; }
                } else {
                    n = NUM(n, 0) + "";
                }
                for (var x = point; x < dec; x++) {
                    n += "0";
                }
                x = n.length, y = mask.length, XMASK = "";
                while (x || y) {
                    if (x) {
                        while (y && "#0.".indexOf(mask.charAt(y - 1)) == -1) {
                            if (n.charAt(x - 1) != "-")
                                XMASK = mask.charAt(y - 1) + XMASK;
                            y--;
                        }
                        XMASK = n.charAt(x - 1) + XMASK, x--;
                    } else if (y && "$0".indexOf(mask.charAt(y - 1)) + 1) {
                        XMASK = mask.charAt(y - 1) + XMASK;
                    }
                    if (y) { y-- }
                }
            } else {
                XMASK = "";
            }
            $("#" + idForm).val(XMASK);
            return XMASK;
        }
        function NUM(s, dec) {
            for (var s = s + "", num = "", x = 0; x < s.length; x++) {
                c = s.charAt(x);
                if (".-+/*".indexOf(c) + 1 || c != " " && !isNaN(c)) { num += c; }
            }
            if (isNaN(num)) { num = eval(num); }
            if (num == "") { num = 0; } else { num = parseFloat(num); }
            if (dec != undefined) {
                r = .5; if (num < 0) r = -r;
                e = Math.pow(10, (dec > 0) ? dec : 0);
                return parseInt(num * e + r) / e;
            } else {
                return num;
            }
        }
        function nombreDeLaFuncion() {
            location.reload();
        }

        function treeList_CustomDataCallbackHold(s, e) {
            document.getElementById('treeListCountCell').innerHTML = e.result;
        }
        function treeList_SelectionChangedHold(s, e) {
            window.setTimeout(function () { s.PerformCustomDataCallback(''); }, 0)
        }

        function treeList_CustomDataCallbackSuspender(s, e) {
            document.getElementById('treeListCountCell').innerHTML = e.result;
        }
        function treeList_SelectionChangedSuspender(s, e) {
            window.setTimeout(function () { s.PerformCustomDataCallback(''); }, 0)
        }

        function treeList_CustomDataCallbackRechazar(s, e) {
            document.getElementById('treeListCountCell').innerHTML = e.result;
        }
        function treeList_SelectionChangedRechazar(s, e) {
            window.setTimeout(function () { s.PerformCustomDataCallback(''); }, 0)
        }

        function ShowAceptarObs()
        {
            var observacionesPrivadas = document.getElementById('<%=txtObservacionesPrivadas.ClientID%>').value;
            if (observacionesPrivadas.length > 0)
            {
                pnlPopAceptarObs.Show();
            }
            else {
                AlertaObservaciones();
                //alert('Las observaciones son Requeridas. Por favor agregue observaciones.');
            }
        }

        function ShowPausa()
        {
            var observacionesPrivadas = document.getElementById('<%=txtObservacionesPrivadas.ClientID%>').value;
            if (observacionesPrivadas.length > 0)
            {
                pnlPopPausaTramite.Show();
            }
            else {
                AlertaObservaciones();
                //alert('Las observaciones son Requeridas. Por favor agregue observaciones.');
            }
        }

        function ShowHold() {
            var observacionesPrivadas = document.getElementById('<%=txtObservacionesPrivadas.ClientID%>').value;
            if (observacionesPrivadas.length > 0)
            {
                pnlPopMotivosHold.Show();
                pnlCallbackMotHold.PerformCallback();
            }
            else {
                AlertaObservaciones();
                //alert('Las observaciones son Requeridas. Por favor agregue observaciones.');
            }
        }

        function ShowSuspender() {
            var observacionesPrivadas = document.getElementById('<%=txtObservacionesPrivadas.ClientID%>').value;
            if (observacionesPrivadas.length > 0)
            {
                pnlPopMotivosSuspender.Show();
                pnlCallbackMotSuspender.PerformCallback();
            }
            else {
                AlertaObservaciones();
                //alert('Las observaciones son Requeridas. Por favor agregue observaciones.');
            }
        }

        function ShowRechazar() {
            var observacionesPrivadas = document.getElementById('<%=txtObservacionesPrivadas.ClientID%>').value;
            if (observacionesPrivadas.length > 0)
            {
                pnlPopMotivosRechazar.Show();
                pnlCallbackMotRechazar.PerformCallback();
            }
            else {
                AlertaObservaciones();
                //alert('Las observaciones son Requeridas. Por favor agregue observaciones.');
            }
        }

        function ShowEnviarMesa() {
            var observacionesPrivadas = document.getElementById('<%=txtObservacionesEnviarMesa.ClientID%>').value;
            if (observacionesPrivadas.length == 0)
            {
                AlertaObservaciones();
            }
        }

        function AlertaObservacionesP(titulo, texto) {
            new PNotify({
                    title: titulo,
                    text: texto,
                    type: 'error',
                    styling: 'bootstrap3'
                });
        }

        function AlertaObservaciones() {
            new PNotify({
                    title: 'Las observaciones son Requeridas !',
                    text: 'Por favor agregue observaciones.',
                    type: 'error',
                    styling: 'bootstrap3'
                });
        }

        function AlertaTexto(texto) {
            new PNotify({
                title: 'Alerta!',
                text: texto,
                type: 'error',
                styling: 'bootstrap3'
            });
        }

        function AlertaMotivosHold() {
            new PNotify({
                    title: 'Debe seleccionar al menos un motivo Hold. !',
                    text: 'Por favor agregue motivos.',
                    type: 'error',
                    styling: 'bootstrap3'
                });
        }

        function AlertaMotivosSuspencion() {
            new PNotify({
                    title: 'Debe seleccionar al menos un motivo de suspensión. !',
                    text: 'Por favor agregue motivos.',
                    type: 'error',
                    styling: 'bootstrap3'
                });
        }

        function LimpiarForm() {
            pnlPopMotivosHold.Hide();
            pnlPopMotivosSuspender.Hide();
            pnlPopMotivosRechazar.Hide();
            pnlPopPausaTramite.Hide();
            pnlPopAceptarObs.Hide();
            document.getElementById("<%=chkEnviar.ClientID %>").checked = false;
            document.getElementById("<%=chkEnviarNo.ClientID %>").checked = false;
            document.getElementById("<%=txtObservacionesPublicasAceptar.ClientID %>").value = "";
            document.getElementById("<%=txtObservacionesPublicasHold.ClientID %>").value = "";
            document.getElementById("<%=txtObservacionesPublicasSuspender.ClientID %>").value = "";
            document.getElementById("<%=txtObservacionesPublicasRechazara.ClientID %>").value = "";
            document.getElementById("<%=txtObservacionesPublicasPausar.ClientID %>").value = "";
            return true;
        }
    </script>

    <!-- Campos Ocultos -->
    <div>
        <asp:HiddenField ID="hfIdArchivo" runat="server" Value="0" />
        <asp:HiddenField ID="hfArchivoNombre" runat="server" Value="0" />
        <asp:HiddenField ID="hfIdTramite" runat="server" Value="0" />
        <asp:HiddenField ID="hfIdMesa"    runat="server" Value="0" />
        <asp:HiddenField ID="hfNombreMesa" runat="server" Value="0" />
        <asp:HiddenField ID="hfAutomatico" runat="server" Value="1" />
        <asp:HiddenField ID="hfTipoTramite" runat="server" Value="0" />
        <asp:HiddenField ID="hfRFC" runat="server" Value="0" />
    </div>

    <!-- Modal : Enviar trámite a Mesa -->
    <div class="modal fade mSendToMesa" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel5">Enviar a Mesa</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="lblSendToMesa" Visible="false" Text=""></asp:Label>
                            <asp:DropDownList runat="server" AutoPostBack="false" ID="cboToSend" Visible="false" class="form-control"></asp:DropDownList><br />
                            <strong>Observaciones Públicas</strong>
                            <asp:TextBox ID="txtObservacionesEnviarMesa" runat="server" TextMode="MultiLine" Width="98%" Height="50px" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterMode="ValidChars" TargetControlID="txtObservacionesEnviarMesa" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ@. = $%*_0123456789-/&" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSendToMesa" runat="server" Text="Enviar a Mesa" class="btn btn-success" OnClick="btnSendToMesa_Click"/>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE BITACORA PÚBLICA -->
    <div class="modal fade BitacoraPublica" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel4">Bitácora Pública </h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:Repeater ID="rptBitacoraPublica" runat="server" >
                                <HeaderTemplate>
                                    <table id="datatable" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Numero</th>
                                                <th>Mesa</th>
                                                <th>Fecha inicio</th>
                                                <th>Fecha termino</th>
                                                <th>Usuario</th>
                                                <th>Estatus mesa</th>
                                                <th>Observación</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Numero")%></td>
                                        <td><%#Eval("Mesa")%></td>
                                        <td><%#Eval("FechaInicio","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                        <td><%#Eval("FechaTermino","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                        <td><%#Eval("Usuario")%></td>
                                        <td><%#Eval("EstatusMesa")%></td>
                                        <td><%#Eval("Observacion")%></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE BITACORA PRIVADA  -->
    <div class="modal fade BitacoraPrivada" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel2">Bitácora Privada </h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:Repeater ID="rptBitacoraPrivada" runat="server" >
                                <HeaderTemplate>
                                    <table id="datatableBitacora" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Numero</th>
                                                <th>Mesa</th>
                                                <th>Fecha inicio</th>
                                                <th>Fecha termino</th>
                                                <th>Usuario</th>
                                                <th>Estatus mesa</th>
                                                <th>Observación</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Numero")%></td>
                                        <td><%#Eval("Mesa")%></td>
                                        <td><%#Eval("FechaInicio","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                        <td><%#Eval("FechaTermino","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                        <td><%#Eval("Usuario")%></td>
                                        <td><%#Eval("EstatusMesa")%></td>
                                        <td><%#Eval("Observacion")%></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE ARCHIVOS EXPEDIENTE  -->
    <div class="modal fade Expediente" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel1">Expedientes </h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:Repeater ID="rptExpedientes" runat="server" >
                                <HeaderTemplate>
                                    <table id="" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Nombre Archivo</th>
                                                <th>Fecha Carga</th>
                                                <th>Unidad</th>
                                                <th>Consultar</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("NmArchivo")%></td>
                                        <td><%#Eval("Fecha_Registro","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                        <td><%#Eval("FusionTexto")%></td>
                                        <td><asp:ImageButton ID="imbtnExpedienteFlot" runat="server" ImageUrl="../../Imagenes/folder-abrir.jpg" CommandName ="Consultar" CommandArgument='<%#Eval("Id")%>' OnCommand="CargaExpedienteID" /></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE CONFIRMACION ACEPTAR -->
    <div class="modal fade confirmacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title" id="myModalLabel10">
                        <asp:label ID="Label4" runat="server" Text="Confirmación de movimiento">
                        </asp:label>
                    </h4>
                </div>
                <div class="modal-body text-center">
                    <h5 class="modal-title" id="myModalLabel11">
                        <asp:Label runat="server" ID="Label5" Text="¿Deseas aceptar el trámite?"></asp:Label>
                    </h5>
                </div>
                <div class="modal-footer text-center">
                    <div class="row text-center">
                        <button type="button" class="btn btn-default col-md-6 col-sm-6 col-xs-12" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="Button1" runat="server" Text="Aceptar" class="btn btn-primary col-md-5 col-sm-5 col-xs-12" CausesValidation="False" OnClientClick =" return Confirmar('message');" OnClick="btnAceptar_Click"  />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE CONFIRMACION PCI -->
    <div class="modal fade confirmacionPCI" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title" id="myModalLabel21">
                        <asp:label ID="Label6" runat="server" Text="Confirmación de movimiento">
                        </asp:label>
                    </h4>
                </div>
                <div class="modal-body text-center">
                    <h5 class="modal-title" id="myModalLabel22">
                        <asp:Label runat="server" ID="Label7" Text="¿ Deseas mandar tramite a PCI ?"></asp:Label>
                    </h5>
                </div>
                <div class="modal-footer text-center">
                    <div class="row text-center">
                        <button type="button" class="btn btn-default col-md-6 col-sm-6 col-xs-12" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="Button3" runat="server" Text="Aceptar" class="btn btn-primary col-md-5 col-sm-5 col-xs-12" CausesValidation="False" OnClick="btnPCI_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE CONFIRMACION SELECCIÓN COMPLETA -->
    <div class="modal fade confirmacionSeleccionCompleta" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title" id="myModalLabel32">
                        <asp:label ID="lblTituloSeleccionCompleta" runat="server" Text="Confirmación de movimiento">
                        </asp:label>
                    </h4>
                </div>
                <div class="modal-body text-center">
                    <h5 class="modal-title" id="myModalLabel33">
                        <asp:Label runat="server" ID="lblTituloSeleccionCompletaConfirma" Text="¿ Deseas mandar tramite a Selección Completa ?"></asp:Label>
                    </h5>
                </div>
                <div class="modal-footer text-center">
                    <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                        <button type="button" class="btn btn-default col-md-6 col-sm-6 col-xs-6" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnAceptarSeleccionCompleta" runat="server" Text="Aceptar" class="btn btn-primary col-md-5 col-sm-5 col-xs-6" CausesValidation="False" OnClick="btnAceptarSeleccionCompleta_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- MODAL DE  OPERACIONES -->
    <div class="modal fade bs-example-modal-sm" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel2">
                        <asp:label ID="TituloModal" runat="server" Text="Actualización de trámite">
                        </asp:label>
                    </h4>
                </div>
                <div class="modal-body">
                    <p><asp:Label runat="server" ID="MensajeModal" Text="Trámite procesado"></asp:Label></p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button2" runat="server" Text="Aceptar" class="btn btn-primary" CausesValidation="False" OnClick="TramiteActualizado"  />
                </div>
            </div>
        </div>
    </div>

    <!-- DATOS MOSTRADOS EN TODAS LAS MESAS -->  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <div class="row">
                <div class="col-md-4 col-sm-4 col-xs-12 text-left" >
                    <div class="x_panel">
                        <div class="x_title">
                            <ul class="nav navbar-right panel_toolbox">
                                <li>
                                    <asp:Label runat="server" ID="LabelFlujo" Text="" Font-Bold="True" ></asp:Label>
                                    <br />
                                    <asp:Label runat="server" ID="LabelNombreMesa" Text="" Font-Bold="True" ></asp:Label>
                      	        </li>
                            </ul>
                            <br /><h2><small> Información del trámite  </small> </h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content text-left" style="max-height:800px; min-height:300px">
                            <div class="row">
                                <!-- Encabezado de la información -->
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <table class="table table-hover table-bordered">
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="text-align:center; border-bottom: 1px solid #ddd; background-color:#8EBB53; color:black;">Folio: <asp:Label runat="server" ID="LabelFolio" Text="Folio" Font-Bold="true" class="control-label"></asp:Label></th>
                                            </tr>
                                        </thead>
                                    </table>
                                </div>

                                <!-- Información del Trámite -->
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:UpdatePanel id="DatosTramiteInformacion" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table border="0" style="width: 100%;">    
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox0" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Póliza
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblPoliza" runat="server" ></asp:Label>
                                                        <br /><asp:TextBox ID="txtPoliza" runat="server" ReadOnly="false" ></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Status Concentrado
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblStausConcentrado" runat="server" ></asp:Label>
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox1" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Unidad de Pago
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblUnidadPago" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtUnidadPago" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox2" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Archivo
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblArchivo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox3" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Tipo de Nomina
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblTipoNomina" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox4" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Tipo de Movimiento
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblTipoMovimiento" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox5" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Quincena
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblQuincena" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox11" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Matrícula
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblMatricula" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox6" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Importe
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblImporte" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox18" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Usuario Servicio
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblUsuarioServicio" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox12" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Trabajador
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblTrabjador" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox19" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Prom Origen
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblPromOrigen" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox20" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Prom Responsable
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblPromResponsable" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox17" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Prom Último Servicio
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblPromoUltimoServicio" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trFirma">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox7" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Firma
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblFirma" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trIdentificacion">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox8" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Identificación Oficial
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblIdOficial" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trSumaAsegurada">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox9" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Suma Asegurada
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblSumaAsegurada" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trImporte">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox10" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Importe Número y Letra
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblImporteNumeroLetra" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trSello">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox13" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Sello
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblSello" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trSelloPromo">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox14" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Sello Promotoría
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblSelloPromotoria" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trMontoActual">
                                                    <td style="width:10%; background-color:#ddd; color:white; font-size:smaller; text-align:center; font-family:'Arial Rounded MT'">
                                                        <asp:CheckBox runat="server"  ID="CheckBox15" Checked="false" />
                                                    </td>
                                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        Monto Actual
                                                    </td>
                                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                                        <asp:Label ID="lblMontoActual" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnValidarCaptura" runat="server" Text="Validar Captura" class="btn btn-warning col-md-5 col-sm-5 col-xs-12" OnClick="btnValidarCaptura_Click" Width="100%"/>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8 col-sm-8 col-xs-12 text-left">
                    <div class="x_panel">
                        <div class="x_content text-left" style="width: 100%; height:600px; ">
                            <asp:Literal ID="ltMuestraPdf" runat="server" ></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
    
            <!-- ACCIONES -->
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2><small>Acciones </small> </h2>
                            <ul class="nav navbar-right panel_toolbox">
                                <li>
                                    <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      	        </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content text-left" >
                            <div class="row">
                                <div class="control-label col-md-5 col-sm-5 col-xs-12">
                                    <strong>OBSERVACIONES PRIVADAS</strong>
                                    <asp:TextBox ID="txtObservacionesPrivadas" runat="server" class="form-control" TextMode="MultiLine" Rows="5" AutoPostBack="false" onkeypress="return soloLetras(event)" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"></asp:TextBox>
                                    <br />
                                </div>
                                <div class="control-label col-md-7 col-sm-12 col-xs-12">
                                    <div class="row">
                                        <code><asp:Label runat="server" ID="Mensajes" Text=""></asp:Label></code>
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="btnAceptarObs" runat="server" Text="Aceptar" class="btn btn-success col-md-5 col-sm-5 col-xs-12"/>
                                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-success col-md-2 col-sm-2 col-xs-12" data-toggle="modal" title="Aceptar" data-target=".confirmacion"/>
                                        <asp:Button ID="btnSelccionCompleta" runat="server" Text="Sel Completa" class="btn btn-warning col-md-2 col-sm-2 col-xs-12" data-toggle="modal" data-target=".confirmacionSeleccionCompleta"/>
                                        <asp:Button ID="btnPCI" runat="server" Text="P C I" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" data-toggle="modal" data-target=".confirmacionPCI"/>
                                        <asp:Button ID="btnHold" runat="server" Text="Hold" class="btn btn-warning col-md-2 col-sm-2 col-xs-12"/>
                                        <asp:Button ID="btnSuspender" runat="server" Text="Rechazar" class="btn btn-danger col-md-2 col-sm-2 col-xs-12"/>
                                        <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" class="btn btn-danger col-md-2 col-sm-2 col-xs-12"/>

                                        <literal runat="server" id="blockEnviarAMEsa">
                                            <button type="button" class="btn btn-info col-md-3 col-sm-3 col-xs-12" data-toggle="modal" title="Enviar a Mesa" data-target=".mSendToMesa">Enviar a Mesa</i></button>
                                        </literal>

                                        
                                    </div>
                                    <div class="row">
                                        <asp:Button ID="btnPausa" runat="server" Text="Pausa de Trámite" class="btn btn-danger col-md-5 col-sm-5 col-xs-12"/>
                                        <asp:Button ID="btnDetener" runat="server" Text="Pausa de Usuario" class="btn btn-warning col-md-5 col-sm-5 col-xs-12" OnClick="btnDetener_Click"/>
                                    </div>
                                </div>
                                </div>
                        
                            </div>
                            <div class="row">
                                <div class="control-label col-md-5 col-sm-5 col-xs-12">
                                    <button type="button" class="btn btn-default col-md-2 col-sm-2 col-xs-12" data-toggle="modal" title="Bitácora publica" data-target=".BitacoraPublica"><i class="fa fa-unlock-alt"></i></button>
                                    <button type="button" class="btn btn-default col-md-2 col-sm-2 col-xs-12" data-toggle="modal" title="Bitácora privada" data-target=".BitacoraPrivada"><i class="fa fa-lock"></i> </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    
            <!-- CARGA DE ARCHIVOS A EXPEDIENTE HE INSUMOS -->
            <asp:UpdatePanel ID="AnexoArchivos" runat="server" UpdateMode="Conditional" Visible="False">
                <ContentTemplate>
                    <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2><small>Archivos Anexos </small></h2>
                                <div class="clearfix"></div>
                                <div class="x_content text-left">
                                    <br />
                                    <div class="row">
                                        <div class=" profile_details">
                                            <div class="col-md-6 col-sm-6 col-xs-12 well profile_view">
                                                <div class="col-xs-12 bottom text-center">
                                                    <h4 class="brief">ARCHIVOS CON DOCUMENTOS REQUERIDOS</h4><br />
                                                </div>
                                                <div class="right col-xs-12 text-left">
                                                    <asp:UpdatePanel ID="PnlArchivosAnexos" runat="server">
                                                        <ContentTemplate>
                                                            <fieldset>
                                                            <asp:Label ID="lblDocumentosRequeridos" runat="server" Text="Archivos (*.PDF, *.JPG, *.PNG)"></asp:Label>
                                                            <asp:FileUpload ID="fileUpDocumento" runat="server"></asp:FileUpload>
                                                            <code><asp:Label ID="LabRespuestaArchivosCarga" runat="server" Text =""></asp:Label></code>
                                                            <br />
                                                            <asp:Button ID="btnSubirDocumento" runat="server" Text="Subir" class="btn btn-primary" CausesValidation="False" OnClick="btnSubirDocumento_Click"/><br />
                                                            <asp:ListBox ID="lstDocumentos" runat="server" Height="100px" Width="100%" SelectionMode="Single" class="select2_multiple form-control">
                                                            </asp:ListBox>
                                                            <br />
                                                            <asp:Button ID="btnEliminaDocumento" runat="server" Text="Eliminar" class="btn btn-danger" CausesValidation="False" OnClick="btnEliminaDocumento_Click" />
                                                        </fieldset>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSubirDocumento" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                            <div class="col-md-6 col-sm-6 col-xs-12 well profile_view">
                                                <div class="col-xs-12 bottom text-center">
                                                    <h4 class="brief">ARCHIVOS ADICIONALES</h4><br />
                                                </div> 
                                                <div class="right col-xs-12 text-left">
                                                    <asp:CheckBox ID="CheckBoxInsumos"  runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_Habilita_Insumos" Text="¿Desea agregar archivos adicionales?" />
                                                    <asp:UpdatePanel ID="PanelInsumos" runat="server" Visible="False">
                                                        <ContentTemplate>
                                                            <fieldset>
                                                                <asp:FileUpload ID="fileUpInsumo" runat="server"></asp:FileUpload>
                                                                <code><asp:Label ID="MensajeInsumos" runat="server" Text =""></asp:Label></code>
                                                                <br />
                                                                <asp:Button ID="btnSubirInsumo" runat="server" Text="Subir" class="btn btn-primary" OnClick="btnSubirInsumo_Click" CausesValidation="False"/><br />
                                                                <asp:ListBox ID="lstInsumos" runat="server" Height="100px" Width="100%" class="select2_multiple form-control" SelectionMode="Single">
                                                                </asp:ListBox>
                                                                <br />
                                                                <asp:Button ID="btnEliminaInsumo" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="btnEliminaInsumo_Click" CausesValidation="False"/>
                                                            </fieldset>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnSubirInsumo" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-- BOTNONES EMERGENTES CATALOGOS DE RECHASOS -->
            <!-- Botones Emergentes HOLD -->
            <dx:ASPxPopupControl ID="pnlPopMotivosHold" 
					            runat="server" 
					            CloseAction="CloseButton" 
					            HeaderText="Motivos HOLD" 
					            ShowFooter="True" 
					            Theme="iOS" 
					            Width="350px" 
					            ClientInstanceName="pnlPopMotivosHold" 
					            Modal="True" 
					            PopupHorizontalAlign="WindowCenter" 
					            PopupVerticalAlign="WindowCenter" 
					            FooterText="">
	            <ContentStyle>
		            <Paddings Padding="5px" />
	            </ContentStyle>
	            <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxCallbackPanel ID="pnlCallbackMotHold" 
								            runat="server" 
					                        ClientInstanceName="pnlCallbackMotHold" 
				                            Width="100%" 
								            OnCallback="pnlCallbackMotHold_Callback">
				            <PanelCollection>
	                            <dx:PanelContent runat="server">
						            <dx:ASPxTreeList ID="treeListHold" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnCustomDataCallback="treeList_CustomDataCallbackHold" OnDataBound="treeList_DataBoundHold" ParentFieldName="idParent" Width="100%">
                                        <Columns>
                                            <dx:TreeListDataColumn AutoFilterCondition="Default" Caption="Motivos de Hold" FieldName="motivoRechazo" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="0"></dx:TreeListDataColumn>
                                        </Columns>
                                        <settingsbehavior allowautofilter="True" expandcollapseaction="NodeDblClick"></settingsbehavior>
                                        <settingscustomizationwindow caption="" popuphorizontalalign="RightSides" popupverticalalign="BottomSides"></settingscustomizationwindow>
                                        <settingsselection enabled="True"></settingsselection>
                                        <settingspopupeditform verticaloffset="-1"></settingspopupeditform>
                                        <settingspopup>
                                            <editform verticaloffset="-1"></editform>
                                        </settingspopup>
                                        <clientsideevents customdatacallback="treeList_CustomDataCallbackHold" selectionchanged="treeList_SelectionChangedHold"></clientsideevents>
                                    </dx:ASPxTreeList>
                                    <br />
                                    <asp:Label ID="lblObservacionesPublicasHold" runat="server" Text="OBSERVACIONES PÚBLICAS" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtObservacionesPublicasHold" runat="server" TextMode="MultiLine" Width="98%" Height="50px" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterMode="ValidChars" TargetControlID="txtObservacionesPublicasHold" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ@. = $%*_0123456789-/&" />
					            </dx:PanelContent>
				            </PanelCollection>
	                    </dx:ASPxCallbackPanel>
		            </dx:PopupControlContentControl>
                </ContentCollection>
	            <FooterTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>

                        <div style="text-align:right;">
                            <br />&nbsp;
                            <asp:Button ID="btnAplicarHold" runat="server" Text="Aplicar Hold" class="btn btn-warning" OnClick="btnAplicarHold_Click"/>
                            <br />&nbsp;
		                </div>
                            </ContentTemplate>
                    </asp:UpdatePanel>
	            </FooterTemplate>
            </dx:ASPxPopupControl>

            <!-- Botones Emergentes SUSPENDER -->
            <dx:ASPxPopupControl ID="pnlPopMotivosSuspender" 
					            runat="server" 
					            CloseAction="CloseButton" 
					            HeaderText="Motivos SUSPENDER" 
					            ShowFooter="True" 
					            Theme="iOS" 
					            Width="350px" 
					            ClientInstanceName="pnlPopMotivosSuspender" 
					            Modal="True" 
					            PopupHorizontalAlign="WindowCenter" 
					            PopupVerticalAlign="WindowCenter" 
					            FooterText="">
	            <ContentStyle>
		            <Paddings Padding="5px" />
	            </ContentStyle>
	            <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxCallbackPanel ID="pnlCallbackMotSuspender" 
								            runat="server" 
					                        ClientInstanceName="pnlCallbackMotSuspender" 
				                            Width="100%" 
								            OnCallback="pnlCallbackMotSuspender_Callback">
				            <PanelCollection>
	                            <dx:PanelContent runat="server">
						            <dx:ASPxTreeList ID="treeListSuspender" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnCustomDataCallback="treeList_CustomDataCallbackSuspender" OnDataBound="treeList_DataBoundSuspender" ParentFieldName="idParent" Width="100%">
                                        <Columns>
                                            <dx:TreeListDataColumn AutoFilterCondition="Default" Caption="Motivos de Suspensión" FieldName="motivoRechazo" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="0"></dx:TreeListDataColumn>
                                        </Columns>
                                        <settingsbehavior allowautofilter="True" expandcollapseaction="NodeDblClick"></settingsbehavior>
                                        <settingscustomizationwindow caption="" popuphorizontalalign="RightSides" popupverticalalign="BottomSides"></settingscustomizationwindow>
                                        <settingsselection enabled="True"></settingsselection>
                                        <settingspopupeditform verticaloffset="-1"></settingspopupeditform>
                                        <settingspopup>
                                            <editform verticaloffset="-1"></editform>
                                        </settingspopup>
                                        <clientsideevents customdatacallback="treeList_CustomDataCallbackSuspender" selectionchanged="treeList_SelectionChangedSuspender"></clientsideevents>
                                    </dx:ASPxTreeList>
                                    <br />
                                    <asp:Label ID="lblObservacionesPublicasSuspender" runat="server" Text="OBSERVACIONES PÚBLICAS" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtObservacionesPublicasSuspender" runat="server" TextMode="MultiLine" Width="98%" Height="50px" onkeypress="return soloLetras(event)" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"></asp:TextBox>
					            </dx:PanelContent>
				            </PanelCollection>
	                    </dx:ASPxCallbackPanel>
		            </dx:PopupControlContentControl>
                </ContentCollection>
	            <FooterTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <div style="text-align:right;">
                                <br />&nbsp;
                                <asp:Button ID="btnAplicarSuspender" runat="server" Text="Aplicar Rechazo" class="btn btn-danger"  OnClick="btnAplicarSuspender_Click"/>
                                <br />&nbsp;
		                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
	            </FooterTemplate>
            </dx:ASPxPopupControl>
    
            <!-- Botones Emergentes RECHAZAR -->
            <dx:ASPxPopupControl ID="pnlPopMotivosRechazar" 
					            runat="server" 
					            CloseAction="CloseButton" 
					            HeaderText="Motivos de Rechazo" 
					            ShowFooter="True" 
					            Theme="iOS" 
					            Width="350px" 
					            ClientInstanceName="pnlPopMotivosRechazar" 
					            Modal="True" 
					            PopupHorizontalAlign="WindowCenter" 
					            PopupVerticalAlign="WindowCenter" 
					            FooterText="">
	            <ContentStyle>
		            <Paddings Padding="5px" />
	            </ContentStyle>
	            <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <dx:ASPxCallbackPanel ID="pnlCallbackMotRechazar" 
								            runat="server" 
					                        ClientInstanceName="pnlCallbackMotRechazar" 
				                            Width="100%" 
								            OnCallback="pnlCallbackMotRechazar_Callback">
				            <PanelCollection>
	                            <dx:PanelContent runat="server">
                                    <dx:ASPxTreeList ID="treeListRechazo" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnCustomDataCallback="treeList_CustomDataCallbackSuspender" OnDataBound="treeList_DataBoundSuspender" ParentFieldName="idParent" Width="100%">
                                        <Columns>
                                            <dx:TreeListDataColumn AutoFilterCondition="Default" Caption="Motivos de Suspensión" FieldName="motivoRechazo" ShowInCustomizationForm="True" ShowInFilterControl="Default" VisibleIndex="0"></dx:TreeListDataColumn>
                                        </Columns>
                                        <settingsbehavior allowautofilter="True" expandcollapseaction="NodeDblClick"></settingsbehavior>
                                        <settingscustomizationwindow caption="" popuphorizontalalign="RightSides" popupverticalalign="BottomSides"></settingscustomizationwindow>
                                        <settingsselection enabled="True"></settingsselection>
                                        <settingspopupeditform verticaloffset="-1"></settingspopupeditform>
                                        <settingspopup>
                                            <editform verticaloffset="-1"></editform>
                                        </settingspopup>
                                        <clientsideevents customdatacallback="treeList_CustomDataCallbackRechazar" selectionchanged="treeList_SelectionChangedRechazar"></clientsideevents>
                                    </dx:ASPxTreeList>
						            <br />
                                    <asp:Label ID="lblObservacionesPublicasRechazar" runat="server" Text="OBSERVACIONES PÚBLICAS" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="txtObservacionesPublicasRechazara" runat="server" TextMode="MultiLine" Width="98%" Height="50px" onkeypress="return soloLetras(event)" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"></asp:TextBox>
					            </dx:PanelContent>
				            </PanelCollection>
	                    </dx:ASPxCallbackPanel>
		            </dx:PopupControlContentControl>
                </ContentCollection>
	            <FooterTemplate>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
                        <ContentTemplate>
                            <div style="text-align:right;">
                                <br />&nbsp;
                                <asp:Button ID="btnAplicarRechazar" runat="server" Text="Aplicar Recahzo" class="btn btn-danger" OnClick="btnAplicarRechazar_Click"/>
                                <br />&nbsp;
		                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
	            </FooterTemplate>
            </dx:ASPxPopupControl>

            <!-- Botón de Pausa -->
            <dx:ASPxPopupControl ID="pnlPopPausaTramite" 
	                runat="server" 
	                CloseAction="CloseButton" 
	                HeaderText="Pausar Trámite" 
	                ShowFooter="True" 
	                Theme="iOS" 
	                Width="350px" 
	                ClientInstanceName="pnlPopPausaTramite" 
	                Modal="True" 
	                PopupHorizontalAlign="WindowCenter" 
	                PopupVerticalAlign="WindowCenter" 
	                FooterText="">
	            <ContentStyle>
		            <Paddings Padding="5px" />
	            </ContentStyle>
	            <ContentCollection>
		            <dx:PopupControlContentControl runat="server">
                        <p>
                            <strong>OBSERVACIONES PÚBLICAS</strong>
                        </p>
                        <asp:TextBox ID="txtObservacionesPublicasPausar" runat="server" TextMode="MultiLine" Width="95%" Height="50px" onkeypress="return soloLetras(event)" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"> </asp:TextBox>
		            </dx:PopupControlContentControl>
	            </ContentCollection>
	            <FooterTemplate>
		            <div style="text-align:right;">
                        <br />
                        <asp:Button ID="btnPausaTramite" runat="server" Text="Pausar" class="btn btn-warning" OnClientClick="pnlPopPausaTramite.Hide();" OnClick="btnCtrlPausarTramite_Click"/>
			            <br />&nbsp;
		            </div>
	            </FooterTemplate>
            </dx:ASPxPopupControl>

            <!-- Botón de Aceptar -->
            <dx:ASPxPopupControl ID="pnlPopAceptarObs" 
		            runat="server" 
		            CloseAction="CloseButton" 
		            HeaderText="Aceptar Trámite" 
		            ShowFooter="True" 
		            Theme="iOS" 
		            Width="350px" 
		            ClientInstanceName="pnlPopAceptarObs" 
		            Modal="True" 
		            PopupHorizontalAlign="WindowCenter" 
		            PopupVerticalAlign="WindowCenter" 
		            FooterText="">
	            <ContentStyle>
		            <Paddings Padding="5px" />
	            </ContentStyle>
	            <ContentCollection>
		            <dx:PopupControlContentControl runat="server">
                        <p>
                                 <asp:CheckBox runat="server" ID="chkEnviar" Text="Enviar a periodo Interactivo." Font-Size="Small" />
                            <br />
                                 <asp:CheckBox runat="server" ID="chkEnviarNo" Text="No Eviar."  Font-Size="Small" />
                        </p>
			            <p>
				            <strong>OBSERVACIONES PÚBLICAS</strong>
			            </p>
			            <asp:TextBox ID="txtObservacionesPublicasAceptar" runat="server" TextMode="MultiLine" Width="95%" Height="50px" onkeypress="return soloLetras(event)" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"> </asp:TextBox>
		            </dx:PopupControlContentControl>
	            </ContentCollection>
	            <FooterTemplate>
		            <div style="text-align:right;">
			            <br />
                        <asp:Button ID="btnPausaTramite" runat="server" Text="Procesar" class="btn btn-success" OnClientClick="pnlPopAceptarObs.Hide();" OnClick="btnCtrlAceptarTramite_Click"/>
			            <br />&nbsp;
		            </div>
	            </FooterTemplate>
            </dx:ASPxPopupControl>
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>