<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DesbloqueoUsuarios.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.DesbloqueoUsuarios" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Desbloqueo de Usuarios</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                                        <table>
                        <tr><td>Clave o Nombre del usuario:</td><td><asp:TextBox ID="txtUsuario" runat="server" Width="250px" CssClass="form-control"></asp:TextBox></td><td>&nbsp;<asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" /></td></tr>
                    </table>

                    <asp:GridView ID="GVUsuarios" runat="server" AutoGenerateColumns="false" 
                        OnRowCommand="GVUsuarios_RowCommand" 
                        CellPadding="5" CellSpacing="5" 
                        HeaderStyle-HorizontalAlign="center" 
                        CssClass="table" 
                        Font-Size="12px" 
                        AlternatingRowStyle-BackColor="LightGray">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Usuario" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="Clave" HeaderText="Clave" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                            <asp:CheckBoxField DataField="Conectado" HeaderText="En línea" HeaderStyle-Wrap="false" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                            <asp:CheckBoxField DataField="Activo" HeaderText="Estado" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                            <asp:BoundField DataField="FechaCambioClave" HeaderText="Cambio Clave" HeaderStyle-Wrap="false" HeaderStyle-BackColor="Gray" HeaderStyle-ForeColor="White" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkDesactivar" runat="server" Text="Activar" CommandArgument='<%# Bind("IdUsuario") %>' CommandName="Desactivar" Font-Bold="true"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkReiniciar" runat="server" Text="Reiniciar Contraseña" CommandArgument='<%# Bind("IdUsuario") %>' CommandName="ReiniciarContra" Font-Bold="true"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:Label ID="lblMensajesUsuarios" runat="server" Font-Bold="true"></asp:Label>



                </div>
            </div>
        </div>
    </div>


</asp:Content>