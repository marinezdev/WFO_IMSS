using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class Concentrado
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable SeleccionarDuplicados(string polizas)
        {
            string consulta = "SELECT * FROM concentrado WHERE poliza in (@polizas)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@polizas", polizas, SqlDbType.VarChar, 1000);
            return b.Select();
        }

        public int EliminarRegistro(string id)
        {
            string consulta = "DELETE FROM concentrado WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public int AgregarConcentrado(params string[] prms)
        {
            string consulta = "INSERT INTO concentrado " +
            "VALUES " +
            "(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, @promotoriaresponsable, @tipomovimiento, @nombretrabajador, " +
            "@unidadpago, @tiponomina, @annqna, @estadocarta, @estadocartainstruccionnoaplica, @estadocartainstruccionrechazo, @motivorechazo, @estado)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 10);
            b.AddParameter("@importe", prms[1], SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 4);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 40);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 2);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annqna", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@estadocarta", prms[12], SqlDbType.NChar, 15);
            b.AddParameter("@estadocartainstruccionnoaplica", prms[13], SqlDbType.NChar, 10);
            b.AddParameter("@estadocartainstruccionrechazo", prms[14], SqlDbType.NChar, 10);
            b.AddParameter("@motivorechazo", prms[15], SqlDbType.NVarChar, 150);
            b.AddParameter("@estado", prms[16], SqlDbType.NChar, 1);
            return b.InsertUpdateDelete();
        }
    }
}
