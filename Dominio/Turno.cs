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

        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaTurno { get; set; }
        public Horario HorarioTurno { get; set; }
        public Cobertura Cobertura { get; set; }
        public string MotivoDeConsulta { get; set; }//podriamos cambiarlo despues, ej: Un paciente consulta con un diagnostico presuntivo, al irse, ya tiene un diagnostico definitivo
        public string Estado{ get; set; }

        public Turno(Medico medico, Paciente paciente, DateTime fechaTurno, Horario horarioTurno, Cobertura cobertura, string motivoDeConsulta, string estado)
        {//Constructor
            Medico = medico;
            Paciente = paciente;
            FechaTurno = fechaTurno;
            HorarioTurno = horarioTurno;
            Cobertura = cobertura;
            MotivoDeConsulta = motivoDeConsulta;
            Estado = estado;
        }
        public Turno() {}//Constructor vacio
    }
}
//Cargar un turno ej
//Turno turno1 = new Turno(medico1, paciente1, new DateTime(2023, 6, 19, 9, 0, 0), horarioTurno1, cobertura, motivo, estado);

