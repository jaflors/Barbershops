using Admin.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Models
{
   
    public class Rol
    {
     BdComun con = new BdComun();

        public string traer_id_rol( string nombre_rol )
        {
            string sql = @"select idrol from rol where rol.Nombre= '"+nombre_rol+"';";
            DataTable dato = con.EjecutarConsulta(sql, CommandType.Text);
            return dato.Rows[0]["idrol"].ToString();



        }


    }
}