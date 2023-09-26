class Program
{
    static void Main(string[] args)
    {
        string cadena;
        int numero = int.MinValue;
        do
        {
            Console.WriteLine("Escribe un número");
            cadena = Console.ReadLine() ?? string.Empty;
        } while (!int.TryParse(cadena, out numero));

        int contador = 0;
        for (int i = 1; i <= Math.Ceiling(Math.Sqrt(numero)); i++)
        {
            if (numero % i == 0)
            {
                contador++;
            }
        }
        if (contador == 1)
        {
            Console.WriteLine("Es primo");
            return;
        }
        Console.WriteLine("No es primo");
    }
}



