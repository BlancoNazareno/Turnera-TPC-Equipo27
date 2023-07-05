<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Disponibilidades.aspx.cs" Inherits="Turnera_TPC_Equipo27.Disponibilidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container" style="background-color: rgb(65, 65, 65);">
            <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
                <h4><strong>Form disponibilidades</strong></h4>
                <br />
                <p>Esto tendría que listar las disponibilidades de los médicos, para hacer el ABML</p>
            </div>

        </div>

        <div class="container">
        <div class="text-end">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success m-2" OnClick="btnAgregar_Click" PostBackUrl="~/FormMedico.aspx"/>
        </div>
<asp:GridView ID="dgvMedicos" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField HeaderText="ID" DataField="Id" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="DNI" DataField="Dni" />
        <asp:TemplateField HeaderText="Fecha de Nacimiento">
            <ItemTemplate>
                <asp:Label ID="lblFechaNacimiento" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="Mail" DataField="Mail" />
        <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
        <asp:TemplateField>
            <HeaderTemplate>
                <div class="text-end mx-4">Acciones</div>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="d-flex justify-content-end m-1">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary mx-2" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" Onclick="btnEliminar_Click" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    </div>
</asp:Content>
