using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Runtime.CompilerServices;
 
namespace negocio
{
    public class ArticuloNegocio
    {
        List<Articulo> listado = new List<Articulo>();

        public List<Articulo> listarArticulos()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("SELECT ARTICULOS.Id as id_Art,Codigo, Nombre, Precio, ARTICULOS.Descripcion as descArt, MARCAS.Descripcion as descMarca, CATEGORIAS.Descripcion as descCat, MARCAS.Id as Id_Marca, CATEGORIAS.Id as Id_Categoria from ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Marca tmpMarca = new Marca();
                    Categoria tmpCat = new Categoria();
                    Articulo tmp = new Articulo();
                    tmp.Id = (int)datos.Lector["id_Art"];
                    tmp.Codigo = (string)datos.Lector["Codigo"];
                    tmp.Nombre = (string)datos.Lector["Nombre"];
                    tmp.Descripcion = (string)datos.Lector["descArt"];
                    tmp.Precio = (decimal)datos.Lector["Precio"];
                    tmpMarca.Descripcion = (string)datos.Lector["descMarca"];
                    tmpMarca.Id = (int)datos.Lector["Id_Marca"];
                    tmp.Marca = tmpMarca;
                    tmpCat.Descripcion = (string)datos.Lector["descCat"];
                    tmpCat.Id = (int)datos.Lector["Id_Categoria"];
                    tmp.Categoria = tmpCat;
                    listado.Add(tmp);
                }
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

        public int insertar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion, Precio, IdMarca, IdCategoria) OUTPUT INSERTED.ID values(@codigo, @nombre, @descripcion, @precio, @idMarca, @idCategoria)");
                datos.setearParametros("@codigo", articulo.Codigo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@precio", articulo.Precio);
                datos.setearParametros("@idMarca", articulo.Marca.Id);
                datos.setearParametros("@idCategoria", articulo.Categoria.Id);
                int id = datos.ejecutarAccion();
                Console.WriteLine(id);
                return id;
 
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

        public void actualizar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("UPDATE ARTICULOS SET Codigo = @codigo ,Nombre = @nombre ,Descripcion = @descripcion ,IdMarca = @idMarca ,IdCategoria = @idCategoria ,Precio = @precio WHERE Id = @idArticulo");
                datos.setearParametros("@codigo", articulo.Codigo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@idMarca", articulo.Marca.Id);
                datos.setearParametros("@idCategoria", articulo.Categoria.Id);
                datos.setearParametros("@precio", articulo.Precio);
                datos.setearParametros("@idArticulo", articulo.Id);
                datos.ejecutarAccionNoEscalar();
                
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
        public void eliminar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.configurarConsulta("DELETE FROM ARTICULOS WHERE Id = @idArticulo");
                datos.setearParametros("@idArticulo", articulo.Id);
                datos.ejecutarAccionNoEscalar();
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
    }
}

