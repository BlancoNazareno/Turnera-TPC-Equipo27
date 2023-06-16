using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    public class Medico : Persona
    {
        public int IdMedico { get; set; }//Id solo no, xq Persona tiene Id
        public DateTime HorarioAtencion { get; set; }
        //gestionar horarios por separado. Clase horarios, tiene dia, hora de entrada y salida por medico, asignar a cada medico una franja horaria
        public Especialidad Especialidad { get; set; }

    }
}
