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
    public partial class BonoConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"];
                
                PacienteNegocio negocio = new PacienteNegocio();
                List<Paciente> listaPacientes = negocio.listar();
                Paciente seleccionado = listaPacientes.Find(m => m.Id.ToString() == id);

                if (seleccionado != null)
                {
                    lblNombreCompleto.Text = seleccionado.Nombre + " " + seleccionado.Apellido; 
                    lblFechaNacimiento.Text = seleccionado.FechaNacimiento.ToString("dd/MM/yyyy");
                    lblCelular.Text = seleccionado.Celular;
                    lblDNI.Text = seleccionado.Dni.ToString();
                    //lblEspecialidad.Text = seleccionado.Especialidad; agregar cuando linkee el turno
                    lblCobertura.Text = seleccionado.Cobertura;


                    

                }
            }
        }

    }
}