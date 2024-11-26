<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmValidar.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmValidar"  MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Validación</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <table style="width: 100%">
                        <tr>
                            <td valign="top" align="center">
                                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" FieldHeaderStyle-Font-Bold="true" FieldHeaderStyle-HorizontalAlign="Right" CellPadding="4" CellSpacing="4"></asp:DetailsView><br />
                    
                            </td>
                            <td valign="top" style="width: 100%">
                                <div id="dvEspacioPDF" style="width: 100%; height: 500px; vertical-align: top; border:1px solid black; overflow:auto" >
                                    <asp:Panel ID="PnlImagenes" runat="server" Height="100%"></asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">


                                <asp:UpdatePanel ID="UPBtnRechazar" runat="server">
                                    <ContentTemplate>

                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" CssClass="btnVerde" OnClick="BtnAceptar_Click" />
                                                </td>
                                                <td valign="top">
                                                    <asp:Button ID="BtnRechazar" runat="server" Text="Rechazar" CssClass="btnRojo" OnClick="BtnRechazar_Click" />
                                                    <asp:DropDownList ID="ddlRechazosInmediatos" runat="server" Visible="false"></asp:DropDownList><br />
                                                    <asp:DropDownList ID="ddlRechazosPromotorias" runat="server" Visible="false"></asp:DropDownList><br />
                                                    <asp:DropDownList ID="ddlRechazosSinCarta" runat="server" Visible="false"></asp:DropDownList><br />
                                                    <asp:DropDownList ID="ddlRechazosValidacionesImss" runat="server" Visible="false"></asp:DropDownList><br />
                                                    <asp:Button ID="BtnGuardarRechazo" runat="server" Text="Guardar Rechazo" CssClass="btnRojo" Visible=" false" OnClick="BtnGuardarRechazo_Click" />
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                    
                            </td>
                        </tr>
                    </table>





                </div>
            </div>
        </div>
    </div>


</asp:Content>