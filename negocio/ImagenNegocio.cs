using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
 
namespace negocio
{
    public class ImagenNegocio
    {
        List<Imagen> listado = new List<Imagen>();

        public List<Imagen> listarImagenes()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("SELECT Id, IdArticulo, ImagenURL from IMAGENES");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Imagen tmp = new Imagen();
                    tmp.Id = (int)datos.Lector["Id"];
                    tmp.IdArticulo = (int)datos.Lector["IdArticulo"];
                    tmp.UrlImagen = (string)datos.Lector["ImagenURL"];
                    listado.Add(tmp);

                }
                datos.cerrarConexion();
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void insertar(List<string> imagenes, int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (string img in imagenes)
                {
                    datos.configurarConsulta("insert into IMAGENES (IdArticulo, ImagenUrl) OUTPUT INSERTED.ID values ('" + id + "','" + img + "')");
                    datos.ejecutarAccion();
                    datos.cerrarConexion();

                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
