using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Especialidad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }

        //public float Copago { get; set; }
        //solo si el paciente es Particular, VER SI LO IMPLEMENTAMOS DESPUES

    }
}
