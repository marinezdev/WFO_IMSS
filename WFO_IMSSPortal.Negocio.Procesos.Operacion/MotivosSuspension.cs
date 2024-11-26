using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using DevExpress.Web.ASPxTreeList;

namespace WFO_IMSSPortal.Negocio.Procesos.Operacion
{
    public class MotivosSuspension
    {
        AccesoDatos.Procesos.Operacion.MotivosSuspension _MotivosSuspension = new AccesoDatos.Procesos.Operacion.MotivosSuspension();

        public List<prop.MotivosSuspension> SelecionarMotivos(int IdMesa)
        {
            return _MotivosSuspension.SelecionarMotivos(IdMesa);
        }

        public void SeleccionarMotivosSuspension(ref ASPxTreeList aspxtreelist1, ref ASPxTreeList aspxtreelist2, int idmesa)
        {
            List<prop.MotivosSuspension> lsMotivosSuspension = _MotivosSuspension.SelecionarMotivos(idmesa);

            aspxtreelist1.ClearNodes();
            aspxtreelist1.DataSource = lsMotivosSuspension.Where(MotivoSuspension => lsMotivosSuspension.FirstOrDefault(valor => MotivoSuspension.IdTramiteTipoRechazo == 4) != null);           // SELECT * FROM cat_Tramite_RechazosTipos;
            aspxtreelist1.DataBind();
            aspxtreelist1.ExpandToLevel(3);

            aspxtreelist2.ClearNodes();
            aspxtreelist2.DataSource = lsMotivosSuspension.Where(MotivoSuspension => lsMotivosSuspension.FirstOrDefault(valor => MotivoSuspension.IdTramiteTipoRechazo == 3) != null);      // SELECT * FROM cat_Tramite_RechazosTipos;
            aspxtreelist2.DataBind();
            aspxtreelist2.ExpandToLevel(3);
        }
    }
}
