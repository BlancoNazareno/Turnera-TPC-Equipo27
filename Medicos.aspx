﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Turnera_TPC_Equipo27.Medicos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-3 align-self-center">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltroApellido" CssClass="form-control" AutoPostBack="true"
                        OnTextChanged="txtFiltroApellido_TextChanged"  placeholder="Buscar por Apellido" />
                </div>
            </div>
            <div class="col-3 align-self-center">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltroEspecialidad" CssClass="form-control" AutoPostBack="true"
                        OnTextChanged="txtFiltroEspecialidad_TextChanged" placeholder="Buscar por Especialidad" />
                </div>
            </div>
            <div class="col-2">
                <div class="mb-3">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-success m-2" 
                        OnClick="btnLimpiar_Click"/>
                </div>
            </div>
            <div class="col-4 text-end">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Medico" CssClass="btn btn-success m-2" OnClick="btnAgregar_Click" PostBackUrl="~/FormMedico.aspx" />
            </div>
        </div>
        <asp:GridView ID="dgvMedicos" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                <asp:BoundField HeaderText="DNI" DataField="Dni" />
                <asp:TemplateField HeaderText="Fecha de Nacimiento">
                    <ItemTemplate>
                        <asp:Label ID="lblFechaNacimiento" runat="server" Text='<%# Eval("FechaNacimiento", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
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
                        </div>
                        <%} %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
