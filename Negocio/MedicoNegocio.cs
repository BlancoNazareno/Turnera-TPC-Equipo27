using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MedicoNegocio
    {
        public List<Medico> listar()
        {
            List<Medico> lista = new List<Medico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select M.IDMedico, M.Apellido, M.Nombre, M.DNI, M.FechaNacimiento, M.Mail, E.Especialidad From Medicos M, Especialidades E Where M.IDEspecialidad = E.IDEspecialidad");
                datos.ejecutarLectura();
                //< asp:BoundField HeaderText = "Id" DataField = "Id" />
                //< asp:BoundField HeaderText = "Nombre" DataField = "Nombre" />
                //< asp:BoundField HeaderText = "Apellido" DataField = "Apellido" />
                //< asp:BoundField HeaderText = "Fecha de Nacimiento" DataField = "FechaDeNacimiento" />
                //< asp:BoundField HeaderText = "Dni" DataField = "Dni" />
                //< asp:BoundField HeaderText = "Mail" DataField = "Mail" />
                //< asp:BoundField HeaderText = "ID Especialidad" DataField = "IDEspecialidad" />
                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)datos.Lector["IDMedico"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Dni = (int)datos.Lector["DNI"];//como en la BD es bigint, aca es long
                    aux.FechaNacimiento = ((DateTime)datos.Lector["FechaNacimiento"]);
                    string fechaNacimiento = aux.FechaNacimiento.ToString("dd/MM/yyyy");
                    
                    //aux.FechaNacimiento = ((DateTime)datos.Lector["FechaNacimiento"]).;//Clave poner DateTime, y no Datetime, sino no anda
                    //con el .Date al final intento hacer q muestre solo la fecha, sin la hora, tambien con esta linea de abajo
                    //string fechaNacimiento = aux.FechaNacimiento.ToString("dd/MM/yyyy");
                    aux.Mail = (string)datos.Lector["Mail"];
                    //aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    //aux.Especialidad = new Especialidad();
                    //aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];

                    aux.Especialidad = new Especialidad(); // Crear instancia de Especialidad
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];



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

        public void agregar(Medico nuevoMedico)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("insert into Medicos (Nombre, Apellido, FechaNacimiento, DNI, Mail, IDEspecialidad, Estado) values (@Nombre, @Apellido, @FechaNacimiento, @DNI, @Mail, @IdEspecialidad, 1)");
                acceso.setearParametro("@Nombre", nuevoMedico.Nombre);
                acceso.setearParametro("@Apellido", nuevoMedico.Apellido);
                acceso.setearParametro("@FechaNacimiento", nuevoMedico.FechaNacimiento);
                acceso.setearParametro("@DNI", nuevoMedico.Dni);
                acceso.setearParametro("@Mail", nuevoMedico.Mail);
                acceso.setearParametro("@IdEspecialidad", nuevoMedico.Especialidad.Id);

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

        public void modificar(Medico nuevoMedico)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("update Medicos set Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, DNI = @DNI, Mail = @Mail, IDEspecialidad = @IdEspecialidad Where IdMedico = @id");
                acceso.setearParametro("@Nombre", nuevoMedico.Nombre);
                acceso.setearParametro("@Apellido", nuevoMedico.Apellido);
                acceso.setearParametro("@FechaNacimiento", nuevoMedico.FechaNacimiento);
                acceso.setearParametro("@DNI", nuevoMedico.Dni);
                acceso.setearParametro("@Mail", nuevoMedico.Mail);
                acceso.setearParametro("@IdEspecialidad", nuevoMedico.Especialidad.Id);
                acceso.setearParametro("@id", nuevoMedico.Id);

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
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Delete From Medicos Where IDMedico = @Id");
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

        public List<Medico> listaFiltrada(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Medico> lista = new List<Medico>();
            try
            {
                datos.setearConsulta("SELECT M.IDMedico, M.Apellido, M.Nombre, M.DNI, M.FechaNacimiento, M.Mail, E.Especialidad FROM Medicos M INNER JOIN Especialidades E ON M.IDEspecialidad = E.IDEspecialidad WHERE E.IDEspecialidad = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)datos.Lector["IDMedico"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];

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
        public bool existeMedicoConEsaEspecialidad(int idEspecialidad)//Para cuando se elimina una Especialidad, se fije si no esta vinculada a un Medico
        {
            List<Medico> lista = listar();
            return lista.Exists(m => m.Especialidad.Id == idEspecialidad);//devuelve true si se cumple lo q esta en parentesis
        }

        public List<Medico> listarMedicosPorEspecialidad(int especialidadId)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Medico> listaMedicos = new List<Medico>();

            string consulta = "Select M.Apellido, M.Nombre From Medicos M Where M.IDEspecialidad = ";
            consulta += especialidadId;

            //datos.setearParametro("@especialidadId", especialidadId);
            //datos.setearConsulta("Select M.Apellido, M.Nombre From Medicos M Where M.IDEspecialidad = @especialidaId");
            datos.setearConsulta(consulta);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Medico aux = new Medico();

                aux.Apellido = (string)datos.Lector["Apellido"];
                aux.Nombre = (string)datos.Lector["Nombre"];

                listaMedicos.Add(aux);
            }

            datos.cerrarConexion();

            return listaMedicos;
        }
    }

   
}
