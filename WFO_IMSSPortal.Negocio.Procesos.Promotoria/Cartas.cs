using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class Cartas
    {
        AccesoDatos.Procesos.Promotoria.Carta carta = new AccesoDatos.Procesos.Promotoria.Carta();

        public List<prop.carta> Consulta_Carta(int Id, string Nombre, int Rechazo)
        {
            return carta.Consulta_Carta(Id, Nombre, Rechazo);
        }

        public List<prop.carta> Consulta_Carta_PCI(int Id)
        {
            return carta.Consulta_Carta_PCI(Id);
        }

        public List<prop.motivosRechazo> Consulta_MotivosRechazo(int Id)
        {
            return carta.Consulta_Motivos_Rechazo(Id);
        }

        public List<prop.bitacora> Consulta_Observaciones_Bitacora(int Id)
        {
            return carta.Consulta_Observaciones_Bitacora(Id);
        }



        
    }
}
