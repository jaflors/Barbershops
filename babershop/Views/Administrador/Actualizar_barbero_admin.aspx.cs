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
    public partial class Actualizar_barbero_admin : System.Web.UI.Page
    {
        DataTable dt_bar;
        UsuarioController usu = new UsuarioController();
        DataTable aux;
        DataRow dato;

        public BarberiaControllers bar = new BarberiaControllers();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               cargarlist();

                aux = usu.Traer_usuario(Session["id_usu_bar_act"].ToString());

                if (aux.Rows.Count > 0)
                {
                    dato = aux.Rows[0];
                    nombres.Value = dato["nombres"].ToString();
                    apellidos.Value = dato["apellidos"].ToString();
                    correo.Value = dato["correo"].ToString();
                    contrasena.Value = dato["contrasena"].ToString();
                    estado.Value = dato["estado"].ToString();


                }

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



        public void Registrar (object sender, EventArgs e)
        {

            string idbar = bar.Consult_idbar(List_barberia.Text.ToString());
             if (usu.actualizar_barbero_admin(nombres.Value.ToString(), apellidos.Value.ToString(), correo.Value.ToString(), contrasena.Value.ToString(),estado.Value.ToString() ,Session["id_usu_bar_act"].ToString(), idbar.ToString()))
            {
                Response.Write("<script> alert('Actualizacion Exitosa'); </script>");
            }
            else
            {
                Response.Write("<script> alert('ERROR ACTULIZACIÓN'); </script>");
            }


        }

    }
}