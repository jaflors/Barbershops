using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class BarberoController
    {
        public Barbero barber = new Barbero();


        public BarberoController()
        {
            barber = new Barbero();

        }

        public BarberoController(string a, string b, string c, string d, string e)
        {
            barber.p_nombre = a;
            barber.p_apellidos = b;
            barber.p_correo = c;
            barber.p_contrasena = d;
            barber.p_recontrasena = e;

        }

        public bool Insertar_barbero(Barbero obj,string id_barberia)
        {
            return barber.insertbarber(obj,id_barberia);
        }

        public DataTable Consultar_barberos()
        {
            return barber.ConsulBarberos();
        }

        public DataTable Consultar_barberos_propietari(string id_barberia)
        {
            return barber.ConsulBarbero_propietario(id_barberia);
        }


        public DataTable Consultar_mis_citas_barbero(string id_barbero)
        {
            return barber.consult_cita_agenda(id_barbero);
        }


        public DataTable Consultar_mis_citas_eliminar(string id_barbero)
        {
            return barber.consult_cita_mis_citas(id_barbero);
        }
        public string Consulta_id_barbero(string id_usu)
        {
            return barber.Consul_id_barbero(id_usu);
        }


        public DataTable Consultar_barberos_propietari2(string id_barberia)
        {
            return barber.ConsulBarberos_propietario_2(id_barberia);
        }

      













    }
}