<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Turnera_TPC_Equipo27.TurnosAdmin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col-8">
                <div class="mb-3">
                    <asp:Button ID="btnActivos" runat="server" Text="Ver Activos" CssClass="btn btn-success m-2" OnClick="btnActivos_Click"
                        Style="background-color: #008B8B; color: #ffffff; border-color: #008B8B;" />
                    <asp:Button ID="btnFinalizados" runat="server" Text="Ver Cancelados" CssClass="btn btn-success m-2" OnClick="btnFinalizados_Click"
                        Style="background-color: #008B8B; color: #ffffff; border-color: #008B8B;" />
                    <asp:Button ID="btnTodos" runat="server" Text="Todos" CssClass="btn btn-success m-2" OnClick="btnTodos_Click"
                        Style="background-color: #008B8B; color: #ffffff; border-color: #008B8B;" />
                </div>
            </div>
            <div class="col-4 text-end">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Turno" CssClass="btn btn-success m-2" OnClick="btnAgregar_Click" PostBackUrl="~/FormTurno.aspx" />
            </div>
        </div>
        <h4 class="text-white">Búsqueda:</h4>
        <div class="row">
            <div class="col-2 align-self-center">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltroApellido" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroApellido_TextChanged" placeholder="Apellido Pte." />
                </div>
            </div>
            <div class="col-2 align-self-center">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltroApellidoMedico" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroApellidoMedico_TextChanged" placeholder="Apellido Med." />
                </div>
            </div>
            <div class="col-2 align-self-center">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltroCobertura" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroCobertura_TextChanged" placeholder="Cobertura" />
                </div>
            </div>
            <div class="col-2 align-self-center">
                <div class="mb-3">
                    <asp:TextBox runat="server" ID="txtFiltroEspecialidad" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroEspecialidad_TextChanged" placeholder="Especialidad" />
                </div>
            </div>
            <div class="col-4 align-self-center">
                <div class="mb-3">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar Búsqueda" CssClass="btn btn-success m-2" OnClick="btnLimpiar_Click" />
                </div>
            </div>
        </div>
        <asp:GridView ID="dgvTurnosAdmin" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="Fecha y hora" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:BoundField HeaderText="Especialidad" DataField="Especialidad.Nombre" />
                <asp:BoundField HeaderText="Médico" DataField="Medico.NombreCompleto" />
                <asp:BoundField HeaderText="Paciente" DataField="Paciente.NombreCompleto" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderTemplate>
                        <% if (Session["usuario"] != null && (((dominio.Paciente)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN))
                            { %>
                        <div class="text-end mx-4">Acciones</div>
                        <%} %>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <% if (Session["usuario"] != null && (((dominio.Paciente)Session["usuario"]).TipoUsuario == dominio.TipoUsuario.ADMIN))
                            { %>
                        <div class="d-flex justify-content-end m-1">
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary mx-2" OnClick="btnModificar_Click" />

                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminar_Click" />

                            <asp:Button ID="btnBono" runat="server" Text="Imp. Bono" CssClass="btn btn-primary mx-2" OnClick="btnBono_Click"
                                Style="background-color: #808080; color: #fff;" />
                        </div>
                        <%} %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
