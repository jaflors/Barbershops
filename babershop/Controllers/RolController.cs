using babershop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class RolController
    {

        Rol r = new Rol();

        public string cosul_rol(string nombre_rol)
        {
            return r.traer_id_rol(nombre_rol);
            
        }


    }
}