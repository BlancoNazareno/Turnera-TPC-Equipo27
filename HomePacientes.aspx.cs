using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class HomePacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No es posible acceder sin estar logueado");
                Response.Redirect("Default.aspx");
            }

            if ((Session["usuario"] != null) &&
                (((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.SUBADMIN ||
                ((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.ADMIN))
            {
                //ya está logueado como ADMIN o SUBADMIN, por lo que redirige a su área correspondiente
                Response.Redirect("HomeAdmin.aspx");
            }
        }
    }
}