using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
    public class Usuario
    {
        BdComun conn = new BdComun();
        public string p_nombre { get; set; }
        public string p_apellidos { get; set; }
     
        public string p_correo { get; set; }
        public string p_contrasena { get; set; }
        public string p_recontrasena { get; set; }

        public bool insertusu(Usuario obj)
        {
            Parameter[] para = new Parameter[5];

            para[0] = new Parameter("p_nombre", obj.p_nombre);
            para[1] = new Parameter("p_apellidos", obj.p_apellidos);
            para[2] = new Parameter("p_correo", obj.p_correo);
            para[3] = new Parameter("p_contrasena", obj.p_contrasena);
            para[4] = new Parameter("p_recontrasena", obj.p_recontrasena);
         

            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert_usuario", para);
            return conn.Transaction(trans);


        }


        public bool insert_propietario_princi (Usuario obj)
        {
            Parameter[] para = new Parameter[5];
            para[0] = new Parameter("p_nombre", obj.p_nombre);
            para[1] = new Parameter("p_apellidos", obj.p_apellidos);
            para[2] = new Parameter("p_correo", obj.p_correo);
            para[3] = new Parameter("p_contrasena", obj.p_contrasena);
            para[4] = new Parameter("p_recontrasena", obj.p_recontrasena);
            



            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("insert_Propietario", para);
            return conn.Transaction(trans);

        }

        public DataTable ConsultarCuenta(Usuario obj)
        {

            string sql = "SELECT * FROM usuario WHERE correo='" + obj.p_correo + "'AND contrasena=md5('" + obj.p_contrasena + "') ;";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }



        public DataTable consultarMenu(string idCuenta)
        {
            string sql = @"select menu.`idmenu`,menu.titulo,menu.icono,vista.idvista,vista.nombre,vista.url,vista.icono,vista.menu_idmenu  from menu 
                         inner join vista on menu.`idmenu`=vista.menu_idmenu
                         inner join rol_vista on vista.idVista=rol_vista.vista_idVista
                         inner join rol on rol.idrol=rol_vista.rol_idrol
                         inner join usuario_rol on usuario_rol.rol_idrol=rol.idrol
                         inner join usuario on usuario.idUsuario=usuario_rol.Usuario_idUsuario 
                         where usuario.idUsuario= '" + idCuenta+ "';";

            return conn.EjecutarConsulta(sql, CommandType.Text);
        }

        public DataTable ConsulNombreRol(string pk_usuario)
        {
            string sql = @"select Nombre from rol
	        inner join usuario_rol as ur on ur.rol_idRol= rol.idRol
	        inner join usuario on usuario.idusuario= ur.Usuario_idUsuario
	        where  usuario.idusuario= '"+pk_usuario+"';";
            return conn.EjecutarConsulta(sql, CommandType.Text);
        }


        public DataTable ConsulUsuarios()
        {
            string sql = @"select u.nombres,u.apellidos,r.Nombre,u.estado,u.idUsuario from usuario as u
            inner join usuario_rol as ur on u.idUsuario=ur.Usuario_idUsuario
            inner join rol as r on  r.idrol= ur.rol_idrol where u.estado='A';    ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }

        public DataTable Traer_usuario(string pk_usuario)
        {
            string sql = @" select u.nombres,u.apellidos,u.correo,u.contrasena,r.Nombre,u.estado from usuario as u
            inner join usuario_rol as ur on u.idUsuario=ur.Usuario_idUsuario
            inner join rol as r on  r.idrol= ur.rol_idrol WHERE u.idUsuario='"+ pk_usuario + "';  ";

            return conn.EjecutarConsulta(sql, CommandType.Text);

        }



        public bool Cambiar_estado_usu(string pk)
        {
            string[] sql = new string[1];
            sql[0] = "UPDATE usuario SET estado='I' WHERE idUsuario='" + pk + "'; ";
            return conn.RealizarTransaccion(sql);
        }


        public bool update_usu(string nombre, string apellido, string correo, string contrasena, string pk_usu, string idrol)
        {
            Parameter[] para = new Parameter[6];
            para[0] = new Parameter("p_nombre", nombre);
            para[1] = new Parameter("p_apellido", apellido);
            para[2] = new Parameter("p_correo", correo);
            para[3] = new Parameter("p_contrasena", contrasena);
            para[4] = new Parameter("p_idusuario", pk_usu);
            para[5] = new Parameter("p_idrol", idrol);

            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("update_uauario", para);
            return conn.Transaction(trans);



        }

        public bool update_barbero_admin(string nombre, string apellido, string correo, string contrasena,string estado ,string pk_usu, string idbarberia)
        {
            Parameter[] para = new Parameter[7];
            para[0] = new Parameter("p_nombre", nombre);
            para[1] = new Parameter("p_apellido", apellido);
            para[2] = new Parameter("p_correo", correo);
            para[3] = new Parameter("p_contrasena", contrasena);
            para[4] = new Parameter("p_estado",estado);
            para[5] = new Parameter("p_idusuario", pk_usu);
            para[6] = new Parameter("p_idBarberia", idbarberia);

            Transaction[] trans = new Transaction[1];
            trans[0] = new Transaction("update_barbero", para);
            return conn.Transaction(trans);



        }






    }
}