using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Promotoria
{
    public class IndicadorGeneral
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.IndicadorGeneral> SeleccionaEstatusTotales(int quincena, string tiponomina)
        {
            b.ExecuteCommandSP("Indicador_General_Promotoria_PorUsuario");
            b.AddParameter("@quincena", quincena, SqlDbType.Int);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.VarChar, 2);
            List<prop.IndicadorGeneral> resultado = new List<prop.IndicadorGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.IndicadorGeneral item = new prop.IndicadorGeneral()
                {
                    Id                      = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Estado                  = reader["nombre"].ToString(),
                    Totales                 = Funciones.Nums.TextoAEntero(reader["TotalTramites"].ToString()),
                    BackgroundColor         = reader["BackgroundColor"].ToString(),
                    BorderColor             = reader["BorderColor"].ToString(),
                    HoverBackgroundColor    = reader["HoverBackgroundColor"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}