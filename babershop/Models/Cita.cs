using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class Cita
    {
        BdComun conn = new BdComun();


        public string p_barbero { get; set; }
        public  string P_cliente { get; set; }
        public string p_fecha { get; set; }
        public string p_hora { get; set; }
        public string p_motivo { get; set; }




        public DataTable Consultar_fecha_horario(string barbero,string fecha,string id_hora)
        {

            string sql = @"SELECT cita.Barbero_idBarbero,cita.fecha,cita.Horario_idHorario FROM cita WHERE cita.Barbero_idBarbero='" + barbero + "' and cita.fecha='"+fecha+"' and cita.Horario_idHorario='"+id_hora+"';";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public bool RegistrarCita(Cita obj)
        {
            Parameter[] para = new Parameter[5];

            para[0] = new Parameter("p_barbero", obj.p_barbero);
            para[1] = new Parameter("P_cliente", obj.P_cliente);
            para[2] = new Parameter("p_fecha", obj.p_fecha);
            para[3] = new Parameter("p_hora", obj.p_hora);
            para[4] = new Parameter("p_motivo", obj.p_motivo);
           



            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert_cita", para);
            return conn.Transaction(trans);


        }








        public bool Update_Cita(Cita obj,string idcita)
        {
            Parameter[] para = new Parameter[6];

            para[0] = new Parameter("p_barbero", obj.p_barbero);
            para[1] = new Parameter("P_cliente", obj.P_cliente);
            para[2] = new Parameter("p_fecha", obj.p_fecha);
            para[3] = new Parameter("p_hora", obj.p_hora);
            para[4] = new Parameter("p_motivo", obj.p_motivo);
            para[5] = new Parameter("p_idcita", idcita);




            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("update_cita", para);
            return conn.Transaction(trans);


        }

        public bool Cancelar_Cita(string id_cita, string id_motivo)
        {
            Parameter[] para = new Parameter[2];

            para[0] = new Parameter("p_id_cita", id_cita);
            para[1] = new Parameter("p_id_motivo_cancela", id_motivo);
          
            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("cancelar_cita", para);
            return conn.Transaction(trans);


        }




        public bool delete_cita(string idcita)
        {

            

            string[] sql = new string[1];
            sql[0] = @"DELETE FROM babershop.cita WHERE idcita='" + idcita + "'; ";
            return conn.RealizarTransaccion(sql);
        }


        public DataTable consult_cita()
        {


            string sql = @"SELECT cit.idcita, concat(cl.nombres,' ',cl.apellidos)as Cliente, DATE_FORMAT(cit.fecha,'%d/%m/%Y') as Fecha,
            h.hora as Hora,m.descripcion as Servicio,concat(barbe.nombres,'',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I' ;";


            return conn.EjecutarConsulta(sql, CommandType.Text);


        }

        public DataTable consult_motivo_cita_cancelada(string id_barbero)
        {


            string sql = @"SELECT  concat(cl.nombres,' ',cl.apellidos)as Cliente, mtc.nombre as motivo,ccit.fecha
			FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            INNER JOIN cancelacion_cita AS ccit ON cit.idcita=ccit.cita_idcita
            INNER JOIN motivo_cancelacion AS mtc ON mtc.idmotivo_cancelacion=ccit.motivo_cancelacion_idmotivo_cancelacion
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario where ba.idBarbero='"+ id_barbero + "';";


            return conn.EjecutarConsulta(sql, CommandType.Text);


        }






        public DataTable consult_cita_cliente(string id_usuario)
        {


            string sql = @"SELECT cit.idcita, concat(cl.nombres,' ',cl.apellidos)as Cliente, DATE_FORMAT(cit.fecha,'%d/%m/%Y') as Fecha,
		    h.Hora ,m.descripcion as Servicio,concat(barbe.nombres,'',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I'and cl.idUsuario='"+ id_usuario+"' and Fecha >=CURDATE() and cit.estado='I' ;";


            return conn.EjecutarConsulta(sql, CommandType.Text);


        }



        public DataTable consultar_detalle_citas(string fecha_ini, string fecha_fin)
        {
            string sql = @"SELECT cit.idcita, concat(cl.nombres,' ',cl.apellidos)as Cliente, DATE_FORMAT(cit.fecha,'%d/%m/%Y') as Fecha,
            h.hora as Hora,m.descripcion as Servicio,concat(barbe.nombres,'',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I' and cit.fecha BETWEEN '"+fecha_ini+"' AND '"+fecha_fin+"' order by cit.fecha;";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }








        public DataTable traer_cita(string pk_cita)
        {


            string sql = @"SELECT concat(cl.nombres,' ',cl.apellidos)as Cliente,DATE_FORMAT(cit.fecha,'%d/%m/%Y') as Fecha,
            TIME_FORMAT(h.Hora,'%h:%i %p') as hora,m.descripcion as Servicio,concat(barbe.nombres,' ',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I' and cit.idcita= '" + pk_cita + "';";


            return conn.EjecutarConsulta(sql, CommandType.Text);


        }
        public DataTable traer_barber()
        {

            string sql = @"select concat(u.nombres, ' ', u.apellidos) as nombres, b.idBarbero from usuario as u
            inner join barbero as b on b.usuario_idUsuario = u.idusuario
            where u.estado = 'A'; ";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable traer_Client()
        {

            string sql = @"select concat(u.nombres,' ',u.apellidos) as nombres, c.idCliente from usuario as u 
            inner join cliente as c on c.usuario_idUsuario = u.idusuario
            where u.estado='A';";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable traer_hora()
        {

            string sql = @"select h.idHorario,TIME_FORMAT(h.Hora,'%h:%i %p') as hora from horario as h where h.estado='A';";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }


        public DataTable traer_motivo()
        {

            string sql = @"select idmotivo,descripcion from motivo ;";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }


        public DataTable traer_motivo_cancelacion()
        {

            string sql = @"SELECT idmotivo_cancelacion, nombre FROM babershop.motivo_cancelacion;";
            return conn.EjecutarConsulta(sql, CommandType.Text);

        }
    }
}