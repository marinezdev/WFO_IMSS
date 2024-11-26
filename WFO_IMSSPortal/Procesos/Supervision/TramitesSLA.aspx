<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="TramitesSLA.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.TramitesSLA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <script>
        function DetalleMesa(parametro1) {
            var valor;
            var quincena;

            quincena = document.getElementById('<%=cboQuincenas.ClientID%>').value;

            if (parametro1 == 0)
            {
                valor = document.getElementById('<%=lblPriodo0.ClientID%>').innerText;
            }
            else if (parametro1 == 1) {
                valor = document.getElementById('<%=lblPriodo1.ClientID%>').innerText;
            }
            else if (parametro1 == 2) {
                valor = document.getElementById('<%=lblPriodo2.ClientID%>').innerText;
            }
            else if (parametro1 == 3) {
                valor = document.getElementById('<%=lblPriodo3.ClientID%>').innerText;
            }

            $.ajax({
                 type: "POST",
                 url: "TramitesSLA.aspx/DetalleMesa",
                data: '{dia: ' + parametro1 + ', IdCalendario: ' + quincena + ', RangoFecha: "' + valor + '"}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: resultado,
                 error: errores
            });
        }

        function resultado(data) {
            console.log(data);
            $("#DetalleMesa").modal("show");
            $('#DatosConsulta').html("");
            var tabla = "<table id='InfomacionMesas' class='table table-striped table-bordered table-hover' style='width:100%'>" +
                "<thead>" +
                "<tr>" +
                "<th scope='col'>Trámite</th>" +
                "<th scope='col'>Poliza</th>" +
                "<th scope='col'>Quincena</th>" +
                "<th scope='col'>Tipo Nomina</th>" +
                "<th scope='col'>Tipo Movimiento</th>" +
                "<th scope='col'>Status Mesa</th>" +
                "</tr>" +
                "</thead>" +
                "<tbody>";
            for (var b = 0; b < data.d.Tramites.length; b++) {
                tabla += "<tr>" +
                    "<td>" + data.d.Tramites[b].IdTramte + "</td>" +
                    "<td>" + data.d.Tramites[b].Poliza + "</td>" +
                    "<td>" + data.d.Tramites[b].Quincena + "</td>" +
                    "<td>" + data.d.Tramites[b].TipoNomina + "</td>" +
                    "<td>" + data.d.Tramites[b].TipoMovimimento + "</td>" +
                    "<td>" + data.d.Tramites[b].statusMesa + "</td>" +
                    "</tr>";
            }
            tabla += "</tbody>" +
                "</table>";

            $('#DatosConsulta').html(tabla);

            $("#InfomacionMesas").dataTable().fnDestroy();
            $('#InfomacionMesas').DataTable({
                "order": [[1, "DESC"]],
                "language": {
                    "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
                },
                dom: "Blfrtip",
                buttons: [{ extend: 'copy', className: 'btn-sm' }, { extend: 'csv', className: 'btn-sm' }, { extend: 'excel', className: 'btn-sm' }, { extend: 'pdfHtml5', className: 'btn-sm' }, { extend: 'print', className: 'btn-sm' }]
            });
        }

        function errores(data) {
            //msg.responseText tiene el mensaje de error enviado por el servidor
            alert('Error: ' + msg.responseText);
        }
    </script>

    <asp:UpdatePanel ID="ObservacionesCartaEjecucion" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
             <!-- Campos Ocultos -->
            <div>
                <asp:HiddenField ID="hfIdPendiente" runat="server" />
            </div>

<div class="modal fade bd-example-modal-lg" id="DetalleMesa" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="NumeroFolio">Tramite</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                
                <div  id="DatosConsulta" class="table-responsive">

                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>


            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Trámites SLA</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <p class="text-muted font-13 m-b-30">
                            Información sobre los tiempos de Atención a trámites.
                        </p>
                        <div class="row">
                            <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="cboQuincenas" runat="server" AutoPostBack="True" class="form-control" Width="250px" OnSelectedIndexChanged="CargaFlujos_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Button ID="btnConsultar" runat="server"  AutoPostBack="True" Text="Actualizar" Class="btn btn-success" OnClick="btnConsultar_Click" />
                            </div>
                            <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                            </div>
                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <br />
                            </div>
                        </div>
                        <div class="row" style="display:none;">
                            <asp:Label ID ="lblPriodo0" runat="server" Text="0"></asp:Label><br />&nbsp;
                            <asp:Label ID ="lblPriodo1" runat="server" Text="1"></asp:Label><br />&nbsp;
                            <asp:Label ID ="lblPriodo2" runat="server" Text="2"></asp:Label><br />&nbsp;
                            <asp:Label ID ="lblPriodo3" runat="server" Text="3"></asp:Label><br />&nbsp;
                        </div>

                        <div class="row">
                            <asp:Literal id="MesasLiteral1" runat=server  text=""/>
                        </div>

                        <div class="row">
                            <asp:Literal id="MesasLiteral2" runat=server  text=""/>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>