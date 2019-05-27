using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Administrador
{
   
    public partial class Actualizar_barberia : System.Web.UI.Page
    {
        BarberiaControllers obj = new BarberiaControllers();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                listview1.DataSource = obj.traer_barberias_actualizar();
                listview1.DataBind();
            }


        }

        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("activar"))
            {
                string idbareria = (e.CommandArgument.ToString());

                if (obj.cambiar_estado_barberia_activar(idbareria) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(' Barberia Activada');", true);
                    Response.Redirect("../Administrador/Actualizar_barberia.aspx");

                }

            }


        }



    }

}
