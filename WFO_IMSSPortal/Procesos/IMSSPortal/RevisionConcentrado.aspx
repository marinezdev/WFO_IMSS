<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisionConcentrado.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.RevisionConcentrado" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Revisión Concentrado</h2>
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
                                    <asp:Label runat="server" ID="lblFolio" Text="Folio:" Visible="false"></asp:Label><br />
                                    <asp:TextBox ID="txtFolio" runat="server" MaxLength="12" Width="200px" Visible="false"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="filTxtFolio" runat="server" TargetControlID="txtFolio" FilterType="Custom, Numbers, UppercaseLetters, lowercaseLetters" ValidChars="" />
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaIncio" Text="Fecha Inicio:"></asp:Label>
                                    <dx:ASPxDateEdit ID="dtFechaInicio" runat="server" Theme="Material" EditFormat="Custom" Width="210" AutoPostBack="false" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                    <asp:RequiredFieldValidator runat="server" id="reqValidaFehcaInicio" controltovalidate="dtFechaInicio" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
                                </td>
                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaFin" Text="Fecha Fin:"></asp:Label>
                                    <dx:ASPxDateEdit ID="dtFechaFin" runat="server" Theme="Material" EditFormat="Custom" Width="210" AutoPostBack="false" DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy">
                                    </dx:ASPxDateEdit>
                                    <asp:RequiredFieldValidator runat="server" id="reqValidaFehcaFin" controltovalidate="dtFechaFin" ForeColor="Crimson" errormessage="*" Font-Size="16px"/>
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
                                    Tipo de nómina:<br />
                                    <asp:RadioButtonList ID="RBLNomina" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="JJ" Text="Jubilados"></asp:ListItem>
                                        <asp:ListItem Value="AA" Text="Activos"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator ID="rfvValidarNomina" runat="server" ControlToValidate="RBLNomina" ForeColor="Crimson" ErrorMessage="Elija una opción" Display="Dynamic"></asp:RequiredFieldValidator> 
                                    <br />
                                </td>

                                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnBuscar" runat="server"  AutoPostBack="True" Text="Buscar" CssClass="boton"  OnClick="btnBuscar_Click"/>
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

                    <dx:ASPxGridView ID="grid" 
                        ClientInstanceName="grid" 
                        runat="server" 
                        Width="100%" 
                        AutoGenerateColumns="false"
                        KeyFieldName="ID" Visible="false" OnRowDeleting="grid_RowDeleting"  
                        >            
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="true" ButtonRenderMode="Link"></dx:GridViewCommandColumn> 
                                <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True"                                                                   VisibleIndex="0" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Folio" FieldName="FOLIO"                                                                VisibleIndex="3" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Matricula" FieldName="MATRICULA"                                                        VisibleIndex="4" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Importe" FieldName="IMPORTE"                                                            VisibleIndex="5" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Póliza" FieldName="POLIZA"                                                              VisibleIndex="6" Width="120" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Promotoría de origen" FieldName="PROM_ORIGEN"                                           VisibleIndex="7" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Usuario de Servicio" FieldName="USR_SERVICIO"                                           VisibleIndex="8" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Promotoría de último servicio" FieldName="PROM_U_SERV"                                  VisibleIndex="9" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Promotoría responsable" FieldName="PROM_RESPON"                                         VisibleIndex="10" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tipo de Movimiento" FieldName="TIPO_MOVIMIENTO"                                         VisibleIndex="11" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nombre del Trabajador" FieldName="NOMBRE_TRABAJADOR"                                    VisibleIndex="12" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Unidad de pago" FieldName="UNIDAD_PAGO"                                                 VisibleIndex="13" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tipo de nómina" FieldName="TIPO_NOMINA"                                                 VisibleIndex="14" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Año/Qna" FieldName="ANO_QUINCENA"                                                       VisibleIndex="15" Width="200" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Estatus de la carta instrucción: OK" FieldName="STATUS_CARTA"                           VisibleIndex="16" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Estatus de la carta instrucción: NO APLICA" FieldName="STATUS_CARTA_DESC"               VisibleIndex="17" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Estatus de la carta instrucción: RECHAZO" FieldName="STATUS_CARTA_RECHAZO"              VisibleIndex="18" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Motivo de Rechazo/Resultado Analisis o  Portal" FieldName="STATUS_CARTA_RESULTADO"      VisibleIndex="19" Width="300" Visible="true"></dx:GridViewDataTextColumn>
                            </Columns>
                            <Templates>
                                <EmptyDataRow>
                                    <div style="width: 300px;">
                                        No hay datos para desplegar...
                                    </div>
                                </EmptyDataRow>
                            </Templates>            
                        <SettingsBehavior AllowSelectByRowClick="false" AllowSelectSingleRowOnly="true" EnableRowHotTrack="True" AllowEllipsisInText="true"  />
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


</asp:Content>