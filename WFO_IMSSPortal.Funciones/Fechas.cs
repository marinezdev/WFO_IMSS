using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Funciones
{
    /// <summary>
    /// Manejo de fechas
    /// </summary>
    public static class Fechas
    {
        public static DateTime ConvertirTextoAFecha(string texto)
        {
            return DateTime.Parse(texto);
        }

        /// <summary>
        /// Convierte una fecha para guardarla en la bd y le agrega la hora
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string PrepararFechaParaAgregar(string fecha)
        {
            return string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Parse(fecha + " " + DateTime.Now.ToLongTimeString()));
        }

        public static string PrepararFechaParaBusqueda(string fecha)
        {
            return string.Format("{0:yyyyMMdd}", DateTime.Parse(fecha));
        }

        public static string GetFormatString(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        public static string PrepararFechaInicialParaConsulta(string fecha)
        {
            string strFechaI = fecha + " 00:00:00";
            DateTime dt1 = DateTime.ParseExact(strFechaI, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return strFechaI = dt1.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string PrepararFechaFinalParaConsulta(string fecha)
        {
            string strFechaF = fecha + " 23:59:59";
            DateTime dt1 = DateTime.ParseExact(strFechaF, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return strFechaF = dt1.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static DateTime TextoAFecha(string valor)
        {
            return DateTime.Parse(valor);
        }

        /// <summary>
        /// Convierte una cadena de texto de fecha a fecha exacta
        /// </summary>
        /// <param name="valor">cadena</param>
        /// <returns>Devuelve el formato yyyymmdd</returns>
        public static DateTime TextoAFechaExacto(string valor)
        {
            return DateTime.ParseExact(valor, "yyyymmdd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Da formato a una fecha.
        /// <c>Ejemplos:</c>
        /// <para>1 - MM/dd/yyyy</para>
        /// <para>2- dddd, dd MMMM yyyy</para>
        /// <para>3 - MMMM dd</para>
        /// <para>4 - yyyy/MM/dd</para>
        /// </summary>
        /// <param name="fecha">Cadena de fecha a la que se aplicará el formato</param>
        /// <param name="formato">Número que indica el formato de fecha correspondiente a aplicarse</param>
        /// <returns>La fecha con el formato aplicado</returns>
        public static string FormatoFechas(DateTime fecha, int formato)
        {
            string nuevoformato = string.Empty;
            switch (formato)
            {
                case 1:
                    nuevoformato = fecha.ToString("dd/MM/yyyy");
                    break;
                case 2:
                    nuevoformato = fecha.ToString("dddd, dd MMMM yyyy");
                    break;
                case 3:
                    nuevoformato = fecha.ToString("dd de MMMM");
                    break;
                case 4:
                    nuevoformato = fecha.ToString("yyyy/MM/dd");
                    break;
            }

            return nuevoformato;
        }


        public static string FormatoFechaHora(DateTime fecha, int formato)
        {
            string nuevoformato = string.Empty;
            switch (formato)
            {
                case 1:
                    nuevoformato = fecha.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                    break;
                case 2:
                    nuevoformato = fecha.ToString("dd/MM/yyyy HH:mm");
                    break;
                case 3:
                    nuevoformato = fecha.ToString("dd/MM/yyyy hh:mm tt");
                    break;
                case 4:
                    nuevoformato = fecha.ToString("dd/MM/yyyy H:mm");
                    break;
                case 5:
                    nuevoformato = fecha.ToString("dd/MM/yyyy HH:mm:ss");
                    break;
                case 6:
                    nuevoformato = fecha.ToString("dd'-'MM'-'yyyy'T'HH':'mm':'ss.fffffffK");
                    break;
                case 7:
                    nuevoformato = fecha.ToString("ddd, dd MMM yyy HH':'mm':'ss 'GMT'");
                    break;
            }

            return nuevoformato;
        }

        public static string FormatoHoras(DateTime fecha, int formato)
        {
            string nuevoformato = string.Empty;
            switch (formato)
            {
                case 1:
                    nuevoformato = fecha.ToString("HH:mm");
                    break;
                case 2:
                    nuevoformato = fecha.ToString("hh:mm tt");
                    break;
                case 3:
                    nuevoformato = fecha.ToString("H:mm");
                    break;
                case 4:
                    nuevoformato = fecha.ToString("h:mm tt");
                    break;
                case 5:
                    nuevoformato = fecha.ToString("HH:mm:ss");
                    break;
                case 6:
                    nuevoformato = fecha.ToString("HH:mm:ss");
                    break;
            }

            return nuevoformato;
        }


    }
}
