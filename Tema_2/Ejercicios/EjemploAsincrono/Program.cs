using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Llamamos a un método asíncrono
        await DoSomethingAsync();

        // Continuamos con otras tareas
        Console.WriteLine("Otras tareas pueden continuar mientras se espera DoSomethingAsync");
    }

    static async Task DoSomethingAsync()
    {
        // Simulamos una operación que lleva tiempo (por ejemplo, una solicitud HTTP)
        using (HttpClient httpClient = new HttpClient())
        {
            string result = await httpClient.GetStringAsync("https://www.example.com");
            Console.WriteLine(result);
        }
    }
}
