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
        public bool Estado { get; set; }

    }
}
