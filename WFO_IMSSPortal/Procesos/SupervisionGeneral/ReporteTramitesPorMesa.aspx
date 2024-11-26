<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteTramitesPorMesa.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.SupervisionGeneral.ReporteTramitesPorMesa" MasterPageFile="~/Utilerias/Site.Master" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server" EnableViewState="true">
<style>
    th { font-size: 12px; font-weight: normal }
    th, td { padding: 5px; border:1px solid black }
    td a { text-decoration: underline; color: blue }
</style>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Reporte de Trámites por Mesa</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <asp:DropDownList ID="DDLFase" runat="server" AutoPostBack="true" EnableViewState="true" OnSelectedIndexChanged="DDLFase_SelectedIndexChanged">
                        <asp:ListItem Value="0" Text="Seleccione..."></asp:ListItem>
                        <asp:ListItem Value="1" Text="Fase 1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Fase 2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Fase 3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Fase 4"></asp:ListItem>
                    </asp:DropDownList>
                    <br /><br />
                    <asp:GridView ID="GVReporte" runat="server"  AutoGenerateColumns="false" 
                        OnRowDataBound="GVReporte_RowDataBound" 
                        GridLines="Both" 
                        HeaderStyle-BackColor="LightGray" 
                        HeaderStyle-ForeColor="Black" 
                        RowStyle-HorizontalAlign="Right" 
                        FooterStyle-BackColor="LightGray" 
                        FooterStyle-HorizontalAlign="Right" 
                        FooterStyle-ForeColor="Black"
                        Font-Names="Tahoma" 
                        ShowFooter="true">
                        <Columns>
                            <asp:BoundField DataField="StatusMesa" HeaderText="Estado Mesa" />
                            <asp:TemplateField HeaderText="ADMISIÓN">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKAdmision" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=2&statusmesa=" + Eval("StatusMesa") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("ADMISIÓN") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="REVISIÓN DOCUMENTAL">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKRevision" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=3&statusmesa=" + Eval("StatusMesa") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("REVISIÓN DOCUMENTAL") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CAPTURA">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKCaptura" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=8&statusmesa=" + Eval("StatusMesa") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("CAPTURA") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CONTROL">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKControl" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=9&statusmesa=" + Eval("StatusMesa") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("CONTROL") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EJECUCIÓN">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKEjecucion" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=10&statusmesa=" + Eval("EJECUCIÓN") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("EJECUCIÓN") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CALIDAD">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKCalidad" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=11&statusmesa=" + Eval("CALIDAD") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("CALIDAD") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="KWIK">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HLKKwik" runat="server" NavigateUrl='<%# "~/Procesos/SupervisionGeneral/ReporteTramitesPorMesa.aspx?idmesa=12&statusmesa=" + Eval("StatusMesa") + "&f=" + DDLFase.SelectedValue %>' Text='<%# Eval("KWIK") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>



                        </Columns>
                    </asp:GridView>
                    <br /><br />
                    <asp:GridView ID="GVDetalle" runat="server" GridLines="Both" 
                        HeaderStyle-BackColor="LightGray" 
                        HeaderStyle-ForeColor="Black" 
                        RowStyle-HorizontalAlign="Right" 
                        FooterStyle-BackColor="LightGray" 
                        FooterStyle-HorizontalAlign="Right" 
                        FooterStyle-ForeColor="Black"
                        Font-Names="Tahoma">
                    </asp:GridView>


                </div>
            </div>
        </div>
    </div>



</asp:Content>