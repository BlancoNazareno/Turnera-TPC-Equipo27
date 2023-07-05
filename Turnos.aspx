<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Turnera_TPC_Equipo27.TurnosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="text-end">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success m-2" OnClick="btnAgregar_Click" PostBackUrl="~/FormTurno.aspx" />
        </div>
        <asp:GridView ID="dgvTurnosAdmin" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id" />
                <asp:BoundField HeaderText="DNI" DataField="DNIPaciente" />
                <asp:BoundField HeaderText="Paciente" DataField="NombrePaciente" />
                <asp:BoundField HeaderText="Médico" DataField="NombreMédico" />

                <asp:TemplateField HeaderText="Fecha del turno">
                    <ItemTemplate>
                        <asp:Label ID="lblFechaTurno" runat="server" Text='<%# Eval("FechaTurno", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hora del turno">
                    <ItemTemplate>
                        <asp:Label ID="lblHoraTurno" runat="server" Text='<%# Eval("HoraTurno", "{0:hh:mm}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                <headertemplate>

                    <div class="text-end mx-4">Acciones</div>
                </headertemplate>
                <itemtemplate>
                    <div class="d-flex justify-content-end m-1">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary mx-2" OnClick="btnModificar_Click" />

                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminar_Click" />
                    </div>
                </itemtemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
