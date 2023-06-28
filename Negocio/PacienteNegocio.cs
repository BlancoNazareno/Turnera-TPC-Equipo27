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
                    datos.setearConsulta("Select P.IDPaciente, P.Apellido, P.Nombre, P.Cobertura, P.DNI, P.FechaNacimiento, P.Mail From Pacientes P");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Paciente aux = new Paciente();
                        aux.Id = (int)datos.Lector["IDPaciente"];
                        aux.Apellido = (string)datos.Lector["Apellido"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Cobertura= (string)datos.Lector["Cobertura"];
                        aux.Dni = (long)datos.Lector["DNI"];
                        aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                     aux.Mail = (string)datos.Lector["Mail"];
                        

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

    }
}
