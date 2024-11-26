namespace WFO_IMSSPortal.Propiedades
{
    /// <summary>
    /// Propiedades de usuario para usarse en el stored procedure Usuarios_Seleccionar_DetalleTramiteMesa
    /// </summary>
    public class Usuarios2 : IUsuarios, ITramiteTipo, IMesa
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int IdTramiteTipo { get; set; }
        public int IdFlujo { get; set; }
        public string NombreTramiteTipo { get; set; }
        public int IdMesa { get; set; }
        public string NombreMesa { get; set; }
    }

    public class Mesa2 : IMesa
    {
        public int IdMesa { get; set; }
        public string Nombre { get; set; }
    }

    public interface IUsuarios
    {
        int IdUsuario { get; set; }
        string Nombre { get; set; }
    }

    public interface ITramiteTipo
    {
        int IdTramiteTipo { get; set; }
        int IdFlujo { get; set; }
        string Nombre { get; set; }
    }

    public interface IMesa
    {
        int IdMesa { get; set; }
        string Nombre { get; set; }
    }


}
