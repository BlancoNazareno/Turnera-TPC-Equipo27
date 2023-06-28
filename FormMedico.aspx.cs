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
    public partial class FormMedicoPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtId.Visible = false;
            try
            {
                if (!IsPostBack)
                {
                    EspecialidadNegocio negocio = new EspecialidadNegocio();
                    List<Especialidad> lista = negocio.listar();
                    ddlEspecialidad.DataSource = lista;
                    ddlEspecialidad.DataValueField = "Id";
                    ddlEspecialidad.DataTextField = "Nombre";
                    ddlEspecialidad.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Medico nuevo = new Medico(); 
                MedicoNegocio negocio = new MedicoNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                nuevo.Dni = int.Parse(txtDni.Text);
                nuevo.Mail = txtMail.Text;

                nuevo.Especialidad = new Especialidad();
                nuevo.Especialidad.Id = int.Parse(ddlEspecialidad.SelectedValue);

                negocio.agregar(nuevo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}