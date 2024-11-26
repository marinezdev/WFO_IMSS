using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class Extraccion
    {
        ManejoDatos b = new ManejoDatos();
        
        public DataTable ObtenerTramiteProcesadoCarta(string TipoNomina, string Quincena, string Poliza)
        {
            string consulta = "";

            if (Poliza.Length < 10)
                Poliza = '%' + Poliza + '%';

            consulta += " SELECT ";
            consulta += " Archivos.Nombre AS 'NombreArchivo' ";
            consulta += " , tramite.id ";
            consulta += " , tramite.FechaRegistro ";
            consulta += " , Tramite_Det_IMSSPortal.Poliza ";
            consulta += " , Tramite_Det_IMSSPortal.Quincena ";
            consulta += " , Tramite_Det_IMSSPortal.TipoNomina ";
            consulta += " , Tramite_Det_IMSSPortal.TipoMovimiento ";
            consulta += " , Tramite_Det_IMSSPortal.UnidadPago ";
            consulta += " , Tramite_Det_IMSSPortal.Importe ";
            consulta += " , Tramite_Det_IMSSPortal.PolizaPortal ";
            consulta += " FROM tramite ";
            consulta += " INNER JOIN Tramite_Det_IMSSPortal ON tramite.Id = Tramite_Det_IMSSPortal.IdTramite ";
            consulta += " INNER JOIN Archivos ON Archivos.Id = Tramite_Det_IMSSPortal.IdArchivo ";
            consulta += " WHERE Tramite_Det_IMSSPortal.Poliza = @Poliza ";
            consulta += " AND Tramite_Det_IMSSPortal.Quincena = @Quincena ";
            consulta += " AND Tramite_Det_IMSSPortal.TipoNomina = @TipoNomina ";
            consulta = consulta.Replace("\t", "");

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@Poliza", Poliza, SqlDbType.NVarChar, 10);
            b.AddParameter("@Quincena", Quincena, SqlDbType.NChar, 6);
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.NChar, 2);
            return b.Select();
        }

        public DataTable ObtenerTramiteProcesado(string TipoNomina, string Quincena, string Poliza)
        {
            string consulta = "";

            if (Poliza.Length <= 8)
                Poliza = '%' + Poliza + '%';

            consulta += " SELECT ";
            consulta += "   tramite.Id AS 'Id Trámite' ";
            consulta += " 	, tramite_mesa.Id AS 'Id Trámite Mesa' ";
            consulta += " 	, tramite.FechaRegistro ";
            consulta += " 	, tramite.FechaTermino ";
            consulta += " 	, statusTramite.Nombre AS 'Status Trámite' ";
            consulta += " 	, Usuarios.Nombre AS 'Usuario' ";
            consulta += " 	, mesa.Nombre AS 'Mesa' ";
            consulta += " 	, statusMesa.Nombre AS 'Status Mesa' ";
            consulta += " 	, IIF(Tramite_Mesa.TieneRechazo = 1, 'SI', '') AS 'Rechazo' ";
            consulta += " 	, ISNULL('[' + CONVERT(nvarchar,Tramite_MotivosRechazo.Id) + '] ' + Tramite_MotivosRechazo.MotivoRechazo,'') AS 'Motivo Rechazo' ";
            consulta += " 	, ISNULL(Tramite_RechazosMesa.ObservacionPrivada,'') AS 'Obs. Rechazo' ";
            consulta += " FROM Tramite ";
            consulta += " 	INNER JOIN Tramite_Det_IMSSPortal ON Tramite.Id = Tramite_Det_IMSSPortal.IdTramite ";
            consulta += " 	INNER JOIN Tramite_Mesa ON tramite.Id = Tramite_Mesa.IdTramite ";
            consulta += " 	INNER JOIN statusTramite ON tramite.IdStatus = statusTramite.Id ";
            consulta += " 	INNER JOIN mesa ON mesa.Id = Tramite_Mesa.IdMesa ";
            consulta += " 	INNER JOIN statusMesa ON statusMesa.Id = Tramite_Mesa.IdStatusMesa ";
            consulta += " 	LEFT JOIN Usuarios ON Usuarios.IdUsuario = Tramite_Mesa.IdUsuario ";
            consulta += " 	LEFT JOIN Tramite_RechazosMesa ON (Tramite_RechazosMesa.IdTramite = tramite.Id AND Tramite_RechazosMesa.IdTramiteMesa = Tramite_Mesa.Id AND Tramite_RechazosMesa.Activo = 1) ";
            consulta += " 	LEFT JOIN Tramite_RechazosMesa_Det ON Tramite_RechazosMesa_Det.IdRechazoMesa = Tramite_RechazosMesa.Id ";
            consulta += " 	LEFT JOIN Tramite_MotivosRechazo ON Tramite_MotivosRechazo.Id = Tramite_RechazosMesa_Det.IdRechazoMotivo ";
            consulta += " WHERE  ";
            consulta += " 	Tramite_Det_IMSSPortal.Poliza LIKE @Poliza ";
            consulta += " 	AND Tramite_Det_IMSSPortal.Quincena = @Quincena ";
            consulta += " 	AND Tramite_Det_IMSSPortal.TipoNomina = @TipoNomina ";
            consulta = consulta.Replace("\t", "");

            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@Poliza", Poliza, SqlDbType.NVarChar, 10);
            b.AddParameter("@Quincena", Quincena, SqlDbType.NChar, 6);
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.NChar, 2);
            return b.Select();
        }

        public int Agregar_EnlaceCasosEspeciales(int IdUsuario, string Folio, string Observaciones, string CartaPDF, string QuincenaEnlace, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            b.ExecuteCommandSP("EnlaceCasosEspeciales_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@CartaPDF", CartaPDF, SqlDbType.NVarChar);
            b.AddParameter("@QuincenaEnlace", QuincenaEnlace, SqlDbType.NVarChar);
            b.AddParameter("@TipoPrestamo", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@Matricula", prms[1], SqlDbType.NChar, 15);
            b.AddParameter("@Concepto", prms[2], SqlDbType.NVarChar);
            b.AddParameter("@Importe", Funciones.Texto.ProcesarImporte(prms[3]), SqlDbType.NChar, 10);
            b.AddParameter("@Plazo", prms[4], SqlDbType.NVarChar);
            b.AddParameter("@NumeroControl", prms[5], SqlDbType.NVarChar);
            b.AddParameter("@NumeroCredito_poliza", prms[6], SqlDbType.NVarChar);
            b.AddParameter("@Promotoria", prms[7], SqlDbType.NVarChar);
            b.AddParameter("@CifraControl", prms[8], SqlDbType.NVarChar);
            b.AddParameter("@TipoMovimiento", prms[9], SqlDbType.NVarChar);
            b.AddParameter("@NombreTrabajador", prms[10], SqlDbType.NVarChar);
            b.AddParameter("@Retenedor", prms[11], SqlDbType.NVarChar);
            b.AddParameter("@Caracter", prms[12], SqlDbType.NVarChar);
            b.AddParameter("@UnidadPago", prms[13], SqlDbType.NVarChar);
            b.AddParameter("@TipoNomina", prms[14], SqlDbType.NVarChar);
            b.AddParameter("@Quincena", prms[15], SqlDbType.NVarChar);
            b.AddParameter("@UsuarioServicio", prms[16], SqlDbType.NVarChar);
            b.AddParameter("@PromoUServicio", prms[17], SqlDbType.NVarChar);
            b.AddParameter("@PromoResponsable", prms[18], SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        public int Agregar_EnlaceCasosAdicionales(int IdUsuario, string Folio, string Observaciones, string CartaPDF, string QuincenaEnlace, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            b.ExecuteCommandSP("EnlaceCasosAdicionales_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@CartaPDF", CartaPDF, SqlDbType.NVarChar);
            b.AddParameter("@QuincenaEnlace", QuincenaEnlace, SqlDbType.NVarChar);
            b.AddParameter("@TipoPrestamo", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@Matricula", prms[1], SqlDbType.NChar, 15);
            b.AddParameter("@Concepto", prms[2], SqlDbType.NVarChar);
            b.AddParameter("@Importe", Funciones.Texto.ProcesarImporte(prms[3]), SqlDbType.NChar, 10);
            b.AddParameter("@Plazo", prms[4], SqlDbType.NVarChar);
            b.AddParameter("@NumeroControl", prms[5], SqlDbType.NVarChar);
            b.AddParameter("@NumeroCredito_poliza", prms[6], SqlDbType.NVarChar);
            b.AddParameter("@Promotoria", prms[7], SqlDbType.NVarChar);
            b.AddParameter("@CifraControl", prms[8], SqlDbType.NVarChar);
            b.AddParameter("@TipoMovimiento", prms[9], SqlDbType.NVarChar);
            b.AddParameter("@NombreTrabajador", prms[10], SqlDbType.NVarChar);
            b.AddParameter("@Retenedor", prms[11], SqlDbType.NVarChar);
            b.AddParameter("@Caracter", prms[12], SqlDbType.NVarChar);
            b.AddParameter("@UnidadPago", prms[13], SqlDbType.NVarChar);
            b.AddParameter("@TipoNomina", prms[14], SqlDbType.NVarChar);
            b.AddParameter("@Quincena", prms[15], SqlDbType.NVarChar);
            b.AddParameter("@UsuarioServicio", prms[16], SqlDbType.NVarChar);
            b.AddParameter("@PromoUServicio", prms[17], SqlDbType.NVarChar);
            b.AddParameter("@PromoResponsable", prms[18], SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }

        public int Agregar_Efectividad(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            System.Diagnostics.Debug.WriteLine("exec Movimientos_Efectividad_Add ");
            System.Diagnostics.Debug.WriteLine("@idUsuario = " + IdUsuario.ToString() + ",");
            System.Diagnostics.Debug.WriteLine("@Folio = " + Folio + ",");
            System.Diagnostics.Debug.WriteLine("@matricula = " + prms[0] + ",");
            System.Diagnostics.Debug.WriteLine("@importe = " + Funciones.Texto.ProcesarImporte(prms[1]) + ",");
            System.Diagnostics.Debug.WriteLine("@poliza = " + prms[2] + ",");
            System.Diagnostics.Debug.WriteLine("@promotoriaorigen = " + prms[3] + ",");
            System.Diagnostics.Debug.WriteLine("@usuarioservicio = " + prms[4] + ",");
            System.Diagnostics.Debug.WriteLine("@promotoriaultimoservicio = " + prms[5] + ",");
            System.Diagnostics.Debug.WriteLine("@promotoriaresponsable = " + prms[6] + ",");
            System.Diagnostics.Debug.WriteLine("@tipomovimiento = " + prms[7] + ",");
            System.Diagnostics.Debug.WriteLine("@nombretrabajador = " + prms[8] + ",");
            System.Diagnostics.Debug.WriteLine("@unidadpago = " + prms[9] + ",");
            System.Diagnostics.Debug.WriteLine("@tiponomina = " + prms[10] + ",");
            System.Diagnostics.Debug.WriteLine("@annquincena = " + prms[11] + ",");
            System.Diagnostics.Debug.WriteLine("@status = " + "'',");
            System.Diagnostics.Debug.WriteLine("@Observaciones = " + "'', ");
            System.Diagnostics.Debug.WriteLine("@Concentrado = " + "0; ");

            b.ExecuteCommandSP("Movimientos_Efectividad_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@importe", Funciones.Texto.ProcesarImporte(prms[1]), SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 10);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 70);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@status", " ", SqlDbType.NChar, 1);
            b.AddParameter("@Observaciones", Observaciones, SqlDbType.NChar);
            b.AddParameter("@Concentrado", 0, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }


        public int Agregar(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            System.Diagnostics.Debug.WriteLine("exec Movimientos_Extraccion_Add ");
            System.Diagnostics.Debug.WriteLine("@idUsuario = " + IdUsuario.ToString() + ",");
            System.Diagnostics.Debug.WriteLine("@Folio = " + Folio + ",");
            System.Diagnostics.Debug.WriteLine("@matricula = " + prms[0] + ",");
            System.Diagnostics.Debug.WriteLine("@importe = " + Funciones.Texto.ProcesarImporte(prms[1]) + ",");
            System.Diagnostics.Debug.WriteLine("@poliza = " + prms[2] + ",");
            System.Diagnostics.Debug.WriteLine("@promotoriaorigen = " + prms[3] + ",");
            System.Diagnostics.Debug.WriteLine("@usuarioservicio = " + prms[4] + ",");
            System.Diagnostics.Debug.WriteLine("@promotoriaultimoservicio = " + prms[5] + ",");
            System.Diagnostics.Debug.WriteLine("@promotoriaresponsable = " + prms[6] + ",");
            System.Diagnostics.Debug.WriteLine("@tipomovimiento = " + prms[7] + ",");
            System.Diagnostics.Debug.WriteLine("@nombretrabajador = " + prms[8] + ",");
            System.Diagnostics.Debug.WriteLine("@unidadpago = " + prms[9] + ",");
            System.Diagnostics.Debug.WriteLine("@tiponomina = " + prms[10] + ",");
            System.Diagnostics.Debug.WriteLine("@annquincena = " + prms[11] + ",");
            System.Diagnostics.Debug.WriteLine("@status = " + "'',");
            System.Diagnostics.Debug.WriteLine("@Observaciones = " + "'', ");
            System.Diagnostics.Debug.WriteLine("@Concentrado = " + "0; ");

            b.ExecuteCommandSP("Movimientos_Extraccion_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@importe", Funciones.Texto.ProcesarImporte(prms[1]), SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 10);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 70);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@status", " ", SqlDbType.NChar, 1);
            b.AddParameter("@Observaciones", Observaciones, SqlDbType.NChar);
            b.AddParameter("@Concentrado", 0, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        
        public int AgregarPolizasCanceladas(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            b.ExecuteCommandSP("Movimientos_Extraccion_Add_PolizasCanceladas");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@importe", Funciones.Texto.ProcesarImporte(prms[1]), SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 10);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 70);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@Observaciones", Observaciones, SqlDbType.NChar);
            b.AddParameter("@Concentrado", 1, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        public int AgregarConcentrado(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            b.ExecuteCommandSP("Movimientos_Extraccion_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@importe", Funciones.Texto.ProcesarImporte(prms[1]), SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 10);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 70);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@status", prms[16], SqlDbType.NChar, 1);
            b.AddParameter("@Observaciones", Observaciones, SqlDbType.NChar);
            b.AddParameter("@Concentrado", 1, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }


    }
}