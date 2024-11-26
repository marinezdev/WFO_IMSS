<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Promotoria.EsperaPromotoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

                <div class="row">
                    <script src="../../JS/Chart.js/dist/Chart.bundle.min.js"></script>
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Promotoría - Indicador General <small>Trámites</small></h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li>
                                        <!--<a id="link" download="Indicador General.jpg"><i class="fa fa-cloud-download"></i> jpg</a>-->
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">

                                <p class="text-muted font-13 m-b-30">
                                    Indicador general correspondiente a trámites registrados en el rango de 4 meses, a partir de la fecha del día de hoy. <asp:Label runat="server" ID="Label2" Text=""></asp:Label>
                                </p>

                                <table>
                                    <tr>
                                        <td><strong>Quincena:</strong>&nbsp;</td><td><asp:DropDownList ID="DDLQuicena" runat="server" CssClass="form-control"></asp:DropDownList></td>
                                        <td><strong>Tipo de Nómina:&nbsp;</strong></td>
                                        <td>
                                            <asp:DropDownList ID="DDLTipoNomina" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="" Text="Seleccione" ></asp:ListItem>
                                                <asp:ListItem Value="AA" Text="Activos" ></asp:ListItem>
                                                <asp:ListItem Value="EA" Text="Estatuto A" ></asp:ListItem>
                                                <asp:ListItem Value="JJ" Text="Jubilados" ></asp:ListItem>
                                                <asp:ListItem Value="MM" Text="Mandos" ></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>&nbsp;</td><td><asp:Button ID="BtnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="BtnBuscar_Click" /></td></tr>
                                </table>

                                <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                    <asp:DropDownList ID="LisEstatusTramite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LisEstatusTramite_SelectedIndexChanged" class="form-control" Visible="false">
                                        <asp:ListItem Value=" ">Seleccionar</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LisEStatusTramite" ErrorMessage="*" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>

                                <asp:Chart ID="grfGrupoUno" runat="server" Width="1000px" Height="300px" BackColor="Transparent" BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderColor="Transparent" BorderlineDashStyle="Solid" BorderWidth="0px" style=" width: 100%; height: 300px;" OnClick="grfGrupoUno_Click" >
                                    <ChartAreas>
                                        <asp:ChartArea Area3DStyle-Enable3D="false" Name="GrupoUno" BackColor="238, 238, 238" BackGradientStyle="TopBottom" BackSecondaryColor="White" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" ShadowColor="Transparent">
                                            <AxisY LineColor="64, 64, 64, 64" IsMarginVisible="false">
                                                <LabelStyle Font="Trebuchet MS, 8pt" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisY>
                                            <AxisX LineColor="64, 64, 64, 64" IsMarginVisible="false">
                                                <LabelStyle Font="Trebuchet MS, 8pt" />
                                                <MajorGrid LineColor="64, 64, 64, 64" />
                                            </AxisX>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                <asp:Literal ID="ltChart" runat="server"></asp:Literal>


                                <!-- NUEVA GRAFICA  -->
                                <asp:Literal ID="ltMuestraGrafica" runat="server" Visible="false"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>

                <asp:panel ID="ListaTramitesEstatus" runat="server" Visible="false">
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Trámites - <asp:Label runat="server" ID="LabelEstado" Text=""></asp:Label> </h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <p class="text-muted font-13 m-b-30">
                                    Listado total de trámites gráfica. <asp:Label runat="server" ID="LabRespyuesta" Text=""></asp:Label>
                                </p>
                                <asp:Repeater ID="rptTramite" runat="server" OnItemCommand="rptTramite_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example" class="table table-striped table-bordered">
                                            <thead>
                                                <tr>
                                                    <th style="width: 15%">Fecha envío</th>
                                                    <th style="width: 10%">Número de trámite</th>
                                                    <th style="width: 10%">Poliza</th>
                                                    <th style="width: 10%">TipoNomina</th>
                                                    <th style="width: 10%">TipoMovimiento</th>
                                                    <th style="width: 10%">UnidadPago</th>
                                                    <th style="width: 10%">Quincena</th>
                                                    <th style="width: 10%">Importe</th>
                                                    <th style="width: 10%">Estado</th>
                                                    <th style="width: 5%"></th>
                                                </tr>
                                            </thead>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("FechaRegistro","{0:dd/MM/yyyy HH:mm:ss}")%></td>
                                            <td><%#Eval("FolioCompuesto")%></td>
                                            <td><%#Eval("Poliza")%></td>
                                            <td><%#Eval("TipoNomina")%></td>
                                            <td><%#Eval("TipoMovimiento")%></td>
                                            <td><%#Eval("UnidadPago")%></td>
                                            <td><%#Eval("Quincena")%></td>
                                            <td><%#Eval("Importe")%></td>
                                            <td><%#Eval("Estatus")%></td>
                                            <td><asp:ImageButton ID="imbtnConsultar" runat="server" ImageUrl="~/Imagenes/folder.png" CommandName ="Consultar" CommandArgument='<%# Eval("Id")%>' /></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
                </asp:panel>
    
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
