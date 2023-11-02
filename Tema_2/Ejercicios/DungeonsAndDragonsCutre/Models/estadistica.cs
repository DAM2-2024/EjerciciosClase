using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragonsCutre.Models
{
    internal class Estadistica
    {
        public int Max_Dealt_Damage { get; set; }
        public int Min_Dealt_Damage { get; set; }
        public int Max_Recieved_Damage { get; set; }
        public int Min_Recieved_Damage { get; set; }

        private readonly DateTime tiempoInicio;
        public double TiempoJugado { 
            get
            {
                return  (DateTime.Now - tiempoInicio).TotalSeconds;
            }
        }
        public Estadistica()
        {
            tiempoInicio = DateTime.Now;
        }

    }
}
