using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Funciones
{
    /// <summary>
    /// Manejo de funciones de texto
    /// </summary>
    public static class Texto
    {
        /// <summary>
        /// Verifica que una cadena de texto cumpla con caracteristicas especificas para guardarse como moneda
        /// </summary>
        /// <param name="cadena">Cadena de texto</param>
        /// <returns>cadena en formato de moneda</returns>
        public static string ProcesarImporte(string cadena)
        {
            string importe = cadena.ToString().Replace(",", "").Replace("$", ""); //quita las comas y el símbolo de pesos
            if (importe.Substring(importe.IndexOf(".")).Length < 3) //Agrega un cero al final si no lo trae
                importe = importe + "0";
            return importe;
        }
    }
}
