using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class PolizaUnidadPago
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(string poliza, string unidadpago, string annquincena)
        {
            string consulta = "INSERT INTO PolizaUnidadPago (Poliza, UnidadPago, AnnQuincena) VALUES(@poliza, @unidadpago, @annquincena)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@poliza", poliza, SqlDbType.NChar, 10);
            b.AddParameter("@unidadpago", unidadpago, SqlDbType.NChar, 3);
            b.AddParameter("@annquincena", annquincena, SqlDbType.NChar, 7);
            return b.InsertUpdateDelete();
        }



    }
}
