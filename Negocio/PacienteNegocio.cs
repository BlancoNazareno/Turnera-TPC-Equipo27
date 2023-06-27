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
                    datos.setearConsulta("Select Nombre from Pacientes");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Paciente aux = new Paciente();
                        //aux.Id = (int)datos.Lector["Id"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        //aux.Copago = (float)datos.Lector["Copago"];

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
