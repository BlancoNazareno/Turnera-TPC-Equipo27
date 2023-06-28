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
    public partial class Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoNegocio negocio = new MedicoNegocio();
            dgvMedicos.DataSource = negocio.listar();
            dgvMedicos.RowDataBound += dgvMedicos_RowDataBound;
            dgvMedicos.DataBind();

        }

        private void dgvMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Medico medico = (Medico)e.Row.DataItem;
                Label lblFechaNacimiento = (Label)e.Row.FindControl("lblFechaNacimiento"); // Reemplaza "lblFechaNacimiento" con el ID del control de fecha en tu GridView
                if (medico != null && lblFechaNacimiento != null)
                {
                    DateTime fechaNacimiento = medico.FechaNacimiento;
                    lblFechaNacimiento.Text = fechaNacimiento.ToString("dd/MM/yyyy");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Realizar operaciones adicionales aquí si es necesario
        }

    }
}