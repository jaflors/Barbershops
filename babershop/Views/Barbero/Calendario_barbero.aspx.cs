using Admin.Conexion;
using babershop.Controllers;
using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;
namespace babershop.Views.Barbero
{
    public partial class Calendario_barbero : System.Web.UI.Page
    {

        BdComun conn = new BdComun();
       static events obj = new events();
       static BarberoController br = new BarberoController();
        CitaController cit = new CitaController();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idcita.Visible =false;
            }


        }

        public void Unnamed_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName.Equals("eliminar"))
            {
               

                if (cit.delete_cita(idcita.Text.ToString())== true)
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
            string idbarbero = br.Consulta_id_barbero(HttpContext.Current.Session["login"].ToString());
            DataTable dt = br.Consultar_mis_citas_barbero(idbarbero);
            List<events> eve = new List<events>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                events a = new events();
                a.EventId = Convert.ToInt32(dt.Rows[i]["idcita"].ToString());
                a.Subject = Convert.ToString(dt.Rows[i]["Cliente"].ToString());
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
