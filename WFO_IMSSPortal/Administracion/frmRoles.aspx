<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRoles.aspx.cs" Inherits="WFO_IMSSPortal.Administracion.frmRoles" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <style>
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Roles</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="BtnNuevo" CancelControlID="BtnCancelar" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>

                    <asp:Panel ID="Panel1" runat="server" align="center" Style="background-color: white; display: none; padding: 5px">

                        <table style="background-color: white">
                            <tr><td><strong>Nombre:</strong></td><td><asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox></td></tr>
                            <tr><td><strong>Página de acceso:</strong></td><td><asp:TextBox ID="txtAcceso" runat="server" class="form-control"></asp:TextBox></td></tr>
                            <tr><td>&nbsp;</td><td></td></tr>
                            <tr><td colspan="2" align="center">
                                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click"  CssClass="btn btn-primary" /> 
                                <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>



                    <table>
                        <tr><td><asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" /></td></tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:LinkButton ID="LigaEditar" runat="server" CommandName="Select" Text="Editar" OnClick="LigaEditar_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
