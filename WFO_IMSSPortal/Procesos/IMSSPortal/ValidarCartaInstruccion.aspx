<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidarCartaInstruccion.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.ValidarCartaInstruccion" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Validar Carta Instrucción</h2>
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
                                <asp:DetailsView 
                                    ID="DetailsView1" 
                                    runat="server" 
                                    Height="50px" 
                                    Width="125px" 
                                    FieldHeaderStyle-Font-Bold="true" 
                                    FieldHeaderStyle-HorizontalAlign="Right" 
                                    CellPadding="4" 
                                    CellSpacing="4"></asp:DetailsView>
                                <br />&nbsp;

                                <strong>VALIDACIÓN DE CARTA</strong><br />&nbsp;
                                <table style="width:100%" border="0" >
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox1" AutoPostBack="false" Checked="false"  Text="Póliza" />
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox2" AutoPostBack="false" Checked="false"  Text="Unidad de Pago" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox3" AutoPostBack="false" Checked="false"  Text="Tipo Nomina" />
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox4" AutoPostBack="false" Checked="false"  Text="Matricula" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox7" AutoPostBack="false" Checked="false"  Text="Importe" />
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox8" AutoPostBack="false" Checked="false"  Text="Trabajador" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox5" AutoPostBack="false" Checked="false"  Text="Firma" />
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox6" AutoPostBack="false" Checked="false"  Text="Sello" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox9" AutoPostBack="false" Checked="false"  Text="Identificación Oficial" />
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox10" AutoPostBack="false" Checked="false"  Text="Sello Promotoría" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox11" AutoPostBack="false" Checked="false"  Text="Suma Asegurada" />
                                        </td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="CheckBox12" AutoPostBack="false" Checked="false"  Text="Monto Anual" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox runat="server" ID="CheckBox13" AutoPostBack="false" Checked="false"  Text="Importe Número y Letra" />
                                        </td>
                                    </tr>
                        
                                </table>
                            </td>
                            <td valign="top" style="width: 100%">
                                <div id="dvEspacioPDF" style="width: 100%; height: 500px; vertical-align: top; border:1px solid black; overflow:auto" >
                                    <asp:Panel ID="PnlImagenes" runat="server" Height="100%"></asp:Panel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td valign="top">
                                                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" CssClass="btnVerde" OnClick="BtnAceptar_Click" />
                                            </td>
                                            <td valign="top">
                                                <asp:Button ID="BtnRechazar" runat="server" Text="Rechazar" CssClass="btnRojo" OnClick="BtnRechazar_Click" />
                                                <asp:DropDownList ID="ddlRechazosPromotorias" runat="server" Visible="false"></asp:DropDownList><br />
                                                <asp:DropDownList ID="ddlRechazosValidacionesImss" runat="server" Visible="false"></asp:DropDownList><br />
                                                <asp:Button ID="BtnGuardarRechazo" runat="server" Text="Guardar Rechazo" CssClass="btnRojo" Visible=" false" OnClick="BtnGuardarRechazo_Click" />
                                                <asp:Label runat="server" ID="lblMensaje" Visible="false" Font-Size="Large" ForeColor="red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>