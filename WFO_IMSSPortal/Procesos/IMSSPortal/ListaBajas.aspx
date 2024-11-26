<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaBajas.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.ListaBajas" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Lista Bajas</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <div style="width: 100%; height: 400px; overflow: scroll; overflow-x:auto; width:1150px; display:none;">
                        <asp:GridView ID="GVConcentrado" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2" Width="99%">
                        </asp:GridView>
                    </div>

                    <div>
                        <dx:ASPxGridView ID="grid" 
                            ClientInstanceName="grid" 
                            runat="server" 
                            Width="100%" 
                            AutoGenerateColumns="false"
                            KeyFieldName="ID"
                            OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared"
                            >
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True"                                                                   VisibleIndex="0" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Folio" FieldName="FOLIO"                                                                VisibleIndex="3" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Matricula" FieldName="MATRICULA"                                                        VisibleIndex="4" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Importe" FieldName="IMPORTE"                                                            VisibleIndex="5" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Póliza" FieldName="POLIZA"                                                              VisibleIndex="6" Width="120" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Promotoría de origen" FieldName="PROM_ORIGEN"                                           VisibleIndex="7" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Usuario de Servicio" FieldName="USR_SERVICIO"                                           VisibleIndex="8" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Promotoría de último servicio" FieldName="PROM_U_SERV"                                  VisibleIndex="9" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Promotoría responsable" FieldName="PROM_RESPON"                                         VisibleIndex="10" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tipo de Movimiento" FieldName="TIPO_MOVIMIENTO"                                         VisibleIndex="11" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Nombre del Trabajador" FieldName="NOMBRE_TRABAJADOR"                                    VisibleIndex="12" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Unidad de pago" FieldName="UNIDAD_PAGO"                                                 VisibleIndex="13" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tipo de nómina" FieldName="TIPO_NOMINA"                                                 VisibleIndex="14" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Año/Qna" FieldName="ANO_QUINCENA"                                                       VisibleIndex="15" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Estatus de la carta instrucción: OK" FieldName="STATUS_CARTA"                           VisibleIndex="16" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Estatus de la carta instrucción: NO APLICA" FieldName="STATUS_CARTA_DESC"               VisibleIndex="17" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Estatus de la carta instrucción: RECHAZO" FieldName="STATUS_CARTA_RECHAZO"              VisibleIndex="18" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Motivo de Rechazo/Resultado Analisis o  Portal" FieldName="STATUS_CARTA_RESULTADO"      VisibleIndex="19" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                </Columns>
                            <Templates>
                                <EmptyDataRow>
                                        <div style="width: 300px; color: red; font-weight: bold">
                                            No existen bajas a procesar...
                                        </div>
                                </EmptyDataRow>
                            </Templates>
                            <SettingsBehavior AllowSelectByRowClick="false" AllowSelectSingleRowOnly="true" EnableRowHotTrack="True" AllowEllipsisInText="true"  />
                            <SettingsPager  Mode="ShowAllRecords"/>
                            <SettingsDetail ShowDetailRow="false" />
                            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" HorizontalScrollBarMode="Visible" />
                            <SettingsSearchPanel Visible="false" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="grdExport" runat="server" GridViewID="grdPrueba"></dx:ASPxGridViewExporter>
                    </div>


                </div>
            </div>
        </div>
    </div>


</asp:Content>