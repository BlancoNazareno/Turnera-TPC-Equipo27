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

        public List<Turno> listar(string id = "")
        {
            List<Turno> lista = new List<Turno>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                //conexion.ConnectionString = ConfigurationManager.AppSettings["cadenaConexion"];
                comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad ";
                //if (id != "")
                //    comando.CommandText += " and P.Id = " + id;

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)lector["Id"];
                    aux.Cancelado = bool.Parse(lector["Cancelado"].ToString());
                  
                    aux.Medico = new Medico();
                    aux.Medico.Apellido= (string)lector["ApellidoMedico"];
                    aux.Medico.Nombre= (string)lector["NombreMedico"];

                    aux.Paciente = new Paciente();
                    aux.Paciente.Apellido = (string)lector["ApellidoPaciente"];
                    aux.Paciente.Nombre = (string)lector["NombrePaciente"];
                    
                    aux.Cobertura = new Cobertura();
                    aux.Cobertura.Nombre = (string)lector["CoberturaPaciente"];

                    aux.Cancelado = bool.Parse(lector["Activo"].ToString());
               
                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    //    public List<Pokemon> listarConSP()
    //    {
    //        List<Pokemon> lista = new List<Pokemon>();
    //        AccesoDatos datos = new AccesoDatos();
    //        try
    //        {
    //            //string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1";
    //            //datos.setearConsulta(consulta);
    //            datos.setearProcedimiento("storedListar");

    //            datos.ejecutarLectura();
    //            while (datos.Lector.Read())
    //            {
    //                Pokemon aux = new Pokemon();
    //                aux.Id = (int)datos.Lector["Id"];
    //                aux.Numero = datos.Lector.GetInt32(0);
    //                aux.Nombre = (string)datos.Lector["Nombre"];
    //                aux.Descripcion = (string)datos.Lector["Descripcion"];
    //                if (!(datos.Lector["UrlImagen"] is DBNull))
    //                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];

    //                aux.Tipo = new Elemento();
    //                aux.Tipo.Id = (int)datos.Lector["IdTipo"];
    //                aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
    //                aux.Debilidad = new Elemento();
    //                aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
    //                aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

    //                aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

    //                lista.Add(aux);
    //            }

    //            return lista;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public void agregar(Pokemon nuevo)
    //    {
    //        AccesoDatos datos = new AccesoDatos();

    //        try
    //        {
    //            datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @urlImagen)");
    //            datos.setearParametro("@idTipo", nuevo.Tipo.Id);
    //            datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
    //            datos.setearParametro("@urlImagen", nuevo.UrlImagen);
    //            datos.ejecutarAccion();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            datos.cerrarConexion();
    //        }
    //    }

    //    public void agregarConSP(Pokemon nuevo)
    //    {
    //        AccesoDatos datos = new AccesoDatos();

    //        try
    //        {
    //            datos.setearProcedimiento("storedAltaPokemon");
    //            datos.setearParametro("@numero", nuevo.Numero);
    //            datos.setearParametro("@nombre", nuevo.Nombre);
    //            datos.setearParametro("@desc", nuevo.Descripcion);
    //            datos.setearParametro("@img", nuevo.UrlImagen);
    //            datos.setearParametro("@idTipo", nuevo.Tipo.Id);
    //            datos.setearParametro("@idDebilidad", nuevo.Debilidad.Id);
    //            //datos.setearParametro("@idEvolucion", null);
    //            datos.ejecutarAccion();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            datos.cerrarConexion();
    //        }
    //    }

    //    public void modificar(Pokemon poke)
    //    {
    //        AccesoDatos datos = new AccesoDatos();
    //        try
    //        {
    //            datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where Id = @id");
    //            datos.setearParametro("@numero", poke.Numero);
    //            datos.setearParametro("@nombre", poke.Nombre);
    //            datos.setearParametro("@desc", poke.Descripcion);
    //            datos.setearParametro("@img", poke.UrlImagen);
    //            datos.setearParametro("@idTipo", poke.Tipo.Id);
    //            datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
    //            datos.setearParametro("@id", poke.Id);

    //            datos.ejecutarAccion();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            datos.cerrarConexion();
    //        }
    //    }

    //    public void modificarConSP(Pokemon poke)
    //    {
    //        AccesoDatos datos = new AccesoDatos();
    //        try
    //        {
    //            datos.setearProcedimiento("storedModificarPokemon");
    //            datos.setearParametro("@numero", poke.Numero);
    //            datos.setearParametro("@nombre", poke.Nombre);
    //            datos.setearParametro("@desc", poke.Descripcion);
    //            datos.setearParametro("@img", poke.UrlImagen);
    //            datos.setearParametro("@idTipo", poke.Tipo.Id);
    //            datos.setearParametro("@idDebilidad", poke.Debilidad.Id);
    //            datos.setearParametro("@id", poke.Id);

    //            datos.ejecutarAccion();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //        finally
    //        {
    //            datos.cerrarConexion();
    //        }
    //    }

    //    public List<Pokemon> filtrar(string campo, string criterio, string filtro, string estado)
    //    {
    //        List<Pokemon> lista = new List<Pokemon>();
    //        AccesoDatos datos = new AccesoDatos();
    //        try
    //        {
    //            string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And ";
    //            if (campo == "Número")
    //            {
    //                switch (criterio)
    //                {
    //                    case "Mayor a":
    //                        consulta += "Numero > " + filtro;
    //                        break;
    //                    case "Menor a":
    //                        consulta += "Numero < " + filtro;
    //                        break;
    //                    default:
    //                        consulta += "Numero = " + filtro;
    //                        break;
    //                }
    //            }
    //            else if (campo == "Nombre")
    //            {
    //                switch (criterio)
    //                {
    //                    case "Comienza con":
    //                        consulta += "Nombre like '" + filtro + "%' ";
    //                        break;
    //                    case "Termina con":
    //                        consulta += "Nombre like '%" + filtro + "'";
    //                        break;
    //                    default:
    //                        consulta += "Nombre like '%" + filtro + "%'";
    //                        break;
    //                }
    //            }
    //            else
    //            {
    //                switch (criterio)
    //                {
    //                    case "Comienza con":
    //                        consulta += "E.Descripcion like '" + filtro + "%' ";
    //                        break;
    //                    case "Termina con":
    //                        consulta += "E.Descripcion like '%" + filtro + "'";
    //                        break;
    //                    default:
    //                        consulta += "E.Descripcion like '%" + filtro + "%'";
    //                        break;
    //                }
    //            }

    //            if (estado == "Activo")
    //                consulta += " and P.Activo = 1";
    //            else if (estado == "Inactivo")
    //                consulta += " and P.Activo = 0";

    //            datos.setearConsulta(consulta);
    //            datos.ejecutarLectura();
    //            while (datos.Lector.Read())
    //            {
    //                Pokemon aux = new Pokemon();
    //                aux.Id = (int)datos.Lector["Id"];
    //                aux.Numero = datos.Lector.GetInt32(0);
    //                aux.Nombre = (string)datos.Lector["Nombre"];
    //                aux.Descripcion = (string)datos.Lector["Descripcion"];
    //                if (!(datos.Lector["UrlImagen"] is DBNull))
    //                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];

    //                aux.Tipo = new Elemento();
    //                aux.Tipo.Id = (int)datos.Lector["IdTipo"];
    //                aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
    //                aux.Debilidad = new Elemento();
    //                aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
    //                aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

    //                aux.Activo = bool.Parse(datos.Lector["Activo"].ToString());

    //                lista.Add(aux);
    //            }

    //            return lista;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public void eliminar(int id)
    //    {
    //        try
    //        {
    //            AccesoDatos datos = new AccesoDatos();
    //            datos.setearConsulta("delete from pokemons where id = @id");
    //            datos.setearParametro("@id", id);
    //            datos.ejecutarAccion();

    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }

    //    public void eliminarLogico(int id, bool activo = false)
    //    {
    //        try
    //        {
    //            AccesoDatos datos = new AccesoDatos();
    //            datos.setearConsulta("update POKEMONS set Activo = @activo Where id = @id");
    //            datos.setearParametro("@id", id);
    //            datos.setearParametro("@activo", activo);
    //            datos.ejecutarAccion();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }


    //}









}
}
