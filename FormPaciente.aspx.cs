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

                    Session.Add("pacienteSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtDni.Text = seleccionado.Dni.ToString();
                    txtMail.Text = seleccionado.Mail.ToString();
                    txtCobertura.Text = seleccionado.Cobertura.ToString();

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
                if (nuevo.FechaNacimiento > DateTime.Today)
                {
                    lblFechaNacimientoError.Visible = true; // Muestra el de error si la fecha de nacimiento es mayor a la fecha actual
                    return;
                }
                else
                {
                    lblFechaNacimientoError.Visible = false;
                }
                nuevo.Dni = int.Parse(txtDni.Text);
                if (nuevo.Dni < 0 || nuevo.Dni > 99999999){
                    lblDniError.Visible = true;//Muestra error si el dni es invalido
                    return;
                }
                else{
                    lblDniError.Visible = false;
                }
                nuevo.Cobertura = txtCobertura.Text;
                nuevo.Mail = txtMail.Text;
                if (!nuevo.Mail.Contains("@") || !nuevo.Mail.Contains(".")) { 
                    lblEmailError.Visible = true; // Muestraerror si el email no contiene @ ni .
                    return;
                }
                else
                {
                    lblEmailError.Visible = false;
                }

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarAdmin(nuevo); //no incluye la contraseña, ya que sólo el paciente la puede cambiar
                    Response.Redirect("Pacientes.aspx", false);
                }
                else
                {
                    nuevo.Contrasenia = txtDni.Text;    //sólo si el paciente está siendo dado de alta por el admin, settea el DNI como contraseña default, si es una modificación 
                    negocio.agregar(nuevo);             //de los datos del paciente, la contraseña sólo puede modificarse estando logueado como el paciente en cuestión.
                    Response.Redirect("Pacientes.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);
        }


    }
}