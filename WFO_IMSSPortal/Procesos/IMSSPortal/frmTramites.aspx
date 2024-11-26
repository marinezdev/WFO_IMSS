<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTramites.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmTramites" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Trámites</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <div style="width: 90%; margin: auto">
                        <table style="width:100%; margin:auto;">
                            <tr><td></td><td></td><td><strong>Fecha de Registro:</strong>&nbsp;<%=DateTime.Now %></td></tr>
                            <tr style="font-weight: bold"><td>Tipo de Nómina</td><td>Tipo de Movimiento</td><td></td></tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rblTipoNomina" runat="server">
                                        <asp:ListItem Text="Activos" Value="activos"></asp:ListItem>
                                        <asp:ListItem Text="Estatuto A" Value="estatutoa"></asp:ListItem>
                                        <asp:ListItem Text="Jubilados" Value="jubilados"></asp:ListItem>
                                        <asp:ListItem Text="Mandos" Value="mandos"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td valign="top">
                                    <asp:RadioButtonList ID="rblTipoMovimiento" runat="server">
                                        <asp:ListItem Text="Alta" Value="Alta"></asp:ListItem>
                                        <asp:ListItem Text="Modificación" Value="Modificación"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td></td>
                            </tr>
                            <tr><td colspan="3" align="center"><asp:Button ID="BtnContinuar" runat="server" Text="Aceptar" CssClass="boton" OnClick="BtnContinuar_Click" /></td></tr>
                            <tr><td></td><td></td><td></td></tr>
                        </table>
                    </div>



                </div>
            </div>
        </div>
    </div>


</asp:Content>