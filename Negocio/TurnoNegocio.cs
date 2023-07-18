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
                datos.setearConsulta("SELECT T.IDTurno, T.Fecha, E.Especialidad AS NombreEspecialidad, M.Nombre AS NombreMedico, M.Apellido AS ApellidoMedico, P.Nombre AS NombrePaciente, P.Apellido AS ApellidoPaciente,  T.Estado FROM Turnos T INNER JOIN Especialidades E ON T.IDEspecialidad = E.IDEspecialidad INNER JOIN Medicos M ON T.IDMedico = M.IDMedico INNER JOIN Pacientes P ON T.IDPaciente = P.IDPaciente");
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
                    turno.Medico = medico;

                    Paciente paciente = new Paciente();
                    paciente.Nombre = (string)datos.Lector["NombrePaciente"];
                    paciente.Apellido = (string)datos.Lector["ApellidoPaciente"];
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
