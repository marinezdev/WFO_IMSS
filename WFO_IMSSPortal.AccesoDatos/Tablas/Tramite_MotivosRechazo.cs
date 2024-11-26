using System.Data;

namespace WFO_IMSSPortal.AccesoDatos.Tablas
{
    public class Tramite_MotivosRechazo
    {
        AccesoDatos.ManejoDatos b = new ManejoDatos();

        public DataTable Seleccionar()
        {
            string consulta = "SELECT tramite_motivosrechazo.Id, tramite_tipo.Nombre AS TipoTramite, mesa.Nombre AS Mesa, cat_Tramite_RechazosTipos.Nombre AS TipoRechazo, " +
            "tramite_motivosrechazo.idparent, tramite_motivosrechazo.MotivoRechazo, tramite_motivosrechazo.Activo " +
            "FROM tramite_motivosrechazo INNER JOIN tramite_tipo ON Tramite_MotivosRechazo.IdTramiteTipo = tramite_tipo.Id " +
            "INNER JOIN mesa ON Tramite_MotivosRechazo.IdMesa = mesa.Id " +
            "INNER JOIN cat_Tramite_RechazosTipos ON Tramite_MotivosRechazo.IdTramiteTipoRechazo = cat_Tramite_RechazosTipos.Id";
            b.ExecuteCommandQuery(consulta);
            return b.Select();
        }

        public int Agregar(string idtramitetipo, string idmesa, string idtramitetiporechazo, string idparent, string motivorechazo)
        {
            string consulta = "INSERT INTO tramite_motivosrechazo (idtramitetipo, idmesa, idtramitetiporechazo, idparent, motivorechazo, activo) " +
            "VALUES(@idtramitetipo, @idmesa, @idtramitetiporechazo, @idparent, @motivorechazo,1)";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idtramitetipo", idtramitetipo, SqlDbType.Int);
            b.AddParameter("@idmesa", idmesa, SqlDbType.Int);
            b.AddParameter("@idtramitetiporechazo", idtramitetiporechazo, SqlDbType.Int);
            b.AddParameter("@idparent", idparent, SqlDbType.Int);
            b.AddParameter("@motivorechazo", motivorechazo, SqlDbType.VarChar, 100);
            return b.InsertUpdateDelete();
        }

        public int Actualizar(string idtramitetipo, string idmesa, string idtramitetiporechazo, string idparent, string motivorechazo, string activo, string id)
        {
            string consulta = "UPDATE tramite_motivosrechazo SET idtramitetipo=@idtramitetipo, idmesa=@idmesa, idtramitetiporechazo=@idtramitetiporechazo, " +
            "idparent=@idparent, motivorechazo=@motivorechazo, activo=@activo WHERE id=@id";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@idtramitetipo", idtramitetipo, SqlDbType.Int);
            b.AddParameter("@idmesa", idmesa, SqlDbType.Int);
            b.AddParameter("@idtramitetiporechazo", idtramitetiporechazo, SqlDbType.Int);
            b.AddParameter("@idparent", idparent, SqlDbType.Int);
            b.AddParameter("@motivorechazo", motivorechazo, SqlDbType.VarChar, 100);
            b.AddParameter("@activo", activo, SqlDbType.Int);
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

    }
}
