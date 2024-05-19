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
        public List<ElementosCarrito> carrito;
        public ElementosCarrito tmpElemtoCarrito;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                carrito = new List<ElementosCarrito>();
                
                Session.Add("listaArticulos", artNegocio.listarArticulos());
                Session.Add("listaImagenes", imgNegocio.listarImagenes());
                Session.Add("listaCarrito", carrito);
                
                listaImagenes = (List<Imagen>)Session["listaImagenes"];
                listaArticulos = (List<Articulo>)Session["listaArticulos"];

                foreach(Articulo art  in listaArticulos)
                {
                    tmpElemtoCarrito = new ElementosCarrito();
                    tmpElemtoCarrito.art = art;
                    tmpElemtoCarrito.imagenes = listaImagenes.FindAll(img => img.IdArticulo == art.Id);
                    carrito.Add(tmpElemtoCarrito);
                }
            }



            homeRepeater.DataSource = carrito;
            homeRepeater.DataBind();
            
        }

        protected void addCarrito_Click(object sender, ImageClickEventArgs e)
        {

        }


    }
}