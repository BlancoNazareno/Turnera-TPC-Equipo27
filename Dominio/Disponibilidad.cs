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
        public int IdMedico { get; set; }
        public int Dia { get; set; }
        public DateTime Hora { get; set; }


    }
}
