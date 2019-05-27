using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class cliente
    {
        BdComun con = new BdComun();



        public string Consul_id_cliente_cita(string obj)
        {
            string sql = @"SELECT cliente.idCliente FROM usuario 
           INNER JOIN cliente ON usuario.idUsuario=cliente.usuario_idUsuario 
           WHERE usuario.idUsuario='"+obj+"'; ";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idCliente"].ToString();
        }
        public DataTable consult_cita_agenda_cliente(string id_cliente)
        {


            string sql = @"SELECT cit.idcita,b.nombre as bareria,concat(DATE_FORMAT(cit.fecha,'%d/%m/%Y'),' ',h.hora) as  Fecha, 
			m.descripcion as Servicio,concat(barbe.nombres,'',barbe.apellidos)as Barbero,
            b.nombre as Barberia FROM usuario as cl
            inner join cliente as clien on cl.idUsuario=clien.usuario_idUsuario
            inner join cita as cit on clien.idCliente= cit.Cliente_idCliente
            inner join horario as h on h.idHorario=cit.Horario_idHorario
            inner join motivo as m on m.idmotivo=cit.motivo_idmotivo
            inner join barbero as ba  on ba.idBarbero= cit.Barbero_idBarbero
            inner join barberia as b on b.idbarberia=ba.barberia_idbarberia
            inner join usuario as barbe on ba.usuario_idUsuario=barbe.idusuario
            WHERE cit.estado='I' and clien.idCliente='" + id_cliente+"' and cit.fecha>=CURDATE() ;";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }

        public string Consul_id_client(string obj)
        {
            string sql = @"SELECT cliente.idCliente FROM usuario 
           INNER JOIN cliente ON usuario.idUsuario=cliente.usuario_idUsuario 
           WHERE usuario.idUsuario='" + obj + "'; ";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idCliente"].ToString();
        }


    }
}