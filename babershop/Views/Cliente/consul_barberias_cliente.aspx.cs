using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Cliente
{
    public partial class consul_barberias_cliente : System.Web.UI.Page
    {
        BarberiaControllers bar = new BarberiaControllers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                list_barberias.DataSource = bar.traer_barberias_clientes();
                list_barberias.DataBind();
            }
        }

        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("traer"))
            {
                string idbarber = (e.CommandArgument.ToString());



                Session["id_barberia_info"] = idbarber;

                Response.Redirect("~/Views/Cliente/Info_barberia_cliente.aspx");
            }

      }

    }
}