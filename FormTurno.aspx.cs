using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class FormTurno : System.Web.UI.Page
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
                Session.Add("error", "No cuenta con los permisos para acceder a este sector");
                Response.Redirect("HomePacientes.aspx");
            }
            else
            {
                ddlMedico.Visible = false;
                lblMedico.Visible = false;
                cldTurno.Visible = false;
                lblCldTurno.Visible = false;
                lblHorarios.Visible = false;
                ddlHorarios.Visible = false;
                txtId.Enabled = false;
                txtId.Visible = false;

                try
                {
                    if (!IsPostBack)
                    {
                        PacienteNegocio negocioPaciente = new PacienteNegocio();
                    List<Paciente> listaPacientes = negocioPaciente.listar();
                    Paciente pacienteSeleccionar = new Paciente { Id = 0, Nombre = "Selecciona un paciente", Apellido = string.Empty };
                    listaPacientes.Insert(0, pacienteSeleccionar);
                    ddlPaciente.DataSource = listaPacientes;
                    ddlPaciente.DataValueField = "Id";
                    ddlPaciente.DataTextField = "NombreCompleto";
                    ddlPaciente.DataBind();

                    EspecialidadNegocio negocioEspecialidad = new EspecialidadNegocio();
                    List<Especialidad> listaEspecialidad = negocioEspecialidad.listar();
                    Especialidad especialidadSeleccionar = new Especialidad { Id = 0, Nombre = "Selecciona una disponibilidad" };
                    listaEspecialidad.Insert(0, especialidadSeleccionar);
                    ddlEspecialidad.DataSource = listaEspecialidad;
                    ddlEspecialidad.DataValueField = "Id";
                    ddlEspecialidad.DataTextField = "Nombre";
                    ddlEspecialidad.DataBind();

                    
                        string id = Request.QueryString.Get("id"); // Obtener el ID del turno correctamente
                        if (!string.IsNullOrEmpty(id))
                        {
                            TurnoNegocio negocioTurno = new TurnoNegocio();
                            Turno turno = negocioTurno.obtenerPorId(Convert.ToInt32(id));

                            if (turno != null)
                            {
                                Session["turnoSeleccionado"] = turno;

                                txtId.Text = turno.Id.ToString();
                                ddlPaciente.SelectedValue = turno.Paciente.NombreCompleto.ToString();
                                ddlEspecialidad.SelectedValue = turno.Especialidad.Nombre.ToString();
                                ddlEspecialidad_SelectedIndexChanged(null, null); // Actualizar los médicos en función de la especialidad seleccionada
                                ddlMedico.SelectedValue = turno.Medico.Nombre.ToString();
                                cldTurno.SelectedDate = turno.Fecha.Date;
                                cldTurno_SelectionChanged(null, null); // Actualizar los horarios disponibles en función de la fecha seleccionada
                                ddlHorarios.SelectedValue = turno.Fecha.ToString("HH:mm");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCldTurno.Visible = true;
            cldTurno.Visible= true;
            lblMedico.Visible = true;
            ddlMedico.Visible = true;

        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMedico.Visible = true;
            ddlMedico.Visible = true;


            int idEspecialidadSeleccionada = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            Medico medicoSeleccionar = new Medico { Id = 0, Nombre = "Selecciona un médico", Apellido = string.Empty };

            MedicoNegocio negocio = new MedicoNegocio();
            List<Medico> listaFiltrada = negocio.listaFiltrada(idEspecialidadSeleccionada);

            listaFiltrada.Insert(0, medicoSeleccionar);

            ddlMedico.DataSource = listaFiltrada;
            ddlMedico.DataValueField = "Id";
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataBind();
        }



        protected void cldTurno_SelectionChanged(object sender, EventArgs e)
        {
            lblCldTurno.Visible = true;
            cldTurno.Visible = true;
            lblMedico.Visible = true;
            ddlMedico.Visible = true;
            ddlHorarios.Visible = true;
            lblHorarios.Visible = true;

            Horario disponibilidadSeleccionar = new Horario { Id = 0, Hora = "Selecciona un horario"};
            HorarioNegocio negocio = new HorarioNegocio();
            List<Horario> listaHorarios = negocio.listar();
            listaHorarios.Insert(0, disponibilidadSeleccionar);
            ddlHorarios.DataSource = listaHorarios;
            ddlHorarios.DataValueField= "Hora";
            ddlHorarios.DataTextField = "Hora";
            ddlHorarios.DataBind();

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {           
            
            Turno nuevo = new Turno();
            TurnoNegocio negocio = new TurnoNegocio();
            Paciente nuevoPaciente = new Paciente();
            PacienteNegocio negocioPaciente = new PacienteNegocio();

            string horarioSeleccionado = ddlHorarios.SelectedValue;
            DateTime fechaSeleccionada = cldTurno.SelectedDate;


            nuevo.Paciente = new Paciente();
            nuevo.Paciente.Id = int.Parse(ddlPaciente.SelectedValue);
            string emailDestino = negocioPaciente.obtenerEmail(int.Parse(ddlPaciente.SelectedValue));
            EmailService emailService = new EmailService();
            emailService.armarCorreo(emailDestino, "Turno Correcto", "Cuerpo");
            try
            {

                nuevo.Especialidad = new Especialidad();
                nuevo.Especialidad.Id = int.Parse(ddlEspecialidad.SelectedValue);

                nuevo.Medico = new Medico();
                nuevo.Medico.Id = int.Parse(ddlMedico.SelectedValue);

                DateTime fechaYHorario = fechaSeleccionada.Date;
                DateTime horario = DateTime.ParseExact(horarioSeleccionado, "HH:mm", CultureInfo.InvariantCulture);
                
                fechaYHorario = fechaYHorario.Add(horario.TimeOfDay);
                Debug.WriteLine(fechaYHorario);

                nuevo.Fecha = fechaYHorario;

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                    emailService.enviarEmail();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCldTurno.Visible = true;
            cldTurno.Visible = true;
            lblMedico.Visible = true;
            ddlMedico.Visible = true;
            ddlHorarios.Visible = true;
            lblHorarios.Visible = true;
        }

        protected void cldTurno_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            lblCldTurno.Visible = true;
            cldTurno.Visible = true;
            lblMedico.Visible = true;
            ddlMedico.Visible = true;
            ddlHorarios.Visible = true;
            lblHorarios.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx");
        }
    }
}