﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Operacion
{
    public class MapaGeneralMesaDetalleTramite
    {
        public int IdFlujo { get; set; }
        public int IdMesa { get; set; }
        public int IdTramite { get; set; }
        public int IdTramiteMesa { get; set; }
        public string Folio { get; set; }
        public int Reingresos { get; set; }
        public DateTime Registro { get; set; }
        public string Usuario { get; set; }
        public string TiempoAtencion { get; set; }
        public string TiempoMesa { get; set; }
        public string StatusMesa { get; set; }
        public string Poliza { get; set; }
        public int Quincena { get; set; }
        public float Importe { get; set; }
        public string TipoNomina { get; set; }
        public string TipoMovimiento { get; set; }
        public string UnidadPago { get; set; }
    }
}
