using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class ArchivosTexto
    {
        ManejoDatos b = new ManejoDatos();

        public DataTable SeleccionarCadenaRearmada()
        {
            string consulta = "SELECT tipoprestamo + matricula + Concepto + importe+Plazo + ncontrol + ncreditopoliza + Promotoria + CifraControlImporte + TipoMovimiento + " +
            "RTRIM(NombreTrabajador) + REPLICATE(' ', 47 - LEN(NombreTrabajador)) + " +
            "Proveedor + caracter " +
            "FROM ArchivosTexto";
            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public int AgregarExcel(params string[] prms)
        {
            string consulta = "INSERT INTO archivostexto " +
            "VALUES" +
            "(@tipoprestamo, @matricula, @concepto, @importe, @plazo, @ncontrol, @ncreditopoliza, @promotoria, @cifracontrolimporte, @tipomovimiento, " +
            "@nombretrabajador, @proveedor, @caracter, @archivopertenece, @annquincena, @estructura)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@tipoprestamo", prms[0], SqlDbType.NChar, 1);
            b.AddParameter("@matricula", prms[1], SqlDbType.NChar, 10);
            b.AddParameter("@concepto", prms[2], SqlDbType.NChar, 3);
            b.AddParameter("@importe", prms[3], SqlDbType.NChar, 7);
            b.AddParameter("@plazo", prms[4], SqlDbType.NChar, 3);
            b.AddParameter("@ncontrol", prms[5], SqlDbType.NChar, 6);
            b.AddParameter("@ncreditopoliza", prms[6], SqlDbType.NChar, 8);
            b.AddParameter("@promotoria", prms[7], SqlDbType.NChar, 4);
            b.AddParameter("@cifracontrolimporte", prms[8], SqlDbType.NChar, 8);
            b.AddParameter("@tipomovimiento", prms[9], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[10].Replace("�", "Ñ"), SqlDbType.NChar, 40);
            b.AddParameter("@proveedor", prms[11], SqlDbType.NChar, 4);
            b.AddParameter("@caracter", prms[12], SqlDbType.NChar, 1);
            b.AddParameter("@archivopertenece", prms[13], SqlDbType.NVarChar, 12);
            b.AddParameter("@annquincena", prms[14], SqlDbType.NChar, 7);
            b.AddParameter("@estructura", prms[15], SqlDbType.NChar, 1);
            return b.InsertUpdateDelete();
        }
    }
}
