using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cobertura
    {
        public int Id{ get; set; }
        public string Nombre{ get; set; }
        public Especialidad Especialidad{ get; set; }
        //q tenga un listado de especialidades es un plus, hacer lo basico primero(manejar los horarios de pacientes/medicos)
        //Por ahora las Coberturas van a trabajar con TODAS las Especialidades
    }
}
