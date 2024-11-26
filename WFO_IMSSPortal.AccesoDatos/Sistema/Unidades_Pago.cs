using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Sistema
{
    public class Unidades_Pago
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable Seleccionar()
        {
            string consulta = "SELECT * FROM unidades_pago";
            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public int Agregar(string tiponomina, string unidadpagoconcentrado, string unidadpagoextraccion)
        {
            string consulta = "INSERT INTO unidades_pago(tiponomina, unidadpago_concentrado, unidadpago_extraccion) " +
            "VALUES(@tiponomina, @unidadpagoconcentrado, @unidadpagoextraccion)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.NVarChar, 2);
            b.AddParameter("@unidadpagoconcentrado", unidadpagoconcentrado, SqlDbType.NVarChar, 2);
            b.AddParameter("@unidadpagoextraccion", unidadpagoextraccion, SqlDbType.NVarChar, 3);
            return b.InsertUpdateDelete();
        }

        
    }
}
