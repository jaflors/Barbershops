using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class Barberia
    {
        BdComun con = new  BdComun();

        public string Nombre_barberia { get; set; }
        public string Direccion { get; set; }


        public bool insertbarberia(Barberia obj, string id_propietario,string imagen)
        {
            Parameter[] para = new Parameter[4];

            para[0] = new Parameter("p_nombre_barberia", obj.Nombre_barberia);
            para[1] = new Parameter("p_direccion", obj.Direccion);
            para[2] = new Parameter("p_propietario", id_propietario);
            para[3] = new Parameter("p_imagen", imagen);
            

            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert_barberia", para);
            return con.Transaction(trans);


        }




        public bool Cambiar_estado_barber(string id_bar)
        {
            string[] sql = new string[1];
            sql[0] = "UPDATE barberia SET estado='I' WHERE idbarberia='" + id_bar + "'; ";
            return con.RealizarTransaccion(sql);
        }

        public bool Cambiar_estado_barber_Actualizar(string id_bar)
        {
            string[] sql = new string[1];
            sql[0] = "UPDATE barberia SET estado='A' WHERE idbarberia='" + id_bar + "'; ";
            return con.RealizarTransaccion(sql);
        }


        public DataTable consult_barberia_registro_barbero(string idusuario)
        {

            string sql = @"select b.idbarberia,b.nombre as 'Nombre Barberia' from usuario 
                inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
                inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
                WHERE b.estado ='A' and usuario.idUsuario='"+ idusuario + "';";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }



        public DataTable traer_barberia_info(string idbarberia)
        {


            string sql = @"select b.nombre as 'Nombre Barberia',b.direccion as dirección,b.idbarberia,g.Foto,
            concat(nombres,' ',apellidos) as 'Propietario' from usuario 
            inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
            inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
            inner join barberia_galeria as bg on b.idbarberia=bg.fk_idbarberia
            inner join galeria as g on g.idgaleria=bg.fk_idgaleria
            WHERE  b.idbarberia='"+idbarberia+"';";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }

        public DataTable consult_mis_barberias(string idusuario)
        {


            string sql = @"select b.idbarberia,b.nombre as 'Nombre Barberia',b.direccion as dirección,
            ga.Foto from usuario 
            inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
            inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
            inner join barberia_galeria as bg on b.idbarberia= bg.fk_idbarberia
            inner join galeria as ga on bg.fk_idGaleria=ga.idGaleria
            WHERE b.estado ='A' and usuario.idUsuario='"+ idusuario + "' ;";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }


        public DataTable consult_barberia_Actualizar()
        {


            string sql = @"select b.idbarberia,b.estado,b.nombre as 'Nombre Barberia',b.direccion as dirección,
                concat(nombres,' ',apellidos) as 'Propietario' from usuario 
                inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
                inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
                WHERE b.estado ='I' ;	";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }
        public DataTable consult_barberia() {
            

                string sql = @"select b.idbarberia,b.nombre as 'Nombre Barberia',b.direccion as dirección,
                concat(nombres,' ',apellidos) as 'Propietario' from usuario 
                inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
                inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
                WHERE b.estado ='A' ;	";


                return con.EjecutarConsulta(sql, CommandType.Text);


            }


        public DataTable consult_mi_barberia(string id_usuario)
        {


            string sql = @"select b.nombre as 'Nombre Barberia',b.direccion as dirección,b.idbarberia,g.Foto,
            concat(nombres,' ',apellidos) as 'Propietario' from usuario 
            inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
            inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
            inner join barberia_galeria as bg on b.idbarberia=bg.fk_idbarberia
            inner join galeria as g on g.idgaleria=bg.fk_idgaleria
            WHERE b.estado ='A' and  usuario.idUsuario='" + id_usuario + "';	";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }
        public DataTable consult_barerias_cliente()
        {


            string sql = @"select b.nombre as 'Nombre Barberia',b.direccion as dirección,b.idbarberia,g.Foto,
            concat(nombres,' ',apellidos) as 'Propietario' from usuario 
            inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
            inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
            inner join barberia_galeria as bg on b.idbarberia=bg.fk_idbarberia
            inner join galeria as g on g.idgaleria=bg.fk_idgaleria where b.estado='A';		";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }





        public DataTable consul_bar()
        {
            string sql = @"SELECT idbarberia,nombre,direccion,estado,fk_idPropietario from barberia where barberia.estado='A';";
            return con.EjecutarConsulta(sql, CommandType.Text);
        }

        
        public string Consul_idbar(string obj)
        {
            string sql = "SELECT idbarberia FROM barberia where barberia.nombre='" + obj + "';";
            DataTable data = con.EjecutarConsulta(sql, CommandType.Text);
            return data.Rows[0]["idbarberia"].ToString();
        }

        public DataTable consult_barerias_propietario_eliminar(string idusu)
        {


            string sql = @"select b.idbarberia,b.estado,b.nombre as 'Nombre Barberia',b.direccion as dirección from usuario 
                inner join propietario on usuario.idusuario=propietario.usuario_idUsuario
                inner join barberia  as b on propietario.idPropietario=b.fk_idPropietario
                WHERE b.estado ='A' AND usuario.idUsuario='" + idusu + "';	";


            return con.EjecutarConsulta(sql, CommandType.Text);


        }
    }
}