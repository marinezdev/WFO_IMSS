<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="EnlaceGenerarMasivo.aspx.cs" Inherits="WFO_IMSSPortal.Procesos.IMSSPortal.EnlaceGenerarMasivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
        <asp:UpdatePanel ID="upPnlCaptura" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Enlace. Generación.</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="row">
                        <br />&nbsp;
                    </div>
                    <div class="x_content">
                        <div class="row">
                            <div class="col-md-1 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena1</strong>
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="ddlQuincena1" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkTNAA1" Text="Activos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNEA1" Text="Estatos Mando"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNMM1" Text="Mandos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNJJ1" Text="Jubilados"></asp:CheckBox>

                            </div>
                            <div class="col-md-5 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkAlata1" Text="Alta"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkModif1" Text="Modificación"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkBaja1" Text="Baja"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena1</strong>
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="ddlQuincena2" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkTNAA2" Text="Activos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNEA2" Text="Estatos Mando"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNMM2" Text="Mandos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNJJ2" Text="Jubilados"></asp:CheckBox>

                            </div>
                            <div class="col-md-5 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkAlata2" Text="Alta"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkModif2" Text="Modificación"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkBaja2" Text="Baja"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena1</strong>
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="ddlQuincena3" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkTNAA3" Text="Activos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNEA3" Text="Estatos Mando"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNMM3" Text="Mandos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNJJ3" Text="Jubilados"></asp:CheckBox>

                            </div>
                            <div class="col-md-5 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkAlata3" Text="Alta"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkModif3" Text="Modificación"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkBaja3" Text="Baja"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena1</strong>
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="ddlQuincena4" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkTNAA4" Text="Activos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNEA4" Text="Estatos Mando"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNMM4" Text="Mandos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNJJ4" Text="Jubilados"></asp:CheckBox>

                            </div>
                            <div class="col-md-5 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkAlata4" Text="Alta"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkModif4" Text="Modificación"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkBaja4" Text="Baja"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena1</strong>
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="ddlQuincena5" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkTNAA5" Text="Activos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNEA5" Text="Estatos Mando"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNMM5" Text="Mandos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNJJ5" Text="Jubilados"></asp:CheckBox>

                            </div>
                            <div class="col-md-5 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkAlata5" Text="Alta"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkModif5" Text="Modificación"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkBaja5" Text="Baja"></asp:CheckBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-1 col-sm-6 col-xs-12 form-group has-feedback">
                                <strong>Quincena1</strong>
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:DropDownList ID="ddlQuincena6" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkTNAA6" Text="Activos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNEA6" Text="Estatos Mando"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNMM6" Text="Mandos"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkTNJJ6" Text="Jubilados"></asp:CheckBox>

                            </div>
                            <div class="col-md-5 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:CheckBox runat="server" ID="chkAlata6" Text="Alta"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkModif6" Text="Modificación"></asp:CheckBox>
                                <asp:CheckBox runat="server" ID="chkBaja6" Text="Baja"></asp:CheckBox>
                            </div>
                        </div>
                        <div class="row">
                            <hr />
                        </div>

                        <div class="row">
                            <div class="col-xs-12 form-group has-feedback">
                                <strong>
                                    Quincena Resultante del Enlace a Generar
                                </strong>
                                <asp:TextBox runat="server" ID="txtQuincena" Text=""></asp:TextBox>
                                <asp:RegularExpressionValidator id="valida_txtQuincena" style="z-index: 101; left: 208px; position: absolute; TOP: 16px; color:red; font-weight:200; " runat="server" ErrorMessage="Quincena Inválida (númerico de 6 dígitos)." ValidationExpression="^[0-9]{6}$" ControlToValidate="txtQuincena" />
                                <br />&nbsp;
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback"></div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:Button ID="btnVerificarEnlace" runat="server" style="width:100%" AutoPostBack="True" Text="Verficar Enlace" Class="btn btn-info" OnClick="btnVerificarEnlace_Click" />
                            </div>
                            <div class="col-md-4 col-sm-6 col-xs-12 form-group has-feedback">
                                <asp:Button ID="btnGenerarEnlace" runat="server"  style="width:100%" AutoPostBack="True" Text="Generar Enlace Masivo" Class="btn btn-success" OnClick="btnGenerarEnlace_Click" />
                            </div>
                            <div class="col-md-2 col-sm-6 col-xs-12 form-group has-feedback"></div>
                        </div>

                       
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
