<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaAjax.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.PruebaAjax" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <h1>Prueba de Ajax</h1>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
               <asp:Button ID="BtnProcesar" runat="server" Text="Procesar" OnClick="BtnProcesar_Click" /> 
                <asp:Label ID="LblMensajes" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
            
        <asp:UpdateProgress ID="updateProgress1" runat="server">
            <ProgressTemplate>
                    <div id="divPantallaBloqueo" style="width: 100%; height: 100%; left: 0%; position: fixed; z-index: 1500; background-color: black; opacity: 0.1; filter: alpha(opacity=90); display: block; overflow: hidden"></div>


                        <asp:Image runat="server" ID="imgLoading" ImageUrl="~/Imagenes/please-wait-gif-transparent-12.gif" />

            </ProgressTemplate>
        </asp:UpdateProgress>

</asp:Content>