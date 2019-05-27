using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class UsuarioController
    {
        public Usuario usu = new Usuario();

        public UsuarioController()
        {
            usu = new Usuario();
        }

        public UsuarioController(string a,string b, string c, string d,string e)
        {
            usu.p_nombre = a;
            usu.p_apellidos = b;
            usu.p_correo = c;
            usu.p_contrasena = d;
            usu.p_recontrasena = e;
        
        }

        public bool Insertar(Usuario obj)
        {
            return usu.insertusu(obj);
        }

        public bool Insertar_propietario_pri(Usuario obj)
        {
            return usu.insert_propietario_princi(obj);
        }

        public DataTable consultarNombreRol(string pk_usuario)
        {
            return usu.ConsulNombreRol(pk_usuario);
        }

        public DataTable Traer_usuario(string pk_usu)
        {
            return usu.Traer_usuario(pk_usu);
        }

        public bool actualizar_usu(string a, string b, string c, string d, string e, string f)
        {
            return usu.update_usu(a, b, c, d, e, f);
        }
        public bool actualizar_barbero_admin(string a, string b, string c, string d, string e, string f,string g)
        {
            return usu.update_barbero_admin(a, b, c, d, e, f,g);
        }

        public bool cambiar_estado_usu (string pk)
        {
            return usu.Cambiar_estado_usu(pk);

        }

      
    }
}