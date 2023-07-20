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
                int idTurnoRecibido = Convert.ToInt32(Request.QueryString["id"]);

                TurnoNegocio negocioTurno = new TurnoNegocio();
                List<Turno> listaTurnos = negocioTurno.listar();
                Turno turnoSeleccionado = listaTurnos.Find(turnos => turnos.Id == idTurnoRecibido);
                int cantidadTurnos = listaTurnos.Count;

                MedicoNegocio negocioMedico = new MedicoNegocio();
                List<Medico> listaMedicos = negocioMedico.listar();
                int idMedico = turnoSeleccionado.Medico.Id;//no me asigna bien el id del medico
                Medico medicoSeleccionado = listaMedicos.Find(m => m.Id == idMedico);

                PacienteNegocio negocioPaciente = new PacienteNegocio();
                List<Paciente> listaPacientes = negocioPaciente.listar();
                int idPaciente = turnoSeleccionado.Paciente.Id;
                Paciente pacienteSeleccionado = listaPacientes.Find(m => m.Id == idPaciente);

                lblFechaTurno.Text = turnoSeleccionado.Fecha.ToString("dd/MM/yyyy");
                lblNombreCompleto.Text = turnoSeleccionado.Paciente.NombreCompleto;
                lblMedico.Text = medicoSeleccionado.Apellido + " " + medicoSeleccionado.Nombre;
                lblFechaNacimiento.Text = pacienteSeleccionado.FechaNacimiento.ToString("dd/MM/yyyy");
                lblCelular.Text = pacienteSeleccionado.Celular;
                lblDNI.Text = pacienteSeleccionado.Dni.ToString();
                lblEspecialidad.Text = turnoSeleccionado.Especialidad.Nombre;
                lblCobertura.Text = pacienteSeleccionado.Cobertura;

            }
        }

    }
}