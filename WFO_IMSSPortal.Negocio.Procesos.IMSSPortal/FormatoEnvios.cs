using System.Data;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class FormatoEnvios
    {

        AccesoDatos.Tablas.PolizaUnidadPago pup = new AccesoDatos.Tablas.PolizaUnidadPago();
        AccesoDatos.Tablas.ResumenValidar rev = new AccesoDatos.Tablas.ResumenValidar();

        //Métodos públicos
        public void GuardarDatos(string annquin, ref DataTable dt)
        {
            foreach (DataRow fila in dt.Rows)
            {
                pup.Agregar(fila[0].ToString(), fila[1].ToString(), annquin);
            }
        }

        public bool ValidarQuincena(string AnoQuincena, string TipoNomina)
        {
            return rev.ValidarQuincena(AnoQuincena, TipoNomina);
        }

        public int GuardarRegistrosFinalesValidados(ref int IdTramite, int IdUsuario, int IdPromotoria, string poliza, string unidadpago, string archivo, string tiponomina, string tipomovimiento, string annquincena, ref string Folio)
        {
            // AgregarFinal(poliza, unidadpago, archivo, tiponomina, tipomovimiento, annquincena);
            return rev.AgregarTramite(ref IdTramite, IdUsuario, IdPromotoria, poliza, unidadpago, archivo, tiponomina, tipomovimiento, annquincena, ref Folio);
        }

        //Métodos privados
        private int Agregar(string poliza, string unidadpago, string annquincena)
        {
            return pup.Agregar(poliza, unidadpago, annquincena);
        }

        private int AgregarFinal(params string[] prms)
        {
            return rev.Agregar(prms);
        }

    }
}
