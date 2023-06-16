using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento{ get; set; }

        public int Celular { get; set; } 
        public string Direccion{ get; set; }
        public bool Genero{ get; set; }

    }
}
