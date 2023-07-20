<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="Turnera_TPC_Equipo27.MisTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="MisTurnos">
        <div class="container" style="background-color: rgb(65, 65, 65);">
            <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
                <h4><strong>Sitio en construcción</strong></h4>
                <br />
                <p>¡Pronto podrás ver los turnos que hayas tomado, tanto vigentes como históricos!</p>
            </div>
            <div style="text-align: center;">
                <td>
                    <a href="Default.aspx" class="btn btn-secondary btn active" role="button" style="margin-bottom: 3rem; margin-top: 3rem">Volver al inicio</a>
                </td>
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
                           

                            

                            
                        </div>
                        <%} %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
    </div>
</asp:Content>
