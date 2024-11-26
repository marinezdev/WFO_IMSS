<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="MapaGeneralProd.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.Supervision.MapaGeneralProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Operación Pendiente IMSS Portal.</h2>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">
                                <p class="text-muted font-13 m-b-30">
                                    Se mostrará la información pendiente por operar en cada una de las mesas dependiendo la quincena seleccionada.
                                </p>
                                <div class="row">
                                    <div class="col-md-4 col-sm-4 col-xs-12 form-group has-feedback">
                                        <asp:DropDownList ID="cboQuincenas" runat="server" AutoPostBack="True" class="form-control" Width="350px" OnSelectedIndexChanged="CargaFlujos_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                <asp:Literal id="MesasLiteral" runat=server  text=""/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
