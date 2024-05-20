<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_CarritoWeb_Equipo_27.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .carousel-item img {
            height: 450px;
            width: 100%;
            object-fit: contain;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Detalle del Producto</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div>
                            <label for="lblMarca">Marca:</label>
                            <asp:Label ID="lblMarca" runat="server" CssClass="form-control" />
                        </div>
                        <div>
                            <label for="lblNombre">Nombre:</label>
                            <asp:Label ID="lblNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div>
                            <label for="lblPrecio">Precio:</label>
                            <asp:Label ID="lblPrecio" runat="server" CssClass="form-control" />
                        </div>
                        <div>
                            <label for="lblDescripcion">Descripción:</label>
                            <asp:Label ID="lblDescripcion" runat="server" CssClass="form-control" />
                        </div>
                        <asp:Button ID="btnVolver" runat="server" Text="Volver al listado" CssClass="btn btn-primary mt-3" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-indicators">
                        <asp:Repeater ID="rptCarouselIndicators" runat="server">
                            <ItemTemplate>
                                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="<%# Container.ItemIndex %>" class="<%# Container.ItemIndex == 0 ? "active" : "" %>" aria-current="true" aria-label="<%# "Slide " + (Container.ItemIndex + 1) %>"></button>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptCarouselImages" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                    <img src='<%# Eval("UrlImagen") %>' class="d-block w-100" alt='<%# "Image " + (Container.ItemIndex + 1) %>' />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


