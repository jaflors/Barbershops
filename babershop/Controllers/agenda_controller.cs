using babershop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace babershop.Controllers
{
    public class agenda_controller
    {
        public agenda obj = new agenda();
        public List<agenda> Calendario()
        {

            DataTable calendario1 = obj.TraerEvento();
            List<agenda> eve = new List<agenda>();
            for (int i = 0; i < calendario1.Rows.Count; i++)
            {
                agenda a = new agenda();
                a.p_nombre = calendario1.Rows[i]["Barberia"].ToString();
                a.fecha = DateTime.Parse(calendario1.Rows[i]["Fecha"].ToString());
                eve.Add(a);
            }

            return eve;
        }






    }
}