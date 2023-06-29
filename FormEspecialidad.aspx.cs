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
            if (!IsPostBack)
            {

                // Obtener el ID de la URL
                int id = Convert.ToInt32(Request.QueryString["ID"]);

                // Realizar la lógica correspondiente según el ID
                if (id == 0)
                {
                    // Estás en modo "Agregar"
                    // Puedes realizar cualquier lógica adicional necesaria para el modo "Agregar"
                }
                else
                {
                    // Estás en modo "Modificar"
                    // Puedes realizar cualquier lógica adicional necesaria para el modo "Modificar"

                    // Obtener el nombre del elemento correspondiente al ID
                    EspecialidadNegocio negocio = new EspecialidadNegocio();
                    Especialidad especialidad = negocio.ObtenerEspecialidadPorId(id);

                    // Verificar si se encontró la especialidad
                    if (especialidad != null)
                    {
                        // Mostrar el nombre en el TextBox
                        Especialidad.Text = especialidad.Nombre;
                    }
                    else
                    {
                        // Manejar el caso en que no se encuentre la especialidad
                    }
                }
            }
        }

        //protected void btnAceptar_Click(object sender, EventArgs e)
        //{
        //    int id = Convert.ToInt32(Request.QueryString["ID"]);

        //    if (id == 0)
        //    {
        //        // Llamar al método Agregar
        //        Agregar();
        //    }
        //    else
        //    {
        //        // Lógica para realizar otra acción si el ID es diferente de 0
        //        // Por ejemplo, llamar a un método para modificar el elemento con el ID especificado
        //    }
        //}

        public Especialidad Auxiliar { get; set; }
        protected void btnAgregarModificarEspecialidad_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            Auxiliar = new Especialidad();
            Auxiliar.Id = id;
            Auxiliar.Nombre = Especialidad.Text;
            EspecialidadNegocio negocio = new EspecialidadNegocio();

            

            if (id == 0)
            {
                negocio.agregar(Auxiliar);
                Response.Redirect("Especialidades.aspx");
            }

            else
            {
                negocio.modificar(Auxiliar);
                Response.Redirect("Especialidades.aspx");
            }

        }

        //    try
        //    {
        //        negocio.agregar(Auxiliar);
        //       
        //        Response.Redirect("Especialidades.aspx");
    }

    //public Especialidad Auxiliar { get; set; }

    //public FormEspecialidad()
    //{
    //    Auxiliar = new Especialidad();
    //}

    //public void GuardarFormulario()
    //{
    //    Auxiliar.Nombre = Especialidad.Text;
    //}

    //public void CargarFormulario()
    //{
    //    Especialidad.Text = Auxiliar.Nombre;
    //}

    //protected void btnAgregarEspecialidad_Click(object sender, EventArgs e)
    //{
    //    GuardarFormulario();
    //    EspecialidadNegocio negocio = new EspecialidadNegocio();

    //    List<Especialidad> listaAux = new List<Especialidad>();
    //    listaAux = (List<Especialidad>)Session["listaEspecialidades"];

    //    try
    //    {
    //        negocio.agregar(Auxiliar);
    //        //Auxiliar = negocio.listarUltimaEspecialidad();
    //        listaAux.Add(Auxiliar);
    //        Session["listaEspecialidades"] = listaAux;
    //        Response.Redirect("Especialidades.aspx");
    //        //if (Auxiliar.Id == 0)
    //        //{
    //        //    negocio.agregar(Auxiliar);
    //        //    Auxiliar = negocio.listarUltimaEspecialidad();
    //        //    listaAux.Add(Auxiliar);
    //        //    Session["listaEspecialidades"] = listaAux;
    //        //    Response.Redirect("Especialidades.aspx");
    //        //    /*Response.Redirect("Especialidades.aspx?idEspecialidad=" + Auxiliar.Id.ToString())*/;
    //        //}
    //        //else
    //        //{
    //        //    negocio.modificarEspecialidad(Auxiliar);
    //        //    listaAux.RemoveAll(item => item.Id == Auxiliar.Id);
    //        //    listaAux.Add(Auxiliar);
    //        //    Session["listaEspecialidades"] = listaAux;
    //        //    Response.Redirect("Especialidades.aspx");
    //        //    //Response.Redirect("Escialidad.aspx?idEspecialidad=" + Auxiliar.Id);
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}


}

