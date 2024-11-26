using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.IMSSPortal
{
    public class Archivos
    {
        AccesoDatos.Procesos.IMSSPortal.Archivos archivos = new AccesoDatos.Procesos.IMSSPortal.Archivos();

        public void Buscar(ref GridView gridview, string nombre)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, archivos.Buscar(nombre));
        }

        public byte[] ArchivoCrear(string nombre)
        {
            return archivos.ArchivoCrear(nombre);
        }

        public int Agregar(string idtipo, byte[] archivo, string nombre, string idusuario)
        {
            return archivos.Agregar(idtipo, archivo, nombre, idusuario);
        }
    }
}
