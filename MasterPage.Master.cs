using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Default.aspx");
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                int idUsuario = ((Paciente)Session["usuario"]).Id;
                Response.Redirect("FormNewPaciente.aspx?id=" + idUsuario);
            }
        }
    }
}