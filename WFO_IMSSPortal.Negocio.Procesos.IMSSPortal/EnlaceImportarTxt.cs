using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class EnlaceImportarTxt
    {
        AccesoDatos.Procesos.IMSSPortal.EnlaceImportarTxt eit = new AccesoDatos.Procesos.IMSSPortal.EnlaceImportarTxt();

        public int AgregarDatos(Propiedades.EnlaceImportarTxt items)
        {
            return eit.Agregar(items);
        }
    }
}
