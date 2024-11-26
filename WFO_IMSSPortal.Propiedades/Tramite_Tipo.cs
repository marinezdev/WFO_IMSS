using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades
{
    public class Tramite_Tipo
    {
        public int Id { get; set; }
        public int Idflujo { get; set; }
        public string Nombre { get; set; }
        public string AbreviaturaFolio { get; set; }
        public string Nivel { get; set; }
        public string Alcance { get; set; }
        public string Tabla { get; set; }
        public string TablaBitacora { get; set; }
        public int Activo { get; set; }
    }
}
