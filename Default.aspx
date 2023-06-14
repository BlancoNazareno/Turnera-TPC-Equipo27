<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Turnera_TPC_Equipo27.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap');

        .card-title,
        .card-text {
            font-family: 'Roboto', sans-serif;
        }
    </style>

    <!-- Catálogo -->
    <div id="Catalogo">
        <div class="container" style="background-color: rgb(65, 65, 65);">
            <div class="text-light p-3 text-center" style="margin-top: 3rem; margin-bottom: 2rem">
                <h4><strong>Turnos disponibles</strong></h4>

                <p>Podés ver los turnos disponibles, buscando a partir de la especialidad</p>
            </div>

        </div>
    </div>

    <!-- Cards con foreach -->
<%--    <div class="container">
        <div class="row row-cols-1 row-cols-md-4">
            <%foreach (Dominio.Articulo item in ListaArticulo)
                { %>

            <div class="col mb-4">
                <div class="card border-dark align-content-sm-center">
                    <img style="max-width: 300px; max-height: 300px; object-fit: contain" src="<%= item.ImagenUrl %>" class="card-img-top" alt="Imagen no disponible">
                    <div class="card-body">
                        <h5 class="card-title"><%= item.Nombre %></h5>
                        <p class="card-text"><%= item.Marca %></p>
                        <a href="Detalle.aspx?idArticulo=<%=item.ID.ToString()%>" class="btn btn-info mb-1">Detalle</a>
                        <a href="Carrito.aspx?idArticulo=<%=item.ID.ToString()%>" class="btn btn-primary mb-1">Añadir al carrito</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>--%>


</asp:Content>
