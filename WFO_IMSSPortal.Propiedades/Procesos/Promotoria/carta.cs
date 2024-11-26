using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Promotoria
{
    public class carta
    {
        public int Id { get; set; }
        public DateTime FechaTermino { get; set; }
        public string TipoTramite { get; set; }
        public string Operacion { get; set; }
        public string FolioCompuesto { get; set; }
        public string Contratante { get; set; }
        public string Titular { get; set; }
        public string IdSisLegados { get; set; }
        public string Producto { get; set; }
        public string Agente { get; set; }
        public string Promotoria { get; set; }
    }
}
