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
                                <div>Nombre: <label style="font-weight:bold;"><%# DataBinder.Eval(Container.DataItem, "art.Nombre") %> </label></div>
                                <div>ID: <asp:Label ID="Label1" runat="server" Text='<%# Eval("art.id") %>' Visible="true"></asp:Label>
                                </div>
                                <div>
                                <asp:Button ID="ButtonSumar" runat="server" CssClass="btn btn-secondary" Text="+" OnClick="sumarCant" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "art.Id") %>' />
                                <asp:Label ID="LabelCantidad" runat="server" Text='<%# "Cantidad: " + Eval("cantidad") %>'></asp:Label>
                                <asp:Button ID="ButtonRest" runat="server" CssClass="btn btn-secondary" Text="-" OnClick="restarCant" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "art.Id") %>' />

                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnLimpiarLista" runat="server" CssClass="btn btn-primary" Text="Limpiar" OnClick="btnLimpiarLista_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
