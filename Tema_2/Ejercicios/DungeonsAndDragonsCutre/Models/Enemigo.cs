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
            Random random = new Random();
            Vida=random.Next(5, 21);
            Fuerza= random.Next(1, 6); 
        }

        public static List<string> GetPathEnemies()
        {
            string[] imagenes = Directory.GetFiles(Constants.ENEMIES_PATH);
            return new List<string>(imagenes);
        }
    }
}
