using babershop.Controllers;
using babershop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Propietario
{
    public partial class Eliminar_Barberia : System.Web.UI.Page
    {
        Barberia bar = new Barberia();
        BarberiaControllers obj = new BarberiaControllers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                listview1.DataSource = bar.consult_barerias_propietario_eliminar(Session["login"].ToString());
                listview1.DataBind();
            }


        }

        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                string idbareria = (e.CommandArgument.ToString());

                if (obj.cambiar_estado_barberia(idbareria) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' Barberia Eliminada');", true);
                    Response.Redirect("~/Views/Propietario/Eliminar_Barberia.aspx");

                }

            }


        }


    }
}