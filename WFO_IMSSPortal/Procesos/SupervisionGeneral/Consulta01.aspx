﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta01.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.SupervisionGeneral.Consulta01" MasterPageFile="~/Utilerias/Site.Master" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2.Web, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="dx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server" EnableViewState="true">
    <style>
        th, td { padding: 3px }
    </style>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Captura Masiva</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:LinkButton ID="lnkExportarResumen" runat="server" Text="Exportar a Excel"  CausesValidation="False" OnClick="lnkExportar_Click">
                        <img src="../../Imagenes/ExcelIcon.png" style="vertical-align:top"/>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
