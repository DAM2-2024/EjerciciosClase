using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoCesar
{
    public class CifradorHelper
    {
        public static void CifrarArchivo(string cadena)
        {
            List<char> abecedario = CrearAbecedario(cadena);
            int indice = int.MinValue;
            StringBuilder builder = new StringBuilder();
            foreach (var caracter in cadena)
            {
                indice = abecedario.IndexOf(caracter);
                if (indice != -1)
                {
                    builder.Append(abecedario[(indice + Constantes.DESPLAZAMIENTO) % abecedario.Count]);
                }
                else
                {
                    builder.Append(caracter);
                }
            }
            File.WriteAllText(Constantes.NOMBRE_ARCHIVO_CIFRADO, builder.ToString());
        }

        /// <summary>
        /// Este método genera a partir de una cadena un abecedario
        /// </summary>
        /// <param name="cadena">valor <see cref="string"/></param>
        /// <returns>Devuelve un abecedario en formato de lista de chars</returns>
        private static List<char> CrearAbecedario(string cadena)
        {
            List<char> caracteresDistintos = cadena.ToCharArray().Distinct().ToList();
            caracteresDistintos = caracteresDistintos.Where(x => char.IsLetterOrDigit(x) && x != ' ').ToList();

            Dictionary<char, int> diccionarioRepeticiones = new Dictionary<char, int>();
            caracteresDistintos.ForEach(caracter =>
            {
                diccionarioRepeticiones.Add(caracter, cadena.Count(x => caracter == x));
            });
            diccionarioRepeticiones = diccionarioRepeticiones.OrderByDescending(z => z.Value).ToDictionary(x => x.Key, y => y.Value);
            File.WriteAllLines(Constantes.ARCHIVO_DICCIONARIO, diccionarioRepeticiones.Select(x => $"{x.Key}:{x.Value}"));

            List<char> abecedario = diccionarioRepeticiones.Keys.ToList();
            return abecedario;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diccionario"></param>
        /// <param name="textoCifrado"></param>
        public static void Descifrar(string diccionario, string textoCifrado)
        {
            List<char> listaOrdenada = GenerarListaCaracteresMayorFrecuenca(diccionario);

            Dictionary<char, char> diccionarioTraductor = GenerarDiccionarioTraduccion(textoCifrado, listaOrdenada);

            File.WriteAllText(Constantes.ARCHIVO_RESULTADO_DESCIFRAR, GenerarTextDesCifrado(textoCifrado, diccionarioTraductor));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoCifrado"></param>
        /// <param name="diccionarioTraductor"></param>
        /// <returns></returns>
        private static string GenerarTextDesCifrado(string textoCifrado, Dictionary<char, char> diccionarioTraductor)
        {
            StringBuilder builder = new StringBuilder();
            char charTraducido;
            textoCifrado.ToCharArray().ToList().ForEach(x =>
            {
                charTraducido = diccionarioTraductor.GetValueOrDefault(x);

                if (charTraducido == default(char))
                {
                    builder.Append(x);
                }
                else
                {
                    builder.Append(charTraducido);
                }
            });
            return builder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoCifrado"></param>
        /// <param name="listaOrdenada"></param>
        /// <returns></returns>
        private static Dictionary<char, char> GenerarDiccionarioTraduccion(string textoCifrado, List<char> listaOrdenada)
        {
            Dictionary<char, int> diccionarioRepeticiones = new Dictionary<char, int>();
            textoCifrado.ToCharArray().Where(x => char.IsLetterOrDigit(x) && x != ' ').Distinct().ToList().ForEach(caracter =>
            {
                diccionarioRepeticiones.Add(caracter, textoCifrado.Count(x => caracter == x));
            });
            diccionarioRepeticiones = diccionarioRepeticiones.OrderByDescending(z => z.Value).ToDictionary(x => x.Key, y => y.Value);

            int contador = 0;
            Dictionary<char, char> diccionarioTraductor = new Dictionary<char, char>();
            diccionarioRepeticiones.Select(x => x.Key).ToList().ForEach(x =>
            {
                diccionarioTraductor.Add(x, listaOrdenada[contador]);
                contador++;
            });
            return diccionarioTraductor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diccionario"></param>
        /// <returns></returns>
        private static List<char> GenerarListaCaracteresMayorFrecuenca(string diccionario)
        {
            Dictionary<char, int> diccionarioOrdenado = new Dictionary<char, int>();
            string[] splitedString;           
            diccionario.Split("\r\n").ToList().ForEach(x =>
            {
                splitedString = x.Split(":");
                if (splitedString.Length == 2)
                {
                    var data = splitedString[0].ToCharArray();
                    diccionarioOrdenado.Add(char.Parse(splitedString[0]), int.Parse(splitedString[1]));
                }
            });

            List<char> listaOrdenada = diccionarioOrdenado.OrderByDescending(x => x.Value).Select(z => z.Key).ToList();
            return listaOrdenada;
        }
    }
}
