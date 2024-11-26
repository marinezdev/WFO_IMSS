<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPendientes.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.frmPendientes" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Movimientos Ingresados por Quincena</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <div style="width: 90%; margin: auto">
                        <table style="width:100%; margin:auto;">
                            <tr><td></td><td></td><td><strong>Fecha de Registro:</strong>&nbsp;<%=DateTime.Now %></td><td>&nbsp;</td></tr>
                            <tr><td></td><td></td><td align="Right">Buscar:</td><td align="Left"><asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox></td></tr>
                            <tr>
                                <td style="font-weight: bold">Año/Quincena:</td>
                                <td>
                                    <asp:DropDownList ID="ddlAnnQuincena" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAnnQuincena_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td></td><td>&nbsp;</td>
                            </tr>
                        </table>

                        <asp:GridView ID="GVDetalle" runat="server" CellPadding="2" CellSpacing="2">

                        </asp:GridView>

            
                    </div>



                </div>
            </div>
        </div>
    </div>


</asp:Content>