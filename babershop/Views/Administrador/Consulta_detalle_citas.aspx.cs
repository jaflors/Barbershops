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
    public partial class Consulta_detalle_citas : System.Web.UI.Page
    {
        public DataTable dtConsul = new DataTable();
        public DataRow drConsul;
        public CitaController cit = new CitaController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Consultar(object sender, EventArgs e)
        {

            Session["fecha_inicio"] = fecha_inicio.Value.ToString();
            Session["fecha_fin"] = fecha_fin.Value.ToString();
            dtConsul =cit.traer_citas_reportes (fecha_inicio.Value.ToString(), fecha_fin.Value.ToString());


            if (dtConsul.Rows.Count > 0)
            {
                drConsul = dtConsul.Rows[0];

            }
        }


    }
}