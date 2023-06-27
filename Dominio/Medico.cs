﻿using System;
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
        public int Dni { get; set; }
        public string Mail { get; set; }
        public Especialidad Especialidad { get; set; }
        public Horario Horario { get; set; }


        public Medico(Horario horario, Especialidad especialidad)
        {//Constructor
            //ver id y lo q hereda de Persona
            Horario = horario;
            Especialidad = especialidad;
        }

        public Medico() { }

        // Crear médicos
        //Medico medico1 = new Medico( . . . , horarioMedico1, especialidad);
    }
}


