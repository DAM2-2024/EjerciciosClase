using DungeonsAndDragonsCutre.Models;

namespace DungeonsAndDragonsCutre
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            /* Este es el que deberia estar por defecto
            FichaPersonaje fichaPersonaje = new FichaPersonaje();
            fichaPersonaje.ShowDialog();
            */
            Personaje personaje = Personaje.GetInstance();
            personaje.Suerte = 5;
            personaje.Fuerza= 5;
            personaje.Vida= 100;
            personaje.Naturaleza = Naturaleza.Evil;
            personaje.Raza = Raza.Humano;
            personaje.Name = "Konan";

            GameForm gameForm = new GameForm(personaje);
            Application.Run(gameForm);
        }
    }
}