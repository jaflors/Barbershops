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
    public partial class Registrar_usu_admi : System.Web.UI.Page
    {
        Usuario usu = new Usuario();
        UsuarioController u = new UsuarioController();
        public DataTable aux;
        public DataRow dato;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                list_usuarios.DataSource = usu.ConsulUsuarios();
                list_usuarios.DataBind();
                




            }
        }

       
      public void Unnamed_Command(object sender ,CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                string idusu = (e.CommandArgument.ToString());
               
                if (u.cambiar_estado_usu(idusu) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('seguro de eliminar ');", true);
                    Response.Redirect("../Administrador/Registrar_usu_admi.aspx");
                    
                }

            }


        }



        public void traer_usuario(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('entro');", true);
            
            if (e.CommandName.Equals("traer"))
            {
                string idusu = (e.CommandArgument.ToString());
                Session["id_usu_act"] = idusu;

                Response.Redirect("~/Views/Administrador/Actualizar_usu_admin.aspx");

               

                }

        }





        public void Registrar(object sender,EventArgs e)
        {
          
            UsuarioController obj_usu = new UsuarioController(txt_Nombres.Text.ToString(),apellidos.Text.ToString(),corre.Text.ToString(),contra.Text.ToString(),recontra.Text.ToString());
          if (u.Insertar(obj_usu.usu)==true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro Correcto');", true);

            }
            else
            {
                Response.Write("<script> alert('Algo salio mal' ); </script>");
                Response.Redirect("~/Views/Administrador/Registrar_usu_admi.aspx");
            }


        }

    }
}