using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public Especialidad Especialidad { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Disponibilidad Disponibilidad { get; set; }
        public bool Estado { get; set; }

    }
}


