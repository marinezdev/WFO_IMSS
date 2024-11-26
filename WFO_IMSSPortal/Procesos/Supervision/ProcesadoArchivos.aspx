<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcesadoArchivos.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.ProcesadoArchivos" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Procesamiento de Archivos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <h4>Archivos a procesar</h4>

                    <table>
                        <tr>
                            <td>
                                
                                <asp:GridView ID="GVArchivosEncontrados" runat="server" CellPadding="5" CellSpacing="5"></asp:GridView>
                            </td>
                        </tr>
                        <tr><td align="center"><asp:Button ID="ProcesarArchivos" runat="server" Text="Cambiar Nuevo Nombre y Guardar en directorio" CssClass="btn btn-primary" OnClick="ProcesarArchivos_Click" /></td></tr>
                    </table>
                
                    
                    

                </div>
            </div>
        </div>
    </div>


</asp:Content>