using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WFO_IMSSPortal.Procesos.Promotoria
{
    public partial class EsperaPromotoria : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                Funciones.LlenarControles.LlenarDropDownList(ref DDLQuicena, i.operacion.mesas.QuincenasActivas(), "Nombre", "Id");

                //PintaGrafica(manejo_sesion.Usuarios.IdUsuario);
                //MuestraGrafica(manejo_sesion.Usuarios.IdUsuario, manejo_sesion.Usuarios.Nombre);
                //LisStatusTramite();
            }
        }

        protected void MuestraGrafica(int Id,string NombrePromotoria)
        {
            //List<prop.IndicadorGeneral> TramitesTotales = i.promotoria.indicadorgeneral.SeleccionaEstatusTotales(Id);

            //ltMuestraGrafica.Text = "<canvas id='myChart' width='400' height='220'></canvas>";
            //string script = "";
            //script = "var ctx = document.getElementById('myChart').getContext('2d');" +
            //         "var myChart = new Chart(ctx, {" +
            //             "type: 'bar'," +
            //             "data: {" +
            //                "labels: [";
            //                string label = "";

            //                for (int i = 0; i < TramitesTotales.Count; i++)
            //                {
            //                    label += "'" + TramitesTotales[i].Estado + "',";
            //                }

            //script += label + "]," +
            //                "datasets: [{ " +
            //                    "label: 'Tramites Promotoria: "+ NombrePromotoria + "',";
            //                    string data = "data: [";

            //                    for (int i = 0; i < TramitesTotales.Count; i++)
            //                    {
            //                        data +=  TramitesTotales[i].Totales + ",";
            //                    }

            //                   data += "],";

            //script += data;

            //script += "backgroundColor: [";
            //                    string backgroundColor = "";
            //                    for (int i = 0; i < TramitesTotales.Count; i++)
            //                    {
            //                        backgroundColor += "'" + TramitesTotales[i].BackgroundColor.Trim().ToString() + "',";
            //                    }
            //                    //backgroundColor += "'#BDC3C7'," +
            //                    //                "'#9B59B6'," +
            //                    //                "'#E74C3C'," +
            //                    //                "'#26B99A'," +
            //                    //                "'#3498DB'";

            //script += backgroundColor;
            //script += "]," +
            //                    "borderColor: [";
            //                    string borderColor = "";
            //                    for (int i = 0; i < TramitesTotales.Count; i++)
            //                    {
            //                        borderColor += "'" + TramitesTotales[i].BorderColor.Trim().ToString() + "',";
            //                    }
            //                            //"'#BDC3C7'," +
            //                            //"'#9B59B6'," +
            //                            //"'#E74C3C'," +
            //                            //"'#26B99A'," +
            //                            //"'#3498DB'";

            //script += borderColor;
            //script += "]," +
            //                    "hoverBackgroundColor: [";
            //                    string hoverBackgroundColor = "";
            //                    for (int i = 0; i < TramitesTotales.Count; i++)
            //                    {
            //                        hoverBackgroundColor += "'" + TramitesTotales[i].HoverBackgroundColor.Trim().ToString() + "',";
            //                    }
            //                        //"'#CFD4D8'," +
            //                        //"'#B370CF'," +
            //                        //"'#E95E4F'," +
            //                        //"'#36CAAB'," +|
            //                        //"'#49A9EA'";

            //script += hoverBackgroundColor;
            //script +=           "]," +
            //                    "borderWidth: 1" +
            //                "}]"+
            //            "},"+
            //            "options:"+
            //            "{"+
            //                "scales:"+
            //                "{"+
            //                    "yAxes: [{"+
            //                        "ticks:"+
            //                        "{"+
            //                            "beginAtZero: true"+
            //                        "}"+
            //                    "}]"+
            //                "}," +
            //                "bezierCurve: false,"+
            //                "animation:"+
            //                "{"+
            //                    "onComplete: descarga"+
            //                "}"+
            //             "}"+
            //        "});" +
            //        "function descarga() {"+
            //            "var url_base64jp = myChart.toBase64Image();" +
            //            "var link = document.getElementById('link');" +
            //            "link.setAttribute('href', url_base64jp);"+
            //        "}" +
            //        "";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }

        protected void PintaGrafica(string quincena, string tiponomina)
        {
            i.promotoria.indicadorgeneral.SeleccionaEstatusTotales(ref grfGrupoUno, quincena, tiponomina); 
        }
        
        private void LisStatusTramite()
        {
            //List<prop.cat_statusTramite> cat_StatusTramites = i.promotoria.catalogos.cat_StatusTramites();
            //LisEstatusTramite.DataSource = cat_StatusTramites;
            //LisEstatusTramite.DataBind();
            //LisEstatusTramite.DataTextField = "Nombre";
            //LisEstatusTramite.DataValueField = "Nombre";
            //LisEstatusTramite.DataBind();

            //Funciones.LlenarControles.LlenarDropDownList(ref LisEstatusTramite, i.promotoria.catalogos.cat_StatusTramites(), "Nombre", "Nombre");

            i.promotoria.catalogos.cat_StatusTramites_DropDownList(ref LisEstatusTramite);
        }

        protected void LisEstatusTramite_SelectedIndexChanged(object sender, EventArgs e)
        {
            //manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            //PintaGrafica(manejo_sesion.Usuarios.IdUsuario);
            //MuestraGrafica(manejo_sesion.Usuarios.IdUsuario, manejo_sesion.Usuarios.Nombre);

            //string estado = Convert.ToString(LisEstatusTramite.SelectedValue.ToString());
            //LabelEstado.Text = estado;
            //ListaTramitesEstatus.Visible = true;

            ////List<prop.TramitesPromotoria> Tramites = i.promotoria.tramitespromotoria.ListaTramitesPromotoriaEstado(manejo_sesion.Usuarios.IdUsuario, estado);

            ////rptTramite.DataSource = Tramites;
            ////rptTramite.DataBind();

            //Funciones.LlenarControles.LlenarRepeater(ref rptTramite, i.promotoria.tramitespromotoria.ListaTramitesPromotoriaEstado(manejo_sesion.Usuarios.IdUsuario, estado));
        }

        protected void grfGrupoUno_Click(object sender, ImageMapEventArgs e)
        {
            //manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            PintaGrafica(DDLQuicena.SelectedValue, DDLTipoNomina.SelectedValue);
            //PintaGrafica(manejo_sesion.Usuarios.IdUsuario);

            string estado = Convert.ToString(e.PostBackValue);
            LabelEstado.Text = estado;
            ListaTramitesEstatus.Visible = true;

            //List<prop.TramitesPromotoria> Tramites = i.promotoria.tramitespromotoria.ListaTramitesPromotoriaEstado(manejo_sesion.Usuarios.IdUsuario, estado);

            //rptTramite.DataSource = Tramites;
            //rptTramite.DataBind();

            //Funciones.LlenarControles.LlenarRepeater(ref rptTramite, i.promotoria.tramitespromotoria.ListaTramitesPromotoriaEstado(manejo_sesion.Usuarios.IdUsuario, estado));
            //Funciones.LlenarControles.LlenarRepeater(ref rptTramite, i.promotoria.tramitespromotoria.ListaTramitesPromotoriaEstado(Funciones.Nums.TextoAEntero(DDLPromotorias.SelectedValue), Funciones.Nums.TextoAEntero(DDLQuicena.SelectedValue), estado));
            i.promotoria.tramitespromotoria.ListaTramitesPromotoriaEstado(ref rptTramite, DDLQuicena.SelectedValue, DDLTipoNomina.SelectedValue, estado);

            string script = "";
            script = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); ";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }

        protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Consultar"))
            {
                string IdTramite = e.CommandArgument.ToString();
                Response.Redirect("ConsultaTramite.aspx?Id=" + IdTramite, true);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Búsqueda en base a lo solicitado
            PintaGrafica(DDLQuicena.SelectedValue, DDLTipoNomina.SelectedValue);
        }

    }
}