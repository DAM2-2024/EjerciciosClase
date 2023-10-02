using System.Data;
using System.Text;

class Program
{
    private const int DESPLAZAMIENTO= 3;
    static void Main(string[] args)
    {
        Console.WriteLine("Escribe un mensaje");
        string cadena= Console.ReadLine() ?? string.Empty;
        cadena= cadena.ToUpper();
        List<char> abecedario = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();
        int indice = int.MinValue;
        StringBuilder builder = new StringBuilder();
        foreach (var caracter in cadena)
        {
            indice= abecedario.IndexOf(caracter);
            if (indice != -1)
            {
                builder.Append(abecedario[(indice + DESPLAZAMIENTO) % abecedario.Count]);
            }
        }
        Console.WriteLine($"El resultado es {builder}");
    }
}



