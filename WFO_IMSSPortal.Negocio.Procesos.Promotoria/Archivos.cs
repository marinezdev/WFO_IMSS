using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class Archivos
    {
        AccesoDatos.Procesos.Promotoria.Archivos archivos = new AccesoDatos.Procesos.Promotoria.Archivos();
        AccesoDatos.Procesos.Promotoria.Expediente expediente = new AccesoDatos.Procesos.Promotoria.Expediente();
        AccesoDatos.Procesos.Promotoria.Insumos insumos = new AccesoDatos.Procesos.Promotoria.Insumos();
        AccesoDatos.Procesos.Archivos arch = new AccesoDatos.Procesos.Archivos();

        public List<prop.control_archivos> ControlArchivoNuevoID()
        {
            return archivos.ControlArchivoNuevoID();
        }

        public int Agregar_Expedientes_Tramite(int TipoTramite, int Id_Tramite, int Id_Archivo, string NmArchivo, string NmOriginal, int Activo, int Fusion, string Descripcion)
        {
            return expediente.Agregar(TipoTramite,Id_Tramite, Id_Archivo,NmArchivo,NmOriginal,Activo,Fusion,Descripcion);
        }

        public int Agregar_Insumo_Tramite(int TipoTramite, int Id_Tramite, int Id_Archivo, string NmArchivo, string NmOriginal, int Activo, string Descripcion)
        {
            return insumos.Agregar(TipoTramite, Id_Tramite, Id_Archivo, NmArchivo, NmOriginal, Activo, Descripcion);
        }

        public List<prop.expediente> ConsultaExpediente(int Id)
        {
            return expediente.ConsultaExpediente(Id);
        }
        
        public void Expediente_Consultar_PorIdTramite(ref Repeater repeater, int Id)
        {
            Funciones.LlenarControles.LlenarRepeater(ref repeater, expediente.Expediente_Consultar_PorIdTramite(Id));
        }

        public int ModificarExpedienteFusion(int Id)
        {
            return expediente.ModificarExpedienteFusion(Id);
        }

        public prop.expediente Asegurados_Selecionar_PorIdTramite(int IdExpediente, int IdTramite)
        {
            return expediente.Asegurados_Selecionar_PorIdTramite(IdExpediente, IdTramite);
        }

        public byte[] Archivo(string nombre)
        {
            return arch.Archivo(nombre);
        }



    }
}
