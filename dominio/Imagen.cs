using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int Id;
        public int IdArticulo { get; set; }
        [DisplayName("URL Imagen")]
        public string UrlImagen {  get; set; }

    }
}
