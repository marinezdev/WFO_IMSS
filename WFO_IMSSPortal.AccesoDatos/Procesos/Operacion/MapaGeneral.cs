using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFO_IMSSPortal.AccesoDatos.Procesos.Operacion
{
    public class MapaGeneral
    {
        ManejoDatos b = new ManejoDatos();


        public List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna> getTramitesPendientesQuincena(int IdCalendario)
        {
            b.ExecuteCommandSP("spWFOMapaGeneral_TramitesPendietes");
            b.AddParameter("@IdCalendario", IdCalendario, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneralPendientesQna item = new Propiedades.Procesos.Operacion.MapaGeneralPendientesQna()
                {
                    IdMesa = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Mesa = reader["Nombre"].ToString(),
                    Icono = reader["Icono"].ToString(),
                    TramitesDisponibles = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Propiedades.Procesos.Operacion.MapaGeneral> getDashboard(int IdFlujo)
        {
            b.ExecuteCommandSP("spWFOMapaGeneral");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneral> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneral item = new Propiedades.Procesos.Operacion.MapaGeneral()
                {
                    IdMesa              = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Mesa                = reader["Nombre"].ToString(),
                    Icono               = reader["Icono"].ToString(),
                    UsuariosConectados  = Funciones.Nums.TextoAEntero(reader["UsuariosDisponibles"].ToString()),
                    TramitesDisponibles = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()),
                    TramitesReingresos  = Funciones.Nums.TextoAEntero(reader["TramitesReingresos"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        
        public List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna> getDashboardMesaProd(int IdCalendario, int IdFlujo, int IdMesa)
        {
            b.ExecuteCommandSP("spWFOMapaGeneralMesaProd");
            b.AddParameter("@IdCalendario", IdCalendario, SqlDbType.Int);
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneralPendientesQna>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneralPendientesQna item = new Propiedades.Procesos.Operacion.MapaGeneralPendientesQna()
                {
                    IdMesa = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Mesa = reader["Nombre"].ToString(),
                    Icono = reader["Icono"].ToString(),
                    TramitesDisponibles = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Procesos.Operacion.MapaGeneral> getDashboardMesa(int IdFlujo, int IdMesa)
        {
            b.ExecuteCommandSP("spWFOMapaGeneralMesa");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneral> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneral item = new Propiedades.Procesos.Operacion.MapaGeneral()
                {
                    IdMesa              = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Mesa                = reader["Nombre"].ToString(),
                    Icono               = reader["Icono"].ToString(),
                    UsuariosConectados  = Funciones.Nums.TextoAEntero(reader["UsuariosDisponibles"].ToString()),
                    TramitesDisponibles = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()),
                    TramitesReingresos  = Funciones.Nums.TextoAEntero(reader["TramitesReingresos"].ToString()),
                    TotalTramites       = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()) + Funciones.Nums.TextoAEntero(reader["TramitesReingresos"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Procesos.Operacion.MapaGeneral> getDashboardMesaDetalle(int IdFlujo, int IdMesa)
        {
            b.ExecuteCommandSP("spWFOMapaGeneralMesa");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneral> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneral item = new Propiedades.Procesos.Operacion.MapaGeneral()
                {
                    IdMesa              = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Mesa                = reader["Nombre"].ToString(),
                    Icono               = reader["Icono"].ToString(),
                    UsuariosConectados  = Funciones.Nums.TextoAEntero(reader["UsuariosDisponibles"].ToString()),
                    TramitesDisponibles = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()),
                    TramitesReingresos  = Funciones.Nums.TextoAEntero(reader["TramitesReingresos"].ToString()),
                    TotalTramites       = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()) + Funciones.Nums.TextoAEntero(reader["TramitesReingresos"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        
        public List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> getDashboardMesaDetalleTramiteProd(int IdCalendario, int IdFlujo, int IdMesa)
        {
            b.ExecuteCommandSP("spWFOMapaGeneralMesaTramiteProd");
            b.AddParameter("@IdCalendario", IdCalendario, SqlDbType.Int);
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite item = new Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite()
                {
                    IdFlujo = IdFlujo,
                    IdMesa = IdMesa,
                    IdTramite = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString()),
                    IdTramiteMesa = Funciones.Nums.TextoAEntero(reader["IdTramiteMesa"].ToString()),
                    Folio = reader["Folio"].ToString(),
                    Reingresos = Funciones.Nums.TextoAEntero(reader["Reingresos"].ToString()),
                    Registro = Convert.ToDateTime(reader["Registro"].ToString()),
                    Usuario = reader["Usuario"].ToString(),
                    TiempoAtencion = reader["TiempoAtencion"].ToString(),
                    TiempoMesa = reader["TiempoMesa"].ToString(),

                    Poliza = reader["Poliza"].ToString(),
                    Quincena = Funciones.Nums.TextoAEntero(reader["Quincena"].ToString()),
                    Importe = Funciones.Nums.TextoAFlotante(reader["Importe"].ToString()),
                    TipoNomina = reader["TipoNomina"].ToString(),
                    TipoMovimiento = reader["TipoMovimiento"].ToString(),
                    UnidadPago = reader["UnidadPago"].ToString(),

                    StatusMesa = reader["StatusMesa"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> getDashboardMesaDetalleTramite(int IdFlujo, int IdMesa)
        {
            b.ExecuteCommandSP("spWFOMapaGeneralMesaTramite");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite> resultado = new List<Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite item = new Propiedades.Procesos.Operacion.MapaGeneralMesaDetalleTramite()
                {
                    IdFlujo         = IdFlujo,
                    IdMesa          = IdMesa,
                    IdTramite       = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString()),
                    IdTramiteMesa   = Funciones.Nums.TextoAEntero(reader["IdTramiteMesa"].ToString()),
                    Folio           = reader["Folio"].ToString(),
                    Reingresos      = Funciones.Nums.TextoAEntero(reader["Reingresos"].ToString()),
                    Registro        = Convert.ToDateTime(reader["Registro"].ToString()),
                    Usuario         = reader["Usuario"].ToString(),
                    TiempoAtencion  = reader["TiempoAtencion"].ToString(),
                    TiempoMesa      = reader["TiempoMesa"].ToString(),
                    
                    Poliza          = reader["Poliza"].ToString(),
                    Quincena        = Funciones.Nums.TextoAEntero(reader["Quincena"].ToString()),
                    Importe         = Funciones.Nums.TextoAFlotante(reader["Importe"].ToString()),
                    TipoNomina      = reader["TipoNomina"].ToString(),
                    TipoMovimiento  = reader["TipoMovimiento"].ToString(),
                    UnidadPago      = reader["UnidadPago"].ToString(),

                    StatusMesa      = reader["StatusMesa"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}