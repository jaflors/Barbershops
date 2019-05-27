<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Mis_barberias.aspx.cs" Inherits="babershop.Views.Propietario.Mis_barberias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Mis barberias Registradas<small> gallery design </small></h2>
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

                    <div class="row">

                        <p>Galeria de Eventos</p>
                        <form runat="server" class="form-horizontal form-label-left">
                        <asp:listview runat="server" id="list_barberias">
                            <ItemTemplate>
                                <div class="col-md-4 text-center">
                                    <div class="thumbnail">
                                        <div class="image view view-first">
                                            <img style="width: 100%; height: 100%; display: block;" src="<%#Eval("Foto")%> " alt="image" />
                                            <div class="mask">
                                                <p>Info</p>

                                                <div class="tools tools-bottom">

                                                    
                                                    <asp:LinkButton runat="server" OnCommand="Unnamed_Command"  CommandArgument='<%#Eval("idbarberia")%>' CommandName="traer"><i class="fa fa-pencil"></i></asp:LinkButton>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="caption">
                                            <p><%#Eval("Nombre Barberia")%></p>
                                            <p>Dirección: <%#Eval("dirección")%></p>

                                        </div>

                                    </div>
                                  </div>
                       </ItemTemplate>
                      </asp:listview>
                             </form>
                    </div>
                </div>
            </div>
        </div>
    </div>






</asp:Content>
