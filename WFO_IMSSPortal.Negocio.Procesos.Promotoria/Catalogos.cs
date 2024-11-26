using System.Collections.Generic;
using System.Web.UI.WebControls;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Promotoria;

namespace WFO_IMSSPortal.Negocio.Procesos.Promotoria
{
    public class Catalogos
    {
        AccesoDatos.Procesos.Promotoria.Catalogos catalogos = new AccesoDatos.Procesos.Promotoria.Catalogos();

        public void Cat_productos(ref DropDownList dropdownlist, int TipoTramite)
        {
            //return catalogos.Cat_Productos(TipoTramite);
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogos.Cat_Productos(TipoTramite), "Nombre", "Id");
        }

        public void Cat_subproductos(ref DropDownList dropdownlist, int Id)
        {
            //return catalogos.Cat_SubProductos(Id);
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogos.Cat_SubProductos(Id), "Nombre", "Id");
        }

        public void Cat_Riesgos(ref DropDownList dropdownlist)
        {
            //return catalogos.Cat_Riesgos();
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogos.Cat_Riesgos(), "Riesgo", "Id");

        }

        public void Cat_Monedas(ref DropDownList dropdownlist)
        {
            //return catalogos.Cat_Monedas();
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, catalogos.Cat_Monedas(), "Nombre", "Id");
        }

        public List<prop.cat_pais> Cat_Paises()
        {
            return catalogos.Cat_Paises();
        }

        public List<prop.promotoria_usuario> Promotoria_Usuarios(int Id)
        {
            return catalogos.Promotoria_Usuarios(Id);
        }

        public List<prop.promotoria_usuario> Promotoria_Seleccionar_PorIdTramite(int Id_Promotoria, int Id_Tramite)
        {
            return catalogos.Promotoria_Seleccionar_PorIdTramite(Id_Promotoria, Id_Tramite);

        }
        public List<prop.agente_promotoria_usuario> Agente_Promotoria_Usuarios(int Id, string Clave)
        {
            return catalogos.agente_Promotoria_Usuarios(Id, Clave);
        }
        public List<prop.cat_pais> cat_Pais_Sancionado(int Id)
        {
            return catalogos.cat_Pais_Sancionado(Id);
        }

        public List<prop.TramiteN1> BustatramiteN1RFC(string RFC)
        {
            return catalogos.BustatramiteN1RFC(RFC);
        }

        public List<prop.cat_moneda> BuscaMonedaId(int Id)
        {
            return catalogos.BuscaMonedaId(Id);
        }
        
        public void cat_StatusTramites_DropDownList(ref DropDownList dropdownlist)
        {
            Funciones.LlenarControles.LlenarDropDownList<prop.cat_statusTramite>(ref dropdownlist, catalogos.SeleccionaEstatusTramite(), "Nombre", "Id");
        }
    }
}
