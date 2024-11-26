using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades;

namespace WFO_IMSSPortal.IU
{
    /// <summary>
    /// Control de la sesión general de todo el sistema para su rasteo e implmentación
    /// </summary>
    public class ManejadorSesion
    {
        private prop.Usuarios _usuarios;
        private List<prop.Configuracion> _configuracion;
        private string _menu;

        private string _Token;

        /* Token de Autentificacion */
        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public prop.Usuarios Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

        public List<prop.Configuracion> Configuracion
        {
            get { return _configuracion; }
            set { _configuracion = value; }
        }

        /// <summary>
        /// Obtiene el valor a usarse para la espera de bloqueo del acceso del login
        /// </summary>
        public string EsperaBloqueo { get; set; }

        /// <summary>
        /// Guarda el id al inicio de la sesión para cerrarlo al final
        /// </summary>
        public int IdParaCierreSesion { get; set; }

        /// <summary>
        /// Mensaje para advertir al usuario sobre su estado en el sistema
        /// </summary>
        public string MensajeAdvertencia { get; set; }

        /// <summary>
        /// Obtiene los días que se avisará para que se cambie la contraseña antes de caducar y bloquearse
        /// </summary>
        public int DiasAvisoCambioContraseña { get; set; }

        /// <summary>
        /// Obtiene el menu del usuario
        /// </summary>
        public string Menu { get; set; }

        public string IdSesion { get; set; }
        public string HoraInicio { get; set; }

        /// <summary>
        /// Arranque del manejo de la sesión (Instanciación general de las propiedades)
        /// </summary>
        public void Inicializar()
        {
            _usuarios = new prop.Usuarios();
            _configuracion = new List<prop.Configuracion>();
        }




    }
}
