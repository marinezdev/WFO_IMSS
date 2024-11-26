<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnlaceImportar.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.EnlaceImportar" MasterPageFile="~/Utilerias/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <script type="text/javascript">  
        function CargaCompletada()  
        {  
            alert('Se procesaron los archivos exitosamente.'); 
            window.location.href = 'Default.aspx';
        }  
    </script> 


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Importación de archivos</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <table>
                        <tr>
                                <td>Tipo de Nómina:</td>
                            <td>
                                <asp:DropDownList ID="ddlTipoNomina" runat="server" Width="200px" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoNomina_SelectedIndexChanged">
                                <asp:ListItem Value="" Text="Seleccione" ></asp:ListItem>
                                <asp:ListItem Value="AA" Text="Activos" ></asp:ListItem>
                                <asp:ListItem Value="EA" Text="Estatuto A" ></asp:ListItem>
                                <asp:ListItem Value="JJ" Text="Jubilados" ></asp:ListItem>
                                <asp:ListItem Value="MM" Text="Mandos" ></asp:ListItem>
                                </asp:DropDownList>
                            </td>                           
                            <td>Quincena:</td>
                            <td>
                                <asp:DropDownList ID="ddlAnnQuincena" runat="server" Width="200px" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAnnQuincena_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>




                    <table style="width: 100%">
                        <tr>
                            <td><asp:GridView ID="GVRegistros" runat="server"></asp:GridView></td>
                            <td>
                                <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="txt" Width="100%" OnUploadComplete="AjaxFileUpload1_UploadComplete" OnClientUploadCompleteAll="CargaCompletada" />
                            </td>

                        </tr>
                    </table>

                </div>
            </div>
        </div>
    </div>


</asp:Content>