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
        public int IdMedico { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        public int DiaSemana { get; set; }

        public Horario(int idMedico, DateTime horaInicio, DateTime horaFin, int diaSemana)//Constructor
        {
            IdMedico = idMedico;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            DiaSemana = diaSemana;
        }

        public Horario() { }
    }
}
// Crear horario, ejemplo aca atiende el medico de 8 a 12hs el 19/6/23
//Horario horarioMedico1 = new Horario(new DateTime(2023, 6, 19, 8, 0, 0),
//                                     new DateTime(2023, 6, 19, 12, 0, 0));






