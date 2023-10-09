using System.Numerics;

class Program
{

    static void Main(string[] args)
    {

        List<Persona> nuevaLista = new();

        Persona persona = new Persona();
        persona.Nombre = "Rafa";

        nuevaLista.Add(persona);
        nuevaLista.Add(persona);

        persona.Nombre = "Javier";

        persona = new Persona();

        persona.Nombre = "Pedro";
        nuevaLista.Add(persona);

        Console.WriteLine("Hola");

    }

    class Persona
    {
        public string Nombre {get;set;}
        public string Apellido { get; set; }
    }
}

