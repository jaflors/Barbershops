using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Propietario
{
    public partial class Registrar_Barberia__Propietario : System.Web.UI.Page
    {
        PropietarioController pro = new PropietarioController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }






        protected void Registrar(object sender, EventArgs e)
        {

            try
            {
                BarberiaControllers barberia = new BarberiaControllers(nombre_bar.Value.ToString(), direccion.Value.ToString());

                if (file_bareria != null)
                {
                    if (ModelState.IsValid)
                    {
                        string img = Path.GetFileName(file_bareria.FileName);
                        string ruta = "../../imagenes/" + img;
                        string carpeta = Path.Combine(Server.MapPath("~/imagenes"), img);
                        string idpro = pro.Consult_id_propietario(Session["login"].ToString());
                        if (barberia.Insertar_barberia(barberia.bar,idpro, ruta) == true)
                        {
                            file_bareria.SaveAs(carpeta);

                            Response.Write("<script> alert('barberia_registrada' ); </script>");
                            //Response.Redirect("~/Views/Administrador/Registrar_barberia.aspx");

                        }
                        else
                        {

                            Response.Redirect("~/Views/Propietario/Registrar_Barberia _Propietario.aspx");
                        }

                    }
                    else
                    {

                        Response.Redirect("~/Views/Propietario/Registrar_Barberia _Propietario.aspx");
                    }


                }
                else
                {

                    Response.Redirect("~/Views/Administrador/Registrar_barberia.aspx");
                }


            }
            catch (Exception)
            {
                Response.Write("<script> alert('ERROR INESPERADO' ); </script>");
            }


        }
    }
}