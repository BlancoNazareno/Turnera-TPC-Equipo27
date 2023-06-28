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
    }
}
