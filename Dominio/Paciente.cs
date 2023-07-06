using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Dni { get; set; }
        public string Mail { get; set; }
        public string Cobertura { get; set; }
        public bool Estado { get; set; }


    }

}
