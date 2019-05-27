using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Administrador
{
    public partial class Actualizar_Cita : System.Web.UI.Page
    {
        CitaController obj = new CitaController();
        DataTable aux;
        DataRow dato;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                traer_barber();
                traer_cliente();
                traer_Hora();
                traer_service();
                aux = obj.traer_cita_p(Session["id_cit_act"].ToString());

                if (aux.Rows.Count > 0)
                {
                    dato = aux.Rows[0];
                    label_client.InnerText = dato["Cliente"].ToString();
                    label_fecha.InnerText = dato["Fecha"].ToString();
                    label_hora.InnerText = dato["Hora"].ToString();
                    label_servi.InnerText= dato["Servicio"].ToString();
                    label_barbero.InnerText= dato["Barbero"].ToString();
                    
                }

            }
        }


        public void traer_barber()
        {
            List_barbero.DataSource = obj.traer_baber();
            List_barbero.DataTextField = "nombres";
            List_barbero.DataValueField = "idBarbero";
            List_barbero.DataBind();
        }



        public void traer_cliente()
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
            CitaController cita = new CitaController(List_barbero.Text.ToString(),List_cliente.Text.ToString(), fecha.Text.ToString(), Hora.Text.ToString(), List_servi.Text.ToString());

            if (cita.update_cita(cita.cit, Session["id_cit_act"].ToString()) == true)
            {
                Response.Write("<script> alert('Cita Actualizada'); </script>");
                Response.Redirect("~/Views/Administrador/Consultar_Cita.aspx");
            }


        }
    }

    
}