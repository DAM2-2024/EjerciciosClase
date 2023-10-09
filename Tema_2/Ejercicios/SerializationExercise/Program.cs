using System;
using System.Text.Json;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Crear un objeto Person
        var person = new Person { Name = "Alice", Age = 30 };

        // Serialización a JSON
        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine("JSON serialized object:");
        Console.WriteLine(jsonString);

        // Deserialización desde JSON
        Person deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine("\nDeserialized object:");
        Console.WriteLine($"Name: {deserializedPerson?.Name ?? "Rafael"}, Age: {deserializedPerson?.Age ?? 0}");
    }
}
