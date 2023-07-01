using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> listar(string id = "")
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select E.IDEspecialidad Id, E.Especialidad Especialidad From Especialidades E");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Especialidad"];

                    lista.Add(aux);
                }

                return lista;
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

        public void agregar(Especialidad nuevaEspecialidad)
        {
            AccesoDatos acceso = new AccesoDatos();

            try
            {
                acceso.setearConsulta("insert into Especialidades (Especialidad) values (@Especialidad)");
                acceso.setearParametro("@Especialidad", nuevaEspecialidad.Nombre);
                acceso.ejecutarAccion();

            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public Especialidad listarUltimaEspecialidad()
        {
            AccesoDatos acceso = new AccesoDatos();
            Especialidad ultima = new Especialidad();
            try
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();

                acceso.setearConsulta("select top 1 * from Especialidades where order by Especialidad.ID desc");
                acceso.ejecutarLectura();
                acceso.Lector.Read();

                ultima.Id = (int)acceso.Lector["ID"];
                ultima.Nombre = (string)acceso.Lector["Especialidad"];

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
            return ultima;
        }

        public void modificar(Especialidad especialidad)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Update Especialidades set Especialidad = @Especialidad where IDEspecialidad=@Id");

                acceso.setearParametro("@Id", especialidad.Id);
                acceso.setearParametro("@Especialidad", especialidad.Nombre);
                acceso.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {//Eliminado FISICO, el Logico no lo podemos hacer aca xq no tenemos en Especialidades un atributo como "Activo"
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Delete from Especialidades where IDEspecialidad=@Id");
                acceso.setearParametro("@Id", id);               
                acceso.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public Especialidad ObtenerEspecialidadPorId(int id)
        {
            // Implementa tu lógica para obtener la especialidad por su ID desde la capa de datos
            // Puedes utilizar una consulta SQL o cualquier otro mecanismo que utilices en tu capa de datos
            // Retorna la especialidad encontrada o null si no se encuentra

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDEspecialidad AS Id, Especialidad FROM Especialidades WHERE IDEspecialidad = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.Id = (int)datos.Lector["Id"];
                    especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    return especialidad;
                }
                else
                {
                    return null; // Especialidad no encontrada
                }
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
