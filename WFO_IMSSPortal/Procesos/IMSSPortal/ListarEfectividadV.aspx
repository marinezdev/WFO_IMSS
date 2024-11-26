<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="ListarEfectividadV.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.ListarEfectividadV" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <script type="text/javascript" language="javascript">
        function postbackButtonClick() {
            updateProgress = $find("<%= UPEnocntrar.ClientID %>");
        window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
        return true;
        }
    </script>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Listar Efectividad</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                <asp:UpdatePanel ID="UPBUscar" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                      <div style="width: 100%; width:1150px; display:block;">
                        <table>
                            <tr>
                                <td>
                                    Quincena:<br /> 
                                    <asp:DropDownList ID="DDLQuincena" runat="server" class="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvValidarSelectQuincena" runat="server" ControlToValidate="DDLQuincena" ForeColor="Crimson" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator> 
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td valign="top">
                                    Tipo de nómina:<br />
                                    <asp:DropDownList ID="DDLTipoNomina" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Seleccione" ></asp:ListItem>
                                        <asp:ListItem Value="AA" Text="Activos" ></asp:ListItem>
                                        <asp:ListItem Value="EA" Text="Estatuto A" ></asp:ListItem>
                                        <asp:ListItem Value="JJ" Text="Jubilados" ></asp:ListItem>
                                        <asp:ListItem Value="MM" Text="Mandos" ></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvValidarNomina" runat="server" ControlToValidate="DDLTipoNomina" ForeColor="Crimson" ErrorMessage="Elija una opción" Display="Dynamic"></asp:RequiredFieldValidator> 
                                </td>

                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" OnClientClick="return postbackButtonClick();" />
                                </td>
                                <td>
                                    <asp:UpdateProgress ID="UPEnocntrar" runat="server" AssociatedUpdatePanelID="UPBuscar">
                                        <ProgressTemplate>
                                            <asp:Image ID="Espera" runat="server" ImageUrl="~/Imagenes/ajax-loader.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td><asp:Label runat="server" ID="lblMensaje" ForeColor="Red" Font-Bold="true" Font-Size="Large" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div> 

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnBuscar" />
                    </Triggers>
                </asp:UpdatePanel>

                    <asp:LinkButton ID="lnkExportarResumen" runat="server"  CausesValidation="False" OnClick="lnkExportar_Click" ToolTip="Exportar a Excel" Visible="false">
                        <img src="../../Imagenes/excel.png" title="Exportar a Excel" />
                    </asp:LinkButton>


                    <div style="width: 100%; height: 100px; overflow: scroll; overflow-x:auto; width:1150px; display:none;">
                        <asp:GridView ID="GVEfectividad" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2" Width="99%">
                        </asp:GridView>
                    </div>


                    <div>
        
                        <dx:ASPxGridView ID="gridEfectividad" 
                            ClientInstanceName="gridEfectividad" 
                            runat="server" 
                            Width="100%" 
                            AutoGenerateColumns="true"
                            KeyFieldName="ID"  Visible="false" SettingsBehavior-ProcessSelectionChangedOnServer="true"
                            >
                                <Templates>
                                    <EmptyDataRow>
                                        <div style="width: 300px;">
                                            No hay datos para desplegar...
                                        </div>
                                    </EmptyDataRow>
                                </Templates>
                            <SettingsBehavior AllowSelectByRowClick="false" AllowSelectSingleRowOnly="true" EnableRowHotTrack="True" AllowEllipsisInText="true"  />
                            <SettingsPager  Mode="ShowAllRecords"/>
                            <SettingsDetail ShowDetailRow="false" />
                            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" HorizontalScrollBarMode="Visible" />
                            <SettingsSearchPanel Visible="false" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="grdExport" runat="server" GridViewID="gridEfectividad"></dx:ASPxGridViewExporter>
                    </div>
                    <br />&nbsp;
                    <div style="width: 100%; height: 400px; overflow: scroll; overflow-x:auto; width:1150px; display:none">
                        <asp:GridView ID="GVConcentrado" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2" Width="99%" Caption="REPORTE">
                        </asp:GridView>
                    </div>

                    <div>
                        <dx:ASPxGridView ID="gridConcentrado" 
                            ClientInstanceName="gridConcentrado" 
                            runat="server" 
                            Width="100%" 
                            AutoGenerateColumns="true"
                            KeyFieldName="ID"  Visible="false" SettingsBehavior-ProcessSelectionChangedOnServer="true"
                            >            
                                <Templates>
                                    <EmptyDataRow>
                                        <div style="width: 300px;">
                                            No hay datos para desplegar...
                                        </div>
                                    </EmptyDataRow>
                                </Templates>
                            <SettingsBehavior AllowSelectByRowClick="false" AllowSelectSingleRowOnly="true" EnableRowHotTrack="True" AllowEllipsisInText="true"  />
                            <SettingsPager  Mode="ShowAllRecords"/>
                            <SettingsDetail ShowDetailRow="false" />
                            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" HorizontalScrollBarMode="Visible" />
                            <SettingsSearchPanel Visible="false" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="grdExportConcentrado" runat="server" GridViewID="gridConcentrado"></dx:ASPxGridViewExporter>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>