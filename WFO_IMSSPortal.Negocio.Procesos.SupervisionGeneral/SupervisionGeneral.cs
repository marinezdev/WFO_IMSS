namespace WFO_IMSSPortal.Negocio.Procesos.SupervisionGeneral
{
    public class SupervisionGeneral
    {
        /// <summary>
        /// Acceso a métodos de negocio de asignar
        /// </summary>
        public Asignar asignar;
        /// <summary>
        /// Acceso a métodos de negocio de catatalogo promotoria
        /// </summary>
        public cat_promotoria catpromotoria;
        /// <summary>
        /// Acceso a métodos de negocio de tramite
        /// </summary>
        public Tramite tramite;
        /// <summary>
        /// Acceso a métodos de negocio de tramite bitacora
        /// </summary>
        public TramiteBitacora tramitebitacora;
        /// <summary>
        /// Acceso a métodos de negocio de tramite mesa
        /// </summary>
        public TramiteMesa tramitemesa;
        /// <summary>
        /// Acceso a métodos de negocio de usuarios
        /// </summary>
        public Usuarios usuarios;

        public SupervisionGeneral()
        {
            asignar = new Asignar();
            catpromotoria = new cat_promotoria();
            tramite = new Tramite();
            tramitebitacora = new TramiteBitacora();
            tramitemesa = new TramiteMesa();
            usuarios = new Usuarios();
        }
    }
}
