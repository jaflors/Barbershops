using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Cliente
{
    public partial class Consultar_Cita_cliente : System.Web.UI.Page
     {
        CitaController cit = new CitaController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                listview1.DataSource = cit.traer_cita_Cliente(Session["login"].ToString());
                listview1.DataBind();
                

            }




        }



        


        public void traer_usuario(object sender, CommandEventArgs e)
        {

            if (e.CommandName.Equals("traer"))
            {
                string idcit = (e.CommandArgument.ToString());
                Session["id_cit_act"] = idcit;

                Response.Redirect("~/Views/Cliente/Actualizar_Cita_Cliente.aspx");



            }

        }








        public void traer_id_cita(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("traer"))
            {
                string idcit = (e.CommandArgument.ToString());
                Session["id_cit_act"] = idcit;



                Response.Redirect("~/Views/Cliente/eliminar_cita.aspx");




            }



        }
        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                //string idcit = (e.CommandArgument.ToString());


                if (cit.Cancelar_cita_cliente(Session["idcit_clien"].ToString(), List_motivo.Text.ToString()) == true)
                {


                    Response.Redirect("~/Views/Cliente/Consultar_Cita_cliente.aspx");
                }

            }



        }

        







        }







    }
