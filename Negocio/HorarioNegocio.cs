using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class HorarioNegocio
    {
        public List<Horario> listar()
        {
            List<Horario> lista = new List<Horario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("Select H.IDHorario, H.Hora from Horario H");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horario aux = new Horario();
                    aux.Id = (int)datos.Lector["IDHorario"];
                    aux.Hora = (int)datos.Lector["Hora"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception)
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

