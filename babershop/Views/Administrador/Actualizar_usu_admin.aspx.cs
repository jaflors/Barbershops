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
    public partial class Actualizar_usu_admin : System.Web.UI.Page
    {
        UsuarioController usu = new UsuarioController();
        DataTable aux;
        DataRow dato;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                aux = usu.Traer_usuario(Session["id_usu_act"].ToString());

                if (aux.Rows.Count > 0)
                {
                    dato = aux.Rows[0];
                    nombres.Value = dato["nombres"].ToString();
                    apellidos.Value = dato["apellidos"].ToString();
                    correo.Value = dato["correo"].ToString();
                    contrasena.Value = dato["contrasena"].ToString();
                    rol.Text = dato["Nombre"].ToString();
                }

                }

        }


        public void Registrar(object sender,EventArgs e)
        {
            string nrol = (new RolController()).cosul_rol(Select1.Value.ToString());
            if (usu.actualizar_usu(nombres.Value.ToString(), apellidos.Value.ToString(), correo.Value.ToString(), contrasena.Value.ToString(), Session["id_usu_act"].ToString(), nrol.ToString()))
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