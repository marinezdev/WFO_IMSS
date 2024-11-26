<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="frmExtraccionDuplicados.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmExtraccionDuplicados" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Extracción. Listado de Movimientos Duplicados.</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena:</strong>&nbsp;
                                <asp:DropDownList ID="cboQuicena" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Tipo Nomina:</strong>&nbsp;
                                <asp:DropDownList ID="cboTipoNomina" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-12 col-xs-12 form-group has-feedback">
                                <br />
                                <asp:Button ID="BtnContinuar" runat="server"  AutoPostBack="True" Text="Listar Movimientos" Class="btn btn-success" OnClick="BtnConsultar_Click" />
                                <br /><br />
                                <asp:Label ID="lblMensajes" runat="server" text="" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <hr />
                            <asp:Repeater ID="RepeaterFechas" runat="server" OnItemCommand="rptTramite_ItemCommand" >
                                <HeaderTemplate>
                                    <table id="example" class="table table-striped table-bordered" style="width:100%">
                                        <thead>
                                            <tr>
                                                <th>Trabajador</th>
                                                <th>Matrícula</th>
                                                <th>Póliza</th>
                                                <th>Movimiento</th>
                                                <th>Nómina</th>
                                                <th>Quincena</th>
                                                <th>Importe</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("Trabajador")%></td>
                                        <td><%#Eval("Matricula")%></td>
                                        <td><%#Eval("Poliza")%></td>
                                        <td><%#Eval("TipoMovimiento")%></td>
                                        <td><%#Eval("TipoNomina")%></td>
                                        <td><%#Eval("Quincena")%></td>
                                        <td><%#Eval("Importe")%></td>
                                        <td style="width: 20px; text-align:center">
                                            <%# Eval("Id").ToString() == "True" ? "<a href='frmExtraccionDuplicados.aspx?Quincena=" + cboQuicena.SelectedValue.ToString() + "&TipoNimina=" + cboTipoNomina.SelectedValue.ToString() + "&Activar=" + Eval("Id").ToString() + "'><img src='../../Imagenes/acpetado.jpg' alt='Duplicados' /></a>" : "<a href='frmExtraccionDuplicados.aspx?Quincena=" + cboQuicena.SelectedValue.ToString() + "&TipoNimina=" + cboTipoNomina.SelectedValue.ToString() + "&Activar=" + Eval("Id").ToString() + "'><img src='../../Imagenes/rechazado.jpg' alt='Duplicados' /></a>" %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                            </div>                            
                            <div class="col-md-6 col-sm-12 col-xs-12 form-group has-feedback">
                                <asp:Button ID="btnGuardarEnlace" runat="server"  AutoPostBack="True" Text="Aplicar Movimientos para Enlace" Class="btn btn-info" OnClick="btnGuardarEnlace_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>