﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTablas.aspx.cs" Inherits="WFO_IMSSPortal.Administracion.frmTablas" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Tablas</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                 Tabla:<asp:DropDownList ID="DDLGenerico" runat="server"></asp:DropDownList>

                </div>
            </div>
        </div>
    </div>


</asp:Content>