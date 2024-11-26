namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class Validar
    {
        AccesoDatos.Tablas.Concentrado con = new AccesoDatos.Tablas.Concentrado();

        public int AgregarConcentrado(params string[] prms)
        {
            return con.AgregarConcentrado(prms);
        }
    }
}
