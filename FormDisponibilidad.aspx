<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="FormDisponibilidad.aspx.cs" Inherits="Turnera_TPC_Equipo27.FormDisponibilidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row d-flex justify-content-center">

            <div class="mb-3">
                <label for="txtApellido" class="form-label text-white">Apellido: </label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtDni" class="form-label text-white">Disponibilidad:</label>
                <asp:TextBox ID="txtDni" CssClass="form-select" runat="server" />
            </div>

            <div class="mb-3 text-center">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
