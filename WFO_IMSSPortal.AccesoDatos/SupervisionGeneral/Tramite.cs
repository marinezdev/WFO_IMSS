using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = WFO_IMSSPortal.Propiedades.Procesos.SupervisionGeneral;
using f = WFO_IMSSPortal.Funciones;

namespace WFO_IMSSPortal.AccesoDatos.SupervisionGeneral
{
    public class Tramite
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Tramite> Seleccionar()
        {
            b.ExecuteCommandSP("Tramite_Seleccionar");
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id              = reader["Id"].ToString(),
                    Folio           = reader["Folio"].ToString(),
                    IdTipoTramite   = reader["IdTipoTramite"].ToString(),
                    TipoTramite     = reader["TipoTramite"].ToString(),
                    FechaRegistro   = reader["FechaRegistro"].ToString(),
                    FechaTermino    = reader["FechaTermino"].ToString(),
                    FechaSolicitud  = reader["FechaSolicitud"].ToString(),
                    IdPromotoria    = reader["IdPromotoria"].ToString(),
                    Promotoría      = reader["Promotoria"].ToString(),
                    ClavePromotoria = reader["ClavePromotoria"].ToString(),
                    IdStatus        = reader["IdStatus"].ToString(),
                    Status          = reader["Status"].ToString(),
                    IdUsuario       = reader["IdUsuario"].ToString(),
                    IdAgente        = reader["IdAgente"].ToString(),
                    NumeroOrden     = reader["NumeroOrden"].ToString(),
                    IdPrioridad     = reader["IdPrioridad"].ToString(),
                    Prioridad       = reader["Prioridad"].ToString(),
                    IdSisLegados    = reader["IdSisLegados"].ToString(),
                    Kwik            = reader["Kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public prop.Tramite SeleccionarPorId(string id)
        {
            b.ExecuteCommandSP("Tramite_Seleccionar_PorId ");
            b.AddParameter("@id", id, SqlDbType.Int);
            prop.Tramite resultado = new prop.Tramite();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id              = reader["id"].ToString();
                resultado.IdTipoTramite   = reader["idtipotramite"].ToString();
                resultado.FechaRegistro   = reader["fecharegistro"].ToString();
                resultado.FechaTermino    = reader["fechatermino"].ToString();
                resultado.IdStatus        = reader["idstatus"].ToString();
                resultado.IdPromotoria    = reader["idpromotoria"].ToString();
                resultado.IdUsuario       = reader["idusuario"].ToString();
                resultado.IdAgente        = reader["idagente"].ToString();
                resultado.NumeroOrden     = reader["numeroorden"].ToString();
                resultado.FechaSolicitud  = reader["fechasolicitud"].ToString();
                resultado.IdPrioridad     = reader["idprioridad"].ToString();
                resultado.IdSisLegados    = reader["idsislegados"].ToString();
                resultado.Kwik            = reader["kwik"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Tramite> Buscar(string foliocompuesto, string fecharegistrodel, string fecharegistroal, string fechasolicituddel, string fechasolicitudal, string idpromotoria, string estado)
        {
            string folio = "%" + foliocompuesto + "%";
            b.ExecuteCommandSP("Tramite_Seleccionar_Buscar");
            b.AddParameter("@foliocompuesto", folio == "%%" ? DBNull.Value : (Object)folio, SqlDbType.VarChar, 20);
            b.AddParameter("@fecharegistrodel",  fecharegistrodel == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fecharegistrodel), SqlDbType.VarChar);
            b.AddParameter("@fecharegistroal", fecharegistroal == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fecharegistroal), SqlDbType.VarChar);
            b.AddParameter("@fechasolicituddel", fechasolicituddel == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fechasolicituddel), SqlDbType.VarChar);
            b.AddParameter("@fechasolicitudal", fechasolicitudal == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fechasolicitudal), SqlDbType.VarChar);
            b.AddParameter("@idpromotoria", idpromotoria == "0" ? DBNull.Value : (Object)idpromotoria, SqlDbType.Int);
            b.AddParameter("@estado", estado == "0" ? DBNull.Value : (Object)estado, SqlDbType.Int);

            List <prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id = reader["Id"].ToString(),
                    Folio = reader["Folio"].ToString(),
                    IdTipoTramite = reader["IdTipoTramite"].ToString(),
                    TipoTramite = reader["TipoTramite"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    FechaTermino = reader["FechaTermino"].ToString(),
                    FechaSolicitud = reader["FechaSolicitud"].ToString(),
                    IdPromotoria = reader["IdPromotoria"].ToString(),
                    Promotoría = reader["Promotoria"].ToString(),
                    ClavePromotoria = reader["ClavePromotoria"].ToString(),
                    IdStatus = reader["IdStatus"].ToString(),
                    Status = reader["Status"].ToString(),
                    IdUsuario = reader["IdUsuario"].ToString(),
                    IdAgente = reader["IdAgente"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    IdPrioridad = reader["IdPrioridad"].ToString(),
                    Prioridad = reader["Prioridad"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    Kwik = reader["Kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataTable SeleccionarTramitesPorMesa(string fase)
        {
            b.ExecuteCommandSP("Tramite_EstadosMesa");
            b.AddParameter("@fase", Int32.Parse(fase), SqlDbType.Int);
            return b.Select();
        }

        public DataTable ListadoTramitesOperacion()
        {
            b.ExecuteCommandSP("spListadoTramitesOperacionN1");
            return b.Select();
        }

        public DataTable ListadoTramitesOperacionN3()
        {
            b.ExecuteCommandSP("spListadoTramitesOperacionN3");
            return b.Select();
        }

        public DataTable SeleccionarTramiteConsultaX()
        {
            b.ExecuteCommandSP("Tramites_Seleccionar_ConsultaX");
            return b.Select();
        }

        public int ModificarPrioridad(string id)
        {
            b.ExecuteCommandSP("Tramite_Modificar_Prioridad");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public List<prop.Tramite> TramiteSupervicionGeneralSelecionar(int Id, DateTime Fecha_Inicio, DateTime Fecha_Termino, string Folio, string RFC, string Nombre, string ApPaterno, string ApMaterno)
        {
            b.ExecuteCommandSP("Tramite_SupervicionGeneral_Selecionar_PorIdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);
            b.AddParameter("@Fecha_Termino", Fecha_Termino, SqlDbType.DateTime);
            b.AddParameter("@Folio", Folio, SqlDbType.NVarChar);
            b.AddParameter("@RFC", RFC, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApPaterno", ApPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApMaterno", ApMaterno, SqlDbType.NVarChar);
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id = reader["Id"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Folio = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    FechaSolicitud = reader["FechaSolicitud"].ToString(),
                    Status = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    Kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public bool EnlaceListadoActivar(string Quincena, string TipoNomina, int IdAplicarEnlace)
        {
            bool resultado = false;
            b.ExecuteCommandSP("Tramites_Enlace_Aplicar");
            b.AddParameter("@IdAplicarEnlace", IdAplicarEnlace, SqlDbType.Int);
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (reader["resultado"].ToString() == "1")
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataSet EnlaceGenerarMasivo(
            string Quincena1, string TNAA1, string TNEA1, string TNMM1, string TNJJ1, string TMAlta1, string TMModif1, string TMBaja1,
            string Quincena2, string TNAA2, string TNEA2, string TNMM2, string TNJJ2, string TMAlta2, string TMModif2, string TMBaja2,
            string Quincena3, string TNAA3, string TNEA3, string TNMM3, string TNJJ3, string TMAlta3, string TMModif3, string TMBaja3,
            string Quincena4, string TNAA4, string TNEA4, string TNMM4, string TNJJ4, string TMAlta4, string TMModif4, string TMBaja4,
            string Quincena5, string TNAA5, string TNEA5, string TNMM5, string TNJJ5, string TMAlta5, string TMModif5, string TMBaja5,
            string Quincena6, string TNAA6, string TNEA6, string TNMM6, string TNJJ6, string TMAlta6, string TMModif6, string TMBaja6,
            string QuincenaResultante, ref string error
        )
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("EXEC Tramites_Enlace_GenerarMasivo ");
                System.Diagnostics.Debug.WriteLine(QuincenaResultante + ", ");
                System.Diagnostics.Debug.WriteLine(Quincena1 + ", " + TNAA1 + ", " + TNEA1 + ", " + TNMM1 + ", " + TNJJ1 + ", " + TMAlta1 + ", " + TMModif1 + ", " + TMBaja1 + ", ");
                System.Diagnostics.Debug.WriteLine(Quincena2 + ", " + TNAA2 + ", " + TNEA2 + ", " + TNMM2 + ", " + TNJJ2 + ", " + TMAlta2 + ", " + TMModif2 + ", " + TMBaja2 + ", ");
                System.Diagnostics.Debug.WriteLine(Quincena3 + ", " + TNAA3 + ", " + TNEA3 + ", " + TNMM3 + ", " + TNJJ3 + ", " + TMAlta3 + ", " + TMModif3 + ", " + TMBaja3 + ", ");
                System.Diagnostics.Debug.WriteLine(Quincena4 + ", " + TNAA4 + ", " + TNEA4 + ", " + TNMM4 + ", " + TNJJ4 + ", " + TMAlta4 + ", " + TMModif4 + ", " + TMBaja4 + ", ");
                System.Diagnostics.Debug.WriteLine(Quincena5 + ", " + TNAA5 + ", " + TNEA5 + ", " + TNMM5 + ", " + TNJJ5 + ", " + TMAlta5 + ", " + TMModif5 + ", " + TMBaja5 + ", ");
                System.Diagnostics.Debug.WriteLine(Quincena6 + ", " + TNAA6 + ", " + TNEA6 + ", " + TNMM6 + ", " + TNJJ6 + ", " + TMAlta6 + ", " + TMModif6 + ", " + TMBaja6 + ", ");

                b.ExecuteCommandSP("Tramites_Enlace_GenerarMasivo");
                b.AddParameter("@QuincenaResultante", QuincenaResultante, SqlDbType.VarChar);
                b.AddParameter("@Quincena1", Quincena1, SqlDbType.VarChar);
                b.AddParameter("@TNAA1", TNAA1, SqlDbType.VarChar);
                b.AddParameter("@TNEA1", TNEA1, SqlDbType.VarChar);
                b.AddParameter("@TNMM1", TNMM1, SqlDbType.VarChar);
                b.AddParameter("@TNJJ1", TNJJ1, SqlDbType.VarChar);
                b.AddParameter("@TMAlta1", TMAlta1, SqlDbType.VarChar);
                b.AddParameter("@TMModif1", TMModif1, SqlDbType.VarChar);
                b.AddParameter("@TMBaja1", TMBaja1, SqlDbType.VarChar);

                b.AddParameter("@Quincena2", Quincena2, SqlDbType.VarChar);
                b.AddParameter("@TNAA2", TNAA2, SqlDbType.VarChar);
                b.AddParameter("@TNEA2", TNEA2, SqlDbType.VarChar);
                b.AddParameter("@TNMM2", TNMM2, SqlDbType.VarChar);
                b.AddParameter("@TNJJ2", TNJJ2, SqlDbType.VarChar);
                b.AddParameter("@TMAlta2", TMAlta2, SqlDbType.VarChar);
                b.AddParameter("@TMModif2", TMModif2, SqlDbType.VarChar);
                b.AddParameter("@TMBaja2", TMBaja2, SqlDbType.VarChar);

                b.AddParameter("@Quincena3", Quincena3, SqlDbType.VarChar);
                b.AddParameter("@TNAA3", TNAA3, SqlDbType.VarChar);
                b.AddParameter("@TNEA3", TNEA3, SqlDbType.VarChar);
                b.AddParameter("@TNMM3", TNMM3, SqlDbType.VarChar);
                b.AddParameter("@TNJJ3", TNJJ3, SqlDbType.VarChar);
                b.AddParameter("@TMAlta3", TMAlta3, SqlDbType.VarChar);
                b.AddParameter("@TMModif3", TMModif3, SqlDbType.VarChar);
                b.AddParameter("@TMBaja3", TMBaja3, SqlDbType.VarChar);

                b.AddParameter("@Quincena4", Quincena4, SqlDbType.VarChar);
                b.AddParameter("@TNAA4", TNAA4, SqlDbType.VarChar);
                b.AddParameter("@TNEA4", TNEA4, SqlDbType.VarChar);
                b.AddParameter("@TNMM4", TNMM4, SqlDbType.VarChar);
                b.AddParameter("@TNJJ4", TNJJ4, SqlDbType.VarChar);
                b.AddParameter("@TMAlta4", TMAlta4, SqlDbType.VarChar);
                b.AddParameter("@TMModif4", TMModif4, SqlDbType.VarChar);
                b.AddParameter("@TMBaja4", TMBaja4, SqlDbType.VarChar);

                b.AddParameter("@Quincena5", Quincena5, SqlDbType.VarChar);
                b.AddParameter("@TNAA5", TNAA5, SqlDbType.VarChar);
                b.AddParameter("@TNEA5", TNEA5, SqlDbType.VarChar);
                b.AddParameter("@TNMM5", TNMM5, SqlDbType.VarChar);
                b.AddParameter("@TNJJ5", TNJJ5, SqlDbType.VarChar);
                b.AddParameter("@TMAlta5", TMAlta5, SqlDbType.VarChar);
                b.AddParameter("@TMModif5", TMModif5, SqlDbType.VarChar);
                b.AddParameter("@TMBaja5", TMBaja5, SqlDbType.VarChar);

                b.AddParameter("@Quincena6", Quincena6, SqlDbType.VarChar);
                b.AddParameter("@TNAA6", TNAA6, SqlDbType.VarChar);
                b.AddParameter("@TNEA6", TNEA6, SqlDbType.VarChar);
                b.AddParameter("@TNMM6", TNMM6, SqlDbType.VarChar);
                b.AddParameter("@TNJJ6", TNJJ6, SqlDbType.VarChar);
                b.AddParameter("@TMAlta6", TMAlta6, SqlDbType.VarChar);
                b.AddParameter("@TMModif6", TMModif6, SqlDbType.VarChar);
                b.AddParameter("@TMBaja6", TMBaja6, SqlDbType.VarChar);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }

            return b.SelectExecuteFunctions();
        }

        public DataSet EnlaceGenerarMasivo_V2(string QuincenaEnlace, ref string error)
        {
            try
            {
                //System.Diagnostics.Debug.WriteLine("EXEC Tramites_Enlace_GenerarV2 ");
                //System.Diagnostics.Debug.WriteLine(" @QuincenaEnlace = " + QuincenaEnlace);

                //b.ExecuteCommandSP("Tramites_Enlace_GenerarV3");
                //b.ExecuteCommandSP("Tramites_Enlace_GenerarV3_dExtraccion");
                b.ExecuteCommandSP("Tramites_Enlace_GenerarV4_Efectividad");
                b.AddParameter("@QuincenaEnlace", QuincenaEnlace, SqlDbType.VarChar);
            }
            catch (Exception ex)
            {
                error = ex.Message.ToString();
            }

            return b.SelectExecuteFunctions();
        }

        public DataSet EnlaceGenerar(string Quincena, string TipoNomina)
        {
            try
            {
                b.ExecuteCommandSP("Tramites_Enlace_Generar");
                b.AddParameter("@Quincena", Quincena, SqlDbType.VarChar, 6);
                b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar, 2);
            }
            catch (Exception ex)
            {
                string Error = ex.Message.ToString();
            }
            
            return b.SelectExecuteFunctions();
        }

        public bool ExtraccionDuplicadosDelete(string Quincena, string TipoNomina, int IdExtraccion, int IdUsuario)
        {
            bool resultado = false;
            b.ExecuteCommandSP("Tramites_Obtener_ExtraccionDuplicadosDelete");
            b.AddParameter("@IdExtraccion", IdExtraccion, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (reader["RESULTADO"].ToString() == "1")
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Extraccion> ExtraccionDuplicados(string Quincena, string TipoNomina)
        {
            b.ExecuteCommandSP("Tramites_Obtener_ExtraccionDuplicados");
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar, 2);
            b.AddParameter("@Quincena", Quincena, SqlDbType.VarChar, 6);
            List<prop.Extraccion> resultado = new List<prop.Extraccion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    prop.Extraccion item = new prop.Extraccion()
                    {
                        Id = reader["ID"].ToString(),
                        Matricula = reader["MATRICULA"].ToString(),
                        Poliza = reader["POLIZA"].ToString(),
                        TipoMovimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                        TipoNomina = reader["ANO_QUINCENA"].ToString(),
                        Quincena = reader["TIPO_NOMINA"].ToString(),
                        Trabajador = reader["NOMBRE_TRABAJADOR"].ToString(),
                        Importe = reader["IMPORTE"].ToString()
                    };
                    resultado.Add(item);
                }
                catch (Exception ex)
                {
                    string error = ex.Message.ToString();
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    
        public List<prop.EnlaceListado> EnlaceListado(string Quincena, string TipoNomina)
        {
                b.ExecuteCommandSP("Tramites_Obtener_EnlaceAplicable");
                b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar,2);
                b.AddParameter("@Quincena", Quincena, SqlDbType.VarChar,6);
                List<prop.EnlaceListado> resultado = new List<prop.EnlaceListado>();
                var reader = b.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        prop.EnlaceListado item = new prop.EnlaceListado()
                        {
                            EnlaceClave = reader["EnlaceClave"].ToString(),
                            TipoPrestamo = reader["Tipo de Prestamo"].ToString(),
                            Matricula = reader["Matrícula"].ToString(),
                            Concepto = reader["Concepto"].ToString(),
                            Importe = reader["Importe"].ToString(),
                            Plazo = reader["Plazo"].ToString(),
                            NumeroControl = reader["Numero de Control"].ToString(),
                            NumeroCredito = reader["Numero de Crédito (Póliza)"].ToString(),
                            CifraControl = reader["Cifra Control (Importe)"].ToString(),
                            TipoMovimiento = reader["Tipo de Movimiento"].ToString(),
                            NombreTrabajador = reader["Nombre del Trabajador"].ToString(),
                            Retenedor = reader["Numero de Provedor (Retenedor)"].ToString(),
                            Caracter = reader["Carácter"].ToString(),
                            AplicaEnlace = bool.Parse(reader["APLICAENLACE"].ToString())
                        };
                        resultado.Add(item);
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message.ToString();
                    }
                }
                reader = null;
                b.ConnectionCloseToTransaction();
                return resultado;
            }
    }
}
