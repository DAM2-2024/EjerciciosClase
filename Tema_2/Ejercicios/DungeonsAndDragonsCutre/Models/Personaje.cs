using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragonsCutre.Models
{
    public class Personaje
    {
        public Raza Raza { get; set; }
        public Naturaleza Naturaleza { get; set; }
        public string Name { get; set; }
        public int Suerte { get; set; }
        public int Fuerza { get; set; }
        public int Vida { get; set; }

        private static Personaje _instance { get; set; }

        private Personaje()
        {
            
        }

        public static Personaje GetInstance()
        {
            if (_instance == null )
            {
                _instance= new Personaje();
            }
            return _instance;
        }
    }

    public enum Naturaleza
    {
        Good,
        Neutral,
        Evil
    }
    public enum Raza
    {
        Orco,
        Elfo,
        Humano,
        Enano
    }
}
