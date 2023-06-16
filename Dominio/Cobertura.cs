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
        public Especialidad Especialidad{ get; set; }//deben ser varias Especialidades que abarca

    }
}
