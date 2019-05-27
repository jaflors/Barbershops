using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class ClienteController
    {

        cliente cli = new cliente();

        public string traer_id_cliente(string id_usu)
        {
          return cli.Consul_id_cliente_cita(id_usu);
        }


        public DataTable consultar_agenda(string id_cliente)
        {
            return cli.consult_cita_agenda_cliente(id_cliente);
        }
        public string consul_id_cliente(string id)
        {
            return cli.Consul_id_cliente_cita(id);
        }




    }
}