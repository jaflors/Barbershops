using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class CitaController
    {

         public Cita cit= new Cita();



        public CitaController()
        {
            cit = new Cita();
        }

        public CitaController(string a, string b, string c, string d, string e)
        {
            cit.p_barbero= a;
            cit.P_cliente= b;
            cit.p_fecha = c;
            cit.p_hora = d;
            cit.p_motivo = e;


        }

        public bool Cancelar_cita_cliente(string id_cita,string id_motivo)
        {
            return cit.Cancelar_Cita(id_cita,id_motivo);
        }


        public bool delete_cita(string idcita)
        {
            return cit.delete_cita(idcita);
        }
        public DataTable traer_cita_p(string pk)
        {

            return cit.traer_cita(pk);
        }

        public bool insert_cita (Cita obj)
        {

            return cit.RegistrarCita(obj);
        }

        public bool update_cita(Cita obj,string idcita)
        {
            return cit.Update_Cita(obj,idcita);
        }
        public DataTable traer_fecha_cita_hota(string barbero,string fecha ,string hora)
        {
            return cit.Consultar_fecha_horario(barbero,fecha,hora);
        }


       public DataTable motivo_ancelacion(string id_barbero)
        {
            return cit.consult_motivo_cita_cancelada(id_barbero);
        }
        public DataTable traer_citas_reportes(string fechaini, string fecha_fin)
        {
            return cit.consultar_detalle_citas(fechaini,fecha_fin);
        }

        public DataTable traer_baber()
        {
            return cit.traer_barber();
        }

        public DataTable traer_Client()
        {
            return cit.traer_Client();
        }
        public DataTable traer_hora()
        {
            return cit.traer_hora();
        }
        public DataTable traer_motivo()
        {
            return cit.traer_motivo();
        }

        public DataTable traer_motivo_cancelacion()
        {
            return cit.traer_motivo_cancelacion();
        }

        public DataTable traer_cita_Cliente(string pk_usuario)
        {

            return cit.consult_cita_cliente(pk_usuario);
        }


    }
}