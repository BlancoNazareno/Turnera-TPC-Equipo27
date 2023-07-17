using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnera_TPC_Equipo27
{
    public partial class FormDisponibilidad : System.Web.UI.Page
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

            else
            {
                lblDgvDisponibilidad.Visible = false;
                lblDgvMedico.Visible = false;
                dgvDisponibilidad.Visible = false;
                ddlMedico.Visible = false;

                try
                {
                    if (!IsPostBack)
                    {
                        EspecialidadNegocio negocioE = new EspecialidadNegocio();
                        List<Especialidad> listaE = negocioE.listar();
                        ddlEspecialidad.DataSource = listaE;
                        ddlEspecialidad.DataValueField = "Id";
                        ddlEspecialidad.DataTextField = "Nombre";
                        ddlEspecialidad.DataBind();

                        MedicoNegocio negocio = new MedicoNegocio();
                        List<Medico> lista = negocio.listar();
                        ddlMedico.DataSource = lista;
                        ddlMedico.DataValueField = "Id";
                        ddlMedico.DataTextField = "NombreCompleto";
                        ddlMedico.DataBind();



                        HorarioNegocio negocioH = new HorarioNegocio();
                        Session.Add("listaHorarios", negocioH.listar());
                        dgvDisponibilidad.DataSource = Session["listaHorarios"];
                        dgvDisponibilidad.DataBind();

                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Disponibilidad nueva = new Disponibilidad();
                DisponibilidadNegocio negocio = new DisponibilidadNegocio();

                foreach (GridViewRow row in dgvDisponibilidad.Rows)
                {
                    for (int i = 1; i < row.Cells.Count ; i++)
                    //Debug.WriteLine(i);
                    {

                        CheckBox chkDia = (CheckBox)row.FindControl("chk" + dgvDisponibilidad.HeaderRow.Cells[i].Text);


                        if (chkDia != null && chkDia.Checked)
                        {
                            Debug.WriteLine("*********", chkDia.Checked);
                            nueva.Medico = new Medico();
                            nueva.Medico.Id = int.Parse(ddlMedico.SelectedValue);
                            string diaSemana = dgvDisponibilidad.HeaderRow.Cells[i].Text;

                            if (diaSemana != null)
                            {
                                switch (diaSemana)
                                {
                                    case "Lunes":
                                        nueva.Dia = 1;
                                        break;
                                    case "Martes":
                                        nueva.Dia = 2;
                                        break;
                                    case "Miércoles":
                                        nueva.Dia = 3;
                                        break;
                                    case "Jueves":
                                        nueva.Dia = 4;
                                        break;
                                    case "Viernes":
                                        nueva.Dia = 5;
                                        break;
                                    
                                }
                            }
                            nueva.Hora = row.Cells[0].Text;
                            negocio.agregar(nueva);

                        }
                        else
                        {
                            Debug.WriteLine("***********No entro**************", i);
                        }

                    }
                }
                Response.Redirect("Disponibilidades.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblDgvMedico.Visible = true;
            ddlMedico.Visible = true;
            dgvDisponibilidad.Visible = true;

            int idEspecialidadSeleccionada = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            MedicoNegocio negocio = new MedicoNegocio();
            List<Medico> listaFiltrada = negocio.listaFiltrada(idEspecialidadSeleccionada);
            ddlMedico.DataSource = listaFiltrada;
            ddlMedico.DataValueField = "Id";
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataBind();
        }
    }
}