<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="FormDisponibilidad.aspx.cs" Inherits="Turnera_TPC_Equipo27.FormDisponibilidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row d-flex justify-content-center">

            <div class="mb-3">
                <label for="ddlEspecialidad" class="form-label text-white">Especialidad</label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label ID="lblDgvMedico" for="ddlMedico" class="form-label text-white" runat="server" >Nombre y Apellido: </label>
                <asp:DropDownList ID="ddlMedico" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" AutoPostBack="true" EnableViewState="true"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label ID="lblDgvDisponibilidad" for="dgvDisponibilidad" class="form-label text-white" runat="server">Disponibilidad:</label>
                <asp:GridView ID="dgvDisponibilidad" runat="server" CssClass="table table-dark" AutoGenerateColumns="false" AutoPostBack="false" >
                    <Columns>
                        <asp:BoundField HeaderText="Horarios" DataField="Hora"/>
                        

                        <asp:TemplateField  HeaderText="Lunes" runat="server">
                            <ItemTemplate>
                               <asp:CheckBox ID="chkLunes" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Martes" runat="server">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkMartes" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Miercoles" runat="server">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkMiercoles" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Jueves" runat="server">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkJueves" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Viernes" runat="server">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkViernes" runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="mb-3 text-center">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" AutoPostBack="true"/>
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" />

            </div>
        </div>
    </div>
</asp:Content>


