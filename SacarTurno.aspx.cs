using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using System.IO;

namespace Turnera_TPC_Equipo27
{
    public partial class Turnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No es posible acceder sin estar logueado");
                Response.Redirect("Default.aspx");
            }

            ddlMedico.Visible = false;
            lblMedico.Visible = false;
            cldTurno.Visible = false;
            lblCldTurno.Visible = false;
            lblHorarios.Visible = false;
            ddlHorarios.Visible = false;

            if (!IsPostBack)
            {
                PacienteNegocio negocioPaciente = new PacienteNegocio();
                List<Paciente> listaPacientes = negocioPaciente.listar();
                ddlPaciente.DataTextField = "NombreCompleto";
                ddlPaciente.DataValueField = "Id";

                int idPacienteEnSesion = ((Paciente)Session["usuario"]).Id;//Envío el NUMERO del ID del pte. q esta actualmente en la Session
                Paciente pacienteEnSesion = listaPacientes.FirstOrDefault(p => p.Id == idPacienteEnSesion);//Busca coincidencia
                List<Paciente> pacienteEnLista = new List<Paciente>();
                if (pacienteEnSesion != null)
                {
                    pacienteEnLista.Add(pacienteEnSesion);
                }

                ddlPaciente.DataSource = pacienteEnLista;
                ddlPaciente.DataBind();

                EspecialidadNegocio negocioEspecialidad = new EspecialidadNegocio();
                List<Especialidad> listaEspecialidad = negocioEspecialidad.listar();
                Especialidad especialidadSeleccionar = new Especialidad { Id = 0, Nombre = "Selecciona una especialidad" };
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


        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCldTurno.Visible = true;
            cldTurno.Visible = true;
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


            //HorarioNegocio negocio = new HorarioNegocio();
            //List<Horario> listaHorarios = negocio.listar();
            DisponibilidadNegocio negocio = new DisponibilidadNegocio();
            DateTime fechaSeleccionada = cldTurno.SelectedDate;
            int dia = (int)fechaSeleccionada.DayOfWeek;
            int idMedico;
            if (int.TryParse(ddlMedico.SelectedValue, out idMedico))
            {
                Debug.WriteLine("******", dia);
                List<Disponibilidad> listaHorarios = negocio.listarDisponibilidad(idMedico, fechaSeleccionada);



                ddlHorarios.DataSource = listaHorarios;
                ddlHorarios.DataValueField = "Hora";
                ddlHorarios.DataTextField = "Hora";
                ddlHorarios.DataBind();
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)//Saca el turno
        {

            Turno nuevo = new Turno();
            TurnoNegocio negocio = new TurnoNegocio();
            Paciente nuevoPaciente = new Paciente();
            PacienteNegocio negocioPaciente = new PacienteNegocio();

            string horarioSeleccionado = ddlHorarios.SelectedValue;
            DateTime fechaSeleccionada = cldTurno.SelectedDate;

            int pacienteId = int.Parse(ddlPaciente.SelectedValue);

            nuevo.Paciente = new Paciente();
            nuevo.Paciente.Id = int.Parse(ddlPaciente.SelectedValue);
            string emailDestino = negocioPaciente.obtenerEmail(int.Parse(ddlPaciente.SelectedValue));
            string nombrePaciente = negocioPaciente.listarNombre(int.Parse(ddlPaciente.SelectedValue));
            EmailService emailService = new EmailService();
            try
            {

                nuevo.Especialidad = new Especialidad();
                nuevo.Especialidad.Id = int.Parse(ddlEspecialidad.SelectedValue);

                nuevo.Medico = new Medico();
                nuevo.Medico.Id = int.Parse(ddlMedico.SelectedValue);

                DateTime fechaYHorario = fechaSeleccionada.Date;
                DateTime horario = DateTime.ParseExact(horarioSeleccionado, "HH", CultureInfo.InvariantCulture);

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
                    string rutaArchivo = Server.MapPath("~/confirmacionTurnoMail.aspx");
                    string contenidoArchivo = File.ReadAllText(rutaArchivo);
                    contenidoArchivo = contenidoArchivo.Replace("{nombre}", nombrePaciente);
                    contenidoArchivo = contenidoArchivo.Replace("{fecha}", cldTurno.SelectedDate.ToShortDateString());


                    emailService.armarCorreo(emailDestino, "Turno Correcto", contenidoArchivo);
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

        protected void cldTurno_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;

            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false; // Deshabilita la selección del día
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
            DateTime fechaSeleccionada = cldTurno.SelectedDate;
            int idMedico;

            if (int.TryParse(ddlMedico.SelectedValue, out idMedico))
            {
                DisponibilidadNegocio negocio = new DisponibilidadNegocio();
                List<Disponibilidad> listaDisponibilidad = negocio.listarDisponibilidad(idMedico);
                foreach (Disponibilidad disponibilidad in listaDisponibilidad)
                {
                    int dia = disponibilidad.Dia;

                    if (e.Day.Date.DayOfWeek == (DayOfWeek)dia && e.Day.Date > DateTime.Today)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Yellow;
                        e.Day.IsSelectable = true;

                    }
                }
            }
        }

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx");
        }
    }

}