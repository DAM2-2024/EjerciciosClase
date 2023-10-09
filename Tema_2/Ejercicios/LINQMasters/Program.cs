using System.Linq.Expressions;
using System.Numerics;

class Program
{

    static void Main(string[] args)
    {
        List<Persona> pipols = new();

        Persona persona= new Persona();
        persona.Nombre = "rafa";
        persona.DNI = "166334A";
        persona.Apellido = "jja";
        pipols.Add(persona);

        persona = new Persona();
        persona.Nombre = "rafa";
        persona.DNI = "166334B";
        persona.Apellido = "dumb";
        pipols.Add(persona);

        persona = new Persona();
        persona.Nombre = "rafa";
        persona.DNI = "166334B";
        persona.Apellido = "DOS";
        pipols.Add(persona);

        var resultado = from person in pipols
                                 group person by person.DNI into gPerson
                                 select new {Clave = gPerson.Key, Apellido=gPerson.Select(x=>x.Apellido).Last()};

        var dicciorio =resultado.ToDictionary(x => x.Clave, x => x);

        var error = pipols.ToDictionary(x => x.DNI, x => x.Apellido);

        Console.WriteLine(resultado);
    }

    class Persona
    {
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Apellido { get; set; }
    }
}

