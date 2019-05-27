using babershop.Controllers;
using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Administrador
{
    public partial class Barberos_Registrados : System.Web.UI.Page
    {
        DataTable dt_bar;
        public BarberiaControllers bar = new BarberiaControllers();
        BarberoController obj = new BarberoController();
        UsuarioController u = new UsuarioController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                list_barberos.DataSource = obj.Consultar_barberos();
                list_barberos.DataBind();
                cargarlist();
            }
        }

        public void cargarlist()
        {

            dt_bar = bar.traer_barberias();

            for (int i = 0; i < dt_bar.Rows.Count; i++)
            {
                List_barberia.Items.Add(dt_bar.Rows[i]["nombre"].ToString());
            }
            
        }
        
        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                string idusu = (e.CommandArgument.ToString());

                if (u.cambiar_estado_usu(idusu) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('seguro de eliminar ');", true);
                    Response.Redirect("~/Views/Administrador/Barberos_Registrados.aspx");

                }

            }



        }

        public void traer_usuario(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('entro');", true);

            if (e.CommandName.Equals("traer"))
            {
                string idusu = (e.CommandArgument.ToString());
                Session["id_usu_bar_act"] = idusu;

                Response.Redirect("~/Views/Administrador/Actualizar_barbero_admin.aspx");



            }

        }


        public void Registrar(object sender, EventArgs e)
        {

            string idbar = bar.Consult_idbar(List_barberia.Text.ToString());
            Session["idbar"] = idbar;
            BarberoController barbe = new BarberoController(txt_Nombres.Text.ToString(),apellidos.Text.ToString(),corre.Text.ToString(),contra.Text.ToString(),recontra.Text.ToString());
            
            if (obj.Insertar_barbero(barbe.barber, Session["idbar"].ToString()))
            {
                Response.Redirect("~/Views/Administrador/Barberos_Registrados.aspx");
            }
           

        }



    }
}