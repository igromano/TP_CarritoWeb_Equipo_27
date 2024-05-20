using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_CarritoWeb_Equipo_27
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string idArticulo = Request.QueryString["id"];
                    CargarDetallesDelArticulo(idArticulo);
                }
                else
                {
                    // SI NO HAY ID ACÁ MANEJAR LA EXCEPCION
                }
            }
        }

        private void CargarDetallesDelArticulo(string idArticulo)
        {
            int idArticuloInt = Convert.ToInt32(idArticulo);
            List<Articulo> listaArticulos = Session["listaArticulos"] as List<Articulo>;
            List<Imagen> listaImagenes = Session["listaImagenes"] as List<Imagen>;
            Articulo articulo = listaArticulos.FirstOrDefault(a => a.Id == idArticuloInt);
            List<Imagen> imagenesArticulo = listaImagenes.Where(img => img.IdArticulo == idArticuloInt).ToList();
            if (articulo != null)
            {
                lblMarca.Text = articulo.Marca.Descripcion;
                lblNombre.Text = articulo.Nombre;
                lblDescripcion.Text = articulo.Descripcion;
                lblPrecio.Text = articulo.Precio.ToString("C");
                rptCarouselIndicators.DataSource = imagenesArticulo;
                rptCarouselIndicators.DataBind();

                rptCarouselImages.DataSource = imagenesArticulo;
                rptCarouselImages.DataBind();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}
