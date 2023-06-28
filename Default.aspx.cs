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
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio especialidad = new EspecialidadNegocio();
                Session.Add("listaEspecialidades", especialidad.listar());//capturo con Session para dps usar la Session en el filtro
                dgvEspecialidades.DataSource = Session["listaEspecialidades"];
                dgvEspecialidades.DataBind();

                MedicoNegocio medico = new MedicoNegocio();
                Session.Add("listaMedicos", medico.listar());//capturo con Session para dps usar la Session en el filtro
                dgvEspecialidades.DataSource = Session["listaMedicos"];
                dgvEspecialidades.DataBind();
            }
        }

        protected void dgvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvEspecialidades.SelectedDataKey.Value.ToString();
            Response.Redirect("Default.aspx?id=" + id);
        }
        protected void filtroEspecialidades_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["listaEspecialidades"];
            List<Especialidad> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvEspecialidades.DataSource = listaFiltrada;
            dgvEspecialidades.DataBind();
        }

        protected void dgvEspecialidades_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvEspecialidades.PageIndex = e.NewPageIndex;
            dgvEspecialidades.DataBind();
        }

                protected void dgvMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvMedicos.SelectedDataKey.Value.ToString();
            Response.Redirect("Default.aspx?id=" + id);
        }
        protected void filtroMedicos_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["listaEspecialidades"];
            List<Especialidad> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvEspecialidades.DataSource = listaFiltrada;
            dgvEspecialidades.DataBind();
        }

        protected void dgvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvEspecialidades.PageIndex = e.NewPageIndex;
            dgvEspecialidades.DataBind();
        }

    }
}