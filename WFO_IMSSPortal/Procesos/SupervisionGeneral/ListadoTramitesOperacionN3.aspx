<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="ListadoTramitesOperacionN3.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.SupervisionGeneral.ListadoTramitesOperacionN3" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Listado de Trámites Operados [ N3 ]</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <p class="text-muted font-13 m-b-30">
                            Las mesas se mostraran a partir del flujo seleccionado.
                        </p>
                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                            <table id="" class="table table-striped table-bordered ">
                                <thead>
                                    <tr>
                                        <th>Descarga reporte captura masiva </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td style="text-align:center">
                                        <asp:LinkButton ID="lnkExportarResumen" runat="server" Text="Exportar a Excel"  CausesValidation="False" OnClick="lnkExportar_Click">
                                            <img src="../../Imagenes/images.png" style="vertical-align:top"/>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                            <table id="" class="table table-striped table-bordered ">
                                <thead>
                                    <tr>
                                        <th>Lista tramites incompletos </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td style="text-align:center;">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="Exportar a Excel"  CausesValidation="False">
                                            <img src="../../Imagenes/post_NUEVAS_SOLIC.jpg" style="vertical-align:top"/>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    
                                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>