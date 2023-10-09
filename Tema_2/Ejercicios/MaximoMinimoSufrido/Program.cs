using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        string cadena;
        string[] cadenaSeparada;
        do
        {
            Console.WriteLine("Escribe una lista de números separada por comas");
            cadena = Console.ReadLine() ?? string.Empty;
            cadenaSeparada = cadena?.Split(",") ?? Array.Empty<string>();
        } while (!SonTodoNumeros(cadenaSeparada));

        int numeroActual = int.MinValue;
        int numeroMax = int.MinValue;
        int numeroMin = int.MaxValue;
        foreach (string element in cadenaSeparada)
        {
            numeroActual = int.Parse(element);
            if (numeroActual> numeroMax)
            {
                numeroMax = numeroActual;
            }
            if (numeroActual<numeroMin)
            {
                numeroMin = numeroActual;
            }
        }
        Console.WriteLine($"Minimo: {numeroMin}");
        Console.WriteLine($"Maximo: {numeroMax}");
    }
    private static bool SonTodoNumeros(string[] array)
    {
        int numero = 0;
        foreach (string cadena in array)
        {
            if (!int.TryParse(cadena, out numero))
            {
                return false;
            }
        }
        return true;
    }
}

