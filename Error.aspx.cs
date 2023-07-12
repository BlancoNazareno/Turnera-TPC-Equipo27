using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string parametro = Request.QueryString["parametro"];

                if (parametro == "Especialidades")
                {
                    lblError.Text = "No se puede eliminar, en nuestro staff hay un Medico con esa Especialidad";
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string pagina = Request.QueryString["parametro"];
            Response.Redirect(pagina + ".aspx");
        }
    }
}
