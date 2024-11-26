using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class Usuarios
    {
        AccesoDatos.SupervisionGeneral.Usuarios usuarios = new AccesoDatos.SupervisionGeneral.Usuarios();

        public void SeleccionarUsuarios(ref GridView gridview)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, usuarios.SeleccionarTodo());
        }

        public void SeleccionarUsuariosPorNombre(ref GridView gridview, string nombre)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, usuarios.SeleccionarBuscarPorNombre(nombre));
        }

        public int ActualizarUsuarioBloqueado(string idusuario)
        {
            return usuarios.ModificarEstadoUsuarioBloqueado(idusuario);
        }

    }
}
