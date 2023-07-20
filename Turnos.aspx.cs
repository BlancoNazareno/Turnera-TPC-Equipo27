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
    public partial class TurnosAdmin : System.Web.UI.Page
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

            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnosAdmin.DataSource = negocio.listar();
            dgvTurnosAdmin.RowDataBound += dgvTurnosAdmin_RowDataBound;     //Empleado por el cambio en el muestro del dato Estado (si es True [SQL] muestra Activo [HTML])
            dgvTurnosAdmin.DataBind();
        }

        protected void dgvTurnosAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)e.Row.FindControl("lblEstado");
                if (lblEstado != null)
                {
                    bool estado = (bool)DataBinder.Eval(e.Row.DataItem, "Estado");
                    lblEstado.Text = estado ? "Activo" : "Cancelado";
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
                Response.Redirect("~/FormTurno.aspx?id=" + id);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;//Obtengo el botón 
            GridViewRow fila = (GridViewRow)btnEliminar.NamingContainer;//Obtengo la fila de ese boton
            int idTurno = Convert.ToInt32(fila.Cells[0].Text);//Obtengo el valor de la celda 0

            TurnoNegocio negocio = new TurnoNegocio();
            negocio.eliminarLogico(idTurno);
            Response.Redirect("Turnos.aspx");
        }


        protected void btnBono_Click(object sender, EventArgs e)
        {
            Button btnBono = (Button)sender;

            // Obtener la fila que contiene el botón
            GridViewRow row = (GridViewRow)btnBono.NamingContainer;

            // Obtener el ID de la fila
            string id = row.Cells[0].Text;

            // Redirigir a otra página pasando el ID como parámetro en la URL
            Response.Redirect("BonoConsulta.aspx?id=" + id);
        }

        protected void txtFiltroApellido_TextChanged(object sender, EventArgs e)
        {
            string apellidoBuscado = txtFiltroApellido.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaCompleta = negocio.listar();

            List<Turno> listaFiltrada = listaCompleta.Where(p => p.Paciente.Apellido.ToLower().Contains(apellidoBuscado.ToLower())).ToList();

            dgvTurnosAdmin.DataSource = listaFiltrada;
            dgvTurnosAdmin.DataBind();

        }

        protected void txtFiltroApellidoMedico_TextChanged(object sender, EventArgs e)
        {
            string apellidoBuscado = txtFiltroApellidoMedico.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaCompleta = negocio.listar();

            List<Turno> listaFiltrada = listaCompleta.Where(p => p.Medico.Apellido.ToLower().Contains(apellidoBuscado.ToLower())).ToList();

            dgvTurnosAdmin.DataSource = listaFiltrada;
            dgvTurnosAdmin.DataBind();
        }

        protected void txtFiltroCobertura_TextChanged(object sender, EventArgs e)
        {
            string cobertura = txtFiltroCobertura.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaCompleta = negocio.listar();

            List<Turno> listaFiltrada = listaCompleta.Where(p => p.Paciente.Cobertura.ToLower().Contains(cobertura.ToLower())).ToList();

            dgvTurnosAdmin.DataSource = listaFiltrada;
            dgvTurnosAdmin.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltroApellido.Text = string.Empty;
            txtFiltroApellidoMedico.Text = string.Empty;
            txtFiltroCobertura.Text = string.Empty;
            txtFiltroEspecialidad.Text = string.Empty;

            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnosAdmin.DataSource = negocio.listar();
            dgvTurnosAdmin.RowDataBound += dgvTurnosAdmin_RowDataBound;
            dgvTurnosAdmin.DataBind();
        }

        protected void btnActivos_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaCompleta = negocio.listar();

            List<Turno> listaFiltrada = listaCompleta.Where(p => p.Estado).ToList();

            dgvTurnosAdmin.DataSource = listaFiltrada;
            dgvTurnosAdmin.DataBind();
        }

        protected void btnFinalizados_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaCompleta = negocio.listar();

            List<Turno> listaFiltrada = listaCompleta.Where(p => !p.Estado).ToList();

            dgvTurnosAdmin.DataSource = listaFiltrada;
            dgvTurnosAdmin.DataBind();
        }

        protected void txtFiltroEspecialidad_TextChanged(object sender, EventArgs e)
        {
            string especialidad = txtFiltroEspecialidad.Text.Trim(); // Obtener el valor del campo de búsqueda y elimino espacios en blanco

            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaCompleta = negocio.listar();

            List<Turno> listaFiltrada = listaCompleta.Where(p => p.Especialidad.Nombre.ToLower().Contains(especialidad.ToLower())).ToList();

            dgvTurnosAdmin.DataSource = listaFiltrada;
            dgvTurnosAdmin.DataBind();
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            txtFiltroApellido.Text = string.Empty;
            txtFiltroApellidoMedico.Text = string.Empty;
            txtFiltroCobertura.Text = string.Empty;
            txtFiltroEspecialidad.Text = string.Empty;

            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnosAdmin.DataSource = negocio.listar();
            dgvTurnosAdmin.RowDataBound += dgvTurnosAdmin_RowDataBound;
            dgvTurnosAdmin.DataBind();
        }
    }
}