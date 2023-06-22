using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    public class Medico : Persona
    {
        public int IdMedico { get; set; }//Id solo no, xq Persona tiene Id. Entonces tiene el IdPersona(q hereda) y el IdMedico
                                         //public DateTime HorarioAtencion { get; set; }//gestionar horarios por separado. Clase horarios, tiene dia, hora de entrada y salida por medico, asignar a cada medico una franja horaria

        public Horario Horario { get; set; }

        public Especialidad Especialidad { get; set; }

        public Medico() { }

        public Medico(Horario horario, Especialidad especialidad)
        {//Constructor
            //ver id y lo q hereda de Persona
            Horario = horario;
            Especialidad = especialidad;
        }
        // Crear médicos
        //Medico medico1 = new Medico( . . . , horarioMedico1, especialidad);
    }
}


