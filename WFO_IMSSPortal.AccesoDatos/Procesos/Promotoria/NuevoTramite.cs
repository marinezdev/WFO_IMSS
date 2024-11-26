using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Promotoria
{
    public class NuevoTramite
    {
        ManejoDatos b = new ManejoDatos();

        //public List<prop.RespuestaNuevoTramiteN1> NuevoTramiteN1(int IdTipoTramite, int IdPromotoria, int IdUsuario, int IdStatus, int idPrioridad, string FechaSolicitud, int IdAgente, string NumeroOrden, int idRamo, string IdSisLegados, string kwik, int IdMoneda, int TipoPersona, string Nombre, string ApPaterno, string ApMaterno, string Sexo, string FechaNacimiento, string RFC, string FechaConst, int IdNacionalidad, string TitularNombre, string TitularApPat, string TitularApMat, int IdTitularNacionalidad, string TitularSexo, string TitularFechaNacimiento, double PrimaCotizacion, int TitularContratante, string Observaciones, int IdProducto, int IdSubProducto)
        public List<prop.RespuestaNuevoTramiteN1> NuevoTramiteN1(prop.TramiteN1 tramiteN1, byte[] archivo)
        {
            System.Diagnostics.Debug.WriteLine("EXEC spTramiteNuevo");
            System.Diagnostics.Debug.WriteLine("    @idtipoarchivo = " + tramiteN1.IdTipoArchivo.ToString() + ", ");
            System.Diagnostics.Debug.WriteLine("    @archivo = null" + ", ");
            System.Diagnostics.Debug.WriteLine("    @nombrearchivo = '" + tramiteN1.NombreArchivo.ToString() + "', ");
            System.Diagnostics.Debug.WriteLine("    @IdTipoTramite = " + tramiteN1.IdTipoTramite.ToString() + ", ");
            System.Diagnostics.Debug.WriteLine("    @IdStatus = " + tramiteN1.IdStatus.ToString() + ", ");
            System.Diagnostics.Debug.WriteLine("    @IdPromotoria = " + tramiteN1.IdPromotoria.ToString() + ", ");
            System.Diagnostics.Debug.WriteLine("    @IdUsuario = " + tramiteN1.IdUsuario.ToString() + ", ");
            System.Diagnostics.Debug.WriteLine("    @idPrioridad = " + tramiteN1.idPrioridad.ToString() + ", ");
            System.Diagnostics.Debug.WriteLine("    @Poliza = '" + tramiteN1.Poliza.ToString() + "', ");
            System.Diagnostics.Debug.WriteLine("    @TipoNomina = '" + tramiteN1.TipoNomina.ToString() + "', ");
            System.Diagnostics.Debug.WriteLine("    @TipoMovimiento = '" + tramiteN1.TipoMovimiento.ToString() + "', ");
            System.Diagnostics.Debug.WriteLine("    @UnidadPago = '" + tramiteN1.UnidadPago.ToString() + "', ");
            System.Diagnostics.Debug.WriteLine("    @Quincena = '" + tramiteN1.Quincena.ToString() + "', ");
            System.Diagnostics.Debug.WriteLine("    @Importe = '0'");



            b.ExecuteCommandSP("spTramiteNuevo");
            b.AddParameter("@idtipoarchivo", tramiteN1.IdTipoArchivo, SqlDbType.Int);
            b.AddParameter("@archivo", archivo, SqlDbType.VarBinary);
            b.AddParameter("@nombrearchivo", tramiteN1.NombreArchivo, SqlDbType.VarChar, 100);
            b.AddParameter("@IdTipoTramite", tramiteN1.IdTipoTramite, SqlDbType.Int);
            b.AddParameter("@IdStatus", tramiteN1.IdStatus, SqlDbType.Int);
            b.AddParameter("@IdPromotoria", tramiteN1.IdPromotoria, SqlDbType.Int);
            b.AddParameter("@IdUsuario", tramiteN1.IdUsuario, SqlDbType.Int);
            b.AddParameter("@idPrioridad", tramiteN1.idPrioridad, SqlDbType.Int);
            b.AddParameter("@Poliza", tramiteN1.Poliza, SqlDbType.NVarChar, 50);
            b.AddParameter("@TipoNomina", tramiteN1.TipoNomina, SqlDbType.NVarChar, 2);
            b.AddParameter("@TipoMovimiento", tramiteN1.TipoMovimiento, SqlDbType.NVarChar, 2);
            b.AddParameter("@UnidadPago", tramiteN1.UnidadPago, SqlDbType.NVarChar, 50);
            b.AddParameter("@Quincena", tramiteN1.Quincena, SqlDbType.NVarChar, 6);
            b.AddParameter("@Importe", "0", SqlDbType.NVarChar, 15);

            List <prop.RespuestaNuevoTramiteN1> resultado = new List<prop.RespuestaNuevoTramiteN1>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.RespuestaNuevoTramiteN1 item = new prop.RespuestaNuevoTramiteN1()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Folio = reader["Folio"].ToString(),
                    DescError = reader["DescError"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public bool LogError(string Tipo, string Numero, string Severidad, string Estado, string Procedimiento, string Linea, string Mensaje)
        {
            bool resultado = false;

            b.ExecuteCommandSP("logAgregar");
            b.AddParameter("@TIPO", Tipo, SqlDbType.NVarChar);
            b.AddParameter("@NUMBER", Numero, SqlDbType.NVarChar);
            b.AddParameter("@SEVERIDAD", Severidad, SqlDbType.NVarChar);
            b.AddParameter("@STATUS", Estado, SqlDbType.NVarChar);
            b.AddParameter("@PROCEDURE", Procedimiento, SqlDbType.NVarChar);
            b.AddParameter("@LINEA", Linea, SqlDbType.NVarChar);
            b.AddParameter("@MESSAGE", Mensaje, SqlDbType.NVarChar);

            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (Funciones.Nums.TextoAEntero(reader["Id"].ToString()) > 0)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
