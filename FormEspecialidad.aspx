<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="FormEspecialidad.aspx.cs" Inherits="Turnera_TPC_Equipo27.FormEspecialidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row d-flex justify-content-center">
            <div class="col-6 ">
<%--                <div class="mb-3">
                    <label for="txtId" class="form-label text-white">Id</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>--%>
                <div class="mb-3">
                    <label for="txtEspecialidad" class="form-label text-white">Especialidad/es: </label>
                    <asp:TextBox runat="server" ID="txtEspecialidad" CssClass="form-control" />
                </div>
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
