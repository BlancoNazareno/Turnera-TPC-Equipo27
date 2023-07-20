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

            if (sender is Button)
            {
                Button btnModificar = (Button)sender;

                // Obtener la fila que contiene el botón
                GridViewRow row = (GridViewRow)btnModificar.NamingContainer;

                // Obtener el ID de la fila
                string id = row.Cells[0].Text;

                // Redirigir a otra página pasando el ID como parámetro en la URL
                Response.Redirect("~/FormMedico.aspx?id=" + id);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            Button btnEliminar = (Button)sender;//Obtengo el botón 
            GridViewRow fila = (GridViewRow)btnEliminar.NamingContainer;//Obtengo la fila de ese boton
            int idMedico = Convert.ToInt32(fila.Cells[0].Text);//Obtengo el valor de la celda 0

            MedicoNegocio negocio = new MedicoNegocio();
            negocio.eliminar(idMedico);
            Response.Redirect("Medicos.aspx");



        }

        protected void txtFiltroEspecialidad_TextChanged(object sender, EventArgs e)
        {
            string especialidad = txtFiltroEspecialidad.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            MedicoNegocio negocio = new MedicoNegocio();
            List<Medico> listaCompleta = negocio.listar();

            List<Medico> listaFiltrada = listaCompleta.Where(m => m.Especialidad.Nombre.ToLower().Contains(especialidad.ToLower())).ToList(); 
            dgvMedicos.DataSource = listaFiltrada;
            dgvMedicos.DataBind();
        }

        protected void txtFiltroApellido_TextChanged(object sender, EventArgs e)
        {
            string apellidoBuscado = txtFiltroApellido.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            MedicoNegocio negocio = new MedicoNegocio();
            List<Medico> listaCompleta = negocio.listar();

            List<Medico> listaFiltrada = listaCompleta.Where(p => p.Apellido.ToLower().Contains(apellidoBuscado.ToLower())).ToList();

            dgvMedicos.DataSource = listaFiltrada;
            dgvMedicos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroApellido.Text = string.Empty;
            txtFiltroEspecialidad.Text = string.Empty;

            MedicoNegocio negocio = new MedicoNegocio();
            dgvMedicos.DataSource = negocio.listar();
            dgvMedicos.RowDataBound += dgvMedicos_RowDataBound;
            dgvMedicos.DataBind();
        }
    }
}