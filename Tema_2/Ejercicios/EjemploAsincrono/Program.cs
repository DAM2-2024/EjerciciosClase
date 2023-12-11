using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Llamamos a un método asíncrono
        Task<List<string>> firstThing = DoSomethingAsync();
        Task<List<string>> otherThing = DoSomethingAsync();
        Task<List<string>> lastThing = DoSomethingAsync();


        await Task.WhenAll(firstThing, otherThing, lastThing);

        List<string> resultado = await firstThing;

        // Continuamos con otras tareas
        Console.WriteLine("Otras tareas pueden continuar mientras se espera DoSomethingAsync");
    }

    static async Task<List<string>> DoSomethingAsync()
    {
        // Simulamos una operación que lleva tiempo (por ejemplo, una solicitud HTTP)
        using (HttpClient httpClient = new HttpClient())
        {
            string result = await httpClient.GetStringAsync("http://localhost:32768/Gods");
            Console.WriteLine(result);
        }
        return new List<string>();
    }
}
