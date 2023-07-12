<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Turnera_TPC_Equipo27.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align: center; color: white;">
    <h3>Error</h3>
    <br />
    <asp:Label Text="text" ID="lblError" runat="server" />
    <br />
    <br />
    <asp:Button ID="btnVolver" runat="server" Text="Volver a la página anterior" CssClass="btn btn-success m-2" OnClick="btnVolver_Click" />
</div>
</asp:Content>
