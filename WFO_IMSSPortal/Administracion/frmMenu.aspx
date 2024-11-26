<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMenu.aspx.cs" Inherits="WFO_IMSSPortal.Administracion.frmMenu" MasterPageFile="~/Utilerias/Site.Master"%>

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
                    <h2>Menú</h2>
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
                            <tr><td align="right"><strong>Nombre de la opción:</strong></td><td><asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox></td></tr>
                            <tr><td align="right"><strong>Nombre de la página:</strong></td><td><asp:TextBox ID="txtUrl" runat="server" class="form-control"></asp:TextBox></td></tr>
                            <tr><td align="right"><strong>Icono:</strong></td><td><asp:DropDownList ID="DDLIconos" runat="server" class="form-control"></asp:DropDownList></td></tr>
                            <tr><td align="right"><strong>Pertenece a:</strong></td><td><asp:DropDownList ID="ddlPerteneceA" runat="server" class="form-control"></asp:DropDownList></td></tr>
                            <tr><td align="right"><strong>Categoría:</strong></td><td><asp:TextBox ID="txtCategoria" runat="server" class="form-control"></asp:TextBox></td></tr>
                            <tr><td align="right"><strong>Orden:</strong></td><td><asp:TextBox ID="txtOrden" runat="server" class="form-control"></asp:TextBox></td></tr>
                            <tr><td>&nbsp;</td><td></td></tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="BtnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="BtnAceptar_Click" />
                                    <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-primary" Text="Cancelar" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>


                    <table>
                        <tr><td><asp:Button ID="BtnNuevo" runat="server" CssClass="btn btn-primary" Text="Nuevo" /></td></tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <asp:LinkButton ID="LigaEditar" runat="server" CommandName="Select" Text="Editar" OnClick="LigaEditar_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField DataField="IdMenu" HeaderText="Id" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                        <asp:BoundField DataField="URL" HeaderText="URL" />
                                        <asp:BoundField DataField="Icono" HeaderText="Icono" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <span class='fa <%# Eval("Icono") %>'></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PerteneceA" HeaderText="Pertenece a" />
                                        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                                        <asp:BoundField DataField="Orden" HeaderText="Orden" />
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
