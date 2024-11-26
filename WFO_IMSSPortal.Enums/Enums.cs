using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Reflection;
using System.Linq;

namespace WFO_IMSSPortal.Enums
{
    public static class Enums
    {
        public enum Roles
        {
            Administrador = 1,
            MetLIfeImssPortal = 2,
            Promotoria = 3,
            Operador = 4,
            SupervisorOperacional = 5,
            SupervisorReportes = 6
        }

        public enum FormatoFechas
        {
            [Description("Mes/dia/año")]
            MesDiaAño = 1,
            [Description("diasemana, dd MMMM yyyy")]
            diasemana_dia_mes_año = 2,
            [Description("dddd, dd MMMM yyyy HH:mm:ss")]
            diasemana_dia_mes_año_hotas_minutos_segundos = 3,
            [Description("MM/dd/yyyy HH:mm")]
            mes_dia_año_horas_minutos = 4
        }


    }
}
