using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            dgvEspecialidades.DataSource = negocio.listar();
            dgvEspecialidades.DataBind();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}