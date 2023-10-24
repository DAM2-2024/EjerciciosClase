using System.Globalization;
using System.Reflection.Metadata;
using Tareas.Models;
using Tareas.Utils;

class Program
{
    static async Task Main(string[] args)
    {
        ListaTareas listaTareas =ListaTareas.GetInstance();
        int opcion = int.MinValue;
        string descripcion;
        string fechaString;
        DateTime fecha;
        string id;
        string nombreFichero;
        do
        {
            Console.WriteLine(Constants.MENU);
            int.TryParse(Console.ReadLine(), out opcion);
            switch(opcion)
            {
                case 1:
                    Console.WriteLine(listaTareas.ListarTareas());
                    break;
                case 2:
                    Console.WriteLine(listaTareas.ListarTareasIncompletas());
                    break;
                case 3:
                    Console.WriteLine(listaTareas.ListartareasOrdenFechaVencimiento());
                    break;
                case 4:
                    Console.WriteLine("Escribe descripcion tarea");
                    descripcion = Console.ReadLine() ?? string.Empty;
                    do
                    {
                        Console.WriteLine("Escribe fecha formato YYYY/MM/DD");
                        fechaString = Console.ReadLine() ?? string.Empty;
                    } while (!DateTime.TryParseExact(
                        fechaString, 
                        "yyyy/MM/dd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.AssumeUniversal, 
                        out fecha));
                    listaTareas.AgregarTarea(descripcion, fecha);
                    break;
                case 5:
                    Console.WriteLine("Escribe el id de la tarea");
                    id = Console.ReadLine() ?? string.Empty;
                    listaTareas.CompletarTarea(id);
                    break;
                case 6:
                    await FileUtils<ListaTareas>.EscribirJSON(listaTareas, $"{DateTime.Now:yyyyMMdd_Download}.json");
                    break;
                case 7:
                    Console.WriteLine("Escribe el nombre de fichero");
                    nombreFichero = Console.ReadLine() ?? string.Empty;
                    ListaTareas listaAuxiliar =await FileUtils<ListaTareas>.LeerJSON(nombreFichero);
                    listaTareas.CargarListaAuxiliar(listaAuxiliar.Tareas);
                    break;
            }
            
        } while (opcion != 8);
      

    }
}



