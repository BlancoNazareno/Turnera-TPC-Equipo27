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

            if (Session["usuario"] == null)
            {
                Session.Add("error", "No es posible acceder sin estar logueado");
                Response.Redirect("Default.aspx");
            }

            if ((Session["usuario"] != null) && (((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.PACIENTE))
            {
                Session.Add("error", "No cuenta con los permisos para acceder a este sector");  //no muestra el mensaje, directamente redirecciona
                Response.Redirect("HomePacientes.aspx");
            }

            if (!IsPostBack)
            {
             PacienteNegocio negocio = new PacienteNegocio();
             dgvPacientes.DataSource = negocio.listar();
             dgvPacientes.RowDataBound += dgvPacientes_RowDataBound;
             dgvPacientes.DataBind();
            }
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

            if (sender is Button)
            {
                Button btnModificar = (Button)sender;

                // Obtener la fila que contiene el botón
                GridViewRow row = (GridViewRow)btnModificar.NamingContainer;

                // Obtener el ID de la fila
                string id = row.Cells[0].Text;

                // Redirigir a otra página pasando el ID como parámetro en la URL
                Response.Redirect("~/FormPaciente.aspx?id=" + id);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;//Obtengo el botón 
            GridViewRow fila = (GridViewRow)btnEliminar.NamingContainer;//Obtengo la fila de ese boton
            int idPaciente = Convert.ToInt32(fila.Cells[0].Text);//Obtengo el valor de la celda 0

            PacienteNegocio negocio = new PacienteNegocio();
            negocio.eliminar(idPaciente);
            Response.Redirect("Pacientes.aspx");

            
        }
    }
}