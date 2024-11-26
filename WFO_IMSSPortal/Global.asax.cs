using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WFO_IMSSPortal
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string sessionId = Session.SessionID;

            if (Session["Sesion"] == null)
            {
                string strpPathApp = string.Empty;
                if (Request.ApplicationPath.Length == 1)
                {
                    strpPathApp = "";
                }
                else
                {
                    strpPathApp = Request.ApplicationPath;
                }
                Response.Redirect(strpPathApp + "/Default.aspx");
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Desconectado de la sesión en caso de error
            Negocio.Sistema.Usuarios sisusr = new Negocio.Sistema.Usuarios();

            if (HttpContext.Current.Session != null)
            {
                IU.ManejadorSesion manejo_sesion = (IU.ManejadorSesion)HttpContext.Current.Session["Sesion"];
                if (manejo_sesion != null)
                    sisusr.ActualizarDesconectarSesion(manejo_sesion.Usuarios.IdUsuario, 0, manejo_sesion.IdParaCierreSesion);
            }
            Exception ex = Server.GetLastError();
            RegistraLog.RegistraLog log = new WFO_IMSSPortal.RegistraLog.RegistraLog("Log", HttpContext.Current.Server.MapPath("~"), "WFO_IMSSPortal Error System");
            log.Agregar("Error: " + ex);
        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                IU.ManejadorSesion manejo_sesion = null;
                Negocio.Sistema.Usuarios usrs = new Negocio.Sistema.Usuarios();

                try
                {
                    manejo_sesion = (IU.ManejadorSesion)HttpContext.Current.Session["Sesion"];
                }
                catch
                {
                }

                if (Session["idusuario"] != null && manejo_sesion != null)
                {
                    usrs.ActualizarDesconectarSesion(int.Parse(Session["idusuario"].ToString()), 0, manejo_sesion.IdParaCierreSesion);
                }
            }
            catch (Exception ex)
            { }
            
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Server.ClearError();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Server.ClearError();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
    }
}