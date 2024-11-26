using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Operacion
{
    public class MotivosSuspension
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.MotivosSuspension> SelecionarMotivos(int IdMesa)
        {
            List<prop.MotivosSuspension> resultado = new List<prop.MotivosSuspension>();

            b.ExecuteCommandSP("MotivosSuspension_Listar");
            b.AddParameter("@Id_Mesa", IdMesa, SqlDbType.Int);
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.MotivosSuspension item = new prop.MotivosSuspension()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    IdTramiteTipo = Funciones.Nums.TextoAEntero(reader["IdTramiteTipo"].ToString()),
                    IdMesa = Funciones.Nums.TextoAEntero(reader["IdMesa"].ToString()),
                    IdTramiteTipoRechazo = Funciones.Nums.TextoAEntero(reader["IdTramiteTipoRechazo"].ToString()),
                    IdParent = Funciones.Nums.TextoAEntero(reader["IdParent"].ToString()),
                    MotivoRechazo = reader["MotivoRechazo"].ToString(),
                    Activo = bool.Parse(reader["Activo"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
