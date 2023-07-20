using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;


namespace negocio
{
    public class TurnoNegocio
    {
        //IDEspecialidad, IDMedico, IDPaciente, Fecha, Estado
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT T.IDTurno, T.Fecha, E.Especialidad AS NombreEspecialidad, M.IDMedico AS IdMedico, M.Nombre AS NombreMedico, M.Apellido AS ApellidoMedico, P.IDPaciente AS IdPaciente, P.Nombre AS NombrePaciente, P.Apellido AS ApellidoPaciente, P.Cobertura AS CoberturaPaciente, P.FechaNacimiento AS FechaNacimiento, P.Celular AS Celular, T.Estado FROM Turnos T INNER JOIN Especialidades E ON T.IDEspecialidad = E.IDEspecialidad INNER JOIN Medicos M ON T.IDMedico = M.IDMedico INNER JOIN Pacientes P ON T.IDPaciente = P.IDPaciente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = (int)datos.Lector["IDTurno"];
                    turno.Fecha = (DateTime)datos.Lector["Fecha"];

                    Especialidad especialidad = new Especialidad();
                    especialidad.Nombre = (string)datos.Lector["NombreEspecialidad"];
                    turno.Especialidad = especialidad;

                    Medico medico = new Medico();
                    medico.Nombre = (string)datos.Lector["NombreMedico"];
                    medico.Apellido = (string)datos.Lector["ApellidoMedico"];
                    medico.Id = (int)datos.Lector["IdMedico"];
                    turno.Medico = medico;

                    Paciente paciente = new Paciente();
                    paciente.Id = (int)datos.Lector["IdPaciente"];
                    paciente.Nombre = (string)datos.Lector["NombrePaciente"];
                    paciente.Apellido = (string)datos.Lector["ApellidoPaciente"];
                    paciente.Cobertura = (string)datos.Lector["CoberturaPaciente"];
                    paciente.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    paciente.Celular = (string)datos.Lector["Celular"];
                    turno.Paciente = paciente;

                    
                    turno.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(turno);
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

        public void agregar( Turno nuevoTurno )
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Turnos (IDEspecialidad, IDMedico, IDPaciente, Fecha, Estado) values (@IDEspecialidad, @IDMedico, @IDPaciente, @Fecha, 1)");
                datos.setearParametro("@IDEspecialidad", nuevoTurno.Especialidad.Id);
                datos.setearParametro("@IDMedico", nuevoTurno.Medico.Id);
                datos.setearParametro("@IDPaciente", nuevoTurno.Paciente.Id);
                datos.setearParametro("@Fecha", nuevoTurno.Fecha);

                datos.ejecutarAccion();
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

        public void eliminarLogico(int id)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Update Turnos set Estado = 0 where IDTurno=@Id");
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

        public void modificar(Turno turno)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("UPDATE Turnos SET IDEspecialidad = @IDEspecialidad, IDMedico = @IDMedico, IDPaciente = @IDPaciente, Fecha = @Fecha WHERE IDTurno = @IDTurno");
                acceso.setearParametro("@IDEspecialidad", turno.Especialidad.Id);
                acceso.setearParametro("@IDMedico", turno.Medico.Id);
                acceso.setearParametro("@IDPaciente", turno.Paciente.Id);
                acceso.setearParametro("@Fecha", turno.Fecha);
                acceso.setearParametro("@IDTurno", turno.Id);

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

        public Turno obtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT T.IDTurno, T.Fecha, E.Especialidad AS NombreEspecialidad, M.Nombre AS NombreMedico, M.Apellido AS ApellidoMedico, P.Nombre AS NombrePaciente, P.Apellido AS ApellidoPaciente, T.Estado FROM Turnos T INNER JOIN Especialidades E ON T.IDEspecialidad = E.IDEspecialidad INNER JOIN Medicos M ON T.IDMedico = M.IDMedico INNER JOIN Pacientes P ON T.IDPaciente = P.IDPaciente WHERE T.IDTurno = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Turno turno = new Turno();
                    turno.Id = (int)datos.Lector["IDTurno"];
                    turno.Fecha = (DateTime)datos.Lector["Fecha"];

                    Especialidad especialidad = new Especialidad();
                    especialidad.Nombre = (string)datos.Lector["NombreEspecialidad"];
                    turno.Especialidad = especialidad;

                    Medico medico = new Medico();
                    medico.Nombre = (string)datos.Lector["NombreMedico"];
                    medico.Apellido = (string)datos.Lector["ApellidoMedico"];
                    turno.Medico = medico;

                    Paciente paciente = new Paciente();
                    paciente.Nombre = (string)datos.Lector["NombrePaciente"];
                    paciente.Apellido = (string)datos.Lector["ApellidoPaciente"];
                    turno.Paciente = paciente;

                    turno.Estado = (bool)datos.Lector["Estado"];

                    return turno;
                }

                return null;
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
