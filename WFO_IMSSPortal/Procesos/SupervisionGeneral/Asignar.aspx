<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignar.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.SupervisionGeneral.Asignar" MasterPageFile="~/Utilerias/Site.Master" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server" EnableViewState="true">
<style>
    th, td { padding: 3px }
</style>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Asignar</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <table id="tablaBusqueda" runat="server">
                        <tr><td colspan="4"><h3>Buscar por:</h3></td></tr>
                        <tr><td>Folio</td><td colspan="3"><asp:TextBox ID="txtFolio" runat="server" class="form-control" Width="150px"></asp:TextBox></td><td rowspan="5"><asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnBuscar_Click" /></td></tr>
                        <tr>
                            <td>Fecha Registro del&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtRegistroDel" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRegistroDel" />
                            </td>
                            <td>&nbsp;Al&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtRegistroAl" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRegistroAl" />
                            </td>
                        </tr>
                        <tr>
                            <td>Fecha Solicitud del&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtSolicitudDel" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtSolicitudDel" />
                            </td>
                            <td>&nbsp;Al&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtSolicitudAl" runat="server" class="form-control" Width="100px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtSolicitudAl" />
                            </td>
                        </tr>
                        <tr><td>Promotoría</td><td colspan="3"><asp:DropDownList ID="DDLCatPromotoria" runat="server" class="form-control" EnableViewState="true"></asp:DropDownList></td></tr>
                        <tr><td>Estado</td><td colspan="3"><asp:DropDownList ID="DDLEstados" runat="server" class="form-control"></asp:DropDownList>  </td></tr>
                        <tr><td colspan="5" align="center">&nbsp;</td></tr>
                    </table>

                    <asp:GridView ID="GVTramites" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LigaAsignar" runat="server" CommandName="Select" CommandArgument='<%# Eval("Id") + "," + Eval("IdUsuario") %>' Text="Asignar" OnClick="LigaAsignar_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Folio" HeaderText="Folio" />
                            <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Trámite" />
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                            <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha Solicitud" />
                            <asp:BoundField DataField="Promotoría" HeaderText="Promotoría" />
                            <asp:BoundField DataField="Status" HeaderText="Estado" />
                        </Columns>
                    </asp:GridView>

                    <!-- gridview de asignación de mesas disponibles -->

                    <table id="tablaMesas" runat="server" visible="false">
                        <tr><td>Cambio de Usuario para una mesa</td></tr>
                        <tr><td>
                                <asp:GridView ID="GVMesas" runat="server" AutoGenerateColumns="false" DataKeyNames="_IdTramiteMesa"
                                    OnRowEditing="GVMesas_RowEditing" 
                                    OnRowCancelingEdit="GVMesas_RowCancelingEdit"
                                    OnRowUpdating="GVMesas_RowUpdating" 
                                    OnSelectedIndexChanged="GVMesas_SelectedIndexChanged" 
                                    OnRowDataBound="GVMesas_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="_Mesa" HeaderText="Mesa" HeaderStyle-HorizontalAlign="Center" ReadOnly="true" />
                                        <asp:BoundField DataField="_Estado" HeaderText="Estado" ReadOnly="true" />
                                        <asp:TemplateField HeaderText="Usuario">
                                            <ItemTemplate>
                                                <asp:Label ID="LblUsuario" runat="server" Text='<%# Eval("_Usuario") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlUsuarios" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="true" ButtonType="Link" EditText="Modificar" CancelText="Cancelar" UpdateText="Cambiar" />
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