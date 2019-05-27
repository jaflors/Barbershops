using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class agenda
    {

        BdComun conn = new BdComun();


        public string p_nombre { get; set; }
        public string p_descripcion { get; set; }
        public string p_fecha_creacion { get; set; }
        public DateTime fecha;
        public string p_fecha_fin { get; set; }
        public string p_hora { get; set; }





        public DataTable TraerEvento()
        {
            string sql = @" SELECT cit.idcita, concat(cl.nombres,' ',cl.apellidos)as Cliente, DATE_FORMAT(cit.fecha,'%d/%m/%Y') as Fecha,
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


    }
}