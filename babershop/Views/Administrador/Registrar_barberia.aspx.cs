using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Administrador
{
    public partial class Registrar_barberia : System.Web.UI.Page
    {
        string msj;
        PropietarioController pro = new PropietarioController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {

                traer_propietarios();
            }
        }


        public void traer_propietarios()
        {

            list_propietarios.DataSource = pro.traer_propitarios();
            list_propietarios.DataTextField = "nombres";
            list_propietarios.DataValueField = "idpro";
            list_propietarios.DataBind();

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

                        if (barberia.Insertar_barberia(barberia.bar,list_propietarios.SelectedValue,ruta)== true)
                        {
                            file_bareria.SaveAs(carpeta);

                            Response.Write("<script> alert('barberia_registrada' ); </script>");
                            //Response.Redirect("~/Views/Administrador/Registrar_barberia.aspx");

                            }
                            else
                            {
                               
                                Response.Redirect("~/Views/Administrador/Registrar_barberia.aspx");
                            }

                    }
                    else
                    {
                        
                        Response.Redirect("~/Views/Administrador/Registrar_barberia.aspx");
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