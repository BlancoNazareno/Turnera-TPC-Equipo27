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
        public List<Especialidad> listar()
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

        public void modificarEspecialidad(Especialidad especialidad)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Update Especialidad set Especialidad = @Especialidad where ID=@Id");

                acceso.setearParametro("@ID", especialidad.Id);
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


    }
}
