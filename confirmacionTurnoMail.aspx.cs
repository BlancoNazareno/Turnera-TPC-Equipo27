using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class confirmacionTurnoMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                
                int pacienteId = int.Parse(Request.QueryString["id"]);

                MedicoNegocio negocio = new MedicoNegocio();
                TurnoNegocio turnoNegocio = new TurnoNegocio();

                Turno turno = turnoNegocio.obtenerPorId(pacienteId);



                string nombre = turno.Paciente.NombreCompleto;
                litNombre.Text = nombre;

            }
        }
    }
}