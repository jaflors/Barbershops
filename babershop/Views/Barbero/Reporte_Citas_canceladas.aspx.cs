using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Barbero
{
    public partial class Reporte_Citas_canceladas : System.Web.UI.Page
    {

        public DataTable dtConsul;
        public DataRow drConsul;
        public CitaController cit = new CitaController();
        public BarberoController br = new BarberoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idbarbero = br.Consulta_id_barbero(Session["login"].ToString());
                Session["idbarbero_cancelacion"] = idbarbero;
                dtConsul = cit.motivo_ancelacion(idbarbero);
                if (dtConsul.Rows.Count > 0)
                {
                    drConsul = dtConsul.Rows[0];

                }


            }

        }
    }
}