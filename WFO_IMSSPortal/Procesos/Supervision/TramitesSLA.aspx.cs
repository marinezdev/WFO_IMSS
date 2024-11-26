using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WFO_IMSSPortal.AccesoDatos.Procesos.Operacion;
using WFO_IMSSPortal.IU;
using WFO_IMSSPortal.Negocio.Procesos.Operacion;
using WFO_IMSSPortal.Propiedades.Procesos.Operacion;
using WFO_IMSSPortal.Utilerias;

namespace WFO_IMSSPortal.Procesos.Supervision
{
    public partial class TramitesSLA : Utilerias.Comun
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			this.manejo_sesion = (ManejadorSesion)this.Session["Sesion"];
			if (!base.IsPostBack)
			{
				this.CargarQuincenasPendiente(this.manejo_sesion.Usuarios.IdUsuario);
			}
		}

		protected void CargarQuincenasPendiente(int Id)
		{
			this.i.operacion.usuariosflujo.SeleccionarQuincenasPendientes_DropDownList(ref this.cboQuincenas, Id);
		}

		protected void CargaFlujos_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		public void btnConsultar_Click(object sender, EventArgs e)
		{
			try
			{
				int IdCalendario = Convert.ToInt32(this.cboQuincenas.SelectedValue.ToString());
				this.MesasLiteral1.Text = "";
				this.MesasLiteral2.Text = "";
				if (IdCalendario != 0)
				{
					List<CalendarioOperacion> calendario = this.i.operacion.pendientes.QuincenanGet(IdCalendario);
					if (calendario.Count > 0)
					{
						CalendarioOperacion data = calendario[0];
						this.TramitesSLA_RevCartas(data);
						this.TramitesSLA_Portal(data);
					}
				}
			}
			catch (Exception ex)
			{
				this.log.Agregar(ex);
			}
		}

		public void TramitesSLA_Portal(CalendarioOperacion dataCalendario)
		{
			try
			{
				string mesas = this.MesasLiteral2.Text;
				int mesaRevision = 0;
				int mesaControl = 0;
				int mesaPortal = 0;
				int mesaInteractivo = 0;
				WFO_IMSSPortal.AccesoDatos.Procesos.Operacion.MapaGeneral mapageneral = new WFO_IMSSPortal.AccesoDatos.Procesos.Operacion.MapaGeneral();
				List<MapaGeneralPendientesQna> Dashboard = mapageneral.getTramitesPendientesQuincena(dataCalendario.Id);
				if (Dashboard.Count > 0)
				{
					foreach (MapaGeneralPendientesQna mesa in Dashboard)
					{
						string mesa2 = mesa.Mesa;
						if (mesa2 != null)
						{
							if (!(mesa2 == "Revisión Cartas"))
							{
								if (!(mesa2 == "Control"))
								{
									if (!(mesa2 == "Captura en Portal"))
									{
										if (mesa2 == "Portal Interactivo")
										{
											mesaInteractivo = mesa.TramitesDisponibles;
										}
									}
									else
									{
										mesaPortal = mesa.TramitesDisponibles;
									}
								}
								else
								{
									mesaControl = mesa.TramitesDisponibles;
								}
							}
							else
							{
								mesaRevision = mesa.TramitesDisponibles;
							}
						}
					}
					mesas = string.Concat(new string[]
					{
						mesas,
						"<div class='col-md-4 col-xs-12'><div class='x_panel'><div class='x_content'><br /><div class='table-responsive'><table class='table table-striped jambo_table bulk_action'><thead><tr class='headings'><th class='column-title'>Trámites Pendientes en Revisión de Catas</th></tr></thead><tbody><tr class='even pointer'><td class=' '>Trámites pendientes de operar en Revisión Cartas: <strong>",
						(mesaRevision + mesaControl).ToString(),
						"</strong></td></tr></tbody></table></div><h5 class='card-title'>Fecha limite para la recepción de cartas: <strong>",
						dataCalendario.Fecha_LimiteCartas.ToString("dd/MM/yyyy"),
						"</strong></h5><hr /><div class='form-group'></div></div></div></div>"
					});
					mesas = string.Concat(new string[]
					{
						mesas,
						"<div class='col-md-4 col-xs-12'><div class='x_panel'><div class='x_content'><br /><div class='table-responsive'><table class='table table-striped jambo_table bulk_action'><thead><tr class='headings'><th class='column-title'>Trámites Pendientes en Portal</th></tr></thead><tbody><tr class='even pointer'><td class=' '>Trámites pendientes de operar en Portal: <strong>",
						mesaPortal.ToString(),
						"</strong></td></tr></tbody></table></div><h5 class='card-title'>Fecha en que finaliza la captura: <strong>",
						dataCalendario.Fecha_TerminaCaptura.ToString("dd/MM/yyyy"),
						"</strong></h5><hr /><div class='form-group'></div></div></div></div>"
					});
					mesas = string.Concat(new string[]
					{
						mesas,
						"<div class='col-md-4 col-xs-12'><div class='x_panel'><div class='x_content'><br /><div class='table-responsive'><table class='table table-striped jambo_table bulk_action'><thead><tr class='headings'><th class='column-title'>Trámites Pendientes en Interactivo</th></tr></thead><tbody><tr class='even pointer'><td class=' '>Trámites pendientes de operar en Interactivo: <strong>",
						mesaInteractivo.ToString(),
						"</strong></td></tr></tbody></table></div><h5 class='card-title'>Fecha en que finaliza el interactivo: <strong>",
						dataCalendario.Fecha_TerminaInteractivo.ToString("dd/MM/yyyy"),
						"</strong></h5><hr /><div class='form-group'></div></div></div></div>"
					});
					this.MesasLiteral2.Text = mesas;
				}
				else
				{
					mesas += "<div class='col-md-6 col-xs-12'><div class='x_panel'><h2><small>No se encontró información de trámites</small></h2></div></div>";
					this.MesasLiteral2.Text = mesas;
				}
			}
			catch (Exception ex)
			{
				this.log.Agregar(ex);
			}
		}

		public void TramitesSLA_RevCartas(CalendarioOperacion dataCalendario)
		{
			try
			{
				string mesas = this.MesasLiteral1.Text;
				List<Tramites_SLA> SLAInformation = this.i.operacion.pendientes.TramitesSLA(dataCalendario.Quincena, dataCalendario.TipoNomina);
				if (SLAInformation.Count > 0)
				{
					int Tramites_Totales = 0;
					string fecha = "";
					mesas += "<div class='col-md-12 col-xs-12'><div class='x_panel'><div class='x_title'><h2><small>ETAPA: <strong>Revisión de Cartas</strong></small></h2><div class='clearfix'></div></div><div class='x_content'><br /><div class='table-responsive'><table class='table table-striped jambo_table bulk_action'><thead><tr class='headings'><th class='column-title' style='text-align: center;'>PERIODO</th><th class='column-title'>DÍA</th><th class='column-title'>TRÁMITES INGRESADOS</th><th class='column-title'>TRÁMITES PROCESADOS</th><th class='column-title'>TRÁMITES PENDIENTES</th><th class='column-title'>VER TRÁMITES</th></tr></thead><tbody>";
					foreach (Tramites_SLA datos in SLAInformation)
					{
						if (fecha.Length == 0)
						{
							Tramites_Totales = datos.Tramites_Total;
							fecha = datos.Periodo.Substring(datos.Periodo.Length - 19);
						}

						mesas += "<tr ";

						switch (datos.SLA)
						{
							case 0:
								lblPriodo0.Text = datos.Periodo;
								break;

							case 1:
								lblPriodo1.Text = datos.Periodo;
								break;

							case 2:
								lblPriodo2.Text = datos.Periodo;
								break;

							case 3:
								lblPriodo3.Text = datos.Periodo;
								break;
						}

						if (datos.SLA >= 3 && datos.Tramites_Pedientes > 0)
						{
							mesas += " style='color:red;' ";
						}

						string strButton = "<button type = 'button' class='btn btn-success' onclick='DetalleMesa(" + datos.SLA.ToString() + ")';>Mostrar detalles</button>";


						mesas = string.Concat(new string[]
						{
							mesas,
							"class='even pointer'><td class=' '>",
							datos.Periodo,
							"</td><td class=' ' style='text-align: center;'> <strong>",
							datos.SLA.ToString(),
							"</strong></td><td class=' ' style='text-align: center;'>",
							datos.Tramites_xDia.ToString(),
							"</td><td class=' ' style='text-align: center;'>",
							datos.Tramites_Procesados.ToString(),
							"</td><td class=' ' style='text-align: center;'>",
							datos.Tramites_Pedientes.ToString(),
							"</td><td class=' ' style='text-align: center;'>",
							strButton,
							"</td></tr>"
						});
					}
					mesas = string.Concat(new string[]
					{
						mesas,
						"</tbody></table></div><h3>Total de Trámites Ingresados en la Quincena: ",
						Tramites_Totales.ToString(),
						"</h3><h5 class='card-title'>Reporte Actualizado a: <strong>",
						fecha,
						"</strong></h5><hr /><div class='form-group'></div></div></div></div>"
					});
					this.MesasLiteral1.Text = mesas;
				}
				else
				{
					mesas += "<div class='col-md-6 col-xs-12'><div class='x_panel'><h2><small>No se encontró información de trámites</small></h2></div></div>";
					this.MesasLiteral1.Text = mesas;
				}
			}
			catch (Exception ex)
			{
				this.log.Agregar(ex);
			}
		}

		protected void rptTramite_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
		}

		[WebMethod]
		public static ListaDeTramites DetalleMesa(int dia, int IdCalendario ,string RangoFecha)
		{
			DataTable dt = null;
			CalendarioOperacion data = null;
			if (IdCalendario != 0)
			{
				List<CalendarioOperacion> calendario = (new WFO_IMSSPortal.Negocio.Procesos.Operacion.Operacion()).pendientes.QuincenanGet(IdCalendario);
				data = calendario[0];
			}

			List<TramitesDetalle> DetalleTramite = (new WFO_IMSSPortal.Negocio.Procesos.Operacion.Operacion()).pendientes.TramitesSLADetalle(dia, RangoFecha, data.Quincena, data.TipoNomina);

			/* LLENAR JSON PARA RETORNAR */
			ListaDeTramites jsonObject = new ListaDeTramites();
			jsonObject.Tramites = new List<TramitesDetalle>();
			foreach (var datos in DetalleTramite)
			{
				jsonObject.Tramites.Add(new TramitesDetalle()
				{
					IdTramte = datos.IdTramte,
					FechaRegitro = datos.FechaRegitro,
					Poliza = datos.Poliza,
					Quincena = datos.Quincena,
					TipoNomina = datos.TipoNomina,
					TipoMovimimento = datos.TipoMovimimento,
					statusMesa = datos.statusMesa
				});
			}

			return jsonObject;
		}
	}
}