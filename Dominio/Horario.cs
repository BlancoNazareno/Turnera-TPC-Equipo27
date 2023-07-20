using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Horario
    {
        public int Id { get; set; }

        public int Hora { get; set; }

        public string Defecto { get; set; }
        public Horario(string def = "Seleccione un Horario") { Defecto = def; }
    }
}
