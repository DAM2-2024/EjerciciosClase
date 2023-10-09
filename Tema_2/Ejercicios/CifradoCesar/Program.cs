using System.Collections.Generic;
using System.Data;
using System.Text;

class Program
{
    private const int DESPLAZAMIENTO = 3;
    static void Main(string[] args)
    {
        string cadena = File.ReadAllText("el_quijote.txt");
        List<char> caracteresDistintos = cadena.ToCharArray().Distinct().ToList();
        Dictionary<char, int> diccionarioRepeticiones = new Dictionary<char, int>();
        caracteresDistintos.ForEach(caracter =>
        {
            diccionarioRepeticiones.Add(caracter, cadena.Count(x => caracter == x));
        });
        diccionarioRepeticiones = diccionarioRepeticiones.OrderByDescending(z => z.Value).ToDictionary(x => x.Key, y => y.Value);
        File.WriteAllLines("diccionario.txt", diccionarioRepeticiones.Select(x => $"{x.Key}:{x.Value}"));

        List<char> abecedario = diccionarioRepeticiones.Keys.ToList();
        int indice = int.MinValue;
        StringBuilder builder = new StringBuilder();
        foreach (var caracter in cadena)
        {
            indice = abecedario.IndexOf(caracter);
            if (indice != -1)
            {
                builder.Append(abecedario[(indice + DESPLAZAMIENTO) % abecedario.Count]);
            }
        }
        File.WriteAllText("textoCifrado.txt", builder.ToString());
    }
}



