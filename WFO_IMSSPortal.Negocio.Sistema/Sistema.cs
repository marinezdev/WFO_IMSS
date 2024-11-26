using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.Negocio.Sistema
{
    public class Sistema
    {
        /// <summary>
        /// Acceso a métodos de negocio de cat_pendientes
        /// </summary>
        public cat_pendientes catpendientes;
        /// <summary>
        /// Acceso a métodos de negocio de cat_producto
        /// </summary>
        public cat_producto catproducto;
        /// <summary>
        /// Acceso a métodos de negocio de configuracion
        /// </summary>
        public Configuracion configuracion;
        /// <summary>
        /// Acceso a métodos de negocio de menu
        /// </summary>
        public Menu menu;
        /// <summary>
        /// Acceso a métodos de negocio de permisos menu
        /// </summary>
        public PermisosMenu permisosmenu;
        /// <summary>
        /// Acceso a métodos de negocio de rol acceso
        /// </summary>
        public RolAcceso rolacceso;
        /// <summary>
        /// Acceso a métodos de negocio de roles
        /// </summary>
        public Roles roles;
        /// <summary>
        /// Acceso a mpetodos de negocio de sesión
        /// </summary>
        public Sesion sesion;
        /// <summary>
        /// Acceso a métodos de negocio de tramite_tipo
        /// </summary>
        public tramite_tipo tramitetipo;
        /// <summary>
        /// Acceso a métodos de negocio de Unidades_Pago
        /// </summary>
        public Unidades_Pago unidadespago;
        /// <summary>
        /// Acceso a métodos de negocio de usuarios
        /// </summary>
        public Usuarios usuarios;

        public Autentificar autentificar;

        public Sistema()
        {
            catpendientes = new cat_pendientes();
            catproducto = new cat_producto();
            configuracion = new Configuracion();
            menu = new Menu();
            permisosmenu = new PermisosMenu();
            rolacceso = new RolAcceso();
            roles = new Roles();
            sesion = new Sesion();
            tramitetipo = new tramite_tipo();
            unidadespago = new Unidades_Pago();
            usuarios = new Usuarios();
            autentificar = new Autentificar();
        }
    }
}
