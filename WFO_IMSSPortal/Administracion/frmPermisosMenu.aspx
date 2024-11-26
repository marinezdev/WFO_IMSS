<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPermisosMenu.aspx.cs" Inherits="WFO_IMSSPortal.Administracion.frmPermisosMenu" MasterPageFile="~/Utilerias/Site.Master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <style type="text/css">
          .DragHandleClass {
              width: 55px;
              height: 20px;
              background-color: blue;
              color: white;
              cursor: move;
          }
 
          .ajaxOrderedList li {
              list-style: none;
          }
    </style>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Permisos Menú</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <table>
                        <tr><td>Seleccione el Rol:</td><td><asp:DropDownList ID="ddlRoles" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged" class="form-control"></asp:DropDownList></td></tr>
                        <tr id="trOpciones" runat="server" visible="false">
                            <td colspan="2">
                                <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="BtnGuardar_Click" /><br />
                                Elija las opciones del menú a las que tendrá acceso el rol seleccionado.<br />
                                <asp:TreeView ID="tvwMenu" runat="server" ShowLines="true" ShowCheckBoxes="All" CssClass="form-control"></asp:TreeView>
                            </td>
                        </tr>
                    </table>    


                   <ajaxToolkit:ReorderList ID="ReorderList1" runat="server"
                       OnItemReorder="ReorderList1_ItemReorder"
                       PostBackOnReorder="true"
                       CallbackCssStyle="callbackStyle"
                       DragHandleAlignment="Left"
                       ItemInsertLocation="Beginning"
                       DataKeyField="ID"
                       SortOrderField="Name" ClientIDMode="AutoID">
                       <ItemTemplate>
                           <div class="itemArea">
                               <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name")%>' />
                               <asp:Label ID="Label2" runat="server" Text='<%#Eval("Order_By") %>' />
                           </div>
                       </ItemTemplate>
                       <ReorderTemplate>
                           <asp:Panel ID="Panel2" runat="server" CssClass="reorderCue" />
                       </ReorderTemplate>
                       <DragHandleTemplate>
                           <div class="DragHandleClass">Arrastrar</div>
                       </DragHandleTemplate>
                    </ajaxToolkit:ReorderList>



                </div>
            </div>
        </div>
    </div>

</asp:Content>