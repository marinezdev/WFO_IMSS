<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMovimientos.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.ListarMovimientos" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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

                     <div style="width: 100%; width:1150px; display:block;">
                        <table>
                            <tr>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td valign="top">
                                    Quincena:<br /> 
                                    <asp:DropDownList ID="DDLQuincena" runat="server"></asp:DropDownList><br />
                                    <asp:RequiredFieldValidator ID="rfvValidarSelectQuincena" runat="server" ControlToValidate="DDLQuincena" ForeColor="Crimson" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator> 
                                    <br />
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td valign="top">

                                </td>

                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server"  AutoPostBack="True" Text="Buscar" CssClass="boton" OnClick="btnBuscar_Click" />
                                    <asp:Label runat="server" ID="lblMensaje" ForeColor="Red" Font-Bold="true" Font-Size="Large" Text=""></asp:Label>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>

                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </div> 

                    <asp:Label ID="LblMensajeDescarga" runat="server" Text="Para descargar un archivo, dé click en la liga correspondiente, se abrirá un cuadro de diálogo para verlo o descargarlo." Visible="false"></asp:Label>
                    <div style="width: 100%; height: 400px; overflow: scroll; overflow-x:auto; width:1150px;">
                        <asp:GridView ID="GVMovmientos" runat="server" Width="100%" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Id Trámite" DataField="IDTRAMITE"           />
                                <asp:BoundField HeaderText="Póliza" DataField="POLIZA"                  />
                                <asp:BoundField HeaderText="Unidad de Pago" DataField="UNIDADPAGO"      />
                                <asp:TemplateField HeaderText="Descargar Archivo">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkArchivo" runat="server" Text='<%# Eval("ARCHIVO") %>' CommandArgument='<%# Eval("ARCHIVO") %>' OnClick="DescargarArchivo"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Fecha" DataField="FECHA"                    />
                                <asp:BoundField HeaderText="Tipo Nomina" DataField="TIPONOMINA"         />
                                <asp:BoundField HeaderText="Tipo Movimiento" DataField="TIPOMOVIMIENTO" />
                                <asp:BoundField HeaderText="Año / Quincena" DataField="ANNQUINCENA"     />
                                <asp:BoundField HeaderText="Id Promotoría" DataField="IDPROMOTORIA"     />
                                <asp:BoundField HeaderText="Promotoría" DataField="promotoria"          />
                                <asp:BoundField HeaderText="Status" DataField="ESTADO"                  />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div>
                        <dx:ASPxGridView ID="grid" 
                            ClientInstanceName="grid" 
                            runat="server" 
                            Width="100%" 
                            AutoGenerateColumns="false"
                            KeyFieldName="ID" Visible="false" >
                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True"                       VisibleIndex="0" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Id Trámite" FieldName="IDTRAMITE"           VisibleIndex="3" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Póliza" FieldName="POLIZA"                  VisibleIndex="4" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Unidad de Pago" FieldName="UNIDADPAGO"      VisibleIndex="5" Width="150" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Carta" FieldName="ARCHIVO"                  VisibleIndex="6" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Fecha" FieldName="FECHA"                    VisibleIndex="7" Width="200" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tipo Nomina" FieldName="TIPONOMINA"         VisibleIndex="8" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tipo Movimiento" FieldName="TIPOMOVIMIENTO" VisibleIndex="9" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Año / Quincena" FieldName="ANNQUINCENA"     VisibleIndex="10" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Id Promotoría" FieldName="IDPROMOTORIA"     VisibleIndex="11" Width="200" Visible="false"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Promotoría" FieldName="promotoria"          VisibleIndex="12" Width="150" Visible="true"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Status" FieldName="ESTADO"                  VisibleIndex="13" Width="200" Visible="false"></dx:GridViewDataTextColumn>
                                </Columns>
                                <Templates>
                                    <EmptyDataRow>
                                        <div style="width: 300px;">
                                            No hay datos para desplegar...
                                        </div>
                                    </EmptyDataRow>
                                </Templates>            
                            <SettingsBehavior AllowSelectByRowClick="true" />
                            <SettingsPager  Mode="ShowAllRecords"/>
                            <SettingsDetail ShowDetailRow="false" />
                            <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" HorizontalScrollBarMode="Visible" />
                            <SettingsSearchPanel Visible="false" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridViewExporter ID="grdExport" runat="server" GridViewID="grdPrueba"></dx:ASPxGridViewExporter>
                    </div>



                </div>
            </div>
        </div>
    </div>


</asp:Content>