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
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No es posible acceder sin estar logueado");
                Response.Redirect("Default.aspx");
            }

            if ((Session["usuario"] != null) && (((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.SUBADMIN))
            {
                Session.Add("error", "No cuenta con los permisos para acceder a este sector");  //no muestra el mensaje, directamente redirecciona
                Response.Redirect("HomeAdmin.aspx");
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
                if (!IsPostBack)
                {
                    EspecialidadNegocio negocio = new EspecialidadNegocio();
                    List<Especialidad> lista = negocio.listar();
                    ddlEspecialidad.DataSource = lista;
                    ddlEspecialidad.DataValueField = "Id";
                    ddlEspecialidad.DataTextField = "Nombre";
                    ddlEspecialidad.DataBind();
                }
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if(id != "" && !IsPostBack)
                {
                    MedicoNegocio negocio = new MedicoNegocio();
                    List<Medico> listaMedicos = negocio.listar();
                    Medico seleccionado = listaMedicos.Find(m => m.Id.ToString() == id);

                    Session.Add("medicoSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtApellido.Text = seleccionado.Apellido;
                    txtFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtDni.Text = seleccionado.Dni.ToString();
                    txtMail.Text = seleccionado.Mail.ToString();

                    ddlEspecialidad.SelectedValue = seleccionado.Especialidad.Id.ToString();
                }
            }
            catch (Exception )
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
                nuevo.Mail = txtMail.Text;
                if (!nuevo.Mail.Contains("@") || !nuevo.Mail.Contains("."))
                {
                    lblEmailError.Visible = true; // Muestraerror si el email no contiene @ ni .
                    return;
                }
                else
                {
                    lblEmailError.Visible = false;
                }
                nuevo.Especialidad = new Especialidad();
                nuevo.Especialidad.Id = int.Parse(ddlEspecialidad.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                   negocio.agregar(nuevo);
                Response.Redirect("Medicos.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}