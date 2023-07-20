using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disponibilidad
    {

        public int Id { get; set; }
        public Medico Medico { get; set; }
        public int Dia { get; set; }
        public int Hora { get; set; }
        public string Defecto { get; set; }


    }
}
