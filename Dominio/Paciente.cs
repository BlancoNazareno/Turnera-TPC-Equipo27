using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        SUBADMIN = 2,
        PACIENTE =  3
    }
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Dni { get; set; }
        public string Mail { get; set; }
        public string Cobertura { get; set; }
        public string Contrasenia { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public bool Estado { get; set; }

        public Paciente(int id, string nombre, string apellido, DateTime fechaNacimiento, long dni, string mail, string cobertura, string contrasenia, TipoUsuario tipoUsuario, bool estado)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Dni = dni;
            Mail = mail;
            Cobertura = cobertura;
            Contrasenia = contrasenia;
            TipoUsuario = TipoUsuario.PACIENTE;
            Estado = true;
        }

        public Paciente(int dni, string contrasenia)
        {
            Dni = dni;
            Contrasenia = contrasenia;
        }

        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

        public Paciente() { }
    }

}
