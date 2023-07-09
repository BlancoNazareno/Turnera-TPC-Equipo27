using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Turnera_TPC_Equipo27
{
    public partial class Default : System.Web.UI.Page
    {   //falta implementar un botón para desloguearse
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblErrorLogin.Text = Session["error"].ToString();
            }


            if ((Session["usuario"] != null) && (((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.PACIENTE))
            {
                //ya está logueado como paciente, por lo que redirige a su área correspondiente
                Response.Redirect("HomePacientes.aspx");
            }
            if ((Session["usuario"] != null) && ((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.SUBADMIN)
            {
                //ya está logueado como ADMIN o SUBADMIN, por lo que redirige a su área correspondiente
                Response.Redirect("HomeAdmin.aspx");
            }


        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Paciente paciente;
            PacienteNegocio negocio = new PacienteNegocio();

            try
            {
                paciente = new Paciente(int.Parse(txtDNI.Text), txtContrasenia.Text);
                if (negocio.loguear(paciente) && paciente.TipoUsuario == TipoUsuario.PACIENTE)
                {
                    Session.Add("usuario", paciente);
                    Response.Redirect("HomePacientes.aspx");
                }
                else if (negocio.loguear(paciente) && (paciente.TipoUsuario == TipoUsuario.ADMIN || paciente.TipoUsuario == TipoUsuario.SUBADMIN))
                {
                    Session.Add("usuario", paciente);
                    Response.Redirect("HomeAdmin.aspx");
                }
                else
                {
                    lblErrorLogin.Text = "DNI o contraseña incorrectos";
                }
            }
            catch (Exception ex)
            {
                lblErrorLogin.Text = "Error al iniciar sesión: " + ex.Message;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormNewPaciente.aspx");
        }

    }
}