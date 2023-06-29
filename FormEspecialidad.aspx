<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="FormEspecialidad.aspx.cs" Inherits="Turnera_TPC_Equipo27.FormEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row d-flex justify-content-center">
            <div class="col-6">
                <div class="mb-3">
                    <label for="inputEspecialidad" class="form-label text-white">Especialidad:</label>
                    <asp:TextBox runat="server" ID="Especialidad" CssClass="form-control" />

                </div>
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAgregarEspecialidad" OnClick="btnAgregarModificarEspecialidad_Click" CssClass="btn btn-primary mx-2" runat="server" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger mx-2" PostBackUrl="~/Especialidades.aspx" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
