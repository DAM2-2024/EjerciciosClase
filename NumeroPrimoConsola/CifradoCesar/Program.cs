using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CifradoCesar;
class Program
{
    static void Main()
    {
        string cadena = File.ReadAllText(Constantes.ARCHIVO_PARA_CIFRAR);
        CifradorHelper.CifrarArchivo(cadena);

        string diccionario = File.ReadAllText(Constantes.ARCHIVO_DICCIONARIO);
        string textoCifrado = File.ReadAllText(Constantes.NOMBRE_ARCHIVO_CIFRADO);
        CifradorHelper.Descifrar(diccionario, textoCifrado);
    }
}



