<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="MapaGeneralDetalleProd.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.MapaGeneralDetalleProd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="container-fluid">
        
        <asp:HiddenField ID="hfIdMesa" runat="server" Value="0" />
        <asp:HiddenField ID="hfIdFlujo" runat="server" Value="0" />
        <asp:HiddenField ID="hfIdCalendario" runat="server" Value="0" />

        <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div class="col-md-12 col-sm-12 col-xs-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <asp:Label ID="lblTitulo" runat="server" Text="" Font-Bold="True" ForeColor="#73879C" Font-Size="30px" Font-Italic="false"></asp:Label>
                            <div class="clearfix"></div>
                        </div>
                        <div class="x_content">
                            <p class="text-muted font-13 m-b-30">
                                <div class="row">
                                    <br />
                                    <asp:Repeater ID="MesaResumen" runat="server">
                                        <HeaderTemplate>
                                            <table id="tMesaResumen" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th style="text-align: center;">Mesa</th>
                                                        <th style="text-align: center;">Mesa</th>
                                                        <th style="text-align: center;">Trámites Pendientes de Operación</th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;"><i class='fa <%#Eval("Icono")%> fa-2x'></i></td>
                                                <td style="text-align: center; font-size:20px; "><%#Eval("Mesa")%></td>
                                                <td style="text-align: center; font-size:20px; "><%#Eval("TramitesDisponibles")%></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>

                                <div class="row">
                                <br />
                                <hr />
                                <asp:Repeater ID="RepeaterFechas" runat="server" OnItemCommand="rptTramite_ItemCommand" Visible="false">
                                    <HeaderTemplate>
                                        <table id="example" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="text-align: center;">Status Mesa</th>
                                                    <th style="text-align: center;">Usuario</th>
                                                    <th style="text-align: center;">Póliza</th>
                                                    <th style="text-align: center;">Quincena</th>
                                                    <th style="text-align: center;">Importe</th>
                                                    <th style="text-align: center;">Tipo de Nomina</th>
                                                    <th style="text-align: center;">Tipo de Movimiento</th>
                                                    <th style="text-align: center;">Unidad Pago</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("statusMesa")%></td>
                                            <td><%#Eval("Usuario")%></td>
                                            <td><%#Eval("Poliza")%></td>
                                            <td><%#Eval("Quincena")%></td>
                                            <td><%#Eval("Importe")%></td>
                                            <td><%#Eval("TipoNomina")%></td>
                                            <td><%#Eval("TipoMovimiento")%></td>
                                            <td><%#Eval("UnidadPago")%></td>
                                            <td><asp:ImageButton ID="imbtnConsultar" runat="server" ImageUrl="~/Imagenes/folder.png" CommandName ="Consultar" CommandArgument='<%# Eval("IdTramite")%>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>

                            </p>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

</asp:Content>