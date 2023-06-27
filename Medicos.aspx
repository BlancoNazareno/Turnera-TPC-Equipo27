<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Turnera_TPC_Equipo27.Medicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="text-end">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success m-2" OnClick="btnAgregar_Click" />
        </div>
        <asp:GridView ID="dgvMedicos" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div class="text-end mx-4">Acciones</div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="d-flex justify-content-end m-1">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary mx-2" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
