<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Turnera_TPC_Equipo27.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function soloNumeros(event) {
            var charCode = event.which ? event.which : event.keyCode;
            if (charCode < 48 || charCode > 57) {
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="background-color: rgb(65, 65, 65);">
        <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
            <h4><strong>Login</strong></h4>
            <br />
            <p>Bienvenido a Space Medicine, tu sitio de gestión de turnos</p>
            <br />
            <p>Debes loguearte para acceder al sitio</p>
        </div>

    </div>

    <div class="container">
        <div class="row d-flex justify-content-center">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtDNI" class="form-label text-white">DNI: </label>
                    <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" onkeypress="return soloNumeros(event)" />
                </div>
                <div class="mb-3">
                    <label for="txtContrasenia" class="form-label text-white">Contraseña: </label>
                    <asp:TextBox runat="server" ID="txtContrasenia" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" OnClick="btnCancelar_Click" />
                    <div class="mt-3">
                        <asp:Label Text="" ID="lblErrorLogin" runat="server" CssClass="text-center text-danger" />
                    </div>
                    <div class="mt-3">
                        <p class="form-label text-white">
                            ¿No estás registrado?
                            <br />
                            Podés hacerlo acá
                        </p>
                        <asp:Button Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-info mx-2" runat="server" OnClick="btnRegistrarse_Click" />
                        <br />
                        <br />
                        <p class="form-label text-white">
                            Consulte gratis que Obra Social/Prepaga posee actualmente 
                            <a href="https://servicioswww.anses.gob.ar/ooss2/" style="text-decoration: underline; 
                            font-style: italic; " target="_blank">aquí</a>
                        </p>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
