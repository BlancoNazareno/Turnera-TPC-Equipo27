<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SacarTurno.aspx.cs" Inherits="Turnera_TPC_Equipo27.Turnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="background-color: rgb(65, 65, 65);">
        <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
            <h4><strong>Solicita tu turno</strong></h4>
            <br />
        </div>
    </div>
    <div class="container">
        <div class="row d-flex justify-content-center">
            <div class="col-6 mb-3 text-center">
                <label for="ddlPaciente" class="form-label text-white"><strong>Paciente</strong></label>
                <asp:DropDownList ID="ddlPaciente" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="row d-flex justify-content-center">
            <div class="col-6 mb-3 text-center">
                <label for="ddlEspecialidad" class="form-label text-white"><strong>Especialidad</strong></label>
                <asp:DropDownList ID="ddlEspecialidad" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
        </div>
        <div class="row d-flex justify-content-center ">
            <div class="col-6 mb-3 text-center">
                <label for="ddlMedico" class="form-label text-white" id="lblMedico" runat="server"><strong>Medico</strong></label>
                <asp:DropDownList ID="ddlMedico" CssClass="form-select " runat="server" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row d-flex justify-content-center pt-3">
            <div runat="server" id="lblCldTurno" class="col-6 mb-3 text-center bg-secondary rounded-1 py-4">
                <label for="cldTurno" class="form-label text-black" runat="server"><strong>Calendario de turnos</strong></label>
                <asp:Calendar class="form-label text-white" ID="cldTurno" runat="server" Style="margin: 0 auto;" OnVisibleMonthChanged="cldTurno_VisibleMonthChanged" OnDayRender="cldTurno_DayRender" OnSelectionChanged="cldTurno_SelectionChanged"></asp:Calendar>
            </div>
        </div>
        <div class="row d-flex justify-content-center ">
            <div class="col-6 mb-3 text-center">
                <label for="ddlHorarios" class="form-label text-white" id="lblHorarios" runat="server"><strong>Horarios Disponibles</strong></label>
                <asp:DropDownList ID="ddlHorarios" CssClass="form-select " runat="server" OnSelectedIndexChanged="ddlHorarios_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>

        <div class="mb-3 text-center">
            <asp:Button Text="Sacar Turno" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" AutoPostBack="false" />
            <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" Onclick="btnCancelar_Click1" runat="server" />
        </div>

    </div>

    <label for="txtId" class="form-label text-white"></label>
    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />

</asp:Content>
