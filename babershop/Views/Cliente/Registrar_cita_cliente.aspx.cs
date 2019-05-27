using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Cliente
{
    public partial class Registrar_cita_cliente : System.Web.UI.Page
    {
        CitaController obj = new CitaController();
        BarberoController barber = new BarberoController();
        ClienteController cl = new ClienteController();
        DataRow dato;
        DataTable aux;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                traer_Hora();
                traer_service();

                Session["id_cliente"] = cl.traer_id_cliente(Session["login"].ToString());


            }



        }

        public void traer_Hora()
        {
            Hora.DataSource = obj.traer_hora();
            Hora.DataTextField = "hora";
            Hora.DataValueField = "idHorario";
            Hora.DataBind();
        }
        public void traer_service()
        {
            List_servi.DataSource = obj.traer_motivo();
            List_servi.DataTextField = "descripcion";
            List_servi.DataValueField = "idmotivo";
            List_servi.DataBind();
        }
        protected void Registrar(object sender, EventArgs e)
        {

            CitaController cita = new CitaController(Session["id_barbero_cita_cliente"].ToString(), Session["id_cliente"].ToString() , fecha.Text.ToString(), Hora.Text.ToString(), List_servi.Text.ToString());

            aux = cita.traer_fecha_cita_hota(Session["id_barbero_cita_cliente"].ToString(), fecha.Text.ToString(), Hora.Text.ToString());


            if (aux.Rows.Count>0)
            {
                Response.Write("<script> alert(' Lo sentimos este horario ya esta reservado '); </script>");

            }
            else
            {


                if (cita.insert_cita(cita.cit) == true)
                {
                    Response.Write("<script> alert(' Cita Registrada'); </script>");
                    return;
                }
                else
                {
                    Response.Write("<script> alert('ALGO  salio mal '); </script>");
                }


            }





           



        }





    }
}