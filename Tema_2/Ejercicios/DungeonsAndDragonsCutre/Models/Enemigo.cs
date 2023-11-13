using DungeonsAndDragonsCutre.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragonsCutre.Models
{
    public class Enemigo
    {
        public string Nombre { get; set; }
        public int Fuerza { get; set; }
        public int Vida { get; set; }
        public string Path { get; set; }

        public Enemigo()
        {
            
        }
    }
}
