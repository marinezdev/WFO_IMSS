<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="TramiteProcesoManual.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.TramiteProcesoManual" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Proceso Manual</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <p class="text-muted font-13 m-b-30">Procesar manualmente la póliza.</p>
                    </div>
                    <div class="row">
                        &nbsp;
                    </div>
                    <div class="row">
                        <div class="col-md-3"> 
                            <strong>Tipo Nomina: </strong>
                            <asp:DropDownList ID="ddlTipoNomina" runat="server" class="form-control" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="col-md-3"> 
                            <strong>Quincena: </strong>
                            <asp:DropDownList ID="ddlAnnQuincena" runat="server" class="form-control" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <strong>Póliza: </strong>
                            <asp:TextBox ID="txtPoliza" runat="server" CssClass="full-width"></asp:TextBox>
                        </div>
                        <div class="col-md-3"> 
                            <br />
                            <asp:Button 
                                ID="BtnExcelAceptar" 
                                runat="server" 
                                CssClass="btn btn-primary" 
                                Text="Buscar" 
                                OnClick="BtnExcelAceptar_Click" 
                                width="100%"
                            />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblBuscar" Text="" Visible="false" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="true"></asp:Label>
                    </div>

                    <div class="row">
                        <hr />
                        <br />&nbsp;
                    </div>
                    
                    <div class="row">
                        <div class="col-md-3"> 
                            <strong>MESA: </strong>
                            <asp:DropDownList ID="ddlMesa" runat="server" class="form-control" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlMesa_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-md-3"> 
                            <strong>Status Mesa: </strong>
                            <asp:DropDownList ID="ddlStatusMesa" runat="server" class="form-control" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlStatusMesa_SelectedIndexChanged"></asp:DropDownList>
                        </div> 
                        <div class="col-md-3">  
                            <strong>Motivo Rechazo: </strong>
                            <asp:DropDownList ID="ddlMotivoRechazo" runat="server" class="form-control" Width="100%"></asp:DropDownList>
                        </div>

                        <div class="col-md-3">  
                            <br />
                            <asp:Button 
                                ID="btnProcesaMesa" 
                                runat="server" 
                                CssClass="btn btn-primary" 
                                Text="Procesar Mesa" 
                                OnClick="btnProcesaMesa_Click" 
                                width="100%"
                            />
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblProcesarTramite" Text="" Visible="false" runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="true"></asp:Label>
                    </div>

                    <div class="row">
                        <hr />
                        <br />&nbsp;
                    </div>
                    <div class="row">
                        <h3>&nbsp; Resultado del Procesamiento.</h3>

                        <div class="col-md-1"></div> 
                        <div class="col-md-10"> 
                            <dx:ASPxGridView ID="grdResultados" 
                                ClientInstanceName="grdResultados" 
                                runat="server" 
                                AutoGenerateColumns="true"
                                KeyFieldName="ID"
                                Width="100%"
                                OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared" Visible="false">
                                    
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Id Tramite"           ReadOnly="True" VisibleIndex="0" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Accion"               ReadOnly="True" VisibleIndex="1" Width="1000" Visible="true"></dx:GridViewDataTextColumn>
                                        
                                    </Columns>

                                    <SettingsBehavior AllowSelectByRowClick="false" 
                                        AllowSelectSingleRowOnly="true" 
                                        EnableRowHotTrack="True" 
                                        AllowEllipsisInText="true"  />
                                    <SettingsPager  Mode="ShowAllRecords"/>
                                    <SettingsDetail ShowDetailRow="false" />
                                    <Settings VerticalScrollBarMode="Visible" 
                                        VerticalScrollableHeight="300" 
                                        HorizontalScrollBarMode="Visible" />
                                    <SettingsSearchPanel Visible="false" />
                            </dx:ASPxGridView>
                        </div>
                        <div class="col-md-1"></div> 
                    </div>

                    <div class="row">
                        <hr />
                        <br />&nbsp;
                    </div>
                    <div class="row">
                        <h3>&nbsp; Información del proceso de la Póliza.</h3>

                        <div class="col-md-1"></div> 
                        <div class="col-md-10"> 
                            <dx:ASPxGridView ID="grid" 
                                ClientInstanceName="grid" 
                                runat="server" 
                                AutoGenerateColumns="false"
                                KeyFieldName="ID"
                                Width="100%"
                                OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared" Visible="false">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Id Trámite"           ReadOnly="True" VisibleIndex="0" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Id Trámite Mesa"      ReadOnly="True" VisibleIndex="1" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="FechaRegistro"        ReadOnly="True" VisibleIndex="2" Width="180" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="FechaTermino"         ReadOnly="True" VisibleIndex="3" Width="180" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Status Trámite"       ReadOnly="True" VisibleIndex="4" Width="150" Visible="false"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Usuario"              ReadOnly="True" VisibleIndex="5" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Mesa"                 ReadOnly="True" VisibleIndex="6" Width="150" Visible="true"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Status Mesa"          ReadOnly="True" VisibleIndex="7" Width="150" Visible="true"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Rechazo"              ReadOnly="True" VisibleIndex="8" Width="30" Visible="true"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Motivo Rechazo"       ReadOnly="True" VisibleIndex="9" Width="500" Visible="true"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Obs. Rechazo"         ReadOnly="True" VisibleIndex="10" Width="1000" Visible="true"></dx:GridViewDataTextColumn>
                                    </Columns>

                                    <SettingsBehavior AllowSelectByRowClick="false" 
                                        AllowSelectSingleRowOnly="true" 
                                        EnableRowHotTrack="True" 
                                        AllowEllipsisInText="true"  />
                                    <SettingsPager  Mode="ShowAllRecords"/>
                                    <SettingsDetail ShowDetailRow="false" />
                                    <Settings VerticalScrollBarMode="Visible" 
                                        VerticalScrollableHeight="300" 
                                        HorizontalScrollBarMode="Visible" />
                                    <SettingsSearchPanel Visible="false" />
                            </dx:ASPxGridView>
                        </div>
                        <div class="col-md-1"></div> 
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>