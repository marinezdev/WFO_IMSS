using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades
{
    public class Archivos
    {
        public int Id { get; set; }
        public int IdTipo { get; set; }
        public byte[] Archivo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
