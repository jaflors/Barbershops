using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Barbero
{
    public partial class consulta_mis_citas : System.Web.UI.Page
    {
        BarberoController br = new BarberoController();
        CitaController cita = new CitaController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                string idbarbero = br.Consulta_id_barbero(Session["login"].ToString());
                listview1.DataSource = br.Consultar_mis_citas_eliminar(idbarbero);
                listview1.DataBind();
            }

        }


        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
                string idcit = (e.CommandArgument.ToString());


                if (cita.delete_cita(idcit.ToString()) == true)
                {
                    Response.Redirect("~/Views/Barbero/consulta_mis citas.aspx");
                }

            }



        }

        public void traer_usuario(object sender, CommandEventArgs e)
        {

            if (e.CommandName.Equals("traer"))
            {
                string idcit = (e.CommandArgument.ToString());
                Session["id_cit_act"] = idcit;

                Response.Redirect("~/Views/Administrador/Actualizar_Cita.aspx");



            }







        }

    }
}