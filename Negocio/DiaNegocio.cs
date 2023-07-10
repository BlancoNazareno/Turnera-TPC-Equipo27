using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DiaNegocio
    {
        public List<Dia> listar()
        {
            List<Dia> lista = new List<Dia>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("Select D.IDDia, D.Dia, D.NombreDia from Dia D");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dia aux = new Dia();
                    aux.Id = (int)datos.Lector["IDDia"];
                    aux.NumeroDia = (int)datos.Lector["Dia"];
                    aux.NombreDia = (string)datos.Lector["NombreDia"];
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