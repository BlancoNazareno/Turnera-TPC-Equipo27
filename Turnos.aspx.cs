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
    public partial class TurnosAdmin : System.Web.UI.Page
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

            TurnoNegocio negocio = new TurnoNegocio();
            dgvTurnosAdmin.DataSource = negocio.listar();
            dgvTurnosAdmin.RowDataBound += dgvTurnosAdmin_RowDataBound;     //Empleado por el cambio en el muestro del dato Estado (si es True [SQL] muestra Activo [HTML])
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
                    lblEstado.Text = estado ? "Activo" : "Inactivo";
                }
            }
        }






        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
       
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
         
        }
    }
}