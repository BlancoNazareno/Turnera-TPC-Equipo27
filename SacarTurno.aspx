<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SacarTurno.aspx.cs" Inherits="Turnera_TPC_Equipo27.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Ayuda">
        <div class="container" style="background-color: rgb(65, 65, 65);">
            <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
                <h4><strong>Seleccione una Especialidad para filtrar, luego actualice la lista: </strong></h4>
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlEspecialidades" CssClass="btn btn-outline-dark dropdown-toggle"
                        AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"
                        DataValueField="Id">
                    </asp:DropDownList>
                </div>
                <h4><strong>Seleccione un Medico</strong></h4>
                <div class="col">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                        CssClass="btn btn-primary mx-2" OnClick="btnActualizar_Click" />
                    <asp:GridView ID="dgvMedicos" runat="server" CssClass="table table-dark" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Dias de atencion" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div style="text-align: center;">
                <td>
                    <a href="Default.aspx" class="btn btn-secondary btn active" role="button"
                        style="margin-bottom: 3rem; margin-top: 3rem">Volver al inicio</a>
                </td>
            </div>
        </div>
    </div>
</asp:Content>
