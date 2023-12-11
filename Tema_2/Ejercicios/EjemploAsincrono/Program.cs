using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
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
        Root root = new Root();
        Random random = new Random();
        root.id = random.Next();
        root.category = new Category()
        {
            id = random.Next(),
            name = random.Next().ToString()
        };
        root.name = random.Next().ToString();
        root.photoUrls = new List<string>
        {
            random.Next().ToString(),
            random.Next().ToString(),
            random.Next().ToString()
        };
        // Simulamos una operación que lleva tiempo (por ejemplo, una solicitud HTTP)
        using (HttpClient httpClient = new HttpClient())
        {
            var result = await httpClient.PostAsJsonAsync("https://petstore.swagger.io/v2/pet", root);
            var data= await result.Content.ReadFromJsonAsync<Root>();
            Console.WriteLine(data);
        }
        return new List<string>();
    }
}
public class Category
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Root
{
    public int id { get; set; }
    public Category category { get; set; }
    public string name { get; set; }
    public List<string> photoUrls { get; set; }
    public List<Tag> tags { get; set; }
    public string status { get; set; }
}

public class Tag
{
    public int id { get; set; }
    public string name { get; set; }
}

