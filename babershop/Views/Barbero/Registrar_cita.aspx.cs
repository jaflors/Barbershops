using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Barbero
{
    public partial class Registrar_cita : System.Web.UI.Page
    {
        CitaController obj = new CitaController();
        DataTable aux;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                traer_Client();
                traer_Hora();
                traer_service();
            }

        }


      

        public void traer_Client()
        {
            List_cliente.DataSource = obj.traer_Client();
            List_cliente.DataTextField = "nombres";
            List_cliente.DataValueField = "idCliente";
            List_cliente.DataBind();
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

            BarberoController bar = new BarberoController();
            string id =bar.Consulta_id_barbero(Session["login"].ToString());




            CitaController cita = new CitaController(id, List_cliente.Text.ToString(), fecha.Text.ToString(), Hora.Text.ToString(), List_servi.Text.ToString());

            aux = cita.traer_fecha_cita_hota(id, fecha.Text.ToString(), Hora.Text.ToString());


            if (aux.Rows.Count > 0)
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