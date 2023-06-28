<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="FormMedico.aspx.cs" Inherits="Turnera_TPC_Equipo27.FormMedicoPaciente" %>

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
                    <label for="txtFechaNacimiento" class="form-label text-white">Fecha de nacimiento: </label>
                    <asp:TextBox textmode="Date" ID="txtFechaNacimiento" CssClass="form-select" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtDni" class="form-label text-white">Dni:</label>
                    <asp:TextBox ID="txtDni" CssClass="form-select" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtMail" class="form-label text-white">Email: </label>
                    <asp:TextBox ID="txtMail" CssClass="form-select" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="ddlEspecialidad" class="form-label text-white">Especialidad: </label>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
