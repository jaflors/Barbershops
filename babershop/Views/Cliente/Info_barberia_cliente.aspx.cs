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
    public partial class Info_barberia_cliente : System.Web.UI.Page
    {
        public DataTable dtbarber;
        public DataRow drbarbert;

        BarberiaControllers barberia = new BarberiaControllers();
        BarberoController obj = new BarberoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtbarber = barberia.traer_barberia_info(Session["id_barberia_info"].ToString());
                if (dtbarber.Rows.Count > 0)
                {
                    drbarbert = dtbarber.Rows[0];

                    list_barber.DataSource = obj.Consultar_barberos_propietari(Session["id_barberia_info"].ToString());
                    list_barber.DataBind();

                }


            }


        }

        public void traer_usuario(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("traer"))
            {


                string idbarber = (e.CommandArgument.ToString());



                Session["id_barbero_cita_cliente"] = idbarber;

                Response.Redirect("~/Views/Cliente/Registrar_cita_cliente.aspx");
            }

        }

    }
}