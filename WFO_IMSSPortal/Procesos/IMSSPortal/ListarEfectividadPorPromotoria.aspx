<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarEfectividadPorPromotoria.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.ListarEfectividadPorPromotoria" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Listar Efectividad por Promotoría</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                     <div style="width: 100%; width:1150px; display:block;">
                        <table>
                            <tr>
                                <td valign="top">
                                    Quincena:<br /> 
                                    <asp:DropDownList ID="DDLQuincena" runat="server" class="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvValidarSelectQuincena" runat="server" ControlToValidate="DDLQuincena" ForeColor="Crimson" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator> 
                                    <br />
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td valign="top">
                                    Tipo de nómina:<br />
                                    <asp:RadioButtonList ID="RBLNomina" runat="server" RepeatDirection="Horizontal" class="form-control">
                                        <asp:ListItem Value="JJ" Text="Jubilados"></asp:ListItem>
                                        <asp:ListItem Value="AA" Text="Activos"></asp:ListItem>
                                        <asp:ListItem Value="EA" Text="Estatuto A"></asp:ListItem>
                                        <asp:ListItem Value="MM" Text="Mandos"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="rfvValidarNomina" runat="server" ControlToValidate="RBLNomina" ForeColor="Crimson" ErrorMessage="Elija una opción" Display="Dynamic"></asp:RequiredFieldValidator> 
                                    <br />
                                </td>

                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>

                                                <asp:Button ID="btnBuscar" runat="server"  AutoPostBack="True" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnBuscar" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    
                                </td>
                                <td>

                                    <asp:UpdateProgress ID="updateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <div>
                                                <asp:Image ID="Imagen1" runat="server" ImageUrl="~/Imagenes/ajax-loader.gif" />
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

                                </td>
                                <td><asp:Label runat="server" ID="lblMensaje" ForeColor="Red" Font-Bold="true" Font-Size="Large" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div> 

                    <asp:LinkButton ID="lnkExportarResumen" runat="server"  CausesValidation="False" OnClick="lnkExportar_Click" Visible="false">
                        <img src="../../Imagenes/excel.png"/>
                    </asp:LinkButton>


                    <div style="width: 100%; height: 30px; overflow: scroll; overflow-x:auto; width:1150px; display:none;">
                        <asp:GridView ID="GVEfectividad" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2" Width="99%">
                        </asp:GridView>
                    </div>

                    <div>
        
                        <dx:ASPxGridView ID="gridEfectividad" 
                            ClientInstanceName="gridEfectividad" 
                            runat="server" 
                            Width="100%"
                            AutoGenerateColumns="true"
                            KeyFieldName="ID" Visible="false"
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
                            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="100" HorizontalScrollBarMode="Visible" />
                            <SettingsSearchPanel Visible="false" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="grdExport" runat="server" GridViewID="gridEfectividad"></dx:ASPxGridViewExporter>
                    </div>
                    <br />&nbsp;
                    <div style="width: 100%; height: 400px; overflow: scroll; overflow-x:auto; width:1150px; display:none">
                        <asp:GridView ID="GVConcentrado" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2" Width="99%">
                        </asp:GridView>
                    </div>

                    <%--<asp:LinkButton ID="lnkExportarConcentrado" runat="server"  CausesValidation="False" OnClick="lnkExportarConcentrado_Click">
                        <img src="../Imagenes/excel.png"/>
                    </asp:LinkButton>--%>
                    <div>
                        <dx:ASPxGridView ID="gridConcentrado" 
                            ClientInstanceName="gridConcentrado" 
                            runat="server" 
                            Width="100%" 
                            AutoGenerateColumns="true"
                            KeyFieldName="ID" Visible="false"
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