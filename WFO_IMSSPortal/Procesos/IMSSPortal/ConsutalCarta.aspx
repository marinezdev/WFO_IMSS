<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="ConsutalCarta.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.ConsutalCarta" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Consulta de Carta</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <p class="text-muted font-13 m-b-30">Realiza la consulta de la carta asignada al movimiento en el WFO.</p>
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
                    <div class="row" runat="server" id="CartaPDF" visible="false">
                        <div class="col-md-1 col-sm-1 col-xs-12 text-left">&nbsp;</div>
                        <div class="col-md-10 col-sm-10 col-xs-12 text-left">
                            <div class="x_panel">
                                <div class="x_content text-left" style="width: 100%; height:300px; ">
                                    <asp:Literal ID="ltMuestraPdf" runat="server" ></asp:Literal>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-1 col-sm-1 col-xs-12 text-left">&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
