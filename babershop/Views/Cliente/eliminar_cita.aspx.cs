using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Cliente
{
    public partial class eliminar_cita : System.Web.UI.Page
    {
        CitaController cit = new CitaController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                traer_motivo();
            }
        }




        public void traer_motivo()
        {
            List_motivo.DataSource = cit.traer_motivo_cancelacion();
            List_motivo.DataTextField = "nombre";
            List_motivo.DataValueField = "idmotivo_cancelacion";
            List_motivo.DataBind();
        }

        protected void Registrar(object sender, EventArgs e)
        {
           


            if (cit.Cancelar_cita_cliente(Session["id_cit_act"].ToString(),List_motivo.Text.ToString())==true)
            {
                Response.Write("<script> alert('Cita cancelada'); </script>");
                Response.Redirect("~/Views/Cliente/Consultar_Cita_cliente.aspx");
            }else
            {
                Response.Write("<script> alert('Algo salio mal '); </script>");
            }


        }



    }
}