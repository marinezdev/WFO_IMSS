using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public string URL { get; set; }
        public string Icono { get; set; }
        public int PerteneceA { get; set; }
        public string Categoria { get; set; }
        public int Orden { get; set; }
    }
}
