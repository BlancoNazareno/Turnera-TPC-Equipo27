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
    public partial class FormNewPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usuario"] == null)
            //{
            //    Session.Add("error", "No es posible acceder sin estar logueado");         //Sí puede, porque justamente se está registrando por primera vez
            //    Response.Redirect("Default.aspx");
            //}

            if ((Session["usuario"] != null) &&
                (((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.SUBADMIN ||
                ((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.ADMIN))
            {
                //ya está logueado como ADMIN o SUBADMIN, por lo que redirige a su área correspondiente
                Response.Redirect("HomeAdmin.aspx");
            }


            //protected void btnAceptar_Click(object sender, EventArgs e)
            //{
            //try
            //{
            //PacienteNegocio negocio = new PacienteNegocio();              //es complicada la implementación, porque tiene que dicernir si el DNI repetido es porque se está modificando 
            //el paciente, o porque erróneamente se está tratando de dar de alta un DNI ya registrado

            //// Verifica si el DNI ya existe en la base de datos
            //int dni = int.Parse(txtDni.Text);
            //if (negocio.ExisteDni(dni))
            //{
            //    Session.Add("error", "El DNI ingresado ya existe en la base de datos, revise los datos e intente nuevamente");
            //    Response.Redirect("Default.aspx");
            //    return; // Salir del evento para evitar que se agregue el paciente duplicado
            //}

            //    Paciente nuevo = new Paciente();

            //    nuevo.Nombre = txtNombre.Text;
            //    nuevo.Apellido = txtApellido.Text;
            //    nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
            //    nuevo.Dni = int.Parse(txtDni.Text);
            //    nuevo.Mail = txtMail.Text;
            //    nuevo.Cobertura = txtVar.Text;


            //    negocio.agregar(nuevo);

            //    Response.Redirect("Default.aspx", false);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}



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
                    txtCelular.Text = seleccionado.Celular;
                    txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtDni.Text = seleccionado.Dni.ToString();
                    txtCobertura.Text = seleccionado.Cobertura.ToString();
                    txtMail.Text = seleccionado.Mail.ToString();
                    txtContrasenia.Text = seleccionado.Contrasenia.ToString();

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
                nuevo.Celular = txtCelular.Text;
                nuevo.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                nuevo.Dni = int.Parse(txtDni.Text);
                nuevo.Cobertura = txtCobertura.Text;
                nuevo.Mail = txtMail.Text;
                nuevo.Contrasenia = txtContrasenia.Text;


                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                    Response.Redirect("HomePacientes.aspx", false);
                }
                else
                {
                    negocio.agregar(nuevo);
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePacientes.aspx", false);
        }
    }
}
