using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Principal
{
    public partial class Registrar_Barberia : System.Web.UI.Page
    {
        string msj;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar(object sender, EventArgs e)
        {

            try
            {
                UsuarioController usu = new UsuarioController(nombres.Value.ToString(), apellidos.Value.ToString(),
                 correo.Value.ToString(), contrasena.Value.ToString(), recontrasena.Value.ToString());

              
                    

                        if (usu.Insertar_propietario_pri(usu.usu) == true)
                        {
                            
                            msj = "Usuario registrado correctamente";
                            //return RedirectToAction("Agregar_Consultorio_Admin", "consultorio");
                            Response.Redirect("~/Views/Principal/Login.aspx");

                        }
                        else
                        {
                            msj = "Error! algo salio mal";
                            Response.Redirect("~/Views/Principal/Registrar_Barberia.aspx");
                        }

                   
                    


                

                //string aux = usu.Insertar(usu.usu);
                //Response.Write("<script> alert('" + aux + "'); </script>");
                //Response.Redirect("Login.aspx");
            }
            catch (Exception)
            {
                Response.Write("<script> alert('ERROR INESPERADO' ); </script>");
            }




        }



        }
}