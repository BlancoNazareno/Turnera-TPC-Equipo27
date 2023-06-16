using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class HistoriaClinica:Turno//que no herede, será un listado filtrado por paciente de los turnos
    {
        public int IdHistoriaClinica { get; set; }

    }
}
