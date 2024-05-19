<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_CarritoWeb_Equipo_27.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
