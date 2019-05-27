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
    public partial class Consultar_Barberos_pr : System.Web.UI.Page
    {
        BarberoController bar = new BarberoController();
        UsuarioController u = new UsuarioController();
        BarberiaControllers barberia = new BarberiaControllers();

        DataTable dtbarber;
        DataRow drbarbert;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

               

                dtbarber = barberia.traer_mi_barberia(Session["login"].ToString());
                if (dtbarber.Rows.Count > 0)
                {
                    drbarbert = dtbarber.Rows[0];
                    
                    list_barbero.DataSource = bar.Consultar_barberos_propietari2(drbarbert["idbarberia"].ToString());
                    list_barbero.DataBind();

                }


            }


        }


        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                string idusu = (e.CommandArgument.ToString());

                if (u.cambiar_estado_usu(idusu) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Usuario Eliminado ');", true);
                    Response.Redirect("~/Views/Propietario/Consultar_Barberos_pr.aspx");

                }

            }


        }



        public void traer_usuario(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('entro');", true);

            if (e.CommandName.Equals("traer"))
            {
             
                
                
                
                //string idusu = (e.CommandArgument.ToString());
                //Session["id_usu_act"] = idusu;

                //Response.Redirect("~/Views/Administrador/Actualizar_usu_admin.aspx");



            }

        }


    }
}