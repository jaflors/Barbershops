<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Consultar_Barberos_pr.aspx.cs" Inherits="babershop.Views.Propietario.Consultar_Barberos_pr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Consultar Barberos <small>Session</small></h2>
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

                                        <th>Nombres </th>
                                        <th>Apellidos</th>
                                        
                                        <th>Estado</th>

                                        <th style="width: 20%">Acción </th>

                                        <th class="bulk-actions" colspan="7">
                                            <a class="antoo" style="color: #fff; font-weight: 500;">Bulk Actions ( <span class="action-cnt"></span>) <i class="fa fa-chevron-down"></i></a>
                                        </th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:ListView runat="server" ID="list_barbero">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("nombres")%> </td>
                                                <td><%#Eval("apellidos")%> </td>
                                                <td><%#Eval("estado")%> </td>
                                                <td>
                                                    
                                                    <asp:LinkButton runat="server" OnCommand="Unnamed_Command"  CssClass="btn btn-danger btn-xs" CommandArgument='<%#Eval("idUsuario")%>' CommandName="eliminar"><i class="fa fa-trash-o"></i>
                                                    Eliminar </asp:LinkButton>

                                                    
                                                    <a ></a>
                                                   
                                                  
                                                    
                                                    <%-- data-toggle="modal" data-target="#myModal"--%>
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
