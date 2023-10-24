using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tareas.Utils
{
    internal class FileUtils<T>
    {
        public async static Task EscribirJSON(T objeto,string path)
        {
            string stringObjeto=JsonSerializer.Serialize(objeto);
            await File.WriteAllTextAsync(path, stringObjeto);
        }
        public async static Task<T> LeerJSON(string path)
        {
            string stringObjeto = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<T>(stringObjeto);
        }
    }
}
