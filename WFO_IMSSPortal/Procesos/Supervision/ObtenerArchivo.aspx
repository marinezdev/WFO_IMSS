<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObtenerArchivo.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.ObtenerArchivo" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Obtener Archivos de la Base de Datos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <table>
                        <tr><td>Nombre del archivo:</td><td><asp:TextBox ID="txtArchivo" runat="server" Width="250px" CssClass="form-control"></asp:TextBox></td><td>&nbsp;<asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" /></td></tr>
                    </table>

                    <asp:GridView ID="GVArchivos" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Archivo" />
                            <asp:CheckBoxField  DataField="Activo" HeaderText="Estado" />
                            <asp:BoundField DataField="IdUsuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LigaVisualizar" runat="server" CommandName="Select" Text="Ver Archivo" OnClick="LigaVisualizar_Click" ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div class="x_content text-left" style="width: 100%; height:600px; ">
                      <asp:Literal ID="ltMuestraPdf" runat="server" ></asp:Literal>
                    </div>



                </div>
            </div>
        </div>
    </div>
</asp:Content>