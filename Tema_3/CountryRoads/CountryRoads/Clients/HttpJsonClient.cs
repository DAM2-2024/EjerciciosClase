using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CountryRoads.Clients
{
    public class HttpJsonClient<T> where T : class, new()
    {
        public static async Task<T> RequestCountryDataAsync(string baseAPI, string URI)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                T? myJsonResponse = await httpClient.GetFromJsonAsync<T>($"{baseAPI}{URI}");
                return myJsonResponse ?? new T();
            }
        }

    }
}
