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
    public partial class Formulario_web1 : System.Web.UI.Page
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
             EspecialidadNegocio negocio = new EspecialidadNegocio();
             dgvEspecialidades.DataSource = negocio.listar();
             dgvEspecialidades.DataBind();
             RegisterPostBackControls();
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;
            string id = btnAgregar.CommandArgument;
            // Redirigir a FormEspecialidad.aspx con ID 0
            Response.Redirect("FormEspecialidad.aspx?ID=" + id);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la fila seleccionada
            Button btnModificar = (Button)sender;
            string id = btnModificar.CommandArgument;

            // Redirigir a FormEspecialidad.aspx con el ID correspondiente
            Response.Redirect("FormEspecialidad.aspx?ID=" + id);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string id = btnEliminar.CommandArgument;
            int a = int.Parse(id);

            MedicoNegocio negocio = new MedicoNegocio();
            bool existeMedico = negocio.existeMedicoConEsaEspecialidad(a);//Si existe un Medico que este trabajando con esa Especialidad devuelve true

            //Ver esto! Esta alreves, no se xq, tengo q invertir la funcion (!existeMedico) <- DEBERIA ESTAR SIN EL SIGNO DE EXCLAMACION, sino me ELIMINA AUNQUE EXISTA EL MEDICO CON ESA ESPECIALIDAD
            if (!existeMedico)
            {
                Response.Redirect("Error.aspx?parametro=Especialidades");
            }
            else
            {
                EspecialidadNegocio eNegocio = new EspecialidadNegocio();
                eNegocio.eliminar(a);
                Response.Redirect("Especialidades.aspx");
            }
        }

        protected void dgvEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                // Redirige a la página FormEspecialidad.aspx pasando el ID como parámetro
                Response.Redirect("~/FormEspecialidad.aspx?ID=" + id);
            }
        }

        private void RegisterPostBackControls()
        {
            foreach (GridViewRow row in dgvEspecialidades.Rows)
            {
                Button btnModificar = (Button)row.FindControl("btnModificar");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnModificar);
            }
        }

    }
}