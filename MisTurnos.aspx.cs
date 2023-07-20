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
    public partial class MisTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "No es posible acceder sin estar logueado");
                Response.Redirect("Default.aspx");
            }

            if ((Session["usuario"] != null) &&
                (((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.SUBADMIN ||
                ((Paciente)Session["usuario"]).TipoUsuario == TipoUsuario.ADMIN))
            {
                //ya está logueado como ADMIN o SUBADMIN, por lo que redirige a su área correspondiente
                Response.Redirect("HomeAdmin.aspx");
            }




            TurnoNegocio negocio = new TurnoNegocio();
            List<Turno> listaTurnos = negocio.listar();
            int idTurnoRecibido = ((Paciente)Session["usuario"]).Id; // Corregido el paréntesis que estaba sobrante
            List<Turno> listaFiltrada = listaTurnos.FindAll(turnos => turnos.Id == idTurnoRecibido); // Cambiado Find por FindAll para obtener todos los turnos que coinciden
            dgvTurnosAdmin.DataSource = listaFiltrada; // Agregado punto y coma al final de la línea
            dgvTurnosAdmin.RowDataBound += dgvTurnosAdmin_RowDataBound; // Corregida la asignación del evento RowDataBound
            dgvTurnosAdmin.DataBind();


        }

        protected void dgvTurnosAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblEstado = (Label)e.Row.FindControl("lblEstado");
                if (lblEstado != null)
                {
                    bool estado = (bool)DataBinder.Eval(e.Row.DataItem, "Estado");
                    lblEstado.Text = estado ? "Activo" : "Cancelado";
                }
            }
        }
    }
}