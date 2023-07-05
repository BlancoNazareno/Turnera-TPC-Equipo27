<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Turnera_TPC_Equipo27.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--    <style>
        @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap');

        .card-title,
        .card-text {
            font-family: 'Roboto', sans-serif;
        }
    </style>

    <!-- Inicio -->
    <div id="Inicio">
        <div class="container" style="background-color: rgb(65, 65, 65);">
            <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
                <h4><strong>Turnos disponibles</strong></h4>

                <p>Podés ver los turnos disponibles, buscando a partir de la especialidad</p>
            </div>

        </div>
    </div>

    <style>
        h3, .Busqueda {
            color: yellow;
        }

        .table {
            color: white;
        }
    </style>

    <div>
        <div id="Especialidades">
            <div class="row row col-4   " style="margin-left: 3rem">
                <h3>Lista de Especialidades</h3>

                <div class="Busqueda">
                    <div class="row">
                        <div class="col-8">
                            <div class="mb-3">
                                <asp:Label Text="Filtrar" runat="server" />
                                <asp:TextBox runat="server" ID="txtfiltro" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="filtroEspecialidades_TextChanged" />
                            </div>
                        </div>


                        <asp:GridView ID="dgvEspecialidades" DataKeyNames="Id"
                            CssClass="table" runat="server" AutoGenerateColumns="false"
                            OnSelectedIndexChanged="dgvEspecialidades_SelectedIndexChanged"
                            OnPageIndexChanging="dgvEspecialidades_PageIndexChanging"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <%--                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />--%>
    <%--aca el DataField es diferente porque tengo en mi clase Articulo la propiedad Marca y Categoria(las cuales son otra clase) --%>
    <%--                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div id="Medicos">
            <div class="row row col-4   " style="margin-left: 3rem">
                <h3>Lista de Médicos</h3>

                <div class="Busqueda">
                    <div class="row">
                        <div class="col-8">
                            <div class="mb-3">
                                <asp:Label Text="Filtrar" runat="server" />
                                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="filtroMedicos_TextChanged" />
                            </div>
                        </div>


                        <asp:GridView ID="dgvMedicos" DataKeyNames="id2"
                            CssClass="table" runat="server" AutoGenerateColumns="false"
                            OnSelectedIndexChanged="dgvMedicos_SelectedIndexChanged"
                            OnPageIndexChanging="dgvMedicos_PageIndexChanging"
                            AllowPaging="true" PageSize="5">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />--%>
    <%--                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />--%>
    <%--aca el DataField es diferente porque tengo en mi clase Articulo la propiedad Marca y Categoria(las cuales son otra clase) --%>
    <%--                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>--%>




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
            <div class="col-6 ">
                <div class="mb-3">
                    <label for="txtDNI" class="form-label text-white">DNI: </label>
                    <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtContrasenia" class="form-label text-white">Contraseña: </label>
                    <asp:TextBox runat="server" ID="txtContrasenia" CssClass="form-control" />
                </div>
       
                <div class="mb-3 text-center">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary mx-2" runat="server" OnClick="btnAceptar_Click" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger mx-2" runat="server" OnClick="btnCancelar_Click"/>
                    <br />>
                    <p class="form-label text-white">¿No estás registrado? <br /> Podés hacerlo acá</p>
                    
                    <asp:Button Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-info mx-2" runat="server" OnClick="btnRegistrarse_Click"  />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
