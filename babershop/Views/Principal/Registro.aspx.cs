using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Principal
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Registrar(object sender, EventArgs e)
        {

            try {
                UsuarioController obj = new UsuarioController(nombres.Value.ToString(),apellidos.Value.ToString(),correo.Value.ToString(),contrasena.Value.ToString(),recontrasena.Value.ToString());
                if (obj.Insertar(obj.usu) == true)
                {
                    Response.Write("<script> alert('Usuario Registrado' ); </script>");
                    return;

                }else
                {
                    Response.Write("<script> alert('Algo salio mal' ); </script>");
                    return;
                }

            }
            catch (Exception)
            {
                Response.Write("<script> alert('error' ); </script>");
                return;
            }
            

        }
    }
}