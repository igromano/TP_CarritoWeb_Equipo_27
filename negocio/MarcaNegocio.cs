using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
 
namespace negocio
{
    public class MarcaNegocio
    {
        List<Marca> listado = new List<Marca>();

        public List<Marca> listarMarcas()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("SELECT Id, Descripcion from MARCAS");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Marca tmp = new Marca();
                    tmp.Id = (int)datos.Lector["Id"];
                    tmp.Descripcion = (string)datos.Lector["Descripcion"];
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

        public void agregar(string marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.configurarConsulta("insert into MARCAS values(@marcasDescripcion)");
                datos.setearParametros("@marcasDescripcion", marca);
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

        public void eliminar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("DELETE FROM MARCAS WHERE Id = @idMarca");
                datos.setearParametros("@idMarca", marca.Id);
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

        public void actualizar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.configurarConsulta("UPDATE MARCAS SET Descripcion = @descripcion WHERE Id = @idMarca");
                datos.setearParametros("@idMarca", marca.Id);
                datos.setearParametros("@descripcion", marca.Descripcion);
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
