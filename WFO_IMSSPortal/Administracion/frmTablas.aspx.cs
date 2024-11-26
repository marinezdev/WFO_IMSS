using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Administracion
{
    public partial class frmTablas : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocio.Inicializador.Inicializador cmn = new Negocio.Inicializador.Inicializador();

            if (!IsPostBack)
            {
                cmn.cats.TramiteTipo_DropDownList(ref DDLGenerico, "tramite_tipo");
            }
        }




    }
}