<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="frmFormatoEnvios2.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmFormatoEnvios2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Utilerias/Archivos.ascx" TagPrefix="uc1" TagName="Archivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Formato Envío de Movimientos de <strong><%=Request["t"] %></strong> a MetLife<asp:Label ID="Label2" runat="server"></asp:Label></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                     <div style="width: 90%; margin: auto">
                        <table style="width:100%; margin:auto;">
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td><strong>Tipo de Nómina:</strong></td>
                                            <td>                                    
                                                <asp:DropDownList ID="ddlTipoNomina" runat="server" Width="200px" class="form-control">
                                                <asp:ListItem Value="" Text="Seleccione" ></asp:ListItem>
                                                <asp:ListItem Value="AA" Text="Activos" ></asp:ListItem>
                                                <asp:ListItem Value="EA" Text="Estatuto A" ></asp:ListItem>
                                                <asp:ListItem Value="JJ" Text="Jubilados" ></asp:ListItem>
                                                <asp:ListItem Value="MM" Text="Mandos" ></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label runat="server" ID="lblTipoNomina" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><strong>Tipo de Movimiento:</strong></td>
                                            <td>
                                                <asp:DropDownList ID="ddlTipoMovimiento" runat="server" Width="200px" class="form-control">
                                                    <asp:ListItem Value="" Text="Seleccione" ></asp:ListItem>
                                                    <asp:ListItem Value="A" Text="Alta" ></asp:ListItem>
                                                    <asp:ListItem Value="M" Text="Modificación" ></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:Label runat="server" ID="lblTipoMovimiento" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><strong>Año/Quincena:</strong></td>
                                            <td>
                                                <asp:DropDownList ID="ddlAnnQuincena" runat="server" Width="200px" OnSelectedIndexChanged="ddlAnnQuincena_OnSelectedIndexChanged" AutoPostBack="true" class="form-control">
                                                </asp:DropDownList>
                                                <asp:Label runat="server" ID="lblAnnQuincena" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="middle">
                                    <strong>Comentarios:</strong>
                                    <asp:TextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Height="69px"></asp:TextBox>
                                    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtComentarios" EnableSanitization="false">
                                        <Toolbar>
                                            <ajaxToolkit:Bold />
                                            <ajaxToolkit:Italic />
                                            <ajaxToolkit:Underline />
                                            <ajaxToolkit:JustifyLeft />
                                            <ajaxToolkit:JustifyCenter />
                                            <ajaxToolkit:JustifyFull />
                                            <ajaxToolkit:JustifyRight />
                                        </Toolbar>
                                    </ajaxToolkit:HtmlEditorExtender>
                                </td>

                            </tr>
                        </table>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td><strong>IMPORTAR ARCHIVO:</strong></td>
                                            <td><ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="true" ClientIDMode="AutoID" UploaderStyle="Modern" ErrorBackColor="Red" /></td>
                                            <td><asp:Button ID="btnImportar" runat="server" Text="Importar XLS" CssClass="btn btn-primary" OnClick="btnImportar_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"><asp:Label ID="lblProcesadoExcel" runat="server" ForeColor="Green"></asp:Label></td>
                            </tr>
                        </table>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td>Número de Póliza</td><td>Unidad de Pago</td><td></td><td style="visibility: hidden">Importe</td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom">
                                                <asp:TextBox ID="txtNoPoliza" runat="server" MaxLength="10"></asp:TextBox>
                                                <asp:Label runat="server" ID="lblNoPoliza" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            </td>
                                            <td valign="bottom">
                                                <asp:TextBox ID="txtUnidadPago" runat="server" MaxLength="10"></asp:TextBox>
                                                <asp:Label runat="server" ID="lblUnidadPago" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            </td>
                                            <td valign="bottom"><asp:Button ID="BtnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="BtnAgregar_Click" /></td>
                                            <td valign="bottom" style="visibility: hidden">
                                                <asp:TextBox ID="txtImporte" runat="server" MaxLength="10"></asp:TextBox>
                                                <asp:Label runat="server" ID="lblImporte" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table>
                            <tr>
                                <td style="width:40%" valign="top">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="GVRegistros" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2"
                                                AutoGenerateColumns="False" 
                                                onrowcommand="GVRegistros_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="T. Nomina">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlNomina" runat="server" Text='<%# Eval("TipoNomina") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="T. Movimiento">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlTipoMovimiento" runat="server" Text='<%# Eval("TipoMovimiento") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Año/Quincena">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlAnoQuincena" runat="server" Text='<%# Eval("AñoQuincena") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Póliza">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlPoliza" runat="server" Text='<%# Eval("Poliza") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="U. Pago">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlUnidadPago" runat="server" Text='<%# Eval("Unidad") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Archivo">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlArchivo" runat="server" Text='<%# Eval("Archivo") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <%--<asp:TemplateField HeaderText="Importe" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="ltrlImporte" runat="server" Text='<%# Eval("Importe") %>'></asp:Literal>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
        
                                                        <asp:TemplateField HeaderText="Acciones">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnViewmore"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Borrar" runat="server" Text="Borrar" />
                                                        </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>
                                                
                                                <asp:GridView ID="GVComparador" runat="server"></asp:GridView>

                                                <asp:Label runat="server" ID="lblAceptar" Visible="false" Text=" * No coinciden los movimientos con las cartas de Instrucción." ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                <asp:Button ID="BtnAceptar" runat="server" Text="Asociar Cartas de Instrucción" CssClass="btn btn-primary" OnClick="BtnAceptar_Click" />&nbsp;
                                                <asp:Label runat="server" ID ="lblResumeRegistros" Text="" Visible ="false" Font-Bold="true" Font-Size="Medium" ForeColor="Blue"></asp:Label>
                                                <br />
                                                <asp:Button id="BtnGuardar" runat="server" Text="Guardar Movimientos" CssClass="btn btn-primary" OnClick="BtnGuardar_Click" Visible="false" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 20%" valign="top">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                Agregar Cartas de Instrucción (PDF)
                                                <asp:Label runat="server" ID="lblUpload" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                                <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="pdf" Width="100%" OnUploadComplete="AjaxFileUpload1_UploadComplete" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
