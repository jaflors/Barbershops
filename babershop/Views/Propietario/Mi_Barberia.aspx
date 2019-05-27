<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Mi_Barberia.aspx.cs" Inherits="babershop.Views.Propietario.Mi_Barberia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Mi Barberia</h2>
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

                    <div class="col-md-7 col-sm-7 col-xs-12">
                        <div class="product-image">

                             <img style="width: 100%; height:100%; display: block;" src=" <%= drbarbert["Foto"] %>" alt="image" />
                           <%-- <img  src=" <%= drbarbert["Foto"] %>" alt="image" />--%>
                        </div>

                    </div>

                    <div class="col-md-5 col-sm-5 col-xs-12" style="border: 0px solid #e5e5e5;">

                        <h1 class="price"><%= drbarbert["Nombre Barberia"] %></h1>



                        <div class="">
                            <div class="product_price">
                                <h1 class="price-tax">Dirección: <%= drbarbert["dirección"] %> </h1>
                                <span class="price-tax">Propietario: <%= drbarbert["Propietario"] %>  </span>
                                <br>
                            </div>
                        </div>


                        <div class="">
                            <h2>Mis Barberos</h2>
                            <ul class="list-unstyled top_profiles scroll-view">
                                <asp:ListView runat="server" ID="list_barber">
                                    <ItemTemplate>
                                        <li class="media event">
                                            <a class="pull-left border-aero profile_thumb">
                                                <i class="fa fa-user aero"></i>
                                            </a>
                                            <div class="media-body">
                                                <a class="title" href="#"><%#Eval("nombres")%> </a>
                                                <p><strong>Barbero Profecional</strong> Estado: <%#Eval("estado")%></p>
                                                
                                            </div>
                                        </li>

                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
                        </div>
                        
                        <div class="product_social">
                            <ul class="list-inline">
                                <li><a href="#"><i class="fa fa-facebook-square"></i></a>
                                </li>
                                <li><a href="#"><i class="fa fa-twitter-square"></i></a>
                                </li>
                                <li><a href="#"><i class="fa fa-envelope-square"></i></a>
                                </li>
                                <li><a href="#"><i class="fa fa-rss-square"></i></a>
                                </li>
                            </ul>
                        </div>

                    </div>



                </div>
            </div>
        </div>
    </div>






</asp:Content>
