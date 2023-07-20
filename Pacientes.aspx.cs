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
            if (sender is Button)
            {
                Button btnModificar = (Button)sender;
                GridViewRow row = (GridViewRow)btnModificar.NamingContainer;
                string id = row.Cells[0].Text;
                Response.Redirect("~/FormPaciente.aspx?id=" + id);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;//Obtengo el botón 
            GridViewRow fila = (GridViewRow)btnEliminar.NamingContainer;//Obtengo la fila de ese boton
            int idPaciente = Convert.ToInt32(fila.Cells[0].Text);//Obtengo el valor de la celda 0

            PacienteNegocio negocio = new PacienteNegocio();
            negocio.eliminarLogico(idPaciente);
            Response.Redirect("Pacientes.aspx");


        }

        protected void btnComunicarse_Click(object sender, EventArgs e)
        {
            Button btnComunicarse = (Button)sender;
            GridViewRow row = (GridViewRow)btnComunicarse.NamingContainer;
            Label lblCelular = (Label)row.FindControl("lblCelular");

            string numeroCelularPaciente = lblCelular.Text;
            string mensajePredeterminado = "Hola! Nos comunicamos desde Space Medicine";

            //Codifica el mensaje para que sea válido en la URL
            string mensajeCodificado = Uri.EscapeDataString(mensajePredeterminado);

            // Generar la URL de WhatsApp
            string enlaceWhatsapp = $"https://api.whatsapp.com/send?phone={numeroCelularPaciente}&text={mensajeCodificado}";

            //Abre WhatsApp en una nueva pestaña
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", $"window.open('{enlaceWhatsapp}', '_blank');", true);
        }
        protected void txtFiltroApellido_TextChanged(object sender, EventArgs e)
        {
            string apellidoBuscado = txtFiltroApellido.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco
           
            PacienteNegocio negocio = new PacienteNegocio();
            List<Paciente> listaCompleta = negocio.listar();

            List<Paciente> listaFiltrada = listaCompleta.Where(p => p.Apellido.ToLower().Contains(apellidoBuscado.ToLower())).ToList();

            dgvPacientes.DataSource = listaFiltrada;
            dgvPacientes.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroApellido.Text = string.Empty;
            txtFiltroCobertura.Text = string.Empty;

            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.listar();
            dgvPacientes.RowDataBound += dgvPacientes_RowDataBound;
            dgvPacientes.DataBind();
        }

        protected void txtFiltroCobertura_TextChanged(object sender, EventArgs e)
        {
            string cobertura = txtFiltroCobertura.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            PacienteNegocio negocio = new PacienteNegocio();
            List<Paciente> listaCompleta = negocio.listar();

            List<Paciente> listaFiltrada = listaCompleta.Where(p => p.Cobertura.ToLower().Contains(cobertura.ToLower())).ToList();

            dgvPacientes.DataSource = listaFiltrada;
            dgvPacientes.DataBind();
        }

    }
}