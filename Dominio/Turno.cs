using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {//agregar observacion/motivo de consulta, diagnostico
        public int Id { get; set; }

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaTurno { get; set; }
        public Cobertura Cobertura { get; set; }
        //public bool Cancelado { get; set; }

    }
}
