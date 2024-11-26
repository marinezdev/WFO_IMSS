using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades
{
    public class Sesion
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Acceso { get; set; }
        public DateTime FinAcceso { get; set; }
    }
}
