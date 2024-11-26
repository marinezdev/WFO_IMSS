<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmBorrarDuplicados.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmBorrarDuplicados" MasterPageFile="~/Utilerias/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Extracción</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    Poliza con duplicados: <asp:TextBox ID="txtPolizas" runat="server"></asp:TextBox><asp:Button ID="BtnBuscar" runat="server" CssClass="boton" Text="Buscar" OnClick="BtnBuscar_Click" />

                    <asp:GridView ID="GVDuplicados" runat="server" OnRowCommand="GVDuplicados_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' CommandName="EliminarRegistro"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>


                </div>
            </div>
        </div>
    </div>


</asp:Content>