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
    public partial class FormPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtId.Visible = false;

            try
            {
                
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PacienteNegocio negocio = new PacienteNegocio();
                    List<Paciente> listaPacientes = negocio.listar();
                    Paciente seleccionado = listaPacientes.Find(m => m.Id.ToString() == id);

                    Session.Add("medicoSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("dd/MM/yyyy");
                    txtDni.Text = seleccionado.Dni.ToString();
                    txtMail.Text = seleccionado.Mail.ToString();
                    txtVar.Text = seleccionado.Cobertura.ToString();
                   
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
                    Paciente nuevo = new Paciente();
                    PacienteNegocio negocio = new PacienteNegocio();

                    nuevo.Nombre = txtNombre.Text;
                    nuevo.Apellido = txtApellido.Text;
                    nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                    nuevo.Dni = int.Parse(txtDni.Text);
                    nuevo.Mail = txtMail.Text;
                    nuevo.Cobertura = txtVar.Text;

                    if (Request.QueryString["Id"] != null)
                    {
                        nuevo.Id = int.Parse(txtId.Text);
                        negocio.modificar(nuevo);
                    }
                    else
                        negocio.agregar(nuevo);
                        Response.Redirect("Pacientes.aspx", false);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        
    }
}