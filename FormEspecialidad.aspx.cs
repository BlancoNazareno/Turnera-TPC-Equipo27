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
    public partial class FormEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Especialidad Auxiliar { get; set; }

        public FormEspecialidad()
        {
            Auxiliar = new Especialidad();
        }

        public void GuardarFormulario()
        {
            Auxiliar.Nombre = Especialidad.Text;
        }

        public void CargarFormulario()
        {
            Especialidad.Text = Auxiliar.Nombre;
        }

        protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            GuardarFormulario();
            EspecialidadNegocio negocio = new EspecialidadNegocio();

            List<Especialidad> listaAux = new List<Especialidad>();
            listaAux = (List<Especialidad>)Session["listaEspecialidades"];

            try
            {
                negocio.agregar(Auxiliar);
                //Auxiliar = negocio.listarUltimaEspecialidad();
                listaAux.Add(Auxiliar);
                Session["listaEspecialidades"] = listaAux;
                Response.Redirect("Especialidades.aspx");
                //if (Auxiliar.Id == 0)
                //{
                //    negocio.agregar(Auxiliar);
                //    Auxiliar = negocio.listarUltimaEspecialidad();
                //    listaAux.Add(Auxiliar);
                //    Session["listaEspecialidades"] = listaAux;
                //    Response.Redirect("Especialidades.aspx");
                //    /*Response.Redirect("Especialidades.aspx?idEspecialidad=" + Auxiliar.Id.ToString())*/;
                //}
                //else
                //{
                //    negocio.modificarEspecialidad(Auxiliar);
                //    listaAux.RemoveAll(item => item.Id == Auxiliar.Id);
                //    listaAux.Add(Auxiliar);
                //    Session["listaEspecialidades"] = listaAux;
                //    Response.Redirect("Especialidades.aspx");
                //    //Response.Redirect("Escialidad.aspx?idEspecialidad=" + Auxiliar.Id);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
