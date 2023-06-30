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

        protected void  btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string id = btnEliminar.CommandArgument;
            int a = int.Parse(id);

            MedicoNegocio negocio = new MedicoNegocio();
            bool existe = negocio.existeEspecialidadEnListaMedicos(a);

            if (existe)
            {
                EspecialidadNegocio eNegocio = new EspecialidadNegocio();
                eNegocio.eliminar(a);
                Response.Redirect("Especialidades.aspx");
            }
            else
            {
                string mensaje = "No se puede eliminar, esa Especialidad esta siendo usada por un Medico";
                string script = "alert('" + mensaje + "');";

                ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessage", script, true);
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