<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Consultar_Cita_cliente.aspx.cs" Inherits="babershop.Views.Cliente.Consultar_Cita_cliente" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    

    </asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Citas Registradas <small>Session</small></h2>
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
                                        <th>Barbero</th>
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
                                                <td><%#Eval("Barbero")%> </td>
                                                <td><%#Eval("Barberia")%> </td>

                                                <td>
                                                    <asp:LinkButton runat="server" CommandArgument='<%#Eval("idcita")%>' OnCommand="traer_id_cita"  CommandName="traer"   CssClass="btn btn-danger">
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
                            <!-- Modal -->
                            <div class="modal fade" id="myModal_jaime" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="myModalLabel">Cancelar Cita</h4>
                                        </div>
                                        <div class="modal-body">
                                            <!-- Modal- body-->
                                            <div class="row">


                                                <div class="col-lg-12">
                                                    <br />
                                                    <div class="panel panel-default">
                                                        <div class="panel-body">

                                                            <div class="row">

                                                                <div class="form-group">
                                                                    <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                                                        Seleccione motivo de cancelación <span class="required">*</span>
                                                                    </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:DropDownList ID="List_motivo" class="form-control" runat="server" required="required"></asp:DropDownList>

                                                                    </div>
                                                                </div>


                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <asp:Button ID="guardar" class="btn btn-primary"   runat="server" OnCommand="Unnamed_Command"  Text ="Aceptar"  CommandName="eliminar"/>

                                        </div>
                                    </div>
                                </div>
                            </div>






                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>









</asp:Content>
