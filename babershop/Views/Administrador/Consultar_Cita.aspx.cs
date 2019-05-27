using babershop.Controllers;
using babershop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Administrador
{
    public partial class Consultar_Cita : System.Web.UI.Page
    {
        CitaController cita = new CitaController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Cita cit = new Cita();
                listview1.DataSource = cit.consult_cita();
                listview1.DataBind();
            }

        }


        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                string idcit = (e.CommandArgument.ToString());
                

                if (cita.delete_cita(idcit.ToString())==true)
                {
                    Response.Redirect("~/Views/Administrador/Consultar_Cita.aspx");
                }

            }



        }

        public void traer_usuario(object sender, CommandEventArgs e)
        {

            if (e.CommandName.Equals("traer"))
            {
                string idcit = (e.CommandArgument.ToString());
                Session["id_cit_act"] = idcit;

                Response.Redirect("~/Views/Administrador/Actualizar_Cita.aspx");



            }



           



        }



    }
}