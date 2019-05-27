using Admin.Conexion;
using babershop.Controllers;
using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Cliente
{
    public partial class agenda_cliente : System.Web.UI.Page
    {
        BdComun conn = new BdComun();
        static events obj = new events();
        static BarberoController br = new BarberoController();
        CitaController cit = new CitaController();
        static ClienteController cli = new ClienteController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idcita.Visible = false;
            }


        }

        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {


                if (cit.delete_cita(idcita.Text.ToString()) == true)

                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('seguro de eliminar ');", true);
                    Response.Redirect("../Administrador/Registrar_usu_admi.aspx");

                }

            }


        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<events> GetEvents()
        {
            string idcliente = cli.consul_id_cliente(HttpContext.Current.Session["login"].ToString());
            DataTable dt = cli.consultar_agenda(idcliente);
            List<events> eve = new List<events>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                events a = new events();
                a.EventId = Convert.ToInt32(dt.Rows[i]["idcita"].ToString());
                a.Subject = Convert.ToString(dt.Rows[i]["bareria"].ToString());
                a.Description = Convert.ToString(dt.Rows[i]["Servicio"].ToString());
                a.Start = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString());
                a.End = Convert.ToDateTime(dt.Rows[i]["Fecha"].ToString());
                a.ThemeColor = "#FF0F0";
                a.IsFullDay = false;




                eve.Add(a);
            }

            return eve;
        }

    }
}