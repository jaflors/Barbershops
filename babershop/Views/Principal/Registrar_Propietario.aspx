<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Principal/Principal.Master" AutoEventWireup="true" CodeBehind="Registrar_Propietario.aspx.cs" Inherits="babershop.Views.Principal.Registrar_Barberia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section class="ftco-section">
        <div class="container">
            <div class="row d-flex">
                <div class="col-md-6 d-flex ftco-animate">
                    <div class="img img-about align-self-stretch" style="background-image: url(../../trim/images/gallery-3.jpg); width: 100%;"></div>
                </div>
                  

                <div class="col-md-6 pl-md-5 ftco-animate">

                    <form action="#" class="contact-form" runat="server">

                        <div class="form-group">
                            
                      <h3 class="nav-link">Regístrate y guarda tu barbería</h3>

                      </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <input id="nombres" type="text" class="form-control" placeholder="Nombre" runat="server">
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <input id="apellidos" type="text" class="form-control" placeholder="Apellido" runat="server">
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <input id="correo" type="email" class="form-control" placeholder="Correo" runat="server">
                        </div>
                        <div class="form-group">
                            <input id="contrasena" type="password" class="form-control" placeholder="Contraseña" runat="server">
                        </div>
                        <div class="form-group">
                            <input id="recontrasena" type="password" class="form-control" placeholder="Repita la contraseña" runat="server">
                        </div>
                        <br />
                        <div class="form-group">
                        
                            <asp:Button ID="bt_registro" CssClass="btn btn-primary py-3 px-5" runat="server" Text="Registrar"  OnClick="Registrar" />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
