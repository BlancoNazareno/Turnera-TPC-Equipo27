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
    public partial class Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.listar();
            dgvPacientes.RowDataBound += dgvPacientes_RowDataBound;
            dgvPacientes.DataBind();
        }

        private void dgvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Paciente paciente = (Paciente)e.Row.DataItem;
                Label lblFechaNacimiento = (Label)e.Row.FindControl("lblFechaNacimiento"); // Reemplaza "lblFechaNacimiento" con el ID del control de fecha en tu GridView
                if (paciente != null && lblFechaNacimiento != null)
                {
                    DateTime fechaNacimiento = paciente.FechaNacimiento;
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