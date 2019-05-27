<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Principal/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="babershop.Views.Principal.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="ftco-section contact-section">
        <div class="container">
            <br />
            <form class="login" runat="server" name="login">
                <h2>Iniciar Sesion</h2>

                <img src="../../imagenes/logo.png" />

                <input id="Correo" runat="server" type="text" name="usuario" placeholder="Usuario" class="bordes" autofocus />
                <input id="Contrasena" runat="server" type="password" name="password" placeholder="Contraseña" class="bordes" />
                <br />
                <br />
                <asp:Button ID="Btt_login" CssClass="btn btn-primary py-3 px-5" runat="server" Text="Ingresar" OnClick="Iniciar" />

                <asp:Label runat="server" ID="princesa"></asp:Label>
                <ul>
                </ul>

            </form>
        </div>
    </section>



</asp:Content>
