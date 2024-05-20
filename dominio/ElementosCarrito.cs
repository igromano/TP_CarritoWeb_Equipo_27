using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ElementosCarrito
    {

        public Articulo art { get; set; }
        public int cantidad { get; set; }

        public List<Imagen> imagenes  { get; set; }
    }
}
