using babershop.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace babershop.Views.Reportes
{
    public partial class Vista_reporte : System.Web.UI.Page
    {
        CitaController cit = new CitaController();
        PropietarioController pro = new PropietarioController();
        BarberoController br = new BarberoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string tipo = Request.Params["tipo"].ToString();
            this.generarReporte(tipo);
        }
        public void generarReporte(string tipo)
        {
            switch (tipo)
            {
                case "1":
                    DataTable eventos = cit.traer_citas_reportes(Session["fecha_inicio"].ToString(), Session["fecha_fin"].ToString());
                    Citas_detalles reporte = new Citas_detalles();
                    reporte.SetDataSource(eventos);
                    CrystalReportViewer1.ReportSource = reporte;
                    CrystalReportViewer1.DataBind();

                    break;
                case "2":
                    DataTable propietarios = pro.Consultar_prpietarios_reportes();
                    propietarios reporte1 = new propietarios();
                    reporte1.SetDataSource(propietarios);
                    CrystalReportViewer1.ReportSource = reporte1;
                    CrystalReportViewer1.DataBind();


                    break;
                case "3":
                    DataTable motivos = cit.motivo_ancelacion(Session["idbarbero_cancelacion"].ToString());
                    cancelacion_barbero reporte2 = new cancelacion_barbero();
                    reporte2.SetDataSource(motivos);
                    CrystalReportViewer1.ReportSource = reporte2;
                    CrystalReportViewer1.DataBind();



                    break;
                case "4":

                    break;

                case "5":

                    break;


            }
        }



    }
}