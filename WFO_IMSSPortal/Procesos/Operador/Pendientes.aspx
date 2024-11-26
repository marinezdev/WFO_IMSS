<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="Pendientes.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Operador.Pendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <script>
        function Cantidades(id) {
            var boton = document.getElementById('<%=btnConsultar.ClientID%>');
            $("#<%= hfIdPendiente.ClientID %>").val(id);
            boton.click();
        }
    </script>

    <asp:UpdatePanel ID="ObservacionesCartaEjecucion" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
             <!-- Campos Ocultos -->
            <div>
                <asp:HiddenField ID="hfIdPendiente" runat="server" />
            </div>

            <!-- MODAL DE BITACORA -->
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                            <h4 class="modal-title" id="myModalLabel2">
                                <asp:label ID="TituloModal" runat="server" Text="">
                                </asp:label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:Repeater ID="rptTramite" runat="server" OnItemCommand="rptTramite_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="datatable" class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Trámite</th>
                                                        <th>Poliza</th>
                                                        <th>Quincena</th>
                                                        <th>Tipo Nomina</th>
                                                        <th>Tipo Movimiento</th>
                                                        <th>Mesa</th>
                                                        <th>Status Mesa</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("FolioCompuesto")%></td>
                                                <td><%#Eval("Poliza")%></td>
                                                <td><%#Eval("Quincena")%></td>
                                                <td><%#Eval("TipoNomina")%></td>
                                                <td><%#Eval("TipoMovimiento")%></td>
                                                <td><%#Eval("NombreMesa")%></td>
                                                <td><%#Eval("EstatusMesa")%></td>
                                                <td><asp:ImageButton ID="imbtnConsultar" runat="server" ImageUrl="~/Imagenes/folder.png" CausesValidation="false" CommandName ="Consultar" CommandArgument='<%#Eval("IdTramite") + ";" +Eval("IdMesa")%>' /></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <asp:Button ID="btnConsultar" Style="display: none" runat="server" Text="Cerrar" class="btn btn-default" CausesValidation="False" OnClick="btnConsultar_Click"  />
                <asp:Literal id="MesasLiteral" runat=server  text=""/>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
