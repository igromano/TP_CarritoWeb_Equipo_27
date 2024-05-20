using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TP_CarritoWeb_Equipo_27
{
    public partial class Default : System.Web.UI.Page
    {
        private ArticuloNegocio artNegocio = new ArticuloNegocio();
        private ImagenNegocio imgNegocio = new ImagenNegocio();
        public List<Articulo> listaArticulos;
        public List<Imagen> listaImagenes;
        public List<ElementosCarrito> carrito = new List<ElementosCarrito>();
        public ElementosCarrito tmpElemtoCarrito;
        protected List<ElementosCarrito> listaCarrito
        {
            get
            {
                if (Session["listaCarritoActiva"] == null)
                {
                    Session["listaCarritoActiva"] = new List<ElementosCarrito>();
                }
                return (List<ElementosCarrito>)Session["listaCarritoActiva"];
            }
            set
            {
                Session["listaCarritoActiva"] = value;
                
            }
        }

        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                carrito = new List<ElementosCarrito>();
                
                Session.Add("listaArticulos", artNegocio.listarArticulos());
                Session.Add("listaImagenes", imgNegocio.listarImagenes());
                Session.Add("listaCarrito", carrito);
                Session.Add("listaCarritoActiva", listaCarrito);
                
                listaImagenes = (List<Imagen>)Session["listaImagenes"];
                listaArticulos = (List<Articulo>)Session["listaArticulos"];

                foreach(Articulo art  in listaArticulos)
                {
                    tmpElemtoCarrito = new ElementosCarrito();
                    tmpElemtoCarrito.art = art;
                    tmpElemtoCarrito.imagenes = listaImagenes.FindAll(img => img.IdArticulo == art.Id);
                    carrito.Add(tmpElemtoCarrito);
                }

                homeRepeater.DataSource = carrito;
                homeRepeater.DataBind();

                repeaterLista.DataSource = Session["listaCarritoActiva"];
                repeaterLista.DataBind();

            }

            carrito = (List<ElementosCarrito>)Session["listaCarrito"];

        }
        protected void actualizarBindListaCarro()
        {

            repeaterLista.DataSource = listaCarrito;
            repeaterLista.DataBind();

        }

        public void addCarrito_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            string texto = btn.CommandArgument;
            int itemId = int.Parse(texto);
            ElementosCarrito selectedItem = carrito.Find(i => i.art.Id == itemId);
            if (selectedItem != null)
            {
                ElementosCarrito buscarElemento = listaCarrito.Find(i => i.art.Id == itemId);
                if (buscarElemento != null)
                {
                    buscarElemento.cantidad++;
                    actualizarBindListaCarro();
                }
                else
                {
                    ElementosCarrito eleTmp = new ElementosCarrito();
                    eleTmp.art = selectedItem.art;
                    eleTmp.cantidad = 1;
                    listaCarrito.Add(eleTmp);
                    actualizarBindListaCarro();
                }


            }

        }
        protected void sumarCant(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemId = int.Parse(btn.CommandArgument);
            ElementosCarrito selectedItem = listaCarrito.FirstOrDefault(i => i.art.Id == itemId);
            if (selectedItem != null)
            {
                selectedItem.cantidad++;
                actualizarBindListaCarro();
            }
        }

        protected void restarCant(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int itemId = int.Parse(btn.CommandArgument);
            ElementosCarrito selectedItem = listaCarrito.FirstOrDefault(i => i.art.Id == itemId);
            if (selectedItem != null)
            {
                if (!(selectedItem.cantidad <= 1))
                {
                    selectedItem.cantidad--;
                    actualizarBindListaCarro();
                }

            }
        }

        protected void btnLimpiarLista_Click(object sender, EventArgs e)
        {
            listaCarrito = new List<ElementosCarrito>();
            actualizarBindListaCarro();
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string idArticulo = btn.CommandArgument;
            Response.Redirect($"DetalleProducto.aspx?id={idArticulo}");
        }
    }


}