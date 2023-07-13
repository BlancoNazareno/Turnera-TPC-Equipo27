using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PacienteNegocio
    {

        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select P.IDPaciente, P.Apellido, P.Nombre, P.DNI, P.FechaNacimiento, P.Cobertura, P.Mail, P.Contrasenia From Pacientes P");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)datos.Lector["IDPaciente"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Dni = (int)datos.Lector["DNI"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    string fechaNacimiento = aux.FechaNacimiento.ToString("dd/MM/yyyy");
                    aux.Cobertura = (string)datos.Lector["Cobertura"];
                    aux.Mail = (string)datos.Lector["Mail"];
                    aux.Contrasenia = (string)datos.Lector["Contrasenia"];


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

        public void eliminar(int id)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("Delete From Pacientes Where IDPaciente = @Id");
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

        public void agregar(Paciente nuevoPaciente)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("insert into Pacientes (Nombre, Apellido, FechaNacimiento, DNI, Cobertura, Mail, Contrasenia, Estado, TipoUsuario) values (@Nombre, @Apellido, @FechaNacimiento, @DNI, @Cobertura, @Mail, @Contrasenia, 1, 3)");
                acceso.setearParametro("@Nombre", nuevoPaciente.Nombre);
                acceso.setearParametro("@Apellido", nuevoPaciente.Apellido);
                acceso.setearParametro("@FechaNacimiento", nuevoPaciente.FechaNacimiento);
                acceso.setearParametro("@DNI", nuevoPaciente.Dni);
                acceso.setearParametro("@Cobertura", nuevoPaciente.Cobertura);
                acceso.setearParametro("@Mail", nuevoPaciente.Mail);
                acceso.setearParametro("@Contrasenia", nuevoPaciente.Contrasenia);

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

        public void modificarAdmin(Paciente nuevoPaciente)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("update Pacientes set Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, DNI = @DNI, Mail = @Mail, Cobertura = @Cobertura Where IDPaciente = @id");
                acceso.setearParametro("@Nombre", nuevoPaciente.Nombre);
                acceso.setearParametro("@Apellido", nuevoPaciente.Apellido);
                acceso.setearParametro("@FechaNacimiento", nuevoPaciente.FechaNacimiento);
                acceso.setearParametro("@DNI", nuevoPaciente.Dni);
                acceso.setearParametro("@Mail", nuevoPaciente.Mail);
                acceso.setearParametro("@Cobertura", nuevoPaciente.Cobertura);
                acceso.setearParametro("@id", nuevoPaciente.Id);

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

        public void modificar(Paciente nuevoPaciente)
        {
            AccesoDatos acceso = new AccesoDatos();
            try
            {
                acceso.setearConsulta("update Pacientes set Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, DNI = @DNI, Cobertura = @Cobertura, Mail = @Mail, Contrasenia = @Contrasenia Where IDPaciente = @id");
                acceso.setearParametro("@Nombre", nuevoPaciente.Nombre);
                acceso.setearParametro("@Apellido", nuevoPaciente.Apellido);
                acceso.setearParametro("@FechaNacimiento", nuevoPaciente.FechaNacimiento);
                acceso.setearParametro("@DNI", nuevoPaciente.Dni);                
                acceso.setearParametro("@Cobertura", nuevoPaciente.Cobertura);
                acceso.setearParametro("@Mail", nuevoPaciente.Mail);
                acceso.setearParametro("@Contrasenia", nuevoPaciente.Contrasenia);
                acceso.setearParametro("@id", nuevoPaciente.Id);

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

        public bool loguear(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select IDPaciente, TipoUsuario from Pacientes where DNI = @DNI and Contrasenia = @contrasenia");
                datos.setearParametro("@DNI", paciente.Dni);
                datos.setearParametro("@contrasenia", paciente.Contrasenia);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    paciente.Id = (int)datos.Lector["IDPaciente"];

                    if ((int)(datos.Lector["TipoUsuario"]) == 1)
                    {
                        paciente.TipoUsuario = TipoUsuario.ADMIN;
                    }
                    else if ((int)(datos.Lector["TipoUsuario"]) == 2)
                    {
                        paciente.TipoUsuario = TipoUsuario.SUBADMIN;
                    }
                    else if ((int)(datos.Lector["TipoUsuario"]) == 3)
                    {
                        paciente.TipoUsuario = TipoUsuario.PACIENTE;
                    }

                    return true;
                }

                return false;
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

        public bool ExisteDni(int dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Pacientes WHERE DNI = @Dni");
                datos.setearParametro("@Dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }

                return false;
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
