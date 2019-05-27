using Admin.Conexion;
using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class BarberiaControllers
    {

       public Barberia bar = new Barberia();

       public BarberiaControllers()
        {
            bar = new Barberia();
        }

        public BarberiaControllers(string a, string b)
        {
            bar.Nombre_barberia = a;
            bar.Direccion = b;
        }
        public bool cambiar_estado_barberia(string id_barberia)
        {
            return bar.Cambiar_estado_barber(id_barberia);
        }

        public bool cambiar_estado_barberia_activar(string id_barberia)
        {
            return bar.Cambiar_estado_barber_Actualizar(id_barberia);
        }


        public DataTable traer_mis_barberias(string idusuario)
        {
            return bar.consult_mi_barberia(idusuario);
        }

        public DataTable traer_barberias_actualizar()
        {
            return bar.consult_barberia_Actualizar();
        }


        public bool Insertar_barberia(Barberia obj, string id_propietario,string imagen)
        {
            return bar.insertbarberia(obj, id_propietario, imagen);
        }


        public string Consult_idbar( string nombre_bar)
        {
            return bar.Consul_idbar(nombre_bar);
        }

        public DataTable traer_barberias()
        {
            return bar.consul_bar();
        }



        public DataTable traer_mi_barberia(string id_usu)
        {
            return bar.consult_mi_barberia(id_usu);
        }



        public DataTable traer_barberia_info(string id_barberia)
        {
            return bar.traer_barberia_info(id_barberia);
        }

        public DataTable traer_barberia_registro_barero(string id_usuario)
        {
            return bar.consult_barberia_registro_barbero(id_usuario);
        }

        public DataTable traer_barberias_clientes()
        {
            return bar.consult_barerias_cliente();
        }

        public DataTable traer_barberias_propietario_eliminar(string idusu)
        {
            return bar.consult_barerias_propietario_eliminar(idusu);
        }


    }
}