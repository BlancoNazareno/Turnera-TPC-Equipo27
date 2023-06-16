using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //public class Medico:Persona, Especialidad
    //{
    //    public int Id { get; set; }
    //    public DateTime HorarioAtencion{ get; set; }

    //} //NO ME DEJA HEREDAR DE PERSONA Y DE ESPECIALIDAD, CREO Q NO PUEDE HEREDAR DE 2 CLASES
    public class Medico : Persona
    {
        public int IdMedico { get; set; }//Id solo no, xq Persona tiene Id
        public DateTime HorarioAtencion { get; set; }

        public Especialidad Especialidad { get; set; }

    }
}
