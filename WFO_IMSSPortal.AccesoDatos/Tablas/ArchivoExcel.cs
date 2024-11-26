using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class ArchivoExcel
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable SeleccionarDatosRevision(string poliza, string unidadpago, string tiponomina, string annquincena)
        {
            string consulta = "SELECT Matricula, Importe, Poliza, PromotoriaOrigen, UsuarioServicio, PromotoriaUltimoServicio, PromotoriaResponsable, TipoMovimiento, NombreTrabajador, UnidadPago, TipoNomina, AnnQna, Estado " +
            "FROM archivoexcel " +
            "WHERE SUBSTRING(poliza, 5, 6)=@poliza " +
            "AND unidadpago=@unidadpago " +
            "AND tiponomina=@tiponomina " +
            "AND annqna=@annquincena";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@poliza", poliza, SqlDbType.NChar, 10);
            b.AddParameter("@unidadpago", unidadpago, SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", tiponomina, SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", annquincena, SqlDbType.NChar, 6);
            return b.Select();
        }

        public int AgregarExcel(params string[] prms)
        {
            string consulta = "INSERT INTO archivoexcel " +
            "VALUES " +
            "(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, @promotoriaresponsable, @tipomovimiento, @nombretrabajador, " +
            "@unidadpago, @tiponomina, @annqna, 1)";
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
            b.AddParameter("@estado", prms[12], SqlDbType.NChar, 1);
            return b.InsertUpdateDelete();
        }
    }
}
