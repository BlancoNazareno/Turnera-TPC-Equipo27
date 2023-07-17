<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="Turnera_TPC_Equipo27.Pacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="text-end">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success m-2" OnClick="btnAgregar_Click" PostBackUrl="~/FormPaciente.aspx" />
        </div>
        <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Celular" DataField="Celular" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />

                <asp:BoundField HeaderText="DNI" DataField="DNI" />
                <asp:TemplateField HeaderText="Fecha de Nacimiento">
                    <ItemTemplate>
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Cobertura" DataField="Cobertura" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <% if (((dominio.Paciente)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
                            { %>
                        <div class="text-end mx-4">Acciones</div>
                        <%} %>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <% if (((dominio.Paciente)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN)
                            { %>
                        <div class="d-flex justify-content-end m-1">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary mx-2" OnClick="btnModificar_Click" />

                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminar_Click" />
                            
                            <%--ESTE BOTON ESTA ACA PARA HACER PRUEBAS, DPS SE MUEVE AL LISTADO DE TURNOS--%>
                            <asp:Button ID="btnComunicarse" runat="server" Text="Enviar Wpp." 
                                style="background-color: #88CC88; color: #fff; border: none; padding: 10px 20px; border-radius: 5px; cursor: pointer;"
                                CssClass="btn btn-primary mx-2" OnClick="btnComunicarse_Click" />
                            
                        </div>
                        <%} %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
