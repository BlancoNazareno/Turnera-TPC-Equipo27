using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Horario
    {
        public DateTime Hora { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public Horario(DateTime horaInicio, DateTime horaFin)//Constructor
        {
            HoraInicio = horaInicio;
            HoraFin = horaFin;
        }

        public Horario() { }
    }
}
// Crear horario, ejemplo aca atiende el medico de 8 a 12hs el 19/6/23
//Horario horarioMedico1 = new Horario(new DateTime(2023, 6, 19, 8, 0, 0),
//                                     new DateTime(2023, 6, 19, 12, 0, 0));






