﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Propiedades.Procesos.Operacion
{
    public class Tramites
    {
        public int IdTramite { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string FolioCompuesto { get; set; }
        public string NumeroOrden { get; set; }
        public string Operacion { get; set; }
        public string Producto { get; set; }
        public string Contratante { get; set; }
        public string RFC { get; set; }
        public string Titular { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estatus { get; set; }
        public string IdSisLegados { get; set; }
        public string kwik { get; set; }

        //Para IMSSPortal
        public int Id { get; set; }
        public string Poliza { get; set; }
        public string TipoNomina { get; set; }
        public string TipoMovimiento { get; set; }
        public string UnidadPago { get; set; }
        public string Quincena { get; set; }
        public string Importe { get; set; }







    }
}