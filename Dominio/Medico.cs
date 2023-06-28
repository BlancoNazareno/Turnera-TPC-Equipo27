using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Medico 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Dni { get; set; }//cambie a long, xq en la BD es bigint
        public string Mail { get; set; }
        public Especialidad Especialidad { get; set; }
        public Horario Horario { get; set; }

        public Medico(Horario horario, Especialidad especialidad)//Constructor
        {
            Horario = horario;
            Especialidad = especialidad;
        }

        public Medico() {}//Constructor vacio

        // Crear médicos
        //Medico medico1 = new Medico( . . . , horarioMedico1, especialidad);
    }
}


