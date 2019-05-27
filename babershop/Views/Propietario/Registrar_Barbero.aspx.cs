using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Propietario
{
    public partial class Registrar_Barbero : System.Web.UI.Page
    {
        BarberiaControllers barberia = new BarberiaControllers();

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                traer_barberia();
            }
        }


        public void traer_barberia()
        {
            List_barberia.DataSource = barberia.traer_barberia_registro_barero(Session["login"].ToString());
            List_barberia.DataTextField = "Nombre Barberia";
            List_barberia.DataValueField = "idBarberia";
            List_barberia.DataBind();
        }


        protected void Registrar(object sender, EventArgs e)
        {
            BarberoController barb = new BarberoController(nombre.Text.ToString(),apellidos.Text.ToString(),correo.Text.ToString(),contrasena.Text.ToString(),recontrasena.Text.ToString());

           



            if (barb.Insertar_barbero(barb.barber,List_barberia.Text.ToString() ) ==true)
            {
                Response.Write("<script> alert('Barbero Registrado' ); </script>");
                return;

            }


        }
    }
}