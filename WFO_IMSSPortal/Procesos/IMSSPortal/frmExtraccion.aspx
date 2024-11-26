<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmExtraccion.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmExtraccion" MasterPageFile="~/Utilerias/Site.Master" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <script type="text/javascript" language="javascript">
        function postbackButtonClick() {
            updateProgress = $find("<%= UPEnocntrar.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    </script>


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

                    <asp:UpdatePanel ID="UPBUscar" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>

                            <table>
                                <tr>
                                    <td align="right"><strong>Tipo de Nómina:</strong>&nbsp;&nbsp;&nbsp;</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlTipoNomina" runat="server" Width="200px" class="form-control">
                                            <asp:ListItem Value="" Text="Seleccione" ></asp:ListItem>
                                            <asp:ListItem Value="AA" Text="Activos" ></asp:ListItem>
                                            <asp:ListItem Value="EA" Text="Estatuto A" ></asp:ListItem>
                                            <asp:ListItem Value="JJ" Text="Jubilados" ></asp:ListItem>
                                            <asp:ListItem Value="MM" Text="Mandos" ></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label runat="server" ID="lblTipoNomina" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"><strong>Tipo de Archivo:</strong>&nbsp;&nbsp;&nbsp;</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlTipoArchivo" runat="server" Width="200px" class="form-control">
                                            <asp:ListItem Value="-1" Text="Seleccione" ></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Extracción" ></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Concentrado" ></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Label runat="server" ID="Label1" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"><strong>Año/Quincena:</strong>&nbsp;&nbsp;&nbsp;</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlAnnQuincena" runat="server" Width="200px" class="form-control">
                                        </asp:DropDownList>
                                        <asp:Label runat="server" ID="lblAnnQuincena" Visible="false" Text=" * " ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <strong>OBSERVACIONES</strong>
                                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Width="93%" Height="50px" class="form-control"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="filObservaciones" runat="server" TargetControlID="txtObservaciones" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyzáéíóúÁÉÍÓÚ =$&%*_0123456789-,.:+*/?¿+¡\/][{}();" BehaviorID="_content_FilteredTextBoxExtender15" />
                                    </td>
                                </tr>
                                <tr>
                                    <!--<td colspan="3">Longitud máxima del nombre del archivo: 23 caracteres.</td>-->
                                </tr>
                                <tr>
                                    <td align="right"><strong>Archivo:</strong>&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right">
                                        <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="true" ClientIDMode="AutoID" UploaderStyle="Modern" ErrorBackColor="Red" Width="100%" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="BtnExcelAceptar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="BtnExcelAceptar_Click" OnClientClick="return postbackButtonClick();"/>
                                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="UPEnocntrar" runat="server" AssociatedUpdatePanelID="UPBuscar">
                                            <ProgressTemplate>
                                                <asp:Image ID="Espera" runat="server" ImageUrl="~/Imagenes/ajax-loader.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><asp:Label ID="lblProcesadoExcel" runat="server" ForeColor="Green"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div style="width: 100%; height: 400px; overflow: scroll; overflow-x: scroll; width:1000px; display:none;">
                                            <asp:GridView ID="GVExtraccion" runat="server" HeaderStyle-Font-Bold="true" CellPadding="2" CellSpacing="2" Width="99%">
                                            </asp:GridView>
                                        </div>

                                        <%--<div style="width: 80%; height: 400px; overflow: scroll; overflow-x:auto; width:1000px; display:block;">--%>
    
                                        <%--</div>--%>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BtnExcelAceptar" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <dx:ASPxGridView ID="grid" 
                        ClientInstanceName="grid" 
                        runat="server" 
                        Width="1000px" 
                        AutoGenerateColumns="false"
                        KeyFieldName="ID"
                        OnHtmlDataCellPrepared="grid_HtmlDataCellPrepared" Visible="false"
                        >
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="Id" ReadOnly="True"                                               VisibleIndex="0" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Fecha Envio" FieldName="FECHA"                                      VisibleIndex="1" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Id Usuario" FieldName="IDUSUARIO"                                   VisibleIndex="2" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Folio" FieldName="FOLIO"                                            VisibleIndex="3" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Matricula" FieldName="MATRICULA"                                    VisibleIndex="4" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Importe" FieldName="IMPORTE"                                        VisibleIndex="5" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Póliza" FieldName="POLIZA"                                          VisibleIndex="6" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Promotoría de origen" FieldName="PROM_ORIGEN"                       VisibleIndex="7" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Usuario de Servicio" FieldName="USR_SERVICIO"                       VisibleIndex="8" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Promotoría de último servicio" FieldName="PROM_U_SERV"              VisibleIndex="9" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Promotoría responsable" FieldName="PROM_RESPON"                     VisibleIndex="10" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tipo de Movimiento" FieldName="TIPO_MOVIMIENTO"                     VisibleIndex="11" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nombre del Trabajador" FieldName="NOMBRE_TRABAJADOR"                VisibleIndex="12" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Unidad de pago" FieldName="UNIDAD_PAGO"                             VisibleIndex="13" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tipo de nómina" FieldName="TIPO_NOMINA"                             VisibleIndex="14" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Año/Qna" FieldName="ANO_QUINCENA"                                   VisibleIndex="15" Width="100" Visible="true"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Obs" FieldName="OBSERVACIONES"                                      VisibleIndex="15" Width="100" Visible="false"></dx:GridViewDataTextColumn>
                            </Columns>
                        <SettingsBehavior AllowSelectByRowClick="false" AllowSelectSingleRowOnly="true" EnableRowHotTrack="True" AllowEllipsisInText="true"  />
                        <SettingsPager  Mode="ShowAllRecords"/>
                        <SettingsDetail ShowDetailRow="false" />
                        <Settings VerticalScrollBarMode="Visible" VerticalScrollableHeight="300" HorizontalScrollBarMode="Visible" />
                        <SettingsSearchPanel Visible="false" />
                    </dx:ASPxGridView> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>