<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="consulta_mis citas.aspx.cs" Inherits="babershop.Views.Barbero.consulta_mis_citas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2> Mis  Citas<small>Session</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Settings 1</a>
                                </li>
                                <li><a href="#">Settings 2</a>
                                </li>
                            </ul>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">

                    <form runat="server" class="form-horizontal form-label-left">



                        <div class="table-responsive">
                            <table class="table table-striped jambo_table bulk_action">
                                <thead>
                                    <tr class="headings">

                                        <th>Cliente </th>
                                        <th>Fecha</th>
                                        <th>Hora</th>
                                        <th>Servicio</th>
                                        <th>Barberia</th>
                                        <th class="column-title no-link last"><span class="nobr">Acción</span>
                                        </th>
                                        <th class="bulk-actions" colspan="7">
                                            <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                        </th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:ListView runat="server" ID="listview1">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Cliente")%> </td>
                                                <td><%#Eval("Fecha")%> </td>
                                                <td><%#Eval("Hora")%> </td>
                                                <td><%#Eval("Servicio")%> </td>
                                                <td><%#Eval("Barberia")%> </td>

                                                <td>
                                                    
                                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("idcita")%>' OnCommand="Unnamed_Command"  CommandName="eliminar"   CssClass="btn btn-danger">
                                                    Cancelar</asp:LinkButton>
                                                    <asp:LinkButton CommandArgument='<%#Eval("idcita")%>' CssClass="btn btn-success" OnCommand="traer_usuario" runat="server" CommandName="traer">
                                                    Actualizar</asp:LinkButton>
                                                    <a></a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </tbody>
                            </table>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
