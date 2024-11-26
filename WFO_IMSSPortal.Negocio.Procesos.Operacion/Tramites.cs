using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class Tramites
    {
        AccesoDatos.Procesos.Operacion.Tramites tramites = new AccesoDatos.Procesos.Operacion.Tramites();

        public void TramiteOperadorSelecionar(ref Repeater repeater, int Id, DateTime Fecha_Inicio, DateTime Fecha_Termino, string Folio, string Poliza, string quincena, string tiponomina)
        {
            Funciones.LlenarControles.LlenarRepeater(ref repeater, tramites.TramiteOperadorSelecionar(Id, Fecha_Inicio, Fecha_Termino,Folio, Poliza, quincena, tiponomina));
        }
    }
}
