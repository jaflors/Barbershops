<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Consultar_propietarios.aspx.cs" Inherits="babershop.Views.Administrador.Consultar_propietarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Usuario Registrados<small>Users</small></h2>
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

                 <form runat="server">
                      <div class="row">


                          <a href="../Reportes/Vista_reporte.aspx?tipo=2" class="btn btn-success">Reporte</a>

                        
                      </div>

                </form>
                <div class="x_content">

                    <table id="datatable" class="table table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>N°</th>
                                <th>Nombres</th>
                                <th>Apellidos</th>
                                <th>Estado</th>
                                <th>Barberia</th>

                            </tr>
                        </thead>


                        <tbody>

                            <%for (int i = 0; i < dtConsulta.Rows.Count; i++)
                                {
                                    drConsulta = dtConsulta.Rows[i];
                                        %>
                            <tr class='<%= (i % 2 == 0 ? "info" : "warning") %>'>
                                <td><%= (i+1)%></td>
                                <td><%=drConsulta["nombres"].ToString().ToUpper() %></td>
                                <td><%=drConsulta["apellidos"].ToString().ToUpper() %></td>
                                <td><%=drConsulta["estado"].ToString().ToUpper() %></td>
                                <td><%=drConsulta["nombre"].ToString().ToUpper() %></td>
                                
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>











</asp:Content>
