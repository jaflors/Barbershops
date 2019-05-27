using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class Barbero
    {

        BdComun conn = new BdComun();
        public string p_nombre { get; set; }
        public string p_apellidos { get; set; }

        public string p_correo { get; set; }
        public string p_contrasena { get; set; }
        public string p_recontrasena { get; set; }

        public bool insertbarber(Barbero obj,string id_barberia)
        {
            Parameter[] para = new Parameter[6];

            para[0] = new Parameter("p_nombre", obj.p_nombre);
            para[1] = new Parameter("p_apellidos", obj.p_apellidos);
            para[2] = new Parameter("p_correo", obj.p_correo);
            para[3] = new Parameter("p_contrasena", obj.p_contrasena);
            para[4] = new Parameter("p_recontrasena", obj.p_recontrasena);
            para[5] = new Parameter("Id_barberia", id_barberia);


            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert_barbero", para);
            return conn.Transaction(trans);


        }



        public DataTable ConsulBarbero_propieta()
        {
            string sql = @"SELECT u.idUsuario, u.nombres, u.apellidos,u.estado,b.nombre FROM usuario as u
            inner join barbero on u.idusuario=barbero.usuario_idUsuario
            inner join barberia as b on barbero.barberia_idbarberia=idbarberia where u.estado='A';  ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }


        public DataTable consult_cita_agenda(string id_barbero)
        {


            string sql = @"SELECT cit.idcita, concat(cl.nombres,' ',cl.apellidos)as Cliente,concat(DATE_FORMAT(cit.fecha,'%d/%m/%Y'),' ',h.hora) as  Fecha, 
			m.descripcion as Servicio,concat(barbe.nombres,'',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I' and ba.idBarbero='"+ id_barbero+"' ;";


            return conn.EjecutarConsulta(sql, CommandType.Text);


        }

        public DataTable consult_cita_mis_citas(string id_barbero)
        {


            string sql = @"SELECT cit.idcita, concat(cl.nombres,' ',cl.apellidos)as Cliente,DATE_FORMAT(cit.fecha,'%d/%m/%Y') as Fecha,
		    h.Hora , 
			m.descripcion as Servicio,concat(barbe.nombres,'',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I' and ba.idBarbero='"+id_barbero+"' and Fecha >=CURDATE() and cit.estado='I' ;";


            return conn.EjecutarConsulta(sql, CommandType.Text);


        }



        public DataTable ConsulBarberos()
        {
            string sql = @"SELECT u.idUsuario, u.nombres, u.apellidos,u.estado,b.nombre FROM usuario as u
            inner join barbero on u.idusuario=barbero.usuario_idUsuario
            inner join barberia as b on barbero.barberia_idbarberia=idbarberia;  ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }
        public DataTable ConsulBarberos_propietario_2(string id_barberia)
        {
            string sql = @"SELECT u.idUsuario, u.nombres, u.apellidos,u.estado,b.nombre FROM usuario as u
            inner join barbero on u.idusuario=barbero.usuario_idUsuario
            inner join barberia as b on barbero.barberia_idbarberia=idbarberia where u.estado='A'and b.idbarberia= '" + id_barberia + "';  ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }
        public DataTable ConsulBarbero_propietario(string id_barberia)
        {
            string sql = @"SELECT  barbero.idBarbero,  u.idUsuario,concat(u.nombres, ' ', u.apellidos) as nombres, u.estado, b.nombre FROM usuario as u
            inner join barbero on u.idusuario= barbero.usuario_idUsuario
            inner join barberia as b on barbero.barberia_idbarberia= idbarberia where u.estado= 'A'and b.idbarberia='"+id_barberia+"'; ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }


        public string Consul_id_barbero(string obj)
        {
            string sql = @"SELECT barbero.idBarbero FROM usuario 
           INNER JOIN barbero ON usuario.idUsuario=barbero.usuario_idUsuario 
           WHERE usuario.idUsuario='"+obj+"'; ";
            DataTable data = conn.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idBarbero"].ToString();
        }



    }
}