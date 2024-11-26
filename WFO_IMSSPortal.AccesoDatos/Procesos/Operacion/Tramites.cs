using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using promotoria = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;
using System.Data;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Operacion
{
    public class Tramites
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Tramites> TramiteOperadorSelecionar(int Id, DateTime Fecha_Inicio, DateTime Fecha_Termino, string Folio, string Poliza, string quincena, string tiponomina)
        {
            b.ExecuteCommandSP("Tramite_Operador_Selecionar_PorIdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);
            b.AddParameter("@Fecha_Termino", Fecha_Termino, SqlDbType.DateTime);
            b.AddParameter("@Folio", Folio, SqlDbType.NVarChar);
            b.AddParameter("@Poliza", Poliza, SqlDbType.NVarChar);
            b.AddParameter("@Quincena", quincena, SqlDbType.VarChar, 6);
            b.AddParameter("@TipoNomina", tiponomina, SqlDbType.VarChar, 2);
            //b.AddParameter("@Nombre", Nombre, SqlDbType.NVarChar);
            //b.AddParameter("@ApPaterno", ApPaterno, SqlDbType.NVarChar);
            //b.AddParameter("@ApMaterno", ApMaterno, SqlDbType.NVarChar);
            List<prop.Tramites> resultado = new List<prop.Tramites>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramites item = new prop.Tramites()
                {
                    Id              = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    FechaRegistro   = Convert.ToDateTime(reader["FechaRegistro"].ToString()),
                    FolioCompuesto  = reader["FolioCompuesto"].ToString(),
                    //NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion       = reader["Operacion"].ToString(),
                    //Producto = reader["Producto"].ToString(),
                    //Contratante = reader["Contratante"].ToString(),
                    //RFC = reader["RFC"].ToString(),
                    //Titular = reader["Titular"].ToString(),
                    //FechaSolicitud = Convert.ToDateTime(reader["FechaSolicitud"].ToString()),
                    IdTramite       = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString()),
                    Poliza          = reader["Poliza"].ToString(),
                    TipoNomina      = reader["TipoNomina"].ToString(),
                    TipoMovimiento  = reader["TipoMovimiento"].ToString(),
                    UnidadPago      = reader["UnidadPago"].ToString(),
                    Quincena        = reader["Quincena"].ToString(),
                    Importe         = reader["Importe"].ToString(),
                    Estatus         = reader["Estatus"].ToString(),
                    //IdSisLegados = reader["IdSisLegados"].ToString(),
                    //kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
