using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Funciones
{
    /// <summary>
    /// Funciones de conversión de texto a números
    /// </summary>
    public static class Nums
    {
        public static int TextoAEntero(string texto)
        {
            return int.Parse(texto);
        }

        public static decimal TextoADecimal(string texto)
        {
            return decimal.Parse(texto);
        }

        public static bool TextoABoleano(string texto)
        {
            return bool.Parse(texto);
        }

        public static float TextoAFlotante(string texto)
        {
            return float.Parse(texto);
        }

        public static double TextoADoble(string texto)
        {

            return double.Parse(texto);
        }

        public static long TextoALong(string texto)
        {
            return long.Parse(texto);
        }

        public static short TextoAShort(string texto)
        {
            return short.Parse(texto);
        }
    }
}
