using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Operacion.Captura
{
    public class AseguradoCaptura
    {
        public int Id { get; set; } 
        public int IdPlan { get; set; }
        public int IdDeducible { get; set; }
        public int IdCausaSeguro { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdRegiones { get; set; }
    }
}
