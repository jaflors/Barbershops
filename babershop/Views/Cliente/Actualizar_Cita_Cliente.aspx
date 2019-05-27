<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Administrador/Administrador.Master" AutoEventWireup="true" CodeBehind="Actualizar_Cita_Cliente.aspx.cs" Inherits="babershop.Views.Cliente.Actualizar_Cita_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Actualizar Cita<small>Session</small></h2>
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
                    <br />


                    <form runat="server" data-parsley-validate class="form-horizontal form-label-left">
                        
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                fecha<span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="fecha" CssClass="form-control" runat="server" TextMode="Date" required="required"></asp:TextBox>

                            </div>
                            <label id="label_fecha" runat="server" class="alert-info col-md-2 col-sm-2 col-xs-12" for="first-name">
                                <span class="required">*</span>
                            </label>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                Hora <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="Hora" CssClass="form-control" runat="server" required="required"></asp:DropDownList>

                            </div>
                            <label id="label_hora" runat="server" class="alert-info col-md-2 col-sm-2 col-xs-12" for="first-name">
                                <span class="required">*</span>
                            </label>
                        </div>


                        <div class="form-group">
                            <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">
                                Servicio<span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="List_servi" CssClass="form-control" runat="server" TextMode="Date" required="required"></asp:DropDownList>

                            </div>
                            <label id="label_servi" runat="server" class="alert-info col-md-2 col-sm-2 col-xs-12" for="first-name">
                                <span class="required">*</span>
                            </label>
                        </div>

                        <div class="form-group">
                            <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12">
                                Barbero<span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="List_barbero" class="form-control" runat="server" required="required"></asp:DropDownList>

                            </div>
                            <label id="label_barbero" runat="server" class="alert-info col-md-2 col-sm-2 col-xs-12" for="first-name">
                                <span class="required">*</span>
                            </label>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="Registrar" Text="Actualizar" />

                                <a href="../Cliente/Consultar_Cita_cliente.aspx" class="btn btn-primary">Volver</a>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>

    </div>






</asp:Content>
