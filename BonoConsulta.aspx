<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSiteMaster.Master" AutoEventWireup="true" CodeBehind="BonoConsulta.aspx.cs" Inherits="Turnera_TPC_Equipo27.BonoConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .white-text {
            color: white;
        }
        .double-space {
            height: 2.5rem;
        }
        .dashed-line {
            border-bottom: 1px dashed #000;
        }
        .encuadrado {
            color: white;
            border: 1px solid #000;
            padding: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container encuadrado">
        <h2 class="white-text">Space Medicine<span class="float-end">ORDEN DE CONSULTA</span></h2>
        <p class="white-text">Hipólito Yrigoyen 288, Gral. Pacheco</p>
        <div class="row mb-4">
            <div class="col-md-4">
                <label for="txtFechaTurno" class="form-label white-text">Fecha de Turno:</label>
                <asp:Label runat="server" ID="lblFechaTurno" CssClass="form-control white-text"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="txtMedico" class="form-label white-text">Medico:</label>
                <asp:Label runat="server" ID="lblMedico" CssClass="form-control white-text"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="txtEspecialidad" class="form-label white-text">Especialidad:</label>
                <asp:Label runat="server" ID="lblEspecialidad" CssClass="form-control white-text"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="txtNombreCompleto" class="form-label white-text">Nombre y apellido:</label>
                <asp:Label runat="server" ID="lblNombreCompleto" CssClass="form-control white-text"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="txtDNI" class="form-label white-text">DNI:</label>
                <asp:Label runat="server" ID="lblDNI" CssClass="form-control white-text"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="txtFechaNacimiento" class="form-label white-text">Fecha de nacimiento:</label>
                <asp:Label runat="server" ID="lblFechaNacimiento" CssClass="form-control white-text"></asp:Label>
            </div>
            <br />
            <br />
            <div class="col-md-4">
                <label for="txtCelular" class="form-label white-text">Celular:</label>
                <asp:Label runat="server" ID="lblCelular" CssClass="form-control white-text"></asp:Label>
            </div>
            <div class="col-md-4">
                <label for="txtCobertura" class="form-label white-text">Cobertura:</label>
                <asp:Label runat="server" ID="lblCobertura" CssClass="form-control white-text"></asp:Label>
            </div>

            <br />
            <br />
            <div class="col-md-12">
                <label for="txtDiagnostico" class="form-label white-text">Diagnóstico:</label>
                <textarea id="txtDiagnostico" class="form-control white-text" rows="2" readonly></textarea>
            </div>
            <div class="row">
                <div class="col-md-6 ">
                    <label for="txtFirmaMedico" class="form-label white-text">Firma y sello de Profesional:</label>
                    <textarea class="form-control white-text" id="txtFirmaMedico" readonly rows="2"></textarea>
                </div>
                <div class="col-md-6">
                    <label for="txtFirmaPaciente" class="form-label white-text">Firma del Afiliado:</label>
                    <textarea class="form-control white-text" id="txtFirmaPaciente" readonly rows="2"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <br>
                    <asp:Button runat="server" ID="btnImprimir" Text="Generar" CssClass="btn btn-primary float-end"
                        OnClientClick="window.print();" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
