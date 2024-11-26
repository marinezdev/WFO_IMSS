<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmExtraccionMovimientos.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmExtraccionMovimientos" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <script>
        function onClientUploadCompleteAll(sender, e) {
            document.getElementById('uploadCompleteInfo').innerHTML = 'Se cargaron los archivos exitosamente.';
        }
    </script>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Extracción de Movimientos de MetLife</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


            <div style="width: 90%; margin: auto">

                <table style="width:70%; margin:auto;">

                    <tr>
                        <td>Observaciones:</td>
                        <td>
                            <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="10" Columns="50" ></asp:TextBox>
                            <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtObservaciones" EnableSanitization="false">
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
                        <td></td>
                    </tr>
                    <tr>
                        <td>Subir Archivo Excel:</td>
                        <td>
                            <table>
                                <tr><td colspan="3">Logitud máxima del nombre del archivo: 23 caracteres.</td></tr>
                                <tr>
                                    <td><ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="true" ClientIDMode="AutoID" UploaderStyle="Modern" /></td>
                                    <td>
                                        <asp:Button ID="BtnExcelAceptar" runat="server" CssClass="boton" Text="Guardar" ClientIDMode="Static" OnClick="BtnExcelAceptar_Click" />
                                    </td>
                                    <td><asp:Label ID="lblProcesadoExcel" runat="server" ForeColor="Green"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td style="height: 31px">Año/Quincena:</td>
                        <td style="height: 31px">
                            <asp:UpdatePanel ID="UPAnnQuincena" runat="server">
                                <ContentTemplate>

                                    <asp:DropDownList ID="ddlAnnQuincena" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAnnQuincena_SelectedIndexChanged"></asp:DropDownList>
                                    

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="ddlAnnQuincena" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:HiddenField ID="HFddlQuincena" runat="server" />

                        </td><td style="height: 31px"></td>
                    </tr>
                    <tr>
                        <td>Estructura:</td>
                        <td>

                            <asp:UpdatePanel ID="UPrblEstructura" runat="server">
                                <ContentTemplate>

                                    <asp:RadioButtonList ID="rblEstructura" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblEstructura_SelectedIndexChanged">
                                        <asp:ListItem Value="A" Text="Activos"></asp:ListItem>
                                        <asp:ListItem Value="E" Text="Estatutos"></asp:ListItem>
                                        <asp:ListItem Value="J" Text="jubilados"></asp:ListItem>
                                        <asp:ListItem Value="M" Text="Mandos"></asp:ListItem>
                                    </asp:RadioButtonList>

                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="rblEstructura" />
                                </Triggers>
                            </asp:UpdatePanel>



                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Seleccionar archivos de texto:</td>
                        <td>
                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" OnUploadComplete="AjaxFileUpload1_UploadComplete" OnClientUploadCompleteAll="onClientUploadCompleteAll" AllowedFileTypes="txt" />
                        </td>
                        <td></td>
                    </tr>
                    <tr><td>&nbsp;</td><td><div id="uploadCompleteInfo" style="color: green"></div></td><td>&nbsp;</td></tr>
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="BtnAceptar" runat="server" Text="Procesar Achivos" CssClass="boton" OnClick="BtnAceptar_Click" />
                        </td>
                    </tr>
                </table>
            </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
