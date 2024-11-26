using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.IMSSPortal
{
    public class EnlaceImportarTxt
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(Propiedades.EnlaceImportarTxt items)
        {
            b.ExecuteCommandQuery("INSERT INTO enlaceimportartxt " +
            "VALUES (@tipoprestamo,@matricula,@concepto,@importe,@plazo,@numcontrol,@numcreditopoliza, @promotoria,@cifracontrolimporte,@tipomovimiento,@nombretrabajador, " +
            "@numproveedor,@caracter,@cifracontrol,@espaciosenblanco, @casos,@xunidadpago,@xretenedor,@xconcepto,@xtiponomina,@xquincena, @idusuario, getdate(), @archivo," +
            "@quincena, @tiponomina)");
            b.AddParameter("@tipoprestamo", items.TipoPrestamo, SqlDbType.NChar,1);
            b.AddParameter("@matricula", items.Matricula, SqlDbType.NChar,10);
            b.AddParameter("@concepto", items.Concepto, SqlDbType.NChar,3);
            b.AddParameter("@importe", items.Importe, SqlDbType.NChar,7);
            b.AddParameter("@plazo", items.Plazo, SqlDbType.NChar,3);
            b.AddParameter("@numcontrol", items.NumControl, SqlDbType.NChar,6);
            b.AddParameter("@numcreditopoliza", items.NumCreditoPoliza, SqlDbType.NChar,8);
            b.AddParameter("@promotoria", items.Promotoria, SqlDbType.NChar,4);
            b.AddParameter("@cifracontrolimporte", items.CifraControlImporte, SqlDbType.NChar,8);
            b.AddParameter("@tipomovimiento", items.TipoMovimiento, SqlDbType.NChar,1);
            b.AddParameter("@nombretrabajador", items.NombreTrabajador, SqlDbType.NChar,47);
            b.AddParameter("@numproveedor", items.NumProveedor, SqlDbType.NChar,4);
            b.AddParameter("@caracter", items.Caracter, SqlDbType.NChar,1);
            b.AddParameter("@cifracontrol", items.CifraControl, SqlDbType.NChar,18);
            b.AddParameter("@espaciosenblanco", items.EspaciosEnBlanco, SqlDbType.NChar,5);
            b.AddParameter("@casos", items.Casos, SqlDbType.NChar,10);
            b.AddParameter("@xunidadpago", items.xUnidadPago, SqlDbType.NChar,2);
            b.AddParameter("@xretenedor", items.xRetenedor, SqlDbType.NChar,4);
            b.AddParameter("@xconcepto", items.xConcepto, SqlDbType.NChar,3);
            b.AddParameter("@xtiponomina", items.xTipoNomina, SqlDbType.NChar,1);
            b.AddParameter("@xquincena", items.xQuincena, SqlDbType.NChar,2);
            b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            b.AddParameter("@archivo", items.Archivo, SqlDbType.NChar, 12);
            b.AddParameter("@quincena", items.Quincena, SqlDbType.NChar, 6);
            b.AddParameter("@tiponomina", items.TipoNomina, SqlDbType.NChar, 2);
            return b.InsertUpdateDelete();
        }
    }
}