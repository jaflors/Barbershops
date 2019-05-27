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
    public partial class Consultar_propietarios : System.Web.UI.Page
    {


        public DataTable dtConsulta = new DataTable();
        public DataRow drConsulta;
       PropietarioController usu = new PropietarioController();
        protected void Page_Load(object sender, EventArgs e)
        {




            dtConsulta = usu.Consultar_prpietarios_reportes();

            if (dtConsulta.Rows.Count > 0)
            {
                drConsulta = dtConsulta.Rows[0];
            }

        }






    }
}