<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_CarritoWeb_Equipo_27.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="homeRepeater" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card p-2">
                        <asp:Image ID="imagenArticulo" ImageUrl='<%#Eval("imagenes[0].UrlImagen")%>' runat="server"></asp:Image>
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("art.Nombre") %></h5>
                            <p class="card-text"><%#Eval("art.Descripcion") %></p>
                            <asp:Button ID="botonDetalle" runat="server" Text="Ver detalle" CssClass="btn btn-primary" OnClick="btnVerDetalle_Click" CommandArgument='<%# Eval("art.id") %>' />
                        </div>
                        <div class="d-flex flex-row-reverse">
                            <asp:ImageButton ID="addCarrito" OnClick="addCarrito_Click" CommandArgument='<%#Eval("art.id") %>' CommandName="idArticulo" runat="server" CssClass="btn btn-primary" ImageUrl="~/Images/carrito-de-compras.png" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight" aria-labelledby="offcanvasRightLabel">
        <div class="offcanvas-header">
            <h5 class="offcanvas-title" id="offcanvasRightLabel">Carrito de Compras</h5>
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="repeaterLista" runat="server">
                        <ItemTemplate>
                            <div class="container">
                                <div class="row">
                                    <div class="col-sm-3" style="margin=4px;">

                                        <asp:Image ID="imagenArticulo" ImageUrl='<%#Eval("imagenes[0].UrlImagen")%>' Width="100" runat="server"></asp:Image>

                                    </div>
                                    <div class="col-sm-9">
                                        <div class="row">
                                            <div class="col-8 col-sm-6">
                                                Nombre:
                                                <label style="font-weight: bold;"><%# DataBinder.Eval(Container.DataItem, "art.Nombre") %> </label>
                                            </div>
                                            <div class="col-4 col-sm-6" style="align-items: center">
                                                <div style="margin: 5px;">
                                                    <asp:Label ID="LabelCantidad" runat="server" Text='<%# "Cantidad: " + Eval("cantidad") %>'></asp:Label>
                                                    <div style="margin-bottom: 3px;">
                                                        <asp:Button ID="ButtonRest" runat="server" CssClass="btn btn-secondary" Text="-" OnClick="restarCant" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "art.Id") %>' />
                                                        <asp:Button ID="ButtonSumar" runat="server" CssClass="btn btn-secondary" Text="+" OnClick="sumarCant" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "art.Id") %>' />
                                                    </div>
                                                    <asp:Button ID="BotonEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="BotonEliminar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "art.Id") %>' />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnLimpiarLista" runat="server" CssClass="btn btn-danger" Text="Vaciar Carrito" OnClick="btnLimpiarLista_Click" />
                    <hr />
                    <div class="container">
                        <div class="row">
                            <div class="col-md-8">
                                <h6>Total a pagar: </h6>
                            </div>
                            <div class="col-6 col-md-4">$ <%= Session["totalPrecio"] %></div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript">
        //Logica para que se recargue la página cuando se actualizan los items.
        document.addEventListener("DOMContentLoaded", function () {
            var offcanvas = document.getElementById('offcanvasRight');

            offcanvas.addEventListener('hidden.bs.offcanvas', function () {

                window.location.href = 'Default.aspx';
            });
        });
    </script>
</asp:Content>
