using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class Propietario
    {




        BdComun con = new BdComun();



        public DataTable Consul_propieta()
        {
            string sql = @"select pr.idPropietario as idpro,concat(u.nombres, ' ', u.apellidos) as nombres from rol as r
            inner join usuario_rol as ur on r.idrol = ur.rol_idrol 
            inner join usuario as u on ur.Usuario_idUsuario= u.idusuario 
            inner join propietario as pr on pr.usuario_idUsuario= u.idusuario
            WHERE u.estado ='A';  ";

            return con.EjecutarConsulta(sql, CommandType.Text);

        }


        public DataTable Consul_propietarios_reportes()
        {
            string sql = @"SELECT u.idUsuario, u.nombres, u.apellidos,u.estado,b.nombre FROM usuario as u
            inner join barbero on u.idusuario=barbero.usuario_idUsuario
            inner join barberia as b on barbero.barberia_idbarberia=idbarberia where u.estado='A';  ";

            return con.EjecutarConsulta(sql, CommandType.Text);

        }






        public DataTable InsertarUsuario(Usuario obj)
        {
            string sql = "INSERT INTO usuario (nombres,apellidos,correo,contrasena,recontrasena) VALUES('" + obj.p_nombre + "','" + obj.p_apellidos + "','" + obj.p_correo + "','" + obj.p_contrasena + "','" + obj.p_recontrasena + "'))";
            return con.EjecutarConsulta(sql, CommandType.Text);

        }

        public string Consul_id_propietario(string obj)
        {
            string sql = @"select pr.idPropietario as idpro from rol as r
            inner join usuario_rol as ur on r.idrol = ur.rol_idrol
            inner join usuario as u on ur.Usuario_idUsuario = u.idusuario
            inner join propietario as pr on pr.usuario_idUsuario = u.idusuario
            WHERE u.estado = 'A'and u.idUsuario = '"+obj+"' ";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idpro"].ToString();
        }


        public DataTable consult_barberia_Actualizar(string id_usuario)
        {


            string sql = @"select b.idbarberia,b.estado,b.nombre as 'Nombre Barberia',b.direccion as dirección,
                concat(nombres,' ',apellidos) as 'Propietario' from usuario 
                inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
                inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
                WHERE b.estado ='A' AND usuario.idUsuario='"+id_usuario+"';	";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }






    }
}