using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Nombre { get; set; }

        [JsonPropertyName("url")]
        public string UrlData { get; set; }
    }

    public class PokemonData
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Pokemon> Pokemons { get; set; }
    }


}
