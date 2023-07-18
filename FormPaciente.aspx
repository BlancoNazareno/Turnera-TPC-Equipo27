﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="FormPaciente.aspx.cs" Inherits="Turnera_TPC_Equipo27.FormPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row d-flex justify-content-center">
            <div class="col-6 ">
                <div class="mb-3">
                    <label for="txtId" class="form-label text-white"></label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label text-white">Nombre: </label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label text-white">Apellido: </label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCelular" class="form-label text-white">Celular: </label>
                    <asp:TextBox runat="server" ID="txtCelular" CssClass="form-control" />
                    <asp:Label runat="server" ID="lblCelularError" CssClass="text-danger" Visible="false">
                        El número de celular debe estar entre 1000000000 y 9999999999</asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label text-white">Fecha de nacimiento: </label>
                    <asp:TextBox TextMode="Date" ID="txtFechaNacimiento" CssClass="form-select" runat="server" />
                    <asp:Label ID="lblFechaNacimientoError" runat="server" CssClass="text-danger" Visible="false">
                      La fecha de nacimiento debe ser válida.
                    </asp:Label>
                </div>
                <div class="mb-3">
                    <label for="txtDni" class="form-label text-white">DNI:</label>
                    <asp:TextBox ID="txtDni" CssClass="form-select" runat="server" />
                    <asp:Label ID="lblDniError" runat="server" CssClass="text-danger" Visible="false">
                         El DNI debe ser un valor válido
                    </asp:Label>
                </div>

                <div class="mb-3">
                    <label for="txtCobertura" class="form-label text-white">Cobertura</label>
                    <asp:TextBox ID="txtCobertura" CssClass="form-select" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtMail" class="form-label text-white">Email:</label>
                    <asp:TextBox ID="txtMail" CssClass="form-select" runat="server" />
                    <asp:Label ID="lblEmailError" runat="server" CssClass="text-danger" Visible="false">
                      El email debe contener "@" y un "."
                    </asp:Label>
                </div>
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
