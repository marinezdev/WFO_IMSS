<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="TramitesProcesados.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.TramitesProcesados" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <script>
       function Cantidades(id) {
            var boton = document.getElementById('<%=btnConsultar.ClientID%>');
            $("#<%= hfIdPendiente.ClientID %>").val(id);
            boton.click();
        }
    </script>

    <asp:UpdatePanel ID="ObservacionesCartaEjecucion" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
             <!-- Campos Ocultos -->
            <div>
                <asp:HiddenField ID="hfIdPendiente" runat="server" />
            </div>

             <!-- MODAL DE  OPERACIONES -->
            <div class="modal fade bs-example-modal-sm" id="myModal" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel1">
                                <asp:label ID="Label2" runat="server" Text="Cargando ... ">
                                </asp:label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="image view view-first">
                                <img style="width: 100%; display: block;" src="../../Imagenes/default-loader.gif" alt="image">
                            </div>
                        </div>
                        <div class="modal-footer">
                        
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Trámites Procesados</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <p class="text-muted font-13 m-b-30">
                            Listado total de trámites ingresados y procesados en el WFO.
                        </p>

                        <div class="row">
                            
                            <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                <asp:Label runat="server" ID="label1"  Font-Bold="True" Text="* Desde" ></asp:Label>
                                <dx:ASPxDateEdit ID="dtFechaInicio" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="" >
                                    <TimeSectionProperties>
                                        <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                    </TimeSectionProperties>
                                    <CalendarProperties>
                                        <FastNavProperties DisplayMode="Inline" />
                                    </CalendarProperties>
                                </dx:ASPxDateEdit>
                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="dtFechaTermino" ForeColor="Crimson" errormessage="*  Debe seleccionar una fechar inicial" Font-Size="16px"/>
                            </div>

                            
                            <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                <asp:Label runat="server" ID="labelFechaSolicitud"  Font-Bold="True" Text="* Hasta" ></asp:Label>
                                <dx:ASPxDateEdit ID="dtFechaTermino" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="">
                                    <TimeSectionProperties>
                                        <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                    </TimeSectionProperties>
                                    <CalendarProperties>
                                        <FastNavProperties DisplayMode="Inline" />
                                    </CalendarProperties>
                                </dx:ASPxDateEdit>
                                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="dtFechaInicio" ForeColor="Crimson" errormessage="* Debe seleccionar una fechar final mayor a la fecha inicial" Font-Size="16px"/>
                            </div>

                            <div class="col-md-2 col-sm-2 col-xs-12 form-group has-feedback">
                                <br />
                                <asp:Button ID="btnConsultar" runat="server"  AutoPostBack="True" Text="Consultar" Class="btn btn-success" OnClick="btnConsultar_Click" />
                                <asp:Label runat="server" ID="lblMensaje"  Font-Bold="True" Text="***" ForeColor="Crimson" Visible ="false"></asp:Label>

                            </div>
                        </div>

                        <div class="row">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Repeater ID="rptTramite" runat="server" OnItemCommand="rptTramite_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="datatable" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th style="text-align:center; ">Fecha</th>
                                                        <th style="text-align:center; ">Ingresados</th>
                                                        <th style="text-align:center; ">Procesados en <br />Revisión</th>
                                                        <th style="text-align:center; ">Procesados en <br />Control</th>
                                                        <th style="text-align:center; ">Procesados en <br />Portal</th>
                                                        <th style="text-align:center; ">Procesados en <br />Interactivo</th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align:center; "><%#Eval("Fecha","{0:dd/MM/yyyy}")%></td>
                                                <td style="text-align:center; "><%#Eval("TramitesIngresados")%></td>
                                                <td style="text-align:center; "><%#Eval("TramitesRevision")%></td>
                                                <td style="text-align:center; "><%#Eval("TramitesControl")%></td>
                                                <td style="text-align:center; "><%#Eval("TramitesPortal")%></td>
                                                <td style="text-align:center; "><%#Eval("TramitesInteractivo")%></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="6">&nbsp;</td>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>

                        </div>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>