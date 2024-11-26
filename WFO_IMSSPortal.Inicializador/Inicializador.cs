namespace WFO_IMSSPortal.Negocio.Inicializador
{
    public class Inicializador
    {
        /// <summary>
        /// Instancia de Procesos de Negocio Imss Portal
        /// </summary>
        public Procesos.IMSSPortal.IMSSPortal imssportal;
        /// <summary>
        /// Instancia de Procesos de Negocio Operación
        /// </summary>
        public Procesos.Operacion.Operacion operacion;
        /// <summary>
        /// Instancia de Procesos de Negocio de Promotoría
        /// </summary>
        public Procesos.Promotoria.Promotoria promotoria;
        /// <summary>
        /// Instancia de Procesos de Negocio de Administración del Sistema
        /// </summary>
        public Sistema.Sistema administracion;
        /// <summary>
        /// Instancia de Procesos de Negocio de supervisión
        /// </summary>
        public Procesos.Supervision.Supervision supervision;
        /// <summary>
        /// Instancia de Procesos de Negocio de Supervisión General
        /// </summary>
        public Procesos.SupervisionGeneral.SupervisionGeneral supervisiongeneral;


        //Catalogos
        /// <summary>
        /// Catalogos Genericos
        /// </summary>
        public Catalogos.Catalogo cats;

        public Inicializador()
        {

            //Catalogos
            cats = new Catalogos.Catalogo();


            imssportal = new Procesos.IMSSPortal.IMSSPortal();
            operacion = new Procesos.Operacion.Operacion();
            promotoria = new Procesos.Promotoria.Promotoria();
            administracion = new Sistema.Sistema();
            supervision = new Procesos.Supervision.Supervision();
            supervisiongeneral = new Procesos.SupervisionGeneral.SupervisionGeneral();
        }


    }
}
