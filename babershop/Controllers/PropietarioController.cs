using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class PropietarioController
    {

        Propietario pro = new Propietario();
        public DataTable traer_propitarios()
        {
            return pro.Consul_propieta();
        }


        public string Consult_id_propietario(string id_usu)
        {
            return pro.Consul_id_propietario(id_usu);
        }

        public DataTable consultar_barberias_propietarios(string id_usu)
        {
            return pro.consult_barberia_Actualizar(id_usu);
        }


        public DataTable Consultar_prpietarios_reportes()
        {
            return pro.Consul_propietarios_reportes();
        }


    }
}